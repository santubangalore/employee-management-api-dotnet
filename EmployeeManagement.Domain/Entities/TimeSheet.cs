namespace EmployeeManagement.Domain.Entities
{
    public class TimeSheet
    {
        public int Id {  get; set; }
        public int TimesheetSummaryId {  get; set; }
        public TimeSheetSummary TimeSheetSummary { get; set; }
        public int WeekNo { get; set; }
        public int year { get; set; }
        public DateTime date { get; set; }  
        public int AttStatus { get; set; }

    }
}
