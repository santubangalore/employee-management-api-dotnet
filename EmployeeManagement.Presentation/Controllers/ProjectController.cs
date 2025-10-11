using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
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

        [HttpPost("CreateProjectRole")]
        public async Task<ActionResult<ResponseMessage>> CreateProjectRole(RoleDTO project)
        {
            var entity = ConvertRole.ConvertToEntity(project);
            var response = await projectInterface.CreateRole(entity);
            return !response.flag ? new ResponseMessage("failed to create", response.flag, response.Message) : new ResponseMessage("success", response.flag, response.Message);
        }

        [HttpPut("UpdateProjectRole")]
        public async Task<ActionResult> UpdateProjectRole(RoleDTO project)
        {
            var entity = ConvertRole.ConvertToEntity(project);
            var response = await projectInterface.UpdateRole(entity);
            return response.flag == false ? NotFound(response) : Ok(response);
        }

        [HttpGet("GetAllProjectRoles")]
        public async Task<ActionResult<ResponseMessage>> GetAllProjectRoles()
        {
            var response = await projectInterface.GetAllRoles();
            return response == null ? new ResponseMessage("failed to create", false, response) : new ResponseMessage("success", true, response);
        }
    }
}
