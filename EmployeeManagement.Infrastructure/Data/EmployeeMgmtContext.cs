using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data
{
    public class EmployeeMgmtContext(DbContextOptions<EmployeeMgmtContext> options) :DbContext(options)
    {
        public DbSet<ParentDepartment> ParentDepartments { get; set; }
        public DbSet<ChildDepartment> ChildDepartments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> EmployeeProjects { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveTypes> LeaveTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<ProjectTasks> ProjectTasks { get; set; }
        public DbSet<TimeSheetDetails> TimeSheetDetails { get; set; }
        public DbSet<TimeSheetSummary> TimeSheetsSummary { get; set; }
        public DbSet<Onboarding> Onboarding { get; set; }
    }
}
