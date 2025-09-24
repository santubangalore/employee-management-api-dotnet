using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface IProjectTasksService
    {
        Task<Response> CreateAsync(ProjectTasksDTO entity);
        Task<Response> UpdateAsync(ProjectTasksDTO entity);
        Task<Response> DeleteAsync(ProjectTasksDTO entity);
        Task<IEnumerable<ProjectTasksDTO>> GetAllAsync();
        Task<ProjectTasksDTO> FindByIdAsync(int Id);
        Task<ProjectTasksDTO> GetByAsync(Expression<Func<ProjectTasksDTO, bool>> predicate);
    }
}
