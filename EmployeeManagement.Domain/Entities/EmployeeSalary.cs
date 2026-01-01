using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class EmployeeSalary
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        //these values are added
        public int BasicSalary {  get; set; }
        public int HRA { get; set; }
        public int DA {  get; set; }
        public int Allowences {  get; set; }

        //these values are subtracted
        public int ProfTax {  get; set; }
        public string PFAccount {  get; set; }
        public int PFDeduction {  get; set; }
        public int TaxDeductions {  get; set; }
        public virtual TaxDeductions taxDeductions { get; set; }
    }
}
