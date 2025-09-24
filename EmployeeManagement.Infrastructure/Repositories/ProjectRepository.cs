using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ProjectRepository(EmployeeMgmtContext dbContext) : IProject
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
                var currentEntity = dbContext.Projects.Add(entity).Entity;
                await dbContext.SaveChangesAsync();
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

        public async Task<Response> DeleteAsync(Project entity)
        {
            try
            {
                var proj = await FindByIdAsync(entity.ProjectId);
                if (proj is null)
                    return new Response(true, $"{entity.ProjectName} not found in Database");
                else
                {
                    dbContext.Projects.Remove(proj);
                    await dbContext.SaveChangesAsync();
                    return new Response(true, $"{entity.ProjectName} deleted");
                }
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred deleting Project ");
            }
        }

        public async Task<Project> FindByIdAsync(int Id)
        {
            try
            {
                var projects = await dbContext.Projects.FindAsync(Id);
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
                var response = await dbContext.Projects.AsNoTracking().ToListAsync();
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
                var proj = await dbContext.Projects.Where(predicate).FirstOrDefaultAsync();
                return proj is not null ? proj : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving project");
            }
        }

        public async Task<Response> UpdateAsync(Project entity)
        {
            try
            {
                var leaveReq = await FindByIdAsync(entity.ProjectId);
                if (leaveReq is null)
                {
                    return new Response(false, "Leave request not found");
                }
                dbContext.Entry(leaveReq).State = EntityState.Detached;
                dbContext.Projects.Update(entity);
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
