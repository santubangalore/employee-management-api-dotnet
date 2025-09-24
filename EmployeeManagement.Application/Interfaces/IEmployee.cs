using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployee : IGenericRepoInterface<Employee> {
    Task<IEnumerable<Employee>> GetAllExcluding(int EmployeeId);
    }
}
