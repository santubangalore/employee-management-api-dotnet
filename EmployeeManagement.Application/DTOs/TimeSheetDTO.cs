namespace EmployeeManagement.Application.DTOs
{
    public class TimeSheetSummaryDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public EmployeeDTO? Employee { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovalStatus { get; set; } // Approved/Re-work/Reject
        public DateTime ApprovalDate { get; set; }
        public int BillableHours { get; set; }
        public int NonBillableHours { get; set; }
        public List<TimeSheetDetailsDto> Details { get; set; }
    }

    public class UpdateTimeSheetSummaryDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public EmployeeDTO? Employee { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovalStatus { get; set; } // Approved/Re-work/Reject
        public DateTime ApprovalDate { get; set; }
        public int BillableHours { get; set; }
        public int NonBillableHours { get; set; }
        public List<WeekTimesheet> Details { get; set; }
    }

    public class WeekTimesheet
    {
        public int Id { get; set; }
        public string TaskId { get; set; }
        public int TimesheetSummaryId { get; set; }
        public List<Attendance> attendance {  get; set; }
    }
    public class Attendance
    {
        public string Date { get; set; }
        public int Hours { get; set; }
    }
}
