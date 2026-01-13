using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController(IProjectTasks projectTaskRepo,IProject projectRepo) : ControllerBase
    {
        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<IEnumerable<ProjectTasksDTO>>> GetAllTasks()
        {
            var tasks = await projectTaskRepo.GetAllAsync();
            if (tasks == null) { return new EmptyResult(); }
            var projects = await projectRepo.GetAllAsync();
            var projTaskDto = ConvertTasks.ConvertToDtoList(tasks, projects);
            return projTaskDto ==null? new EmptyResult(): Ok(new ResponseMessage("Success",true,projTaskDto));
        }

        [HttpGet("GetProjectTasks/{ProjectId}")]
        public async Task<ActionResult> GetProjectTasks(int ProjectId)
        {
            var tasks = await projectTaskRepo.GetResultsFromStoredProcedure(ProjectId);
            if (tasks == null) { return new EmptyResult(); }
            return tasks == null ? new EmptyResult() : Ok(new ResponseMessage("Success", true, tasks));
        }

        [HttpPost("CreateProjectTask")]
        public async Task<ActionResult> CreateProjectTask(ProjectTasksDTO projectTask)
        {
            var entity = ConvertTasks.ConvertToEntity(projectTask);
            var response = await projectTaskRepo.CreateAsync(entity);
            return response.flag == false ? throw new Exception(response.Message) : Ok(response);
        }

        [HttpPut("UpdateProjectTask")]
        public async Task<ActionResult> UpdateProjectTask(ProjectTasksDTO projectTask)
        {
            var entity = ConvertTasks.ConvertToEntity(projectTask);
            var response = await projectTaskRepo.UpdateAsync(entity);
            return response.flag == false ? throw new ArgumentException("Not found") : Ok(response);
        }

        [HttpDelete("DeleteProjectTask")]
        public async Task<ActionResult> DeleteProjectTask(int projectTaskId)
        {
            var projectTask = await projectTaskRepo.FindByIdAsync(projectTaskId);
            if (projectTask == null) { throw new ArgumentException("Not found"); }
            var response = await projectTaskRepo.UpdateAsync(projectTask);
            return response.flag == false ? NotFound(response) : Ok(response);
        }
    }
}
