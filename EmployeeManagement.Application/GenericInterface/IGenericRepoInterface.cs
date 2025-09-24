using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.GenericInterface
{
    public interface IGenericRepoInterface<T> where T : class
    {
        Task<Response> CreateAsync(T entity);
        Task<Response> UpdateAsync(T entity);
        Task<Response> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindByIdAsync(int Id);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
    }
}
