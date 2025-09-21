using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ProjectTasksRepository : IProjectTasks
    {
        public Task<Response> CreateAsync(ProjectTasks entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(ProjectTasks entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTasks> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectTasks>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTasks> GetByAsync(Expression<Func<ProjectTasks, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(ProjectTasks entity)
        {
            throw new NotImplementedException();
        }
    }
}
