using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.models;
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
            var projects = await projectRepo.GetAllAsync();
            return tasks == null ? new EmptyResult() : Ok(new ResponseMessage("Success", true, tasks));
        }

        [HttpPost("CreateProjectTask")]
        public async Task<ActionResult> CreateProjectTask(ProjectTasksDTO projectTask)
        {
            var entity = ConvertTasks.ConvertToEntity(projectTask);
            var response = await projectTaskRepo.CreateAsync(entity);
            return response.flag == false ? NotFound(response) : Ok(response);
        }

        [HttpPut("UpdateProjectTask")]
        public async Task<ActionResult> UpdateProjectTask(ProjectTasksDTO projectTask)
        {
            var entity = ConvertTasks.ConvertToEntity(projectTask);
            var response = await projectTaskRepo.UpdateAsync(entity);
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
