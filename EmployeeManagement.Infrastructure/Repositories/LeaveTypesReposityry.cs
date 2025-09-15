using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class LeaveTypesRepository(EmployeeMgmtContext dbcontext) : ILeaveTypes
    {
        public async Task<Response> CreateAsync(LeaveTypes entity)
        {
            var getLeaveType = await GetByAsync(_ => _.LeaveTypeName == entity.LeaveTypeName);
            if (getLeaveType is not null && !string.IsNullOrEmpty(getLeaveType.LeaveTypeName))
            {
                return new Response(false, $"{entity.LeaveTypeName} already exists");
            }

            var currentEntity = dbcontext.LeaveTypes.Add(entity).Entity;
            await dbcontext.SaveChangesAsync();
            if (currentEntity is not null && currentEntity.LeaveTypeId > 0)
            {
                return new Response(true, $"{entity.LeaveTypeName} added to Database successfully");
            }
            else
                return new Response(false, $"Error occurred while adding {entity.LeaveTypeName} ");
        }

        public Task<Response> DeleteAsync(LeaveTypes entity)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypes> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeaveTypes>> GetAllAsync()
        {
            try
            {
                var leaveTypes = await dbcontext.LeaveTypes.AsNoTracking().ToListAsync();
                return leaveTypes is not null ? leaveTypes : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving all products");
            }
        }

        public async Task<LeaveTypes> GetByAsync(Expression<Func<LeaveTypes, bool>> predicate)
        {
            try
            {
                var leaveType = await dbcontext.LeaveTypes.Where(predicate).FirstOrDefaultAsync();
                return leaveType is not null ? leaveType : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving leaveType");
            }
        }

        public Task<Response> UpdateAsync(LeaveTypes entity)
        {
            throw new NotImplementedException();
        }
    }
}
