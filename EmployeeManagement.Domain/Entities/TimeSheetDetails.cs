namespace EmployeeManagement.Domain.Entities
{
    public class TimeSheetDetails
    {
        public int Id {  get; set; }
        public DateTime Date { get; set; }
        public string TaskId { get; set; } =string.Empty;
        public int TimesheetSummaryId {  get; set; }
        public TimeSheetSummary TimeSheetSummary { get; set; }
        public int Hours { get; set; } // because an employee can work half day, and be on leave half day.
        public string AttStatus { get; set; }
    }
}
