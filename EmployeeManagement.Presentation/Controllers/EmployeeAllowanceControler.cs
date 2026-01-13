using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAllowanceController (IAllowanceTypes IallowanceTypes) : ControllerBase
    {
        [HttpGet("GetAllAllowanceTypes")]
        public async Task<ActionResult> GetAllAllowanceTypes()
        {
            var result=await IallowanceTypes.GetAllAsync();
            if (result == null) return new EmptyResult();
            var AllowanceDto = ConvertAllowance.ConvertAllowanceToDtoList(result.ToList());
            return Ok(new ResponseMessage("success",true,AllowanceDto));
        }

        [HttpPost("CreateAllowanceType")]
        public async Task<ActionResult> CreateAllowancetype(AllowancesTypesDto allowancesType)
        {
            var allowacTypeEntity= ConvertAllowance.ConvertAllowancesTypesToEntity(allowancesType);
            var result=await IallowanceTypes.CreateAsync(allowacTypeEntity);
            if (!result.flag)  { return BadRequest("Error occured while inserting"); }
            
            return Ok(new ResponseMessage("Inserted allowance record", true, result));
        }
    }
}
