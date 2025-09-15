using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    internal class LeaveRequestRepository(EmployeeMgmtContext dbContext) : ILeaveRequest
    {
        public async Task<Response> CreateAsync(LeaveRequest entity)
        {
            var exists=await GetByAsync(_=>_.LeaveId==entity.LeaveId);
            if (exists is not null) return new Response(false, "Exists");
            var currentEntity = dbContext.LeaveRequests.Add(entity).Entity;
            await dbContext.SaveChangesAsync();
            if (currentEntity is not null && currentEntity.LeaveId > 0)
            {
                return new Response(true, $"{currentEntity.LeaveId} added to Database successfully");
            }
            else
                return new Response(false, $"Error occurred while adding {currentEntity.LeaveId} ");
        }

        public Task<Response> DeleteAsync(LeaveRequest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveRequest> FindByIdAsync(int Id)
        {
            try
            {
                var leaveReq = await dbContext.LeaveRequests.FindAsync(Id);
                return leaveReq is not null ? leaveReq : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred finding leave request");
            }
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            try
            {
                var leaveReq = await dbContext.LeaveRequests.AsNoTracking().ToListAsync();
                return leaveReq is not null ? leaveReq : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred retrieving leave requests");
            }
        }

        public Task<LeaveRequest> GetByAsync(Expression<Func<LeaveRequest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateAsync(LeaveRequest entity)
        {
            try
            {
                var leaveReq = await FindByIdAsync(entity.LeaveId);
                if (leaveReq is null)
                {
                    return new Response(false, "Leave request not found");
                }
                dbContext.Entry(leaveReq).State = EntityState.Detached;
                dbContext.LeaveRequests.Update(entity);
                await dbContext.SaveChangesAsync();
                return new Response(true, "Leave request updated");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while updating Leave request");
            }
        }
    }
}
