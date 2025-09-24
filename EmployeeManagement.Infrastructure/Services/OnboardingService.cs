using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    public class OnboardingService(IOnboarding onboardingRepository) : IOnboardingService
    {
        public Task<Response> CreateAsync(OnboardingDTO entity)
        {
            //Convert to entity
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(OnboardingDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<OnboardingDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OnboardingDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OnboardingDTO> GetByAsync(Expression<Func<OnboardingDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(OnboardingDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
