using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Services
{
    internal class EmployeeService(IEmployee employeeRepository) : IEmployeeService
    {
        public Task<Response> CreateAsync(EmployeeDTO employeeDto)
        {
            //Conversion
            //if error in convertion, throw error.
            //else invoke repository to insert with wntiry obj
            //if duplicate found at insert time,
            //throw error as record already exists
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(EmployeeDTO employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> GetByAsync(Expression<Func<EmployeeDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(EmployeeDTO employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
