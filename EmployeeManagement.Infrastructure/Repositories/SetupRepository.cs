using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class SetupRepository(EmployeeMgmtContext dbContext,IConfiguration configuration) : ISetup
    {
        public async Task<Response> CreateAdmin(Setup entity, List<Employee> employees)
        {
            var getAdmin = await GetByAsync(_ => _.AdminUserId == entity.AdminUserId );
            if (getAdmin is not null && !string.IsNullOrEmpty(getAdmin.AdminUserId))
            {
                return new Response(false, $"{entity.AdminUserId} already exists in SetupTable");
            }
            if (dbContext.CompanySetup.Count() > 0)
            {
                var adminExists = await GetByAsync(_ => _.AdminUserId != null || _.AdminUserId != "" && _.SuperAdminUserId!=null   );
                return new Response(false, $"Super Admin & Admin already exists");

            }

            var res = dbContext.CompanySetup.Add(entity).Entity;

            foreach (var employee in employees)
            {
                var state = dbContext.Employees.Add(employee).Entity;
            }
            dbContext.SaveChanges();

            if (res.Id > 0)
                return new Response(true, "Record created successfully");
            else return new Response(false, "Error creating record");
        }

        public async Task<Response> CreateSuperAdmin(Setup entity, Employee employee)
        {
            throw new NotImplementedException();
            //var getAdmin = await GetByAsync(_ => _.AdminEmail == entity.AdminEmail);
            //if (getAdmin is not null && !string.IsNullOrEmpty(getAdmin.AdminUser))
            //{
            //    return new Response(false, $"{entity.AdminEmail} already exists");
            //}
            //var adminExists = await GetByAsync(_ => _.AdminUser != null || _.AdminUser != "");



            //var state = dbContext.Employees.Add(employee).Entity;

            //dbContext.SaveChanges();

            //if (res.Id > 0)
            //    return new Response(true, "Record created successfully");
            //else return new Response(false, "Error creating record");
        }

       
        public async Task<Response> LoginAsync(LoginDTO login)
        {
            var password = configuration.GetSection("Installer:password").Value;
            if(login == null) throw new ArgumentNullException(nameof(login));
            if ((login.EmailId == "setupinstaller@netquest.in") && login.Password == password)
                return new Response(true, "Login success");
            else return new Response(false,"Invalid cedential");
        }

        public Task<Response> DeleteSuperAdmin(Setup setupEntity, string deleteby)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAdmin(Setup setupEntity, string deleteby)
        {
            throw new NotImplementedException();
        }

        public async Task<Setup> GetByAsync(Expression<Func<Setup, bool>> predicate)
        {
            try
            {
                var dept = await dbContext.CompanySetup.Where(predicate).FirstOrDefaultAsync();
                return dept is not null ? dept! : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error while retrieving Employee,{ex.Message}");
            }
        }

        public Task<Response> UpdateAdmin(Setup setup, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateSuperAdmin(Setup setup, int id)
        {
            throw new NotImplementedException();
        }
    }
}
