using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface ILeaveBalanceService
    {
        Task<Response> CreateAsync(LeaveBalanceDTO entity);
        Task<Response> UpdateAsync(LeaveBalanceDTO entity);
        Task<Response> DeleteAsync(LeaveBalanceDTO entity);
        Task<IEnumerable<LeaveBalanceDTO>> GetAllAsync();
        Task<LeaveBalanceDTO> FindByIdAsync(int Id);
        Task<LeaveBalanceDTO> GetByAsync(Expression<Func<LeaveBalanceDTO, bool>> predicate);
    }
}
