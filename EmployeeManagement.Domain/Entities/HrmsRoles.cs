using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class HrmsRoles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
