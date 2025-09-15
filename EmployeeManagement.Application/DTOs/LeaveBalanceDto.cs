using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    public class LeaveBalanceDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveType { get; set; }
        public decimal BalanceLeave { get; set; }
        public int Year { get; set; }
        public int CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
