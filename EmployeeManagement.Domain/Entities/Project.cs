using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LeadByEmpId { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public virtual List<Employee> Employees { get; set;} 
        public virtual List<ProjectTasks> ProjectTasks { get; set; }     
        public string? ProjectStatus { get; set; }
    }
}
