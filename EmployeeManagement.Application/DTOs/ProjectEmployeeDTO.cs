namespace EmployeeManagement.Application.DTOs
{
    public class ProjectEmployeeDTO
    {
        public int EmpProjectId { get; set; }
        public int ProjectId { get; set; }
        public int EmpId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
    }
}
