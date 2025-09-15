namespace EmployeeManagement.Application.DTOs
{
    public class ChildDeptDTO
    {
        public int ChildDeptId { get; set; }
        public int ParentDeptId { get; set; }
        public string ParentDepartmentName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
    }
}
