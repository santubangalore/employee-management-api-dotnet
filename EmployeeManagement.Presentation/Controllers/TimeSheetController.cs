using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions.Interfaces;
using EmployeeManagement.Application.DTOs;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<TimeSheetSummaryDTO>>> GetAll() 
        {
            var response =await timeSheetService.GetAllAsync();
            if (response == null) { return NotFound("No TimeSheet Found"); }
            return Ok(new ResponseMessage("List of timesheets", true, response));
        }
        
        /// <summary>
        /// Gets all timesheets of an employee
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeTimeSheets/{EmailId}")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> GetAllAsync(string EmailId)
        {
            var response= await timeSheetService.GetTimeSheetByEmployeeId(EmailId);
            if (response is null) return NotFound(new ResponseMessage("Not found", false, null));
            return Ok(new ResponseMessage("List of timesheets", true, response));
        }

        /// <summary>
        /// Gets all timesheets of an employee
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        [HttpGet("GetReporteesTimeSheets/{EmailId}")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> GetReporteesTimeSheets(string EmailId)
        {
            if (EmailId.Trim()=="" | EmailId==string.Empty) { return BadRequest("EmailId should not be empty"); }

            var response = await timeSheetService.GetTimeSheetOfReportees(EmailId);

            return response==null? NotFound(new ResponseMessage("No timesheet found",false,null!)): Ok(new ResponseMessage("List of timesheets", true, response));
        }

        /// <summary>
        /// Check if employee has submitted timesheet for this week already.
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="EmpEmailId"></param>
        /// <returns></returns>

        [HttpGet("GetTimeSheetforWeek")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> GetTimeSheetforWeek(DateTime fromDate, DateTime toDate, string EmpEmailId)
        {
            var response = await timeSheetService.GetTimeSheetsByEmployeeId(fromDate, toDate, EmpEmailId);
            if (response == 0) { return Ok(new ResponseMessage("No Data Found", true, response)); }
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
        [HttpPut("ApproveRejectTimeSheet")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> ApproveRejectTimeSheet(TimeSheetSummaryDTO timeSheetDto)
        {
            var response=await timeSheetService.ApproveRejectTimesheetAsync(timeSheetDto);
            return response.flag? Ok(new ResponseMessage("Updated timesheet", true, response)): BadRequest(new ResponseMessage("Failed to update",false, response));
        }

        [HttpDelete("DeleteTimesheet/{Id}")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> DeleteTimeSheet(int Id)
        {
            var timeSheet= await timeSheetService.GetByAsync(_=>_.Id==Id);
            if (timeSheet == null) return NotFound("TimeSheet Not Found");
            var response=await timeSheetService.DeleteAsync(timeSheet!);

            return response.flag? Ok(new ResponseMessage("Deleted",true,response)):BadRequest(new ResponseMessage("",false,response));
        }
    }
}
