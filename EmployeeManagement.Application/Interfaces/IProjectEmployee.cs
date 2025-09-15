using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IProjectEmployee :IGenericInterface<ProjectEmployee> {
        Task<IEnumerable<ProjectEmployee>> GetProjectEmployees(int ProjectId);
    }
}
