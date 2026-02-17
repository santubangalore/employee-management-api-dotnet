namespace EmployeeManagement.Application.DTOs
{
    public class GetEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public int ParentDeptId{ get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int ReportingTo { get; set; }
        public string ReportingToName { get; set; } = string.Empty;
        public string LastUpdatedBy {  get; set; }= string.Empty;

    }
}
