using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class LeaveTypes
    {
        [Key]
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; } =string.Empty;
    }
}
