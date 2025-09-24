using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ProjectTasksRepository(EmployeeMgmtContext dbContext) : IProjectTasks
    {
        public async Task<Response> CreateAsync(ProjectTasks entity)
        {
            try
            {
                //Check if the product already exists
                var getProject = await GetByAsync(_ => _.TaskName == entity.TaskName && _.ProjectId==entity.ProjectId);
                if (getProject is not null && !string.IsNullOrEmpty(getProject.TaskName))
                {
                    return new Response(false, $"{entity.TaskName} already exists");
                }
                var currentEntity = dbContext.ProjectTasks.Add(entity).Entity;
                await dbContext.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.ProjectId > 0)
                {
                    return new Response(true, $"{entity.TaskName} added to Database successfully");
                }
                else
                    return new Response(false, $"Error occurred while adding {entity.TaskName} ");
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred adding new project");
            }
        }

        public async Task<Response> DeleteAsync(ProjectTasks entity)
        {
            try
            {
                var leaveReq = await FindByIdAsync(entity.ProjectId);
                if (leaveReq is null)
                {
                    return new Response(false, "Task not found");
                }
                dbContext.Entry(leaveReq).State = EntityState.Detached;
                dbContext.ProjectTasks.Remove(entity);
                await dbContext.SaveChangesAsync();
                return new Response(true, "Task deleted");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, $"Error happened while deleting Task {entity.TaskName}, with Id: {entity.Id}");
            }
        }

        public async Task<ProjectTasks> FindByIdAsync(int Id)
        {
            try
            {
                var projectTasks = await dbContext.ProjectTasks.FindAsync(Id);
                return projectTasks is not null ? projectTasks : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new Exception("Error occurred finding parent dept");
            }
        }

        public async Task<IEnumerable<ProjectTasks>> GetAllAsync()
        {
            try
            {
                var response = await dbContext.ProjectTasks.AsNoTracking().ToListAsync();
                return response is null ? null! : response;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception("Error occurred getting task list from db!");
            }
        }

        public async Task<ProjectTasks> GetByAsync(Expression<Func<ProjectTasks, bool>> predicate)
        {
            try
            {
                var proj = await dbContext.ProjectTasks.Where(predicate).FirstOrDefaultAsync();
                return proj is not null ? proj : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving project");
            }
        }

        public async Task<Response> UpdateAsync(ProjectTasks entity)
        {
            try
            {
                var leaveReq = await FindByIdAsync(entity.ProjectId);
                if (leaveReq is null)
                {
                    return new Response(false, "Leave request not found");
                }
                dbContext.Entry(leaveReq).State = EntityState.Detached;
                dbContext.ProjectTasks.Update(entity);
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
