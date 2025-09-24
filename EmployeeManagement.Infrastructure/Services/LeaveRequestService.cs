using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    internal class LeaveRequestService(ILeaveRequest leaveRequestRepository) : ILeaveReaquestService
    {
        public Task<Response> CreateAsync(LeaveRequestDTO entity)
        {
            //Conversion
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(LeaveRequestDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveRequestDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestDTO> GetByAsync(Expression<Func<LeaveRequestDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(LeaveRequestDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
