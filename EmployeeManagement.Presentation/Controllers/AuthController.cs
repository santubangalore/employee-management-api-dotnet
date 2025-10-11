using EmployeeManagement.Application;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (ILogin loginInterface) : ControllerBase
    {
        [HttpPost("DoLogin")]
        public async Task<ActionResult<ResponseMessage>> DoLogin(LoginDTO loginDTO)
        {
            if (loginDTO == null || !ModelState.IsValid) {
                return BadRequest();
            }
            var result = await loginInterface.LoginAsync(loginDTO);
            if(result is null) return NotFound(new ResponseMessage("Invalid credentials",false,null!));
            return Ok(new ResponseMessage("Login Success",true,result!));
        }

        [HttpGet("IsAdmin/{EmailId}")]
        [Authorize]
        public async Task<ActionResult> IsAdmin(string EmailId)
        {
            if (EmailId.Trim() =="" ) return BadRequest();

            var result = await loginInterface.IsAdmin(EmailId);
            if (result==null) return Ok(new ResponseMessage("Not An Admin", false, result));
            return Ok(new ResponseMessage("Is an Admin",true, result));
        }
    }
}
