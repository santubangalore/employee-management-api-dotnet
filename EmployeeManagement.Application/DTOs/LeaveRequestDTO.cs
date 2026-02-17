using EmployeeManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs
{
    public class LeaveRequestDTO
    {
        public int LeaveId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveStatus { get; set; } = string.Empty;
        public int ApprovedBy { get; set; }

        [Required, MinLength(8)]
        public string Reason { get; set; } = string.Empty;
        public string RequestDate { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
    }
}
