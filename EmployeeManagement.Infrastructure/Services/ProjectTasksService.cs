using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    public class ProjectTasksService(IProjectTasks projectTasksRepository) : IProjectTasksService
    {
        public Task<Response> CreateAsync(ProjectTasksDTO entity)
        {
            //Convert to entity
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(ProjectTasksDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTasksDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectTasksDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectTasksDTO> GetByAsync(Expression<Func<ProjectTasksDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(ProjectTasksDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
