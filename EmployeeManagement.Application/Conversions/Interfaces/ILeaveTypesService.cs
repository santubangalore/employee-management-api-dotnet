using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface ILeaveTypesService
    {
        Task<Response> CreateAsync(LeaveTypesDTO entity);
        Task<Response> UpdateAsync(LeaveTypesDTO entity);
        Task<Response> DeleteAsync(LeaveTypesDTO entity);
        Task<IEnumerable<LeaveTypesDTO>> GetAllAsync();
        Task<LeaveTypesDTO> FindByIdAsync(int Id);
        Task<LeaveTypesDTO> GetByAsync(Expression<Func<LeaveTypesDTO, bool>> predicate);
    }
}
