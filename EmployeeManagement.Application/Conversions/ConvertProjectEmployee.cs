using EmployeeManagement.Application.DTOs;
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
                ProjectId = prjEmplDto.ProjectId,
                EmpId= prjEmplDto.EmpId,
                EmployeeName = prjEmplDto.EmployeeName,
                AssignedDate = prjEmplDto.AssignedDate, 
                
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
            };
        }

        public static List<ProjectEmployeeDTO> ConvertToDtos(IEnumerable<ProjectEmployee> projectEmployees)
        {
            if (projectEmployees.Count() <= 0) return null;
            List<ProjectEmployeeDTO> projectEmployeeDtos = new List<ProjectEmployeeDTO>();
            foreach (var perEmp in projectEmployees)
            {
                projectEmployeeDtos.Add(ConvertToDto(perEmp));
            }
            return projectEmployeeDtos;
        }
    }
}
