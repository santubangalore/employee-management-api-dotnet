using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.models;
using System.Collections.Generic;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertTimeSheets
    {
        public static TimeSheetSummary ConvertToEntity(TimeSheetSummaryDTO timeSheet, Employee employee)
        {
            try
            {
                if (timeSheet is null) return null;
                var tssumm = new TimeSheetSummary()
                {
                    Id  =timeSheet.Id,
                    EmployeeId = employee.EmployeeId,
                    StartDate = timeSheet.StartDate,
                    EndDate = timeSheet.EndDate,
                    ProjectId = timeSheet.ProjectId,
                    SubmitDate = timeSheet.SubmitDate,
                    ApprovalDate = timeSheet.ApprovalDate,
                    ApprovedBy = timeSheet.ApprovedBy,
                    ApprovalStatus = timeSheet.ApprovalStatus,
                    BillableHours = timeSheet.BillableHours,
                    NonBillableHours = timeSheet.NonBillableHours,
                    Details = ConvertToDetailTimeSheet(timeSheet.Details),
                };
                return tssumm;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public static List<TimeSheetDetails> ConvertToDetailTimeSheet(List<TimeSheetDetailsDto> details)
        {
            try
            {
                var list = new List<TimeSheetDetails>();
                foreach (var detail in details)
                {
                    list.Add(new TimeSheetDetails()
                    {
                         Id = detail.Id,
                         Date = detail.Date,
                         AttStatus = detail.AttStatus,
                         Hours = detail.Hours,
                         TaskId = detail.TaskId,
                         TimesheetSummaryId = detail.TimesheetSummaryId,   
                    });
                }
     
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static TimeSheetSummaryDTO ConvertToDTO(TimeSheetSummary timeSheet,List<ProjectTasksResult> tasks, string ProjectName)
        {
            if (timeSheet is null) return null;
            var lrq = new TimeSheetSummaryDTO()
            {
                Id=timeSheet.Id,
                EmployeeId = timeSheet.EmployeeId,
                StartDate = timeSheet.StartDate,
                EndDate = timeSheet.EndDate,
                ProjectId = timeSheet.ProjectId,
                ProjectName=ProjectName,
                SubmitDate = timeSheet.SubmitDate,
                ApprovalDate = timeSheet.ApprovalDate,
                ApprovedBy = timeSheet.ApprovedBy,
                ApprovalStatus = timeSheet.ApprovalStatus,
                BillableHours  = timeSheet.BillableHours,
                NonBillableHours = timeSheet.NonBillableHours,
                Details = ConvertToDetailTimeSheetDto(timeSheet.Details,  tasks),
            };
            return lrq;
        }
        private static List<TimeSheetDetailsDto> ConvertToDetailTimeSheetDto(List<TimeSheetDetails> details,  List<ProjectTasksResult> tasks)
        {
            var timeSheetDetails = from TimeSheetDetails det in details
                                   join task in tasks on det.TaskId equals task.TaskId
                                   select new TimeSheetDetailsDto()
                                   {
                                       TimesheetSummaryId = det.TimesheetSummaryId,
                                       Date = det.Date,
                                       TaskId = det.TaskId,
                                       TaskName=task.TaskName,
                                       Hours = det.Hours,
                                       AttStatus = det.AttStatus,
                                       Id = det.Id,
                                   };
            return timeSheetDetails.ToList();
        }

        private static List<TimeSheetDetailsDto> ConvertToDetailTimeSheetDto(List<TimeSheetDetails> details)
        {
            var timeSheetDetails = from TimeSheetDetails det in details
                                   select new TimeSheetDetailsDto()
                                   {
                                       TimesheetSummaryId = det.TimesheetSummaryId,
                                       Date = det.Date,
                                       TaskId = det.TaskId,
                                       Hours = det.Hours,
                                       AttStatus = det.AttStatus,
                                       Id = det.Id,
                                   };
            return timeSheetDetails.ToList();
        }
        public static IEnumerable<TimeSheetSummaryDTO> ConvertToDTOs(IEnumerable<TimeSheetSummary> timeSheets, 
            IEnumerable<Employee> employees)
        {
            if (timeSheets is null|| timeSheets.Count()==0) return null;
            List<TimeSheetSummaryDTO> timeSheetSummaryDTOs = new List<TimeSheetSummaryDTO>();

            foreach (var timeSheetSummary in timeSheets) {
                var employee=employees.SingleOrDefault(q=>q.EmployeeId==timeSheetSummary.EmployeeId);
                var summary= new TimeSheetSummaryDTO()
                {
                    EmployeeId = timeSheetSummary.EmployeeId,
                    StartDate = timeSheetSummary.StartDate,
                    EndDate = timeSheetSummary.EndDate,
                    ProjectId = timeSheetSummary.ProjectId,
                    SubmitDate = timeSheetSummary.SubmitDate,
                    EmpName = employee?.EmployeeName!,
                    ApprovalDate = timeSheetSummary.ApprovalDate,
                    ApprovedBy = timeSheetSummary.ApprovedBy,
                    ApprovalStatus = timeSheetSummary.ApprovalStatus,
                    BillableHours = timeSheetSummary.BillableHours,
                    NonBillableHours = timeSheetSummary.NonBillableHours,
                    Details = ConvertToDetailTimeSheetDto(timeSheetSummary.Details),
                    Id = timeSheetSummary.Id,
                };
                timeSheetSummaryDTOs.Add(summary);
            }
            return timeSheetSummaryDTOs.ToList();
        }

    }
}
