using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetController(ITimeSheetService timeSheetService) : ControllerBase
    {
        /// <summary>
        /// Gets all timesheets of all employees
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        [HttpGet("GetAllTimeSheets")]
        public async Task<ActionResult<IEnumerable<TimeSheetSummaryDTO>>> GetAll() 
        {
            var response = timeSheetService.GetAllAsync();
            if (response == null) { return NotFound("No TimeSheet Found"); }
            return Ok(new ResponseMessage("List of timesheets", true, response));
        }
        
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
            var response= timeSheetService.GetTimeSheetByEmployeeId(EmployeeId);

            return Ok(new ResponseMessage("List of timesheets", true, response));
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
            var response = await timeSheetService.CreateAsync(timeSheetDto);
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
            var response=await timeSheetService.UpdateAsync(timeSheetDto);
            return response.flag? Ok(new ResponseMessage("Updated timesheet", true, response)): BadRequest(new ResponseMessage("Failed to update",false, response));
        }

        [HttpGet("GetWeeklyCalendar/{Year}")]
        public async Task<ActionResult<ResponseMessage>> GetWeeklyCalendarAsync(int Year)
        {
           throw new NotImplementedException();
        }

        [HttpGet("GetTimeSheetforWeek")]
        public async Task<ActionResult<ResponseMessage>> GetTimeSheetforWeek(DateTime fromDate, DateTime toDate,string EmpEmailId)
        {
            var response=await timeSheetService.GetTimeSheetsByEmployeeId(fromDate, toDate, EmpEmailId);
            if(response is null) { return Ok( new ResponseMessage("No Data Found",true,response)); }
            return Ok(new ResponseMessage("List of timesheets", true, response));
        }
    }
}
