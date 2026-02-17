namespace EmployeeManagement.Application.DTOs
{
    public class ProjectEmployeeDTO
    {
        public int EmpProjectId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int EmpId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
        public DateTime ExitDate { get; set; } // Date on which the employee exited the project
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
