namespace EmployeeManagement.Application.DTOs
{
    public class TimeSheetCalendar
    {
        public DateOnly WeekStart {  get; set; }
        public DateOnly WeekFinish { get; set; }
        public int WeekNum { get; set; }

    }
}
