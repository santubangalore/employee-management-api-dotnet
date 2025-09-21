namespace EmployeeManagement.Application.DTOs
{
    public class ProjectTasksDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string TaskDescription { get; set; } = string.Empty;
    }
}
