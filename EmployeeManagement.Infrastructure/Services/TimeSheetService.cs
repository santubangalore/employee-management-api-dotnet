using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    internal class TimeSheetService(ITimeSheetSummary timeSheetRepository) : ITimeSheetService
    {
        public Task<Response> CreateAsync(TimeSheetSummaryDTO timesheetDto)
        {

            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(TimeSheetSummaryDTO timesheetDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteTimeSheetDetail(TimeSheetSummary summry)
        {
            throw new NotImplementedException();
        }

        public Task<TimeSheetSummaryDTO> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeSheetSummaryDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TimeSheetSummaryDTO> GetByAsync(Expression<Func<TimeSheetSummaryDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetByEmployeeId(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeSheetDetailsDTO>> GetTimeSheetDetail(TimeSheetSummary timesheetDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetsByEmployeeId(DateTime fromDate, DateTime toDate, int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeSheetCalendar>> GetWeeklyCalendar(int year)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(TimeSheetSummaryDTO timesheetDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateTimeSheetDetail(TimeSheetSummary timesheetDto)
        {
            throw new NotImplementedException();
        }
    }
}
