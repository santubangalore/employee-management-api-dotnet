using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
