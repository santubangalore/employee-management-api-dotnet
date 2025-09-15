using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class EmployeeAttendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        public string Month { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
        public int Status { get; set; } // Present/Absent/Leave etc
    }
}
