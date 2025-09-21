using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository(EmployeeMgmtContext dbcontext) : IEmployee
    {
        public async Task<Response> CreateAsync(Employee entity)
        {
            var getEmployee = await GetByAsync(_ => _.EmployeeName == entity.EmployeeName && _.EmailId ==entity.EmailId);
            if (getEmployee is not null && !string.IsNullOrEmpty(getEmployee.EmployeeName))
            {
                return new Response(false, $"{entity.EmployeeName} already exists");
            }
            var res= dbcontext.Employees.Add(entity).Entity;
            dbcontext.SaveChanges();
            if (res.EmployeeId>0)
                return new Response(true, "Record created successfully");
            else return new Response(false, "Error creating record");
        }

        public async Task<Response> DeleteAsync(Employee entity)
        {
            try
            {
                var employee = await FindByIdAsync(entity.EmployeeId);
                if (employee == null)
                {
                    return new Response(false, "employee not found");
                }
                dbcontext.Entry(employee).State = EntityState.Detached;
                dbcontext.Employees.Remove(entity);
                await dbcontext.SaveChangesAsync();
                return new Response(true, "Employee deleted");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while updating employee");
            }
        }

        public async Task<Employee> FindByIdAsync(int Id)
        {
            var EmpObj= await dbcontext.Employees.FindAsync(Id);
            return EmpObj!;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await dbcontext.Employees.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Employee>> GetAllExcluding(int EmployeeId)
        {
            var emplist = await dbcontext.Employees.AsNoTracking().ToListAsync();
            var result = emplist.Where(x => x.EmployeeId != EmployeeId);
            return result;
        }

        public async Task<Employee> GetByAsync(Expression<Func<Employee, bool>> predicate)
        {
            try
            {
                var dept = await dbcontext.Employees.Where(predicate).FirstOrDefaultAsync();
                return dept is not null ? dept! : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error while retrieving Employee,{ex.Message}");
            }
        }

        public async Task<Response> UpdateAsync(Employee entity)
        {
            try
            {
                var employee = await FindByIdAsync(entity.EmployeeId);
                if (employee == null)
                {
                    return new Response(false, "employee not found");
                }
                dbcontext.Entry(employee).State = EntityState.Detached;
                dbcontext.Employees.Update(entity);
                await dbcontext.SaveChangesAsync();
                return new Response(true, "Employee updated");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while updating employee");
            }
        }
    }
}
