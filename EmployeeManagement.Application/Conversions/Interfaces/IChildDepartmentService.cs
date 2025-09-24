using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface IChildDepartmentService
    {
            Task<Response> CreateAsync(ChildDeptDTO entity);
            Task<Response> UpdateAsync(ChildDeptDTO entity);
            Task<Response> DeleteAsync(ChildDeptDTO entity);
            Task<IEnumerable<ChildDeptDTO>> GetAllAsync();
            Task<ChildDeptDTO> FindByIdAsync(int Id);
            Task<ChildDeptDTO> GetByAsync(Expression<Func<ChildDeptDTO, bool>> predicate);
    }
}
