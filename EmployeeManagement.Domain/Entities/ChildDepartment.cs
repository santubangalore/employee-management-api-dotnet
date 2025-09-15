using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class ChildDepartment
    {
        [Key]
        public int ChildDeptId { get; set; }
        public int ParentDeptId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }
}
