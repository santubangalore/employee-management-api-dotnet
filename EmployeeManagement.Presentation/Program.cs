using EmployeeManagement.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace EmployeeManagement.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen(opt =>
            {

            });
            //builder.Services.AddCors(opt =>
            //{
            //    opt.AddDefaultPolicy(pol =>
            //    {
            //        pol.WithMethods("GET","POST","DELETE","PUT").AllowAnyOrigin().AllowCredentials();
            //    }
            //    );
            //});
            builder.Services.AddInfrastructureService(builder.Configuration);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["AppSettings:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
                        ValidateIssuerSigningKey = true,
                    };
                });
          
            var app = builder.Build();

           // if (app.Environment.IsDevelopment())
           
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHsts();
            
            //app.Use(async (context, next) =>
            //{
            //    // Do work that can write to the Response.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});

            app.UseHttpsRedirection();
            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
