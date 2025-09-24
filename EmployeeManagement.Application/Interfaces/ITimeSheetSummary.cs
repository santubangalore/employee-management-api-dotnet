using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.GenericInterface;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Interfaces
{
    public interface ITimeSheetSummary :IGenericRepoInterface<TimeSheetSummary>
    {
        Task<IEnumerable<TimeSheetSummary>> GetTimeSheetByEmployeeId(int EmployeeId);
        Task<IEnumerable<TimeSheetDetails>> GetTimeSheetDetail(TimeSheetSummary summary);
        //submit after re-work or re-submit
        Task<Response> UpdateTimeSheetDetail(TimeSheetSummary summary);
        Task<Response> DeleteTimeSheetDetail(TimeSheetSummary summry);
        Task<IEnumerable<TimeSheetCalendar>> GetWeeklyCalendar(int year);
    }
}
