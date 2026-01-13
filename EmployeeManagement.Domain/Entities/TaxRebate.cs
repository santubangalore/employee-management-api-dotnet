using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class TaxRebate
    {
        public int Id { get; set; }
        public int FinYear { get; set; }

        [MaxLength(20)]
        public string RebateCode { get; set; } = string.Empty;
        public string RebateDesc { get; set; } = string.Empty;
        public int RebateAmount { get; set; } // how much employee gets  rebate this year under this code
    }

    public class TaxSlab
    {
        [Key]
        public int TaxSlabId { get; set; }
        public int TaxSlabAmount { get; set; } // govt set tax slab
        public int TaxYear { get; set; }
        public float TaxPercent { get; set; } //govt set tax slab tax rate
    }
}
