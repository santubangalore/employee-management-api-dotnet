using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{
    public class TaxDeductions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public int FinYear { get; set; }
        public int ProfTax {  get; set; }
        public int PfDeduction { get; set; }
        public int InsuranceAmt { get; set; }
        public int TotTaxAmount { get; set; }
        public int TotRebateAmount { get; set; }
        public virtual List<EmployeeTaxRebate>? TaxRebate { get; set; }
    }

    public class EmployeeTaxRebate
    {
        [Key]
        public int EmployeeTaxRebateId { get; set; }
        public int EmployeeId { get; set; }
        //public virtual Employee? Employee { get; set; }
        public int ?RebateId { get; set; }
        public virtual TaxRebate? TaxRebate {get;set;}
        public string? DocumentDetails { get; set; }
        public int FinYear {  get; set; }
        public int EmployeeRebateAmount { get; set; } // how much this employee gets  rebate this year under tis code
    }

    //public class EmployeeTaxSlabs
    //{
    //    [Key]
    //    public int EmployeeTaxSlabId { get; set; }

    //    [ForeignKey("TaxSlabId")]
    //    public int TaxSlabId { get; set; }
    //    public virtual TaxSlab TaxSlab { get; set; }
    //    public int EmployeeId { get; set; }
    //    public int EmployeeTaxAmount { get; set; } // how much this employee got to pay this year in this slab
    //    public int TaxYear { get; set; }
    //}
}
