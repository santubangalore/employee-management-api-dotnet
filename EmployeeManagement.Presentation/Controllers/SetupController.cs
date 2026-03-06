using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController (ISetup setupInterface) : ControllerBase
    {
        [HttpPost("SetupAdmin")]
        public async Task<ActionResult> SetupAdmin(SetupDto setupObj)
        {
            if (setupObj.AdminUserId.Trim() == "" | setupObj.SuperAdminUserId == null|setupObj.AdminPassword=="") { return BadRequest(setupObj); }
            if (!ModelState.IsValid) { return BadRequest("Invalid Admin entity"); }

            var empl = ConvertSetup.ConvertDtoToEntity(setupObj);
            var res = await setupInterface.CreateAdmin(empl.Item1, empl.Item2);
            return (res.flag) ? Ok(new ResponseMessage("success",true,res)) : throw new Exception(res.Message);
        }

        [HttpPost("DoLogin")]
        public async Task<ActionResult<ResponseMessage>> DoLogin(LoginDTO loginDTO)
        {
            if (loginDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await setupInterface.LoginAsync(loginDTO);
            if (result is null) return NotFound(new ResponseMessage("Invalid credentials", false, null!));
            return Ok(new ResponseMessage("Login Success", true, result!));
        }

        [HttpGet("GetAdmin")]
        public async Task<ActionResult> GetAdminDetails()
        {

            return Ok("");
        }
    }
}
