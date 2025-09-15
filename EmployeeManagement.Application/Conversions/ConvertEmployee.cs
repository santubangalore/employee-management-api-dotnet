using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertEmployee(IConfiguration config, IEncryption encryption) 
    {
        //Convert to Entity, before saving to DB
        public static Employee ConvertToEntity(EmployeeDTO employee)
        {
            if (employee is null) return null;
          
            var Emp = new Employee()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                ContactNo = employee.ContactNo,
                DeptId = employee.DeptId,
                EmailId = employee.EmailId,
                Gender = employee.Gender,
                Role = employee.Role,
                CreatedDate = employee.CreatedDate,

            };

            string passwordHash = new PasswordHasher<Employee>().HashPassword(Emp, employee.Password);
            Emp.PasswordHash = passwordHash;
            return Emp;
        }

        public static GetEmployeeDTO ConvertToDto(Employee employee,ChildDepartment childDept)
        {
            if (employee is null) return null;
            return new GetEmployeeDTO()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                ContactNo = employee.ContactNo,
                DeptId = employee.DeptId,
                DeptName=childDept.DepartmentName,
                EmailId = employee.EmailId,
                Gender = employee.Gender,
                Role = employee.Role,
                CreatedDate = employee.CreatedDate,
            };
        }

        public static IEnumerable<GetEmployeeDTO> ConvertToDtoList(IEnumerable<Employee> employees,IEnumerable<ChildDepartment> childDepts)
        {
            if (employees.Count() <= 0) return null;
            List<GetEmployeeDTO> listEmployeeDto = new List<GetEmployeeDTO>();
            var result = from employee in employees
                         join childDept in childDepts
                         on employee.DeptId equals childDept.ChildDeptId
                         select new GetEmployeeDTO()
                         {
                             EmployeeId = employee.EmployeeId,
                             EmployeeName = employee.EmployeeName,
                             ContactNo = employee.ContactNo,
                             DeptId = employee.DeptId,
                             DeptName =childDept.DepartmentName,
                             EmailId = employee.EmailId,
                             Gender = employee.Gender,
                             Role = employee.Role,
                             CreatedDate = employee.CreatedDate,
                         };

            return result.ToList();
        }

        private  string EncryptPassword(string PlainPassword)
        {
            var encPassword = encryption.Encrypt(PlainPassword);
            return encPassword.Result;
        }
    }
}
