using EmployeeManagement.Application;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (ILogin loginInterface, IMailService mailService) : ControllerBase
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

        [HttpGet("ForgotPassword/{EmailId}")]
        public async Task<IActionResult> ForgotPassword(string EmailId)
        {
            var res=await mailService.SendEmail("Admin", EmailId);
            return Ok(new ResponseMessage("Success", res, "email sent"));
        }
        
        [HttpGet("GetRole/{EmailId}")]
        [Authorize]
        public async Task<ActionResult> IsAdmin(string EmailId)
        {
            if (EmailId.Trim() =="" ) return BadRequest();

            var result = await loginInterface.IsAdmin(EmailId);
            if (result==null) return Ok(new ResponseMessage("Not An Admin", false, result!));
            return Ok(new ResponseMessage("Is an Admin",true, result));
        }

        [HttpGet("GetAboutInfo")]
        [Authorize]
        public async Task<ActionResult> GetAboutInfo()
        {
            string result = " Santu Ghosh, Bangalore, Karnataka, IND";
            return Ok(new ResponseMessage(" Santu Ghosh, Bangalore, Karnataka, IND", false, result!));
        }
    }
}
