using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveBalanceController(IEmployee employeeRepo,ILeaveBalance leaveBalanceRepo) : ControllerBase
    {
        [HttpGet("GetLeaveBalance/{EmailId}")]
        [Authorize]
        public async Task<ActionResult> GetLeaveBalance(string EmailId)
        {
            var employee=employeeRepo.GetByAsync(_=>_.EmailId==EmailId);
            if (employee == null) { return new NotFoundObjectResult("not found employee with email," + EmailId); }
            var leaveBalance = leaveBalanceRepo.FindByIdAsync(employee.Id);
            if (leaveBalance == null) { return  NotFound("Leave Balance Record not found"); }

            return Ok(new ResponseMessage("Success",true,leaveBalance));
        }

        [HttpGet("GetAllLeaveBalances")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> GetAllLeaveBalance()
        {
            var leaveBalance = await leaveBalanceRepo.GetAllAsync();
            if (leaveBalance == null) { return NotFound("No Leave Balance Record found in DB"); }
            var LEaveBalanceDto = ConvertLeaveBalance.ConvertToDtoList(leaveBalance.ToList());
            return Ok(new ResponseMessage("Success", true, leaveBalance));
        }

        [HttpPost("AddLeaveBalance")]
        [Authorize]
        public async Task<ActionResult> AddLeaveBalance(LeaveBalanceDTO leaveBalance)
        {
            var leavebalance = ConvertLeaveBalance.ConvertToEntity(leaveBalance);
            var response=leaveBalanceRepo.CreateAsync(leavebalance);

            return Ok();
        }

        [HttpPut("UpdateLeaveBalance")]
        [Authorize]
        public async Task<ActionResult> UpdateLeaveBalance(LeaveBalanceDTO leaveBalance)
        {
            return Ok();
        }

        [HttpPost("CarryForwardLeave")]
        [Authorize]
        public async Task<ActionResult> CarryForwardLeave(LeaveBalanceDTO leaveBalance)
        {
            return Ok();
        }
    }
}
