using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class LoginRepository(EmployeeMgmtContext dbcontext,IConfiguration configuration) : ILogin
    {
        public DateTime LastLoginDateTime {  get; set; }

        public async Task<TokenResponseDto?> LoginAsync(LoginDTO userDto)
        {
            var user = await dbcontext.Employees.FirstOrDefaultAsync(q => q.EmailId == userDto.EmailId);
            if (user is null)
            {
                return null;
            }

            if (new PasswordHasher<Employee>().VerifyHashedPassword(user, user.PasswordHash, userDto.Password) ==
                PasswordVerificationResult.Failed)
            {
                return null;
            }
            var response = await CreateTokenResponse(user);

            return response;
        }

        public async Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);
            if (user is null)
                return null;
            var response = await CreateTokenResponse(user);
            return response;
        }

        /// <summary>
        /// Check that the refresh token provided is valid.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="refreshtoken"></param>
        /// <returns></returns>
        private async Task<Employee?> ValidateRefreshTokenAsync(Guid userId, string refreshtoken)
        {
            var user = await dbcontext.Employees.FindAsync(userId);
            if (user is null || user.RefreshToken != refreshtoken
                || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                return null;
            }
            return user;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<string> GenerateAndSaveRefreshTokenAsync(Employee user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await dbcontext.SaveChangesAsync();
            return refreshToken;
        }

        private async Task<TokenResponseDto> CreateTokenResponse(Employee user)
        {
            var response = new TokenResponseDto
            {   EmailId = user.EmailId,
                UserName = user.EmployeeName,
                AccessToken = createToken(user),
                Role= user.Role,
                RefreshToken = await this.GenerateAndSaveRefreshTokenAsync(user),
            };
            return response;
        }

        /// <summary>
        /// createToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string createToken(Employee user)
        {
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, user.EmployeeName),
                 new Claim(ClaimTypes.NameIdentifier, user.EmployeeId.ToString()),
                 new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer")!,
                audience: configuration.GetValue<string>("AppSettings:Audience")!,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task<string> IsAdmin(string EmailId)
        {
            var emp= await dbcontext.Employees.Where(q=>q.EmailId==EmailId).SingleOrDefaultAsync();
            if (emp == null) return null;
            return emp.Role;
        }
    }
}
