using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    public class ProjectEmployeeService(IProjectTasks projectTasksRepository) : IProjectEmployeeService
    {
        public Task<Response> CreateAsync(ProjectEmployeeDTO projectEmployeeDto)
        {
            //Convert to entity
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(ProjectEmployeeDTO projectEmployeeDto)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectEmployeeDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectEmployeeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectEmployeeDTO> GetByAsync(Expression<Func<ProjectEmployeeDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectEmployeeDTO>> GetProjectEmployees(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(ProjectEmployeeDTO projectEmployeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
