using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class OnboardingRepository : IOnboarding
    {
        public async Task<Response> CreateAsync(IOnboarding entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> DeleteAsync(IOnboarding entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IOnboarding> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IOnboarding>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IOnboarding> GetByAsync(Expression<Func<IOnboarding, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateAsync(IOnboarding entity)
        {
            throw new NotImplementedException();
        }
    }
}
