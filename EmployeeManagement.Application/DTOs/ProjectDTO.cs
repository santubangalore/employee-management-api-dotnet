using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.DTOs
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LeadByEmpId { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public List<ProjectTasksDTO> ? ProjectTasks { get; set; }
        public virtual List<Employee>? Employees { get; set; }
        public string ProjectStatus { get; set; }
    }
}
