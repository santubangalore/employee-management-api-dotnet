using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface IProjectEmployeeService
    {
        Task<Response> CreateAsync(ProjectEmployeeDTO entity);
        Task<Response> UpdateAsync(ProjectEmployeeDTO entity);
        Task<Response> DeleteAsync(ProjectEmployeeDTO entity);
        Task<IEnumerable<ProjectEmployeeDTO>> GetAllAsync();
        Task<ProjectEmployeeDTO> FindByIdAsync(int Id);
        Task<ProjectEmployeeDTO> GetByAsync(Expression<Func<ProjectEmployeeDTO, bool>> predicate);
        Task<IEnumerable<ProjectEmployeeDTO>> GetProjectEmployees(int ProjectId);
    }
}
