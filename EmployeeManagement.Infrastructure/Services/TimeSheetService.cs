using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
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
            var timeSheetDetail = from p in timesheetDto.Details
                                  group p by p.TaskId into g
                                  select new
                                  {
                                      TaskId = g.Key,
                                      Hours = g.Sum(p => p.Hours)
                                  };

            int billableHrs = 0, nonBillableHrs = 0;
            foreach (var taskTotalHrs in timeSheetDetail)
            {
                if (taskTotalHrs.TaskId.StartsWith("TSK"))
                    billableHrs += taskTotalHrs.Hours;
                else
                    nonBillableHrs += taskTotalHrs.Hours;
            }
            return new HourType(billableHrs, nonBillableHrs);
        }

        public async Task<Response> DeleteAsync(TimeSheetSummary timesheet)
        {
           
            var result = await timeSheetRepo.DeleteAsync(timesheet);
            return result;
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
                var employee = await employeeRepo.GetByAsync(_ => _.EmployeeId == TimeSheet.EmployeeId);
                var TimeSheetDto = ConvertTimeSheets.ConvertToDTO(TimeSheet);
                TimeSheetDto.EmpName = employee.EmployeeName;
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
            var employees=await employeeRepo.GetAllAsync();
            if( result is null ){ return null; }
            var TimesheetsDtos=ConvertTimeSheets.ConvertToDTOs(result, employees);

            return TimesheetsDtos;
        }

        public async Task<TimeSheetSummary> GetByAsync(Expression<Func<TimeSheetSummary, bool>> predicate)
        {
            try
            {
                var timeSheet = await timeSheetRepo.GetByAsync(predicate);
                return timeSheet is not null ? timeSheet : null!;
            }
            catch (Exception exception)
            {
                LogException.LogExceptions(exception);
                throw new InvalidOperationException("Error occurred retrieving project");
            }
        }

        public async Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetByEmployeeId(string EmailId)
        {
            try
            {
                if (EmailId ==null||EmailId==string.Empty) { return null; }
                var employee = await employeeRepo.GetByAsync(_ => _.EmailId == EmailId);
                if (employee is null) { return null; }
                List<Employee> employees = new List<Employee> { employee };
                var TimeSheets = await timeSheetRepo.GetAllAsync();
                var filterdByEmployee = TimeSheets.Where(q => q.EmployeeId == employee.EmployeeId);
                var TimeSheetDto = ConvertTimeSheets.ConvertToDTOs(filterdByEmployee, employees);
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

        public async Task<int> GetTimeSheetsByEmployeeId(DateTime fromDate, DateTime toDate, string EmpEmailId)
        {
            try
            {
                var employee = await employeeRepo.GetByAsync(_ => _.EmailId == EmpEmailId);
                var timeSheetObj = await timeSheetRepo.GetSummariesAsync(fromDate, toDate,employee.EmployeeId);
                List<Employee> employees = new List<Employee> { employee };
                if (timeSheetObj == null) { return 0; }

                return timeSheetObj.Count();
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
                var employee = await employeeRepo.GetByAsync(_ => _.EmployeeId==timesheetDto.EmployeeId);
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

        public async Task<Response> ApproveRejectTimesheetAsync(TimeSheetSummaryDTO timesheetDto)
        {
            try
            {
                var employee = await employeeRepo.GetByAsync(_ => _.EmployeeId == timesheetDto.EmployeeId);
                
                if (employee is null) { return null; }
                var timeSheetEntity = await timeSheetRepo.GetByAsync(_ => _.Id == timesheetDto.Id);
                var details = await timeSheetRepo.GetTimeSheetDetail(timeSheetEntity);
                timeSheetEntity.Details = details.ToList();
                timeSheetEntity.ApprovalStatus = timesheetDto.ApprovalStatus;
                if (timeSheetEntity == null) { return null; }
                var response = await timeSheetRepo.UpdateAsync(timeSheetEntity);
                return response;
            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                throw;
            }
        }

        public Task<Response> UpdateTimeSheetDetail(TimeSheetSummary timesheetDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TimeSheetSummaryDTO>> GetTimeSheetOfReportees(string EmailId)
        {
            try
            {
                var result = await timeSheetRepo.GetSummariesForReportees(EmailId);
                if (result is null) return null;
                var employees = await employeeRepo.GetAllAsync();
                var TimeSheetDtos = from res in result
                              join emp in employees on
                              res.EmployeeId equals emp.EmployeeId
                              select new TimeSheetSummaryDTO
                              {
                                  Id = res.Id,
                                  EmployeeId = res.EmployeeId,
                                  StartDate = res.StartDate,
                                  EndDate = res.EndDate,
                                  BillableHours = res.BillableHours,
                                  SubmitDate = res.SubmitDate,
                                  NonBillableHours = res.NonBillableHours,
                                  EmpName = emp.EmployeeName,
                                  ApprovalStatus = res.ApprovalStatus,
                              };
                
                return TimeSheetDtos;
            }
            catch (Exception ex) {
                LogException.LogExceptions(ex);
                throw;
            }
        }
    }
}
