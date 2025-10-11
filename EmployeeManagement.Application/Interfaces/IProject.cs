using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IProject : IGenericRepoInterface<Project>
    {
        Task<Response> CreateRole(Role role);
        Task<Response> UpdateRole(Role role);
        Task<Response> DeleteRole(Role role);
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRole(int RoleId);
        Task<Role> GetRoleByAsync(Expression<Func<Role, bool>> predicate);
    }
}
