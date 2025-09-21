using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.DTOs
{
    public class TimeSheetSummaryDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovalStatus { get; set; } // Approved/Re-work/Reject
        public DateTime ApprovalDate { get; set; }
        public virtual List<TimeSheetDetailsDTO> Details { get; set; }
    }
}
