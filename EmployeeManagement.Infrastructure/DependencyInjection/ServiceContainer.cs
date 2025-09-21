using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repositories;
using EmployeeManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<EmployeeMgmtContext>(options =>
                options.UseSqlServer(conf.GetConnectionString("EmployeeMgmtConnection"), sqlServerOptions =>
                    sqlServerOptions.EnableRetryOnFailure())
                );
            
            services.AddScoped<IEncryption, EncryptionService>();
            services.AddScoped<ILeaveRequest, LeaveRequestRepository>();
            services.AddScoped<ILeaveTypes, LeaveTypesRepository>();
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddScoped<IChildDepartment,ChildDepartmentRepository>();
            services.AddScoped<IParentDepartment, ParentDeptRepository>();
            services.AddScoped<IProject, ProjectRepository>();
            services.AddScoped<IProjectEmployee,ProjectEmployeeRepository>();
            services.AddScoped<ILogin,LoginRepository>();
            services.AddScoped<ITimeSheetSummary,TimeSheetRepository>();
            services.AddScoped<ILeaveRequest, LeaveRequestRepository>();
            services.AddScoped<ILeaveBalance, LeaveBalanceRepository>();
            services.AddScoped<IOnboarding,OnboardingRepository>();
            services.AddScoped<IProjectTasks, ProjectTasksRepository>();

            return services;
        }
    }
}
