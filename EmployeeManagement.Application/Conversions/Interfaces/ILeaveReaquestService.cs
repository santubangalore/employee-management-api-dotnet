using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface ILeaveReaquestService
    {
        Task<Response> CreateAsync(LeaveRequestDTO entity);
        Task<Response> UpdateAsync(LeaveRequestDTO entity);
        Task<Response> DeleteAsync(LeaveRequestDTO entity);
        Task<IEnumerable<LeaveRequestDTO>> GetAllAsync();
        Task<LeaveRequestDTO> FindByIdAsync(int Id);
        Task<LeaveRequestDTO> GetByAsync(Expression<Func<LeaveRequestDTO, bool>> predicate);
    }
}
