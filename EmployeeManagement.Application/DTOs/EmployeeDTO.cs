namespace EmployeeManagement.Application.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string EmployeeStatus { get; set; } = string.Empty;
        public int ReportingTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;

    }
}
