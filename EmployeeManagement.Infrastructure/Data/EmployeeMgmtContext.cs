using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Data
{
    public class EmployeeMgmtContext(DbContextOptions<EmployeeMgmtContext> options) :DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
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
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<AllowancesTypes> AllowancesTypes { get; set; }
        public DbSet<EmployeeAllowances> EmployeeAllowances { get; set; }
        public DbSet<TaxDeductions> TaxDeductions { get; set; }
        public DbSet<EmployeeTaxRebate> EmployeeTaxRebate { get; set; }
        public DbSet<TaxRebate> TaxRebateCodes { get; set; }
        public DbSet<TaxSlab> TaxSlabs { get; set; }
        public DbSet<EmployeeTaxRebate> EmployeeTaxRebates { get; set; }
        public DbSet<ProjectTasksResult> ProjectTasksResult {  get; set; }
        public DbSet<LoginRecord> LoginRecords { get; set; }
        public DbSet<Setup> CompanySetup {  get; set; }
        public DbSet<HrmsRoles> HrmsRoles { get; set; }
    }
}
