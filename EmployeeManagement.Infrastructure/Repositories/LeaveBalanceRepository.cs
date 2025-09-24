using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class LeaveBalanceRepository(EmployeeMgmtContext dbContext) : ILeaveBalance
    {
        public async Task<Response> CreateAsync(LeaveBalance entity)
        {
            var exists = await GetByAsync(_ => _.EmployeeId == entity.EmployeeId && _.LeaveType== entity.LeaveType && _.ToYear==entity.ToYear);
            if (exists is not null) return new Response(false, "Leave Balance exists");
            var currentEntity = dbContext.LeaveBalances.Add(entity).Entity;
            await dbContext.SaveChangesAsync();
            if (currentEntity is not null && currentEntity.Id > 0)
            {
                return new Response(true, $"{currentEntity.Id} added to Database successfully");
            }
            else
                return new Response(false, $"Error occurred while adding {currentEntity} ");
        }
        public async Task<Response> DeleteAsync(LeaveBalance entity)
        {
            try
            {
                var leaveReq = await FindByIdAsync(entity.Id);
                if (leaveReq is null)
                {
                    return new Response(false, "Leave request not found");
                }
                dbContext.Entry(leaveReq).State = EntityState.Detached;
                dbContext.LeaveBalances.Remove(entity);
                await dbContext.SaveChangesAsync();
                return new Response(true, "Leave request deleted");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while deleting Leave request");
            }
        }

        public async Task<LeaveBalance> FindByIdAsync(int Id)
        {
            try
            {
                var leaveBal = await dbContext.LeaveBalances.FindAsync(Id);
                return leaveBal is not null ? leaveBal : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred finding leave balance");
            }
        }

        public async Task<IEnumerable<LeaveBalance>> GetAllAsync()
        {
            try
            {
                var leaveBal = await dbContext.LeaveBalances.AsNoTracking().ToListAsync();
                return leaveBal is not null ? leaveBal : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred retrieving leave balances");
            }
        }

        public async Task<LeaveBalance> GetByAsync(Expression<Func<LeaveBalance, bool>> predicate)
        {
            var result = await dbContext.LeaveBalances.Where(predicate).SingleOrDefaultAsync();
            return result is not null ? result : null!;
        }

        public async Task<Response> UpdateAsync(LeaveBalance entity)
        {
            try
            {
                var leaveBal = await FindByIdAsync(entity.Id);
                if (leaveBal is null)
                {
                    return new Response(false, "Leave balance not found");
                }
                dbContext.Entry(leaveBal).State = EntityState.Detached;
                dbContext.LeaveBalances.Update(entity);
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
