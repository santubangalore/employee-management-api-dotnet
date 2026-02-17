using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class TaxRebateRepository : ITaxRebate, ITaxSlabs
    {
        public Task<Response> CreateAsync(TaxRebate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> CreateAsync(TaxSlab entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(TaxRebate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(TaxSlab entity)
        {
            throw new NotImplementedException();
        }

        public Task<TaxRebate> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaxRebate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaxRebate> GetByAsync(Expression<Func<TaxRebate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TaxSlab> GetByAsync(Expression<Func<TaxSlab, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(TaxRebate entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(TaxSlab entity)
        {
            throw new NotImplementedException();
        }

        Task<TaxSlab> IGenericRepoInterface<TaxSlab>.FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TaxSlab>> IGenericRepoInterface<TaxSlab>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
