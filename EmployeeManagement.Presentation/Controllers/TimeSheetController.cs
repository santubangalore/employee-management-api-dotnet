using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Conversions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetController(ITimeSheetSummary timeSheetInterface) : ControllerBase
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
            if (timeSheetDto.EmployeeId <= 0) { return BadRequest("EmployeeId Id cannot be  0"); }
            var timeSheetObj=  ConvertTimeSheets.ConvertToEntity(timeSheetDto);
            if (timeSheetObj == null) { return BadRequest(); }
            var response = await timeSheetInterface.CreateAsync(timeSheetObj);
            if (!response.flag) { return BadRequest(response); ; }
            return Ok(new ResponseMessage("List of timesheets", true, response));
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
            if (timeSheetDto.EmployeeId <= 0) { return BadRequest("EmployeeId Id cannot be  0"); }
            var timeSheetObj = ConvertTimeSheets.ConvertToEntity(timeSheetDto);
            if (timeSheetObj == null) { return BadRequest(); }
            var response = await timeSheetInterface.CreateAsync(timeSheetObj);
            if (!response.flag) { return BadRequest(response); ; }
            return Ok(new ResponseMessage("List of timesheets", true, response));
        }

        [HttpGet("GetWeeklyCalendar/{Year}")]
        public async Task<ActionResult<ResponseMessage>> GetWeeklyCalendarAsync(int Year)
        {
            var calendartObj =await timeSheetInterface.GetWeeklyCalendar(Year);
            if (calendartObj == null) { return NotFound(); }
            
            return Ok(new ResponseMessage("List of timesheets", true, calendartObj));
        }

        [HttpGet("GetTimeSheetforWeek")]
        public async Task<ActionResult<ResponseMessage>> GetTimeSheetforWeek(DateTime fromDate, DateTime toDate)
        {
            var timeSheetObj = await timeSheetInterface.GetByAsync(q=>q.StartDate==fromDate && q.EndDate==toDate);
            if (timeSheetObj == null) { return Ok(new ResponseMessage("No timesheet found", false, null!)); }

            return Ok(new ResponseMessage("List of timesheets", true, timeSheetObj));
        }
    }
}
