using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ProjectEmployeeRepository(EmployeeMgmtContext dbcontext) : IProjectEmployee
    {
        public async Task<Response> CreateAsync(ProjectEmployee entity)
        {
            try
            {
                //Check if the product already exists
                var getEmployeeExists = await GetAllByAsync(_ => _.EmpId == entity.EmpId && _.IsActive && _.AssignedDate>_.ExitDate  );
                if (getEmployeeExists.Count()>0) { 
                    return new Response(false, "Employee already exists in active project");
                }

                var getPrjEmployee = await GetByAsync(_ => _.EmployeeName == entity.EmployeeName && _.ProjectId==entity.ProjectId);
                if (getPrjEmployee is not null && !string.IsNullOrEmpty(getPrjEmployee.EmployeeName))
                {
                    return new Response(false, $"Project Employee already exists");
                }
                var currentEntity = dbcontext.EmployeeProjects.Add(entity).Entity;
                await dbcontext.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.EmpProjectId > 0)
                {
                    return new Response(true, $"{entity.EmployeeName} added to Database successfully");
                }
                else
                    return new Response(false, $"Error occurred while adding {entity.EmployeeName} ");
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred adding new ProjectEmployee");
            }
        }

        public async Task<Response> DeleteAsync(ProjectEmployee entity)
        {
            try
            {
                var proj = await FindByIdAsync(entity.EmpProjectId);
                if (proj is null)
                    return new Response(true, $"{entity.EmployeeName} not found in Database");
                else
                {
                    dbcontext.EmployeeProjects.Remove(proj);
                    await dbcontext.SaveChangesAsync();
                    return new Response(true, $"{entity.EmployeeName} deleted");
                }
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred deleting Project Employee");
            }
        }

        public async Task<ProjectEmployee> FindByIdAsync(int Id)
        {
            try
            {
                var product = await dbcontext.EmployeeProjects.FindAsync(Id);
                return product is not null ? product : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred finding Project Employee");
            }
        }

        public async Task<IEnumerable<ProjectEmployee>> GetAllAsync()
        {
            try
            {
                var projEmployees = await dbcontext.EmployeeProjects.AsNoTracking().ToListAsync();
                return projEmployees is not null ? projEmployees : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving ProjectEmployees");
            }
        }
        public async Task<IEnumerable<ProjectEmployee>> GetAllByAsync(Expression<Func<ProjectEmployee, bool>> predicate)
        {
            var projEmployee = await dbcontext.EmployeeProjects.Where(predicate).ToListAsync();
            return projEmployee!;
        }
        public async Task<ProjectEmployee> GetByAsync(Expression<Func<ProjectEmployee, bool>> predicate)
        {
            var projEmployee = await dbcontext.EmployeeProjects.Where(predicate).SingleOrDefaultAsync();
            return projEmployee!;
        }

        public async Task<IEnumerable<ProjectEmployee>> GetProjectEmployees(int ProjectId)
        {
            try
            {
                var projEmployees = await dbcontext.EmployeeProjects.Where(p => p.ProjectId == ProjectId).ToListAsync();
                return projEmployees is not null ? projEmployees : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving ProjectEmployees");
            }
        }

        public Task<Response> UpdateAsync(ProjectEmployee entity)
        {
            throw new NotImplementedException();
        }
    }
}
