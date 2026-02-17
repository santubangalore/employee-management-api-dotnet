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
                var response = await dbContext.Projects.AsNoTracking().Include(p=>p.ProjectTasks).ToListAsync();

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

        public async Task<Response> CreateRole(Role entity)
        {
            try
            {
                //Check if the product already exists
                var getRole = await GetRoleByAsync(_ => _.RoleName == entity.RoleName);
                if (getRole is not null && !string.IsNullOrEmpty(getRole.RoleName))
                {
                    return new Response(false, $"{entity.RoleName} already exists");
                }
                var currentEntity = dbContext.Roles.Add(entity).Entity;
                await dbContext.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.RoleId > 0)
                {
                    return new Response(true, $"{entity.RoleName} added to Database successfully");
                }
                else
                    return new Response(false, $"Error occurred while adding {entity.RoleName} ");
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred adding new project");
            }
        }

        public async Task<Response> DeleteRole(Role entity)
        {
            try
            {
                var role = await GetRole(entity.RoleId);
                if (role is null)
                    return new Response(true, $"{entity.RoleName} not found in Database");
                else
                {
                    dbContext.Roles.Remove(role);
                    await dbContext.SaveChangesAsync();
                    return new Response(true, $"{entity.RoleName} deleted");
                }
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred deleting Role ");
            }
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
           try 
            { 
                var roles = await dbContext.Roles.AsNoTracking().ToListAsync();
                return roles;
            }
            catch(Exception ex) {
                LogException.LogExceptions(ex);
                throw;
            }
        }

        public async Task<Role> GetRole(int RoleId)
        {
            try
            {
                var role= await dbContext.Roles.FindAsync(RoleId);
                if (role == null) return null!;

                return role;

            } catch (Exception exception) 
            {
                LogException.LogExceptions(exception);
                throw;
            }

        }

        public async Task<Role> GetRoleByAsync(Expression<Func<Role, bool>> predicate)
        {
            try
            {
                var role = await dbContext.Roles.Where(predicate).FirstOrDefaultAsync();
                return role is not null ? role : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving Role");
            }
        }

        public Task<Response> UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
