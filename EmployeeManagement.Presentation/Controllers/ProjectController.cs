using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProject projectInterface) : ControllerBase
    {
        [HttpGet("GetProjects")]
        public async Task<ActionResult<ProjectDTO>> GetProjects()
        {
            var result = await projectInterface.GetAllAsync();
            var leaveTypesDto = ConvertProject.ConvertToDtoList(result);
            if (leaveTypesDto == null) { return NotFound("No records found in Db!"); }
            return Ok(leaveTypesDto);
        }

        [HttpPost("CreateProject")]
        public async Task<ActionResult> CreateProject(ProjectDTO project)
        {
            var entity = ConvertProject.ConvertToEntity(project);
            var response = await projectInterface.CreateAsync(entity);
            return response.flag == false ? NotFound(response) : Ok(response);
        }
    }
}
