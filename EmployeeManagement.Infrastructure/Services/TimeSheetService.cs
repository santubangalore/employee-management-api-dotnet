using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Shared;
using System.Linq.Expressions;

namespace EmployeeManagement.Infrastructure.Services
{
    internal class TimeSheetService(ITimeSheetSummary timeSheetRepo, IEmployee employeeRepo, IProjectTasks projectTasksRepo) : ITimeSheetService
    {
        public async Task<Response> CreateAsync(TimeSheetSummaryDTO timesheetDto)
        {
            try
            {
                var employee = await employeeRepo.GetByAsync(_ => _.EmailId == timesheetDto.Employee.EmailId);
                if (employee is null) { return new Response(false, "Employee email Id not found"); }
                var billableNonBillabe = await this.CalcBillableAndNonBillableHrs(timesheetDto);
                timesheetDto.BillableHours = billableNonBillabe.Billable;
                timesheetDto.NonBillableHours = billableNonBillabe.NonBillable;
                var timeSheetEntity = ConvertTimeSheets.ConvertToEntity(timesheetDto, employee);
                var response = await timeSheetRepo.CreateAsync(timeSheetEntity);
                return response;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw ;
            }
        }

      
        
        private async Task< HourType > CalcBillableAndNonBillableHrs(TimeSheetSummaryDTO timesheetDto)
        {
            HourType retval=new HourType();

            var timeSheetTasks = timesheetDto.Details.DistinctBy(q=>q.TaskId).ToList();

            var billableTasks = await projectTasksRepo.GetAllAsync();
            var BillablinThisTimeSheet = from billable in billableTasks join detail in timeSheetTasks on billable.Id equals detail.Id
                                  select new { billable.Id ,
                                              detail.Hours,  
                                  }  ;

            var nonBillablinThisTimeSheet = from billable in timeSheetTasks
                                            where !BillablinThisTimeSheet.Any(innerItem => innerItem.Id == billable.Id)
                                            select new
                                            {
                                                billable.Id,
                                                billable.Hours,
                                            };

            var timeSheetDetail = timesheetDto.Details;
           
            int billableAmt=0, nonBillableAmount = 0;
            foreach (var dailyAmount in BillablinThisTimeSheet)
            {
                billableAmt += dailyAmount.Hours;
            }

            nonBillableAmount = nonBillablinThisTimeSheet.Sum(innerItem => innerItem.Hours);
            return new  HourType(billableAmt, nonBillableAmount);
        }

        public Task<Response> DeleteAsync(TimeSheetSummaryDTO timesheetDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteTimeSheetDetail(TimeSheetSummary summry)
        {
            throw new NotImplementedException();
        }

        public async Task<TimeSheetSummaryDTO> FindByIdAsync(int Id)
        {
            try
            {
                if (Id <= 0) { return null; }
                var TimeSheet = await timeSheetRepo.FindByIdAsync(Id);
                var TimeSheetDto = ConvertTimeSheets.ConvertToDTO(TimeSheet);
                return TimeSheetDto;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw;
            }
        }

        public async Task<IEnumerable<TimeSheetSummaryDTO>> GetAllAsync()
        {
            var result=await timeSheetRepo.GetAllAsync();
            if( result is null ){ return null; }
            var TimesheetsDtos=ConvertTimeSheets.ConvertToDTOs(result);
            return TimesheetsDtos;
        }

        public Task<TimeSheetSummaryDTO> GetByAsync(Expression<Func<TimeSheetSummaryDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetByEmployeeId(int EmployeeId)
        {
            try
            {
                if (EmployeeId <= 0) { return null; }
                var TimeSheets = await timeSheetRepo.GetAllAsync();
                var filterdByEmployee = TimeSheets.Where(q => q.EmployeeId == EmployeeId);
                var TimeSheetDto = ConvertTimeSheets.ConvertToDTOs(filterdByEmployee);
                return TimeSheetDto;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw;
            }
        }

        public Task<IEnumerable<TimeSheetDetailsDTO>> GetTimeSheetDetail(TimeSheetSummary timesheetDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetsByEmployeeId(DateTime fromDate, DateTime toDate, string EmpEmailId)
        {
            try
            {
                var employee = await employeeRepo.GetByAsync(_ => _.EmailId == EmpEmailId);
                var timeSheetObj = await timeSheetRepo.GetSummariesAsync(fromDate, toDate,employee.EmployeeId);

                if (timeSheetObj == null) { return null; }
                var convertedDto = ConvertTimeSheets.ConvertToDTOs(timeSheetObj);

                return convertedDto;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex); 
                throw;
            }
        }

        public Task<IEnumerable<TimeSheetCalendar>> GetWeeklyCalendar(int year)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> UpdateAsync(TimeSheetSummaryDTO timesheetDto)
        {
            try
            {
                var employee = await employeeRepo.GetByAsync(_ => _.EmailId == timesheetDto.Employee.EmailId);
                if (employee is null) { return null; }
                var timeSheetEntity = await timeSheetRepo.GetByAsync(_ => _.StartDate == timesheetDto.StartDate && _.EndDate == timesheetDto.EndDate && _.EmployeeId == timesheetDto.EmployeeId);
                if (timeSheetEntity == null) { return null; }
                var response = await timeSheetRepo.UpdateAsync(timeSheetEntity);
                return response;
            }catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw;
            }
        }

        public Task<Response> UpdateTimeSheetDetail(TimeSheetSummary timesheetDto)
        {
            throw new NotImplementedException();
        }
    }
}
