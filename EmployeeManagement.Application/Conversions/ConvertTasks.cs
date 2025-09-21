using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertTasks
    {
        public static ProjectTasks ConvertToEntity(ProjectTasksDTO prjTaskDto)
        {
            if (prjTaskDto is null) return null;
            var prj = new ProjectTasks()
            {
                ProjectId = prjTaskDto.ProjectId,
                TaskName = prjTaskDto.TaskName,
                TaskDescription = prjTaskDto.TaskDescription,
            };
            return prj;
        }

        public static ProjectTasksDTO ConvertToDto(ProjectTasks prjTask, List<Project> projects)
        {
            if (prjTask is null) return null;
            var projDto = projects.Where(q => q.ProjectId == prjTask.ProjectId).SingleOrDefault();
            return new ProjectTasksDTO()
            {
                ProjectId = projDto.ProjectId,
                TaskDescription = prjTask.TaskDescription,
                TaskName = prjTask.TaskName
            };
        }

        public static IEnumerable<ProjectTasksDTO> ConvertToDtoList(IEnumerable<ProjectTasks> prjTask, IEnumerable<Project> projects)
        {
            if (prjTask is null) return null;
            var result = from p in prjTask
                         join proj in projects
                        on p.ProjectId equals proj.ProjectId
                         select new ProjectTasksDTO()
                         {
                             ProjectId = p.ProjectId,
                             TaskDescription = p.TaskDescription,
                             TaskName = p.TaskName,
                         };
            return result;
        }
    }
}
