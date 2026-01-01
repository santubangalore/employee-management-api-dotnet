using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.models;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.Data.SqlClient;
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

        public async Task<Response> DeleteAsync(TimeSheetSummary entity)
        {
            try
            {
                var timesheet = await FindByIdAsync(entity.Id);
                if (timesheet == null)
                {
                    return new Response(false, "timesheet not found");
                }
                dbcontext.TimeSheetsSummary.Remove(timesheet);
                await dbcontext.SaveChangesAsync();
                return new Response(true, "Timesheet deleted");
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                return new Response(false, "Error happened while deleting Timesheet");
            }
        }

        public async Task<Response> DeleteTimeSheetDetail(TimeSheetSummary summry)
        {
            try { 
                foreach (TimeSheetDetails details in summry.Details) {
                    dbcontext.Entry(details).State=EntityState.Detached;
                    var result = dbcontext.TimeSheetDetails.Remove(details);
                }
                dbcontext.SaveChanges(true);
                return new Response(true, "success");
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<TimeSheetSummary> FindByIdAsync(int Id)
        {
            var timeSheetObj = await dbcontext.TimeSheetsSummary.FindAsync(Id);
            if (timeSheetObj== null) { return null; }
           
            return timeSheetObj!;
        }

        public async Task<IEnumerable<TimeSheetSummary>> GetSummariesAsync(DateTime startDate, DateTime endDate, int EmployeeId)
        {
            var summaryExists = await dbcontext.TimeSheetsSummary.Where(q => q.EmployeeId == EmployeeId && q.StartDate == startDate && q.EndDate == endDate).ToListAsync();
            if (!summaryExists.Any()) { return null; }
            return summaryExists.ToList();
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
                var timesheet =  dbcontext.TimeSheetsSummary.Where(q => q.Id == entity.Id).Include(q => q.Details).SingleOrDefault();
                if (timesheet is null)
                {
                    return new Response(false, "Timesheet invalid");
                }

                await this.DeleteTimeSheetDetail(timesheet);
                dbcontext.Entry(timesheet).State = EntityState.Detached;
                dbcontext.TimeSheetsSummary.Update(entity);
                
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

        public async Task<IEnumerable<TimeSheetSummary>> GetSummariesForReportees(string EmailId)
        {
            try
            {
                var manager = dbcontext.Employees.Where(q=>q.EmailId==EmailId).FirstOrDefault();
                if (manager is null) return null;
                var employees = dbcontext.Employees.Where(q=>q.ReportingTo==manager!.EmployeeId);

                var affectedRows = from timesheet in dbcontext.TimeSheetsSummary
                                   join employee in employees on
                                   timesheet.EmployeeId equals employee.EmployeeId  
                                                       
                                   select new TimeSheetSummary
                                   {
                                       Id= timesheet.Id,
                                       EmployeeId = employee.EmployeeId,
                                       StartDate = timesheet.StartDate,
                                       EndDate = timesheet.EndDate,
                                       ApprovalDate = timesheet.ApprovalDate,
                                       ApprovalStatus = timesheet.ApprovalStatus,
                                       SubmitDate = timesheet.SubmitDate,
                                       BillableHours= timesheet.BillableHours,
                                       NonBillableHours= timesheet.NonBillableHours,

                                   };
                                    
                return await affectedRows.ToListAsync();
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw;
            }
        }
    }
}
