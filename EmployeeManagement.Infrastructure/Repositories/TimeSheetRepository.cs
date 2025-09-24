using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class TimeSheetRepository(EmployeeMgmtContext dbcontext) : ITimeSheetSummary
    {
        public async Task<Response> CreateAsync(TimeSheetSummary entity)
        {
            try
            {
                int employeeId = entity.EmployeeId;
                DateTime fromDate, toDate;
                fromDate = entity.StartDate;
                toDate = entity.EndDate;
                var summaryExists = dbcontext.TimeSheetsSummary.Where(q => q.EmployeeId == employeeId && q.StartDate == fromDate && q.EndDate == toDate);
                if (summaryExists.Any()) { return new Response(false, "Timesheet exists"); }
                var result = await dbcontext.TimeSheetsSummary.AddAsync(entity);
                dbcontext.SaveChanges();
           
                return new Response(true, "Timesheet saved");
            }catch (Exception ex) 
            { 
                return new Response(false, ex.InnerException.ToString());
            }
        }

        public Task<Response> DeleteAsync(TimeSheetSummary entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteTimeSheetDetail(TimeSheetSummary summry)
        {
            throw new NotImplementedException();
        }

        public Task<TimeSheetSummary> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeSheetSummary>> GetAllAsync()
        {
            try
            {
                var timeSheetSummary = await dbcontext.TimeSheetsSummary.Include(q => q.Details).ToListAsync();
                if (!timeSheetSummary.Any())
                    return null;
                return timeSheetSummary;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error in GetAllAsync,TimeSheetRepository {ex.Message}");
            }
     
        }

        public async Task<TimeSheetSummary> GetByAsync(Expression<Func<TimeSheetSummary, bool>> predicate)
        {
            try
            {
                var timesheetSummary = await dbcontext.TimeSheetsSummary.Where(predicate).FirstOrDefaultAsync();
                return timesheetSummary is not null ? timesheetSummary! : null!;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error in GetByAsync,TimeSheetRepository {ex.Message}");
            }
        }

        public async Task<IEnumerable<TimeSheetSummary>> GetTimeSheetByEmployeeId(int EmployeeId)
        {
            try
            {
                var timesheetSummary = await dbcontext.TimeSheetsSummary.Where(q => q.EmployeeId == EmployeeId).Include(q => q.Details).ToListAsync();
                return timesheetSummary is null? null!: timesheetSummary;

            }catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error in GetTimeSheetByEmployeeId,TimeSheetRepository {ex.Message}");
            }
        }

        public async Task<IEnumerable<TimeSheetDetails>> GetTimeSheetDetail(TimeSheetSummary summary)
        {
          try {             
                var details= await dbcontext.TimeSheetDetails.Where(q=>q.TimesheetSummaryId==summary.Id).ToListAsync();
                return details == null ? null! : details!;
            }catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error in GetTimeSheetDetail,TimeSheetRepository {ex.Message}");
            }
        }

        public async Task<IEnumerable<TimeSheetCalendar>> GetWeeklyCalendar(int year)
        {
            try
            {
                var weeklyCalendar = new TimeSheetCalendar();
                var jan1 = new DateTime(DateTime.Today.Year, 1, 1);
                //beware different cultures, see other answers
                var startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));
                var weeks =
                    Enumerable
                        .Range(0, 54)
                        .Select(i => new
                        {
                            WeekStart = startOfFirstWeek.AddDays(i * 7)
                        })
                        .TakeWhile(x => x.WeekStart.Year <= jan1.Year)
                        .Select(x => new
                        {
                            WeekStart = x.WeekStart,
                            WeekFinish = x.WeekStart.AddDays(4)
                        })
                        .SkipWhile(x => x.WeekFinish < jan1.AddDays(1))
                        .Select((x, i) => new TimeSheetCalendar
                        {
                            WeekStart = DateOnly.FromDateTime(x.WeekStart),
                            WeekFinish = DateOnly.FromDateTime(x.WeekFinish),
                            WeekNum = i + 1
                        });

                return weeks;

            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw new Exception($"Error in GetWeeklyCalendar,TimeSheetRepository {ex.Message}");
            }
        }

        public async Task<Response> UpdateAsync(TimeSheetSummary entity)
        {
            try
            { 
                var timesheetDetails=entity.Details;

                var summary = await FindByIdAsync(entity.Id);
                if (summary is null)
                {
                    return new Response(false, "Timesheet summary not found");
                }
                dbcontext.Entry(summary).State = EntityState.Detached;
                dbcontext.TimeSheetsSummary.Update(entity);
                // no need to update child records.
               // var details = dbcontext.TimeSheetDetails.UpdateRange(timesheetDetails);
                
                await dbcontext.SaveChangesAsync();
                return new Response(true, "Timesheet  updated");

            }
            catch (Exception ex) { 
                LogException.LogExceptions(ex);
                throw;
            }
        }

        public Task<Response> UpdateTimeSheetDetail(TimeSheetSummary summary)
        {
            throw new NotImplementedException();
        }
    }
}
