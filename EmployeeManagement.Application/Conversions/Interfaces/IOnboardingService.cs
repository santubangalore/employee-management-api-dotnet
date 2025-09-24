using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface IOnboardingService
    {
        Task<Response> CreateAsync(OnboardingDTO entity);
        Task<Response> UpdateAsync(OnboardingDTO entity);
        Task<Response> DeleteAsync(OnboardingDTO entity);
        Task<IEnumerable<OnboardingDTO>> GetAllAsync();
        Task<OnboardingDTO> FindByIdAsync(int Id);
        Task<OnboardingDTO> GetByAsync(Expression<Func<OnboardingDTO, bool>> predicate);
    }
}
