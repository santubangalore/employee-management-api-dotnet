namespace EmployeeManagement.Application.DTOs
{
    public class ParentDeptDTO
    {
        public int DepartmentId { get; set; }
        public string ParentDepartmentName { get; set; } = string.Empty;
        public string DepartmentLogo { get; set; } = string.Empty;
    }
}
