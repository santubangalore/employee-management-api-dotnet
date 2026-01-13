using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class EmployeeSalary
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required, MaxLength(4),Range(2020,2500)]
        public string FinYear { get; set; }
        public int BasicSalary {  get; set; }
        public virtual List<EmployeeAllowances> Allowences {  get; set; }
        public string PFAccount {  get; set; } = string.Empty;
        public int TotDeductions {  get; set; }
        public TaxDeductions Deductions { get; set; }
        public int TakeHomeSalary { get; set; }
    }
}
