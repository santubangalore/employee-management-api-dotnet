using EmployeeManagement.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveBalanceController : ControllerBase
    {
        [HttpGet("GetLeaveBalance/{EmployeeId}")]
        [Authorize]
        public async Task<ActionResult> GetLeaveBalance(int EmployeeId)
        {
            return Ok();
        }

        [HttpGet("GetAllLeaveBalances")]
        [Authorize]
        public async Task<ActionResult> GetAllLeaveBalance()
        {
            return Ok();
        }

        [HttpPost("AddLeaveBalance")]
        [Authorize]
        public async Task<ActionResult> AddLeaveBalance(LeaveBalanceDTO leaveBalance)
        {
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
