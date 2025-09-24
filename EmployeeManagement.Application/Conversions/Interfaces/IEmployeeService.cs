using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface IEmployeeService
    {
        Task<Response> CreateAsync(EmployeeDTO entity);
        Task<Response> UpdateAsync(EmployeeDTO entity);
        Task<Response> DeleteAsync(EmployeeDTO entity);
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> FindByIdAsync(int Id);
        Task<EmployeeDTO> GetByAsync(Expression<Func<EmployeeDTO, bool>> predicate);
    }
}
