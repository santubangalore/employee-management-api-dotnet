using EmployeeManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Application.DTOs
{
    public class TaxDeductionsDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int FinYear { get; set; }
        public int ProfTax { get; set; }
        public int PfDeduction { get; set; }
        public int TotTaxAmount { get; set; }
        public int InsuranceAmt { get; set; }
        public int TotRebateAmount { get; set; }
        public List<EmployeeTaxRebateDto> TaxRebates { get; set; }
    }


    public class EmployeeTaxRebateDto
    {
        [Key]
        public int EmployeeTaxRebateId { get; set; }
        public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }
        [ForeignKey("RebateId")]
        public int RebateId { get; set; }
        public virtual TaxRebate? TaxRebate { get; set; }
        public string DocumentDetails { get; set; }
        public int FinYear { get; set; }
        public int EmployeeRebateAmount { get; set; } // how much thi
    }
   
  
}
