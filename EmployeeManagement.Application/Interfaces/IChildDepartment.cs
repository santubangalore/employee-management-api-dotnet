using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IChildDepartment :IGenericInterface<ChildDepartment> {
        Task<IEnumerable<ChildDepartment>> GetChildDepartmentsByParent(int ParentDeptId);
    }
}
