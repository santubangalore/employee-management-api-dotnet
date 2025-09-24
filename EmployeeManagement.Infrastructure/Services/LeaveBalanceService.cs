using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    internal class LeaveBalanceService(IEmployee employeeRepository, ILeaveBalance leaveBalanceRepository) : ILeaveBalanceService
    {
        public Task<Response> CreateAsync(LeaveBalanceDTO entity)
        {
            //Conversion
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(LeaveBalanceDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveBalanceDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveBalanceDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveBalanceDTO> GetByAsync(Expression<Func<LeaveBalanceDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(LeaveBalanceDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
