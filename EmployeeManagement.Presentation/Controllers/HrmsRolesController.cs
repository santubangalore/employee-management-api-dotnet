using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrmsRolesController (IHrmsRoles rolesInterface) : ControllerBase
    {
        [HttpGet ("GetHrmsRoles")]
        public async Task<ActionResult<ResponseMessage>> GetParentDeprtments()
        {
            var result = await rolesInterface.GetHrmsRoles();
            return result is null ? NotFound(new ResponseMessage("Not Found", false, result!)) : Ok(new ResponseMessage("Hrms Roles", true, result));
        }

        [HttpPost("CreateHrmsRole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseMessage>> CreateHrmsRole(HrmsRoleDTO hrmsRoleDto)
        {
            if (!ModelState.IsValid) { return BadRequest("Invalid Data"); }

            var hrmsRole = new HrmsRoles
            {
                RoleName = hrmsRoleDto.RoleName
            };
            var response = await rolesInterface.CreateHrmsRole(hrmsRole);
            return response ? Ok(new ResponseMessage("Hrms Role created", true, null)) : BadRequest(new ResponseMessage("Unable to create Hrms role", false, null));
        }
    }
}
