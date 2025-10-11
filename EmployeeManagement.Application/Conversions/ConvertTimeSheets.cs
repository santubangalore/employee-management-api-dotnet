using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

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

        public static List<TimeSheetDetails> ConvertToDetailTimeSheet(List<TimeSheetDetailsDTO> details)
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

        public static TimeSheetSummaryDTO ConvertToDTO(TimeSheetSummary timeSheet)
        {
            if (timeSheet is null) return null;
            var lrq = new TimeSheetSummaryDTO()
            {
                EmployeeId = timeSheet.EmployeeId,
                StartDate = timeSheet.StartDate,
                EndDate = timeSheet.EndDate,
                ProjectId = timeSheet.ProjectId,
                SubmitDate = timeSheet.SubmitDate,
                ApprovalDate = timeSheet.ApprovalDate,
                ApprovedBy = timeSheet.ApprovedBy,
                ApprovalStatus = timeSheet.ApprovalStatus,
                BillableHours  = timeSheet.BillableHours,
                NonBillableHours = timeSheet.NonBillableHours,
                Details = ConvertToDetailTimeSheetDto(timeSheet.Details),
            };
            return lrq;
        }
        private static List<TimeSheetDetailsDTO> ConvertToDetailTimeSheetDto(List<TimeSheetDetails> details)
        {
            var timeSheetDetails = from TimeSheetDetails det in details
                                   select new TimeSheetDetailsDTO()
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
        public static IEnumerable<TimeSheetSummaryDTO> ConvertToDTOs(IEnumerable<TimeSheetSummary> timeSheets,IEnumerable<Employee> employees)
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
