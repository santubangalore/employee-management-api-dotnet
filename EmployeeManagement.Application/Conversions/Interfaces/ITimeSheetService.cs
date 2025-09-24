using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeeManagement.Application.Conversions.Interfaces
{
    public interface ITimeSheetService
    {
        Task<Response> CreateAsync(TimeSheetSummaryDTO entity);
        Task<Response> UpdateAsync(TimeSheetSummaryDTO entity);
        Task<Response> DeleteAsync(TimeSheetSummaryDTO entity);
        Task<IEnumerable<TimeSheetSummaryDTO>> GetAllAsync();
        Task<TimeSheetSummaryDTO> FindByIdAsync(int Id);
        Task<TimeSheetSummaryDTO> GetByAsync(Expression<Func<TimeSheetSummaryDTO, bool>> predicate);
        Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetsByEmployeeId(DateTime fromDate, DateTime toDate, string EmailAddress);
        Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetByEmployeeId(int EmployeeId);
        Task<IEnumerable<TimeSheetDetailsDTO>> GetTimeSheetDetail(TimeSheetSummary summary);
        //submit after re-work or re-submit
        Task<Response> UpdateTimeSheetDetail(TimeSheetSummary summary);
        Task<Response> DeleteTimeSheetDetail(TimeSheetSummary summry);
        Task<IEnumerable<TimeSheetCalendar>> GetWeeklyCalendar(int year);
    }
}
