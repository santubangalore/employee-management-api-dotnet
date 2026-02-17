using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    public class TaxRebateDto
    {
        public int Id { get; set; }
        public int FinYear { get; set; }

        [MaxLength(20)]
        public string RebateCode { get; set; } = string.Empty;
        public string RebateDesc { get; set; } = string.Empty;
        public int RebateAmount { get; set; } // how much employee gets  rebate this year under this code
    }
    public class TaxSlabsDto
    {
        [Key]
        public int TaxSlabId { get; set; }
        public int TaxSlabAmount { get; set; } // govt set tax slab
        public int TaxYear { get; set; }
        public float TaxPercent { get; set; } //govt set tax slab tax rate
    }
}
