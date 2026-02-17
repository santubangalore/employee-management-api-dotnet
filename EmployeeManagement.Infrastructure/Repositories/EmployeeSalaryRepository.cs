using EmployeeManagement.Application.GenericInterface;
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
    public class EmployeeSalaryRepository(EmployeeMgmtContext dbContext) : IEmployeeSalary 
    {
        /// <summary>
        /// Add multiple allowances at one time
        /// </summary>
        /// <param name="allowances"></param>
        /// <returns></returns>
        public async Task<Response> CreateAllowanceAsync(List<EmployeeAllowances> allowances)
        {
            var currentEmployeeId = allowances.FirstOrDefault().EmployeeId;
            var exists=await dbContext.EmployeeAllowances.Where(_=>_.EmployeeId== currentEmployeeId).FirstOrDefaultAsync();
            if (exists != null) {
               await this.DeleteAllowancesAsync(allowances.FirstOrDefault().EmployeeId);
            }    

            try
            {
                foreach (var item in allowances)
                {
                    dbContext.EmployeeAllowances.AddRange(allowances);
                }
            }
            catch (Exception ex) 
            {
                throw;
            }
            await dbContext.SaveChangesAsync();

            return new Response(true, $"added to Database successfully ");
        }

        /// <summary>
        /// Add Employee Allowance record
        /// </summary>
        /// <param name="allowance"></param>
        /// <returns></returns>
        public async Task<Response> AddEmployeeAllowanceAsync(EmployeeAllowances allowance)
        {
            var currentEmployeeId = allowance.EmployeeId;
            var exists = await dbContext.EmployeeAllowances.Where(_ => _.EmployeeId == currentEmployeeId && _.AllowanceTypeId==allowance.AllowanceTypeId).FirstOrDefaultAsync();
            if (exists != null)
            {
                await this.DeleteAllowanceAsync(allowance.EmployeeId,allowance.AllowanceTypeId);
            }

            try
            {
                    dbContext.EmployeeAllowances.Add(allowance);
            }
            catch (Exception ex)
            {
                throw;
            }
            await dbContext.SaveChangesAsync();

            return new Response(true, $"added to Database successfully ");
        }

        public async Task<Response> CreateAsync(Domain.Entities.EmployeeSalary entity)
        {
            var exists = await GetByAsync(_ => _.EmployeeId == entity.EmployeeId && _.FinYear == entity.FinYear);
            //if (exists is not null) return new Response(false, "Employee salary already exists");
            if(entity.TakeHomeSalary==0) return new Response(false, "Employee Take home cannot be 0");

            var currentEntity = dbContext.EmployeeSalary.Add(entity).Entity;
            await dbContext.SaveChangesAsync();
            var existingAllowances =  dbContext.EmployeeAllowances.Where(_=>_.EmployeeId==entity.EmployeeId).ToList();
            if (!existingAllowances.Any()) { await this.CreateAllowanceAsync(entity.Allowences); }
            
            var deductions = dbContext.TaxDeductions.Where(_ => _.EmployeeId == entity.EmployeeId).ToList();
            if (!deductions.Any()) { await this.CreateTaxDeductionsAsync(entity.Deductions); }

            if (currentEntity is not null && currentEntity.Id > 0)
            {
                return new Response(true, $"Employee Salary record added to database successfully");
            }
            else
                return new Response(false, $"Error occurred while adding {currentEntity} ");
        }

        public async Task<Response> CreateTaxDeductionsAsync(TaxDeductions taxDeductions)
        {
            var currentEmployeeId = taxDeductions.EmployeeId;
            var exists = await dbContext.TaxDeductions.Where(_ => _.EmployeeId == currentEmployeeId ).FirstOrDefaultAsync();
            if (exists != null)
            {
                await this.DeleteTaxDeductionsAsync(currentEmployeeId);
            }

            try
            {
                dbContext.TaxDeductions.Add(taxDeductions);
            }
            catch (Exception ex)
            {
                return new Response(false, $"added to Database successfully "); ;
            }
            await dbContext.SaveChangesAsync();

            return new Response(true, $"added to Database successfully ");
        }

        public async Task<Response> DeleteAsync(EmployeeSalary entity)
        {
            try
            {
                dbContext.EmployeeSalary.Remove(entity);
                await dbContext.SaveChangesAsync();
                return new Response(true, $"Salary Record deleted");
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred deleting Salary Record");
            }
        }

        public Task<Response> DeleteTaxDeductionsAsync(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.EmployeeSalary> FindByIdAsync(int Id)
        {
            var EmpObj = await dbContext.EmployeeSalary.FindAsync(Id);
            return EmpObj!;
        }
        public async Task<EmployeeAllowances> FindAllowanceByIdAsync(int AllowanceId,int EmployeeId)
        {
            var EmpObj = await dbContext.EmployeeAllowances.SingleOrDefaultAsync(_=>_.AllowanceTypeId==AllowanceId && _.EmployeeId==EmployeeId);
            return EmpObj!;
        }
        public async Task<IEnumerable<Domain.Entities.EmployeeSalary>> GetAllAsync()
        {
            var EmpSalaryList=await dbContext.EmployeeSalary.AsNoTracking().Include((_)=>_.Allowences).Include((_)=>_.Deductions).ThenInclude(q=>q.TaxRebate).ToListAsync();
            if (!EmpSalaryList.Any()) return null;
            return EmpSalaryList;
        }

        public async Task<Domain.Entities.EmployeeSalary> GetByAsync(Expression<Func<EmployeeSalary, bool>> predicate)
        {
            var result = await dbContext.EmployeeSalary.Where(predicate).SingleOrDefaultAsync();
            if (result is not null) { 
                var allowances=dbContext.EmployeeAllowances.Where(q=>q.EmployeeId==result.EmployeeId);
                if (allowances.Any()) {result.Allowences=allowances.ToList(); }
                var expenses = dbContext.TaxDeductions.SingleOrDefault(q => q.EmployeeId == result.EmployeeId);
                result.Deductions=expenses!;
            }
            return result!;
        }

        public async Task<List<EmployeeAllowances>> GetEmployeeAllowancesAsync(int EmployeeId)
        {
            var EmpAllowances = await dbContext.EmployeeAllowances.Where(q=>q.EmployeeId==EmployeeId).ToListAsync();
            if (!EmpAllowances.Any()) return null;
            return EmpAllowances;
        }

        public Task<TaxDeductions> GetEmployeeTaxDeductionsAsync(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAllowanceAsync(List<EmployeeAllowances> allowances)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateAsync(EmployeeSalary entity)
        {
       
            try
            {
                var leaveBal = await FindByIdAsync(entity.Id);
                if (leaveBal is null)
                {
                    return new Response(false, "Leave balance not found");
                }
                dbContext.Entry(leaveBal).State = EntityState.Detached;
                dbContext.EmployeeSalary.Update(entity);
                await dbContext.SaveChangesAsync();
                return new Response(true, "Leave balance updated");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while updating Leave balance");
            }
        }

        public Task<Response> UpdateTaxDeductionsAsync(TaxDeductions taxDeductions)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAllowancesAsync(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> DeleteAllowanceAsync(int EmployeeId, int AllowanceId)
        {
            try
            {
                var allowance = await FindAllowanceByIdAsync(AllowanceId, EmployeeId);
                if (allowance is null)
                {
                    return new Response(false, "allowance not found");
                }
                dbContext.Entry(allowance).State = EntityState.Detached;
                dbContext.EmployeeAllowances.Remove(allowance);
                await dbContext.SaveChangesAsync();
                return new Response(true, "Allowance record deleted");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while deleting Leave request");
            }
        }

        public async Task<Response> DeleteSalaryRecAsync(int EmployeeSalaryId)
        {
            try
            {
                var EmployeeSalObj = await this.FindByIdAsync(EmployeeSalaryId);
                return await this.DeleteAsync(EmployeeSalObj);
            }
            catch (Exception ex) {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while deleting Leave request"); 
            }
        }
    }
}
