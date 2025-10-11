
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.models
{
    public class ProjectTasksResult
    {
        [Key]
        public int Id { get; set; }
        public string TaskId { get; set; } = string.Empty;
        public string TaskName { get; set; } =string.Empty;
    }
}
