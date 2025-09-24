using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    public class ProjectService(IProject projectRepository) : IProjectService
    {
        public Task<Response> CreateAsync(ProjectDTO entity)
        {
            //Convert to entity
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(ProjectDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDTO> GetByAsync(Expression<Func<ProjectDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(ProjectDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
