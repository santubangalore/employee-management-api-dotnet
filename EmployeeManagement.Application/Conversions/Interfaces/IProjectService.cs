using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface IProjectService
    {
        Task<Response> CreateAsync(ProjectDTO entity);
        Task<Response> UpdateAsync(ProjectDTO entity);
        Task<Response> DeleteAsync(ProjectDTO entity);
        Task<IEnumerable<ProjectDTO>> GetAllAsync();
        Task<ProjectDTO> FindByIdAsync(int Id);
        Task<ProjectDTO> GetByAsync(Expression<Func<ProjectDTO, bool>> predicate);
    }
}
