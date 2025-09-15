using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController(IProjectEmployee projectEmployeeInterface) : ControllerBase
    {
        [HttpGet("GetProjectEmployees")]
        public async Task<ActionResult<IEnumerable<ProjectEmployeeDTO>>> GetProjectEmployees()
        {
            var projectEmployees = await projectEmployeeInterface.GetAllAsync();
            if (!projectEmployees.Any())
            {
                return NotFound("No Project Employee Record found in the db");
            }
            var list =ConvertProjectEmployee.ConvertToDtos(projectEmployees);
            return list!.Any() ? Ok(list) : NotFound("Conversion Error !");
        }

        [HttpGet("GetEmployeeByProject/{ProjectId}")]
        public async Task<ActionResult<IEnumerable<ProjectEmployeeDTO>>> GetEmployeeByProject(int ProjectId)
        {
            if (ProjectId <= 0) return BadRequest("ProjectId cannot be 0 or less");
            var employees = await projectEmployeeInterface.GetProjectEmployees(ProjectId);
            if (employees is null) return NotFound(string.Empty);

            var result = ConvertProjectEmployee.ConvertToDtos(employees);
            return result is null ? BadRequest(string.Empty) : Ok(result);
        }

        [HttpPost("CreateProjectEmployee")]
        public async Task<ActionResult> CreateProjectEmployee(ProjectEmployeeDTO project)
        {
            var entity = ConvertProjectEmployee.ConvertToEntity(project);
            var response = await projectEmployeeInterface.CreateAsync(entity);
            return response.flag == false ? NotFound(response) : Ok(response);
        }
    }
}
