using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public string LeaveStatus { get; set; } = string.Empty;
        public int ApprovedBy { get; set; } 

        [Required,MinLength(8)]
        public string Reason { get; set; } = string.Empty ;
        public string RequestDate { get; set; } =string.Empty ;
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
