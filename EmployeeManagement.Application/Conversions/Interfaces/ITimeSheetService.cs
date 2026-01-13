using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface ITimeSheetService
    {
        Task<Response> CreateAsync(TimeSheetSummaryDTO entity);
        Task<Response> CreateTestAsync(TestTimeSheetSummaryDTO entity);
       // Task<Response> TestCalcBillableAndNonBillableHrs(TestTimeSheetSummaryDTO timesheetDto);
        Task<Response> UpdateAsync(TimeSheetSummaryDTO entity);
        Task<Response> DeleteAsync(TimeSheetSummary entity);
        Task<IEnumerable<TimeSheetSummaryDTO>> GetAllAsync();
        Task<TimeSheetSummaryDTO> FindByIdAsync(int Id);
        Task<TimeSheetSummary> GetByAsync(Expression<Func<TimeSheetSummary, bool>> predicate);
        Task<int> GetTimeSheetsByEmployeeId(DateTime fromDate, DateTime toDate, string EmailAddress);
        Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetOfReportees(string EmailId);
        Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetByEmployeeId(string EmailId);
        Task<IEnumerable<TimeSheetDetails>> GetTimeSheetDetail(TimeSheetSummary summary);
        Task<Response> ApproveRejectTimesheetAsync(TimeSheetSummaryDTO timesheetDto);

        //submit after re-work or re-submit
        Task<Response> UpdateTimeSheetDetail(TimeSheetSummary summary);
        Task<Response> DeleteTimeSheetDetail(TimeSheetSummary summry);
        Task<IEnumerable<TimeSheetCalendar>> GetWeeklyCalendar(int year);
    }
}
