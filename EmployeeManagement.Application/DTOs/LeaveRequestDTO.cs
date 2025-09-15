using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs
{
    public class LeaveRequestDTO
    {
        public int leaveId { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveStatus { get; set; } = string.Empty;

        public string Reason { get; set; } = string.Empty;
        public string RequestDate { get; set; } = string.Empty;
    }
}
