namespace EmployeeManagement.Application.DTOs
{
    public class TimeSheetSummaryDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public EmployeeDTO Employee { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovalStatus { get; set; } // Approved/Re-work/Reject
        public DateTime ApprovalDate { get; set; }
        public int BillableHours { get; set; }
        public int NonBillableHours { get; set; }
        public List<TimeSheetDetailsDTO> Details { get; set; }
    }
}
