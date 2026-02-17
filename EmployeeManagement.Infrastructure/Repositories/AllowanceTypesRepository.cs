using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class AllowanceTypesRepository(EmployeeMgmtContext dbContext) : IAllowanceTypes
    {
        public async Task<Response> CreateAsync(AllowancesTypes entity)
        {
            var getAllowanceName = dbContext.AllowancesTypes.Where(_ => _.AllowanceName == entity.AllowanceName).FirstOrDefault();
            if (getAllowanceName is not null)
            {
                return new Response(false, $"{entity.AllowanceName} already exists");
            }
            var res = dbContext.AllowancesTypes.Add(entity).Entity;
            dbContext.SaveChanges();
            if (res.AllowanceTypeId > 0)
                return new Response(true, "Record created successfully");
            else return new Response(false, "Error creating record");
        }

        public Task<Response> DeleteAsync(AllowancesTypes entity)
        {
            throw new NotImplementedException();
        }

        public Task<AllowancesTypes> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AllowancesTypes>> GetAllAsync()
        {
            try
            {
                var result = dbContext.AllowancesTypes.AsNoTracking().ToList();
                return result is not null ? result : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred retrieving AllowancesTypes");
            }
        }

        public async Task<AllowancesTypes> GetByAsync(Expression<Func<AllowancesTypes, bool>> predicate)
        {
            try
            {
                var allowanceType = await dbContext.AllowancesTypes.Where(predicate).FirstOrDefaultAsync();
                return allowanceType is not null ? allowanceType : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving allowanceType");
            }
        }

        public async Task<Response> UpdateAsync(AllowancesTypes entity)
        {
            try
            {
                var leaveBal = await FindByIdAsync(entity.AllowanceTypeId);
                if (leaveBal is null)
                {
                    return new Response(false, "Leave balance not found");
                }
                dbContext.Entry(leaveBal).State = EntityState.Detached;
                dbContext.AllowancesTypes.Update(entity);
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
