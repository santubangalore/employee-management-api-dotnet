using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController(IProjectTasks projectTasksInterface,IProject projectInterface) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTasksDTO>>> GetProjectTasks()
        {
            var tasks = await projectTasksInterface.GetAllAsync();
            if (tasks == null) { return new EmptyResult(); }
            var projects = await projectInterface.GetAllAsync();
            var projTaskDto = ConvertTasks.ConvertToDtoList(tasks, projects);
            return projTaskDto ==null? new EmptyResult(): Ok(new ResponseMessage("Success",true,projTaskDto));
        }

        [HttpPost("CreateProjectTask")]
        public async Task<ActionResult> CreateProjectTask(ProjectTasksDTO projectTask)
        {
            var entity = ConvertTasks.ConvertToEntity(projectTask);
            var response = await projectTasksInterface.CreateAsync(entity);
            return response.flag == false ? NotFound(response) : Ok(response);
        }

        [HttpPut("UpdateProjectTask")]
        public async Task<ActionResult> UpdateProjectTask(ProjectTasksDTO projectTask)
        {
            var entity = ConvertTasks.ConvertToEntity(projectTask);
            var response = await projectTasksInterface.CreateAsync(entity);
            return response.flag == false ? NotFound(response) : Ok(response);
        }

        [HttpDelete("DeleteProjectTask")]
        public async Task<ActionResult> DeleteProjectTask(int projectTaskId)
        {
            throw new NotImplementedException("Method not implemented");
            //var entity = ConvertTasks.ConvertToEntity(projectTask);
            //var response = await projectTasksInterface.CreateAsync(entity);
            //return response.flag == false ? NotFound(response) : Ok(response);
        }
    }
}
