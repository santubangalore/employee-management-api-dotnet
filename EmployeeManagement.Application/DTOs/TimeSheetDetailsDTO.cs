namespace EmployeeManagement.Application.DTOs
{
    public class TimeSheetDetailsDto
    {
        public int Id { get; set; }
        public string TaskId { get; set; } =string.Empty;
        public string TaskName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TimesheetSummaryId { get; set; }
        public int Hours { get; set; } // because an employee can work half day, and be on leave half day.
        public string AttStatus { get; set; }
        public TimeSheetDetailsDto()
        {
            
        }
        public TimeSheetDetailsDto(int id,string taskId,string taskname,DateTime date,int timesheetSumId,int hours,string attStatus )
        {
            this.Id=id;
            this.TaskId=taskId;
            this.TaskName=taskname;
            this.Date=date;
            this.TimesheetSummaryId=timesheetSumId;
            this.Hours=hours;
            this.AttStatus=attStatus;
        }
    }
}
