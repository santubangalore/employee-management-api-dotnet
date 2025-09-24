using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    public class DepartmentService(IParentDepartment parentDepartmentRepository, IChildDepartment childDepartmentRepository)  : IParentDepartmentService, IChildDepartmentService
    {
        public Task<Response> CreateAsync(ParentDeptDTO parentDeptDto)
        {
            //Conversion
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> CreateAsync(ChildDeptDTO parentDeptDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(ParentDeptDTO parentDeptDto)
        {
            //Convert to entity
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if no record found at delete time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(ChildDeptDTO entity)
        {
            //Convert to cild dept entity
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if no record found at delete time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<ParentDeptDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParentDeptDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ParentDeptDTO> GetByAsync(Expression<Func<ParentDeptDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ChildDeptDTO> GetByAsync(Expression<Func<ChildDeptDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(ParentDeptDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(ChildDeptDTO entity)
        {
            throw new NotImplementedException();
        }

        Task<ChildDeptDTO> IChildDepartmentService.FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ChildDeptDTO>> IChildDepartmentService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
