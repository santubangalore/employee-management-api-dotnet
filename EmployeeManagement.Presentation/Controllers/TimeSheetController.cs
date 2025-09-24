using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetController(ITimeSheetSummary timeSheetInterface, IEmployee employeeInterface) : ControllerBase
    {
        /// <summary>
        /// Gets all timesheets of an employee
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeTimeSheets/{EmployeeId}")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> GetAllAsync(int EmployeeId)
        {
            if(EmployeeId<=0) { return BadRequest("EmployeeId should be greater than 0"); }
            var TimeSheets =await timeSheetInterface.GetAllAsync();
            var TimeSheetDto=ConvertTimeSheets.ConvertToDTO(TimeSheets);
            if (TimeSheetDto == null) { return NotFound(); }
            return Ok(new ResponseMessage("List of timesheets", true, TimeSheetDto));
        }

        /// <summary>
        /// Add to database submitted weekly timesheet
        /// </summary>
        /// <param name="timeSheetDto"></param>
        /// <returns></returns>

        [HttpPost("SubmitEmployeeTimeSheet")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> CreateTimeSheetAsync(TimeSheetSummaryDTO timeSheetDto)
        {
           // if (timeSheetDto.EmployeeId <= 0) { return BadRequest("EmployeeId Id cannot be  0"); }
            var employee = await employeeInterface.GetByAsync(_=>_.EmailId==timeSheetDto.Employee.EmailId);
            if(employee is null) { return NotFound("Employee email Id not found"); }
            var timeSheetObj=  ConvertTimeSheets.ConvertToEntity(timeSheetDto,employee);
            if (timeSheetObj == null) { return BadRequest(); }
            var response = await timeSheetInterface.CreateAsync(timeSheetObj);
            if (!response.flag) { return BadRequest(response); ; }
            return Ok(new ResponseMessage("Timesheet created", true, response));
        }

        /// <summary>
        /// Add to db/update the status of a weekly timesheet
        /// Approval time also same endpoint is used
        /// </summary>
        /// <param name="timeSheetDto"></param>
        /// <returns></returns>
        [HttpPut("UpdateEmployeeTimeSheet")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> UpdateEmployeeTimeSheet(TimeSheetSummaryDTO timeSheetDto)
        {
            var employee = await employeeInterface.GetByAsync(_ => _.EmailId == timeSheetDto.Employee.EmailId);
            if (employee is null) { return NotFound("Employee email Id not found"); }
            var timeSheetObj = ConvertTimeSheets.ConvertToEntity(timeSheetDto, employee);
            if (timeSheetObj == null) { return BadRequest(); }
            var response = await timeSheetInterface.CreateAsync(timeSheetObj);
            if (!response.flag) { return BadRequest(response); ; }
            return Ok(new ResponseMessage("Updated timesheet", true, response));
        }

        [HttpGet("GetWeeklyCalendar/{Year}")]
        public async Task<ActionResult<ResponseMessage>> GetWeeklyCalendarAsync(int Year)
        {
            var calendartObj =await timeSheetInterface.GetWeeklyCalendar(Year);
            if (calendartObj == null) { return NotFound(); }
            
            return Ok(new ResponseMessage("List of timesheets", true, calendartObj));
        }

        [HttpGet("GetTimeSheetforWeek")]
        public async Task<ActionResult<ResponseMessage>> GetTimeSheetforWeek(DateTime fromDate, DateTime toDate,string EmpEmailId)
        {
            var employee = await employeeInterface.GetByAsync(_ => _.EmailId == EmpEmailId);

            var timeSheetObj = await timeSheetInterface.GetByAsync(q=>q.StartDate==fromDate && q.EndDate==toDate && q.EmployeeId==employee.EmployeeId);
            if (timeSheetObj == null) { return Ok(new ResponseMessage("No timesheet found", false, null!)); }

            return Ok(new ResponseMessage("List of timesheets", true, timeSheetObj));
        }
    }
}
