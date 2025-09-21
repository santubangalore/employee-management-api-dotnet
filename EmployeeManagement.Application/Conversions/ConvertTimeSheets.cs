using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertTimeSheets
    {
        public static TimeSheetSummary ConvertToEntity(TimeSheetSummaryDTO timeSheet)
        {
            if (timeSheet is null) return null;
            var lrq = new TimeSheetSummary()
            {
                EmployeeId = timeSheet.EmployeeId,
                StartDate = timeSheet.StartDate,
                EndDate = timeSheet.EndDate,
                ProjectId = timeSheet.ProjectId,
                SubmitDate = timeSheet.SubmitDate,
                ApprovalDate = timeSheet.ApprovalDate,
                ApprovedBy = timeSheet.ApprovedBy,
                ApprovalStatus=timeSheet.ApprovalStatus,
                Details = ConvertToDetailTimeSheet(timeSheet.Details),
            };
            return lrq;
        }

        private static List<TimeSheetDetails> ConvertToDetailTimeSheet(List<TimeSheetDetailsDTO> details)
        {
            var timeSheetDetails= from TimeSheetDetails det in details
                                  select new TimeSheetDetails()
                                  {
                                    TimesheetSummaryId = det.TimesheetSummaryId,
                                    Date = det.Date,
                                    TaskId = det.TaskId,
                                    AttStatus = det.AttStatus,
                                    Id = det.Id,
                                  };
            return timeSheetDetails.ToList();
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
                                       AttStatus = det.AttStatus,
                                       Id = det.Id,
                                   };
            return timeSheetDetails.ToList();
        }
        public static IEnumerable<TimeSheetSummaryDTO> ConvertToDTO(IEnumerable<TimeSheetSummary> timeSheets)
        {
            if (timeSheets is null|| timeSheets.Count()==0) return null;
            var timeSheetDtos = from TimeSheetSummary det in timeSheets
                                   select new TimeSheetSummaryDTO()
                                   {
                                       EmployeeId = det.EmployeeId,
                                       StartDate = det.StartDate,
                                       EndDate = det.EndDate,
                                       ProjectId = det.ProjectId,
                                       SubmitDate = det.SubmitDate,
                                       ApprovalDate = det.ApprovalDate,
                                       ApprovedBy = det.ApprovedBy,
                                       ApprovalStatus = det.ApprovalStatus,
                                       Details = ConvertToDetailTimeSheetDto(det.Details),
                                       Id = det.Id,
                                   };
            return timeSheetDtos.ToList();
        }

    }
}
