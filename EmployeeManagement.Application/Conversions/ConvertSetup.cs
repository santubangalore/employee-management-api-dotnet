using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertSetup
    {
        public static  (Setup, List<Employee>) ConvertDtoToEntity(SetupDto dto)
        {
            if(dto is null) return (null,null);
            if (dto.ClientEmail == null) { return (null,null); }
         
            Employee AdminEmployee = new Employee
            {
                CreatedDate = DateTime.Today,
                EmployeeId = 0,
                EmailId = dto.AdminUserId,
                Role = "Admin",
                ContactNo = "",
                DeptId = 0,
                EmployeeName = dto.AdminUserName,
                Gender = "",
                LastUpdatedDate = DateTime.UtcNow,
                ReportingTo=0,
                LastUpdatedBy = dto.SetupBy
            };
            Employee SuperAdminEmployee = new Employee
            {
                CreatedDate = DateTime.Today,
                EmployeeId = 0,
                EmailId = dto.SuperAdminUserId,
                Role = "SuperAdmin",
                ContactNo = "",
                DeptId = 0,
                EmployeeName = dto.SuperAdminUserName,
                Gender = "",
                LastUpdatedDate = DateTime.UtcNow,
                ReportingTo = 0,
                LastUpdatedBy = dto.SetupBy
            };

            string adminPasswordHash = new PasswordHasher<Employee>().HashPassword(AdminEmployee, dto.AdminPassword);
            string superAdminPasswordHash = new PasswordHasher<Employee>().HashPassword(AdminEmployee, dto.SuperAdminPassword);
            AdminEmployee.PasswordHash = adminPasswordHash;
            SuperAdminEmployee.PasswordHash = superAdminPasswordHash;

            Setup setup = new Setup
            {
                ClientName = dto.ClientName,
                ClientEmail = dto.ClientEmail,
                AdminUserId = dto.AdminUserId,
                AdminUserName = dto.AdminUserName,
                AdminPassword =adminPasswordHash,
                SetupBy = dto.SetupBy,
                SetupDate = dto.SetupDate,
                SuperAdminUserId = dto.SuperAdminUserId,
                SuperAdminUserName = dto.SuperAdminUserName,
                SuperAdminPassword = superAdminPasswordHash,
                CreationDate = DateTime.Now,
                LastUpdationDate = DateTime.Now,
            };
            List<Employee> employees = new List<Employee> { AdminEmployee, SuperAdminEmployee };
            return (setup, employees); 

        }

    }
}
