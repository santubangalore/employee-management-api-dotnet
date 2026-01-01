using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertProject
    {
        public static Project ConvertToEntity(ProjectDTO projectDto)
        {
            if (projectDto is null) return null;
            var lrq = new Project()
            {
              ProjectId=projectDto.ProjectId,
              ProjectName=projectDto.ProjectName,
              ClientName=projectDto.ClientName,
              ContactNo=projectDto.ContactNo,
              ContactPerson=projectDto.ContactPerson,
              EmailId=projectDto.EmailId,
              LeadByEmpId=projectDto.LeadByEmpId,
              StartDate=projectDto.StartDate,
              ProjectStatus=projectDto.ProjectStatus
            };
            return lrq;
        }

        public static ProjectDTO ConvertToDto(Project prj)
        {
            if (prj is null) return null;
            return new ProjectDTO()
            {
                ProjectId = prj.ProjectId,
                ProjectName = prj.ProjectName,
                ClientName = prj.ClientName,
                ContactNo = prj.ContactNo,
                ContactPerson = prj.ContactPerson,
                EmailId = prj.EmailId,
                LeadByEmpId = prj.LeadByEmpId,
                StartDate = prj.StartDate,
                ProjectStatus=prj.ProjectStatus!,
                ProjectTasks = getProjTaskDto(prj.ProjectTasks, prj.ProjectId)
            };
        }
       
        private static List<ProjectTasksDTO>  getProjTaskDto(List<ProjectTasks> tasks, int projId)
        {
            List<ProjectTasksDTO> projectTasksDTOs = new List<ProjectTasksDTO>();
            foreach (ProjectTasks task in tasks) {
                projectTasksDTOs.Add(new ProjectTasksDTO()
                {       Id=task.Id,
                        ProjectId=projId, 
                        TaskName=task.TaskName,  
                        TaskDescription=task.TaskDescription,
                });
            }
            return projectTasksDTOs;

        }

        public static List<ProjectDTO> ConvertToDtoList(IEnumerable<Project> projects)
        {
            if (projects.Count() <= 0) return null;
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
            foreach (var lrq in projects)
            {
                projectDTOs.Add(ConvertToDto(lrq));
            }
            return projectDTOs;
        }
    }
}
