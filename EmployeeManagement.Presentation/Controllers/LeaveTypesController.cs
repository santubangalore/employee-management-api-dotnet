using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController(ILeaveTypes leaveTypesInterface) : ControllerBase
    {
        [HttpGet("GetLeaveTypes")]
        public async Task<ActionResult<IEnumerable<LeaveTypesDTO>>> GetLeaveTypes()
        {
            var result=await leaveTypesInterface.GetAllAsync();
            var leaveTypesDto = ConvertLeaveType.ConvertToDtoList(result);
            if (leaveTypesDto != null) { return NotFound("No records found in Db!"); }
            return Ok(leaveTypesDto);
        }

        [HttpGet("GetLeavetypeById/{Id}")]
        public async Task<ActionResult<LeaveTypesDTO>> GetLeaveType(int Id)
        {
            var leaveType = await leaveTypesInterface.FindByIdAsync(Id);
            if (leaveType is null)
                return NotFound("Leave type not found");
            var leave = ConvertLeaveType.ConvertToDto(leaveType);
            return leave is not null ? Ok(leave) : NotFound("Error converting Leave type");
        }

        [HttpPost("CreateLeaveType")]
        public async Task<ActionResult<Response>> CreateLeaveType(LeaveTypesDTO leaveType)
        {
            var entity = ConvertLeaveType.ConvertToEntity(leaveType);
            var response = await leaveTypesInterface.CreateAsync(entity);
            return response.flag == false ? NotFound(response) : Ok(response);

        }
    }
}
