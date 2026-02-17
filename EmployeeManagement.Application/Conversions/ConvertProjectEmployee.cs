using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertProjectEmployee
    {
        public static ProjectEmployee ConvertToEntity(ProjectEmployeeDTO prjEmplDto)
        {
            if (prjEmplDto is null) return null;
            var prj = new ProjectEmployee()
            {
                EmpProjectId = prjEmplDto.EmpProjectId,
                Role=prjEmplDto.Role,
                IsActive=prjEmplDto.IsActive,
                ProjectId = prjEmplDto.ProjectId,
                EmpId= prjEmplDto.EmpId,
                EmployeeName = prjEmplDto.EmployeeName,
                AssignedDate = prjEmplDto.AssignedDate, 
                ExitDate = prjEmplDto.ExitDate,
            };
            return prj;
        }

        public static ProjectEmployeeDTO ConvertToDto(ProjectEmployee projectEmployee)
        {
            if (projectEmployee is null) return null;
            return new ProjectEmployeeDTO()
            {
                EmpProjectId = projectEmployee.EmpProjectId,
                ProjectId = projectEmployee.ProjectId,
                
                EmpId = projectEmployee.EmpId,
                EmployeeName = projectEmployee.EmployeeName,
                AssignedDate = projectEmployee.AssignedDate,
                ExitDate = projectEmployee.ExitDate,
                Role = projectEmployee.Role,
                IsActive = projectEmployee.IsActive,
            };
        }

        public static List<ProjectEmployeeDTO> ConvertToDtos(IEnumerable<ProjectEmployee> projectEmployees,IEnumerable<Project> projects)
        {
            if (projectEmployees.Count() <= 0) return null;
            List<ProjectEmployeeDTO> projectEmployeeDtos = new List<ProjectEmployeeDTO>();
            var result = from employee in projectEmployees
                         join project in projects
                         on employee.ProjectId equals project.ProjectId
                         select new ProjectEmployeeDTO()
                         {
                             EmpProjectId = employee.EmpProjectId,
                             EmployeeName = employee.EmployeeName,
                             Role = employee.Role,
                             IsActive = employee.IsActive,
                             AssignedDate= employee.AssignedDate,
                             ProjectName=project.ProjectName,
                             ProjectId=project.ProjectId,
                             ExitDate=employee.ExitDate,
                         };
            //foreach (var perEmp in projectEmployees)
            //{
            //    projectEmployeeDtos.Add(ConvertToDto(perEmp));
            //}
            return result.ToList();
        }
    }
}
