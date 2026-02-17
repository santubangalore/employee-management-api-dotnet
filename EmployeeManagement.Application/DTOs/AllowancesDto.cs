using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    public class AllowancesTypesDto
    {
        [Key]
        public int AllowanceTypeId { get; set; }
        public string AllowanceName { get; set; } = string.Empty;
        public string AllowanceDescription { get; set; } = string.Empty;
        public string AllowanceType { get; set; } = string.Empty; // per year or per month
    }

    public class EmployeeAllowancesDto
    {
        [Key]
        public int EployeeAllowancesId { get; set; }
        public int EmployeeId { get; set; }
        public int FinYear { get; set; }
        public int AllowanceTypeId { get; set; } // percentage or flat amnt per employee
        public int AllowanceAmount { get; set; }
    }
}
