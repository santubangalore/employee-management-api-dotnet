
namespace EmployeeManagement.Application.DTOs
{
    public class EmployeeSalaryDto 
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string FinYear { get; set; }
        public int BasicSalary { get; set; }
        public virtual List<EmployeeAllowancesDto> Allowances { get; set; }
        public string PFAccount { get; set; } = string.Empty;
        public int TotDeductions { get; set; }
        public virtual TaxDeductionsDto? Deductions { get; set; }
        public int TakeHomeSalary { get; set; }
    }
}
