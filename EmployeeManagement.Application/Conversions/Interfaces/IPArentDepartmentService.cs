using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface IParentDepartmentService
    {
        Task<Response> CreateAsync(ParentDeptDTO entity);
        Task<Response> UpdateAsync(ParentDeptDTO entity);
        Task<Response> DeleteAsync(ParentDeptDTO entity);
        Task<IEnumerable<ParentDeptDTO>> GetAllAsync();
        Task<ParentDeptDTO> FindByIdAsync(int Id);
        Task<ParentDeptDTO> GetByAsync(Expression<Func<ParentDeptDTO, bool>> predicate);
    }
}
