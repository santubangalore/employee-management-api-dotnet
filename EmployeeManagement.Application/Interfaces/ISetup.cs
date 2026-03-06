using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EmployeeManagement.Application.Interfaces
{
    public interface ISetup 
    {
        Task<Response> CreateSuperAdmin(Setup entity, Employee employee);
        Task<Setup> GetByAsync(Expression<Func<Setup, bool>> predicate) ;
        Task<Response> LoginAsync(LoginDTO login);
        Task<Response> UpdateSuperAdmin(Setup setup, int id);
        //Task<Response> DeleteSuperAdmin(Setup setupDto, string deleteby);
        Task<Response> CreateAdmin(Setup entity, List<Employee> employees);
        Task<Response> UpdateAdmin(Setup setup, int id);
        //Task<Response> DeleteAdmin(Setup setup, string deleteby);

    }
}
