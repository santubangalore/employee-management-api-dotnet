using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.DTOs
{
    public class TimeSheetDetailsDTO
    {
        public int Id { get; set; }
        public string TaskId { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TimesheetSummaryId { get; set; }
        public int Hours { get; set; } // because an employee can work half day, and be on leave half day.
        public string AttStatus { get; set; }
    }
}
