using EmployeeManagement.Application.Conversions.Interfaces;
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
            
            //Respsitories
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

            // Services
      
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IChildDepartmentService, DepartmentService>();
            services.AddScoped<ILeaveReaquestService, LeaveRequestService>();
            services.AddScoped<ILeaveBalanceService, LeaveBalanceService>();
            //services.AddScoped<ILeaveTypes, LeaveTypesRepository>();

            services.AddScoped<IParentDepartmentService, DepartmentService>();
            services.AddScoped<IOnboardingService, OnboardingService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();
            services.AddScoped<IProjectTasksService, ProjectTasksService>();
            services.AddScoped<ITimeSheetService, TimeSheetService>();

            return services;
        }
    }
}
