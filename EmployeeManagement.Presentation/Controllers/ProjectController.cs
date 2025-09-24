using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProject projectInterface) : ControllerBase
    {
        [HttpGet("GetProjects")]
        public async Task<ActionResult<ResponseMessage>> GetProjects()
        {
            var result = await projectInterface.GetAllAsync();
            var projectListDto = ConvertProject.ConvertToDtoList(result);
            if (projectListDto == null) { return NotFound("No records found in Db!"); }
            return Ok(new ResponseMessage("Projects",true,projectListDto ));
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
