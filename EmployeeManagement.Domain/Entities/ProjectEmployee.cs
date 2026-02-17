using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{
    public class ProjectEmployee
    {
        [Key]
        public int EmpProjectId { get; set; }
        [ForeignKey(nameof(Project.ProjectId))]
        public int ProjectId { get; set; }
        [ForeignKey(nameof (Employee.EmployeeId))]
        public int EmpId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
        public DateTime ExitDate { get; set; } // Date on which the employee exited the project
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
     
    }
}
