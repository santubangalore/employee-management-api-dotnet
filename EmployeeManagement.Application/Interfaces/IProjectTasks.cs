using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.models;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IProjectTasks :IGenericRepoInterface<ProjectTasks> {
        Task<IEnumerable<ProjectTasksResult>> GetResultsFromStoredProcedure(int projectId);
        Task<IEnumerable<ProjectTasks>> GetProjectTasks(int projectId);
    }
}
