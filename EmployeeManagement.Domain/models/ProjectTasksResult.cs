

using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.models
{
    public class ProjectTasksResult
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }
    }
}
