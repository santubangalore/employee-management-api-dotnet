namespace EmployeeManagement.Domain.Entities
{
    public class TimeSheetSummary
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
        public int ApprovalStatus { get; set; } // Approved/Re-wor
        public DateTime ApprovalDate { get; set; }


    }
}
