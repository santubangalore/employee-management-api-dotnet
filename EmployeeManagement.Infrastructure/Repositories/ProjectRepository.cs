using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ProjectRepository(EmployeeMgmtContext dbcontext) : IProject
    {
        public async Task<Response> CreateAsync(Project entity)
        {
            try
            {
                //Check if the product already exists
                var getProject = await GetByAsync(_ => _.ProjectName == entity.ProjectName);
                if (getProject is not null && !string.IsNullOrEmpty(getProject.ProjectName))
                {
                    return new Response(false, $"{entity.ProjectName} already exists");
                }
                var currentEntity = dbcontext.Projects.Add(entity).Entity;
                await dbcontext.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.ProjectId > 0)
                {
                    return new Response(true, $"{entity.ProjectName} added to Database successfully");
                }
                else
                    return new Response(false, $"Error occurred while adding {entity.ProjectName} ");
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred adding new project");
            }
        }

        public Task<Response> DeleteAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> FindByIdAsync(int Id)
        {
            try
            {
                var projects = await dbcontext.Projects.FindAsync(Id);
                return projects is not null ? projects : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred finding parent dept");
            }
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            try
            {
                var response = await dbcontext.Projects.AsNoTracking().ToListAsync();
                return response is null ? null! : response;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception("Error occurred getting project list from db!");
            }
        }

        public async Task<Project> GetByAsync(Expression<Func<Project, bool>> predicate)
        {
            try
            {
                var proj = await dbcontext.Projects.Where(predicate).FirstOrDefaultAsync();
                return proj is not null ? proj : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving project");
            }
        }

        public Task<Response> UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
