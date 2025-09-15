using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ParentDeptRepository(EmployeeMgmtContext dbcontext) : IParentDepartment
    {
        public async Task<Response> CreateAsync(ParentDepartment entity)
        {
            try
            {
                var getParentDepartment = await GetByAsync(_ => _.DepartmentName == entity.DepartmentName);
                if (getParentDepartment is not null && !string.IsNullOrEmpty(getParentDepartment.DepartmentName))
                {
                    return new Response(false, $"{entity.DepartmentName} department already exists");
                }
                var currentEntity = dbcontext.ParentDepartments.Add(entity).Entity;
                await dbcontext.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.DepartmentId > 0)
                {
                    return new Response(true, $"{entity.DepartmentName} added to Database successfully");
                }
                else
                    return new Response(false, $"Error occurred while adding {entity.DepartmentName} ");
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred adding new product");
            }
        }

        public Task<Response> DeleteAsync(ParentDepartment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ParentDepartment> FindByIdAsync(int Id)
        {
            try
            {
                var parentDept = await dbcontext.ParentDepartments.FindAsync(Id);
                return parentDept is not null ? parentDept : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred finding parent dept");
            }
        }
        public async Task<IEnumerable<ParentDepartment>> GetAllAsync()
        {
            try
            {
               var response =  await dbcontext.ParentDepartments.AsNoTracking().ToListAsync();
               return response is null ? null! : response;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception("Error occurred getting parent dept from db!");
            }
        }

        public async Task<ParentDepartment> GetByAsync(Expression<Func<ParentDepartment, bool>> predicate)
        {
            try
            {
                var dept = await dbcontext.ParentDepartments.Where(predicate).FirstOrDefaultAsync();
                return dept is not null ? dept! : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error while retrieving dept,{ex.Message}");
            }
        }

        public async Task<Response> UpdateAsync(ParentDepartment entity)
        {
            try
            {
                var dept = await FindByIdAsync(entity.DepartmentId);
                if (dept is null)
                {
                    return new Response(false, "Parent dept not found");
                }
                dbcontext.Entry(dept).State = EntityState.Detached;
                dbcontext.ParentDepartments.Update(entity);
                await dbcontext.SaveChangesAsync();
                return new Response(true, "Parent dept updated");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while updating Parent dept");
            }
        }
    }
}
