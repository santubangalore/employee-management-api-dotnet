using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class ParentDepartment
    {
        [Key]
        public int DepartmentId {  get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentLogo { get; set; } =string.Empty;

    }
}
