using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class LeaveTypesRepository(EmployeeMgmtContext dbContext) : ILeaveTypes
    {
        public async Task<Response> CreateAsync(LeaveTypes entity)
        {
            var getLeaveType = await GetByAsync(_ => _.LeaveTypeName == entity.LeaveTypeName);
            if (getLeaveType is not null && !string.IsNullOrEmpty(getLeaveType.LeaveTypeName))
            {
                return new Response(false, $"{entity.LeaveTypeName} already exists");
            }

            var currentEntity = dbContext.LeaveTypes.Add(entity).Entity;
            await dbContext.SaveChangesAsync();
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
                var leaveTypes = await dbContext.LeaveTypes.AsNoTracking().ToListAsync();
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
                var leaveType = await dbContext.LeaveTypes.Where(predicate).FirstOrDefaultAsync();
                return leaveType is not null ? leaveType : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving leaveType");
            }
        }

        public async Task<Response> UpdateAsync(LeaveTypes entity)
        {
            try
            {
                var leaveBal = await FindByIdAsync(entity.LeaveTypeId);
                if (leaveBal is null)
                {
                    return new Response(false, "Leave balance not found");
                }
                dbContext.Entry(leaveBal).State = EntityState.Detached;
                dbContext.LeaveTypes.Update(entity);
                await dbContext.SaveChangesAsync();
                return new Response(true, "Leave balance updated");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while updating Leave balance");
            }
        }
    }
}
