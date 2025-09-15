using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController(ILeaveRequest leaveRequestInterface) : ControllerBase
    {
        [HttpGet("GetLeaveRequest")] 
        public async Task<ActionResult<LeaveRequestDTO>> GetLeaveRequest(int LeaveId)
        {
            var leaveRequest = await leaveRequestInterface.FindByIdAsync(LeaveId);
            if (leaveRequest == null) { return NotFound(); }
            var response = ConvertLeaveRequest.ConvertToDto(leaveRequest);
            if(response == null) { return NotFound(); }
            return Ok(response);
        }

        [HttpGet("GetLeaveRequestByEmpId/{EmployeeId}")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDTO>>> GetLeavesByEmployee(int EmployeeId)
        {
            var leaveRewquests=await leaveRequestInterface.GetByAsync(_=>_.EmployeeId==EmployeeId);
            if (leaveRewquests == null) { return NotFound("No matching Record Found"); }
            var response=ConvertLeaveRequest.ConvertToDto(leaveRewquests);
            return response==null? NotFound() : Ok(response);
        }

        [HttpPost("AddLeaveRequest")]
        public async Task<ActionResult<Response>> AddLeaveRequest(LeaveRequestDTO leaveRequest)
        {
            var entity=ConvertLeaveRequest.ConvertToEntity(leaveRequest);
            var response = await leaveRequestInterface.CreateAsync(entity);
            return response.flag==false? NotFound(response):Ok(response);
        }

        [HttpPut("UpdateLeaveRequest")]
        public async Task<ActionResult<Response>> UpdateLeaveRequest(LeaveRequestDTO leaveRequest)
        {
            var entity = ConvertLeaveRequest.ConvertToEntity(leaveRequest);
            var response = await leaveRequestInterface.UpdateAsync(entity);
            return response.flag == false ? NotFound(response) : Ok(response);
        }
    }
}
