using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces
{
    public interface ILogin
    {
        Task<TokenResponseDto?> LoginAsync(LoginDTO userDto);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
        Task<Boolean> IsAdmin(string EmpailId);

    }
}
