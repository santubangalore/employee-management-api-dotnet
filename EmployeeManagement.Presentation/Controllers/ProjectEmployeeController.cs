using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController(IProjectEmployee projectEmployeeRepo,IProject projectRepo) : ControllerBase
    {
        [HttpGet("GetProjectEmployees")]
        public async Task<ActionResult<IEnumerable<ProjectEmployeeDTO>>> GetProjectEmployees()
        {
            var projectEmployees = await projectEmployeeRepo.GetAllAsync();
            if (!projectEmployees.Any())
            {
                return NotFound("No Project Employee Record found in the db");
            }
            var projectRecords =await projectRepo.GetAllAsync();
            if (projectRecords is null) return NotFound();
            var list =ConvertProjectEmployee.ConvertToDtos(projectEmployees, projectRecords);
            return list!.Any() ? Ok(new ResponseMessage("successs", true, list)) : NotFound("Conversion Error !");
        }
        
        [HttpGet("GetProjectEmployeeDetail/{ProjectEmpId}")]
        public async Task<ActionResult<ProjectEmployeeDTO>> GetProjectEmployeeDetail(int ProjectEmpId)
        {
            var projectEmployee = await projectEmployeeRepo.FindByIdAsync(ProjectEmpId);
            if (projectEmployee is null)
            {
                return BadRequest("No matching Record found in the database");
            }
            var prjEmpDtoObj = ConvertProjectEmployee.ConvertToDto(projectEmployee);
            return prjEmpDtoObj is null ? Ok(new ResponseMessage("successs", true, prjEmpDtoObj)) : BadRequest("Conversion Error !");
        }

        [HttpGet("GetEmployeeByProject/{ProjectId}")]
        public async Task<ActionResult<IEnumerable<ProjectEmployeeDTO>>> GetEmployeeByProject(int ProjectId)
        {
            if (ProjectId <= 0) return BadRequest("ProjectId cannot be 0 or less");
            var employees = await projectEmployeeRepo.GetProjectEmployees(ProjectId);
            if (employees is null) return NotFound(string.Empty);
            var projectRecords = await projectRepo.GetAllAsync();
            var result = ConvertProjectEmployee.ConvertToDtos(employees, projectRecords);
            return result is null ? BadRequest(string.Empty) : Ok(new ResponseMessage("successs",true,result));
        }

        [HttpPost("CreateProjectEmployee")]
        public async Task<ActionResult<ResponseMessage>> CreateProjectEmployee(ProjectEmployeeDTO project)
        {
            var entity = ConvertProjectEmployee.ConvertToEntity(project);
          
            var response = await projectEmployeeRepo.CreateAsync(entity);
            return !response.flag ? Ok(new ResponseMessage("failed to create", response.flag, response.Message)): Ok(new ResponseMessage("success", response.flag, response.Message));

        }

        [HttpPut("UpdateProjectEmployee")]
        public async Task<ActionResult<ResponseMessage>> UpdateProjectEmployee(ProjectEmployeeDTO project)
        {
            var entity = ConvertProjectEmployee.ConvertToEntity(project);
            var response = await projectEmployeeRepo.UpdateAsync(entity);
            return !response.flag ? 
                 Ok( new ResponseMessage("failed to update", response.flag, response.Message)) 
                : Ok( new ResponseMessage("success", response.flag, response.Message));

        }

        [HttpDelete("DeleteProjectEmployee/{projectEmpId}")]
        public async Task<ActionResult<ResponseMessage>> DeleteProjectEmployee(int projectEmpId)
        { 
            var entity = await projectEmployeeRepo.FindByIdAsync(projectEmpId);
            var response = await projectEmployeeRepo.DeleteAsync(entity);

            return !response.flag ?
                 Ok(new ResponseMessage("failed to delete", response.flag, response.Message))
                : Ok(new ResponseMessage("success", response.flag, response.Message));

        }
    }
}
