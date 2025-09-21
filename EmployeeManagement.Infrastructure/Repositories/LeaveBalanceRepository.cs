using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class LeaveBalanceRepository(EmployeeMgmtContext dbcontext) : ILeaveBalance
    {
        public Task<Response> CreateAsync(LeaveBalance entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(LeaveBalance entity)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveBalance> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeaveBalance>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveBalance> GetByAsync(Expression<Func<LeaveBalance, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(LeaveBalance entity)
        {
            throw new NotImplementedException();
        }
    }
}
