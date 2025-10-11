using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class OnboardingRepository(EmployeeMgmtContext dbContext) : IOnboarding
    {
        public async Task<Response> CreateAsync(Onboarding entity)
        {
            try
            {
                //Check if the product already exists
                var onboardingCandidate = await GetByAsync(_ => _.Name == entity.Name && _.EmailId == entity.EmailId && _.OnboardingStartDate==entity.OnboardingStartDate);
                if (onboardingCandidate is not null && !string.IsNullOrEmpty(onboardingCandidate.Name))
                {
                    return new Response(false, $"Onboarding Employee already exists");
                }
                var currentEntity = dbContext.Onboarding.Add(entity).Entity;
                await dbContext.SaveChangesAsync();
                if (currentEntity is not null && currentEntity.Id > 0)
                {
                    return new Response(true, $"{entity.Name} added to Database successfully");
                }
                else
                    return new Response(false, $"Error occurred while adding {entity.Name} ");
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                return new Response(false, "Error occurred adding new product");
            }
        }

        public async Task<Response> DeleteAsync(Onboarding entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Onboarding> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Onboarding>> GetAllAsync()
        {
            try { 
                var result=await dbContext.Onboarding.AsNoTracking().ToListAsync();
                return result is not null ? result : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw;
            }
        }

        public async Task<Onboarding> GetByAsync(Expression<Func<Onboarding, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateAsync(Onboarding entity)
        {
            throw new NotImplementedException();
        }
    }
}
