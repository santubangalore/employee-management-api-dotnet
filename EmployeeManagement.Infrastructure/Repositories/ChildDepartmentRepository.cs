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
    public class ChildDepartmentRepository(EmployeeMgmtContext dbcontext) : IChildDepartment
    {
        public async Task<Response> CreateAsync(ChildDepartment entity)
        {
            var ParentDept = dbcontext.ParentDepartments;
            try
            {
                //Check if the product already exists
                var getDept = await GetByAsync(_ => _.DepartmentName == entity.DepartmentName);
                if (getDept is not null && !string.IsNullOrEmpty(getDept.DepartmentName))
                {
                    return new Response(false, $"{entity.DepartmentName} department already exists");
                }

                var getChildDept = await ParentDept.Where(p=>p.DepartmentId==entity.ParentDeptId).ToListAsync();
                if (getChildDept is null )
                {
                    return new Response(false, $"ParentDepartmentId is wrong!");
                }

                var currentEntity = dbcontext.ChildDepartments.Add(entity).Entity;
                await dbcontext.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.ChildDeptId > 0)
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

        public Task<Response> DeleteAsync(ChildDepartment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ChildDepartment> FindByIdAsync(int ChildDeptId)
        {
            try
            {
                var ChildDept = await dbcontext.ChildDepartments.FindAsync(ChildDeptId);
                return ChildDept==null? null!: ChildDept!;

            }catch (Exception exx)
            {
                LogException.LogExceptions(exx);
                throw new Exception("Error occurred in ChildDepartment FindByIdAsync");
            }
        }

        public async Task<IEnumerable<ChildDepartment>> GetAllAsync()
        {
            try
            {
                var response = await dbcontext.ChildDepartments.AsNoTracking().ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ChildDepartment> GetByAsync(Expression<Func<ChildDepartment, bool>> predicate)
        {
            try
            {
                var dept = await dbcontext.ChildDepartments.Where(predicate).FirstOrDefaultAsync();
                return dept is not null ? dept! : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error while retrieving dept,{ex.Message}");
            }
        }

        public async Task<IEnumerable<ChildDepartment>> GetChildDepartmentsByParent(int ParentDeptId)
        {
            try
            {
                var childDepartments = await dbcontext.ChildDepartments.Where(p=>p.ParentDeptId == ParentDeptId).ToListAsync();
                return childDepartments is not null ? childDepartments : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving childDepartments");
            }
        }

        public async Task<Response> UpdateAsync(ChildDepartment entity)
        {
            try
            {
                var employee = await FindByIdAsync(entity.ChildDeptId);
                if (employee == null)
                {
                    return new Response(false, "Child dept not found");
                }
                dbcontext.Entry(employee).State = EntityState.Detached;
                dbcontext.ChildDepartments.Update(entity);
                await dbcontext.SaveChangesAsync();
                return new Response(true, "Child dept updated");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while updating Child dept");
            }
        }
    }
}
