using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Records;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController(IEmployeeSalary employeeSalary, IEmployee employee) : ControllerBase
    {
        [HttpGet("GetAllEmployeeSalary")]
        public async Task<ActionResult<IEnumerable<EmployeeSalaryDto>>> GetAllEmployeeSalary()
        {
            var result=await employeeSalary.GetAllAsync();
            if (result == null) return new EmptyResult();
            var employeeList=await employee.GetAllAsync();
            var resultDto = ConvertEmployeeSalary.ConvertSalaryEntityListToDto(result, employeeList);
            return Ok(new ResponseMessage("result",true,resultDto));
        }

        [HttpGet("GetEmployeeSalaryDetail/{EmployeeId}")]
        public async Task<ActionResult<ResponseMessage>> GetEmployeeSary(int EmployeeId)
        {
            var result = await employeeSalary.GetByAsync(_=>_.EmployeeId== EmployeeId);
            if (result == null) return Ok(new ResponseMessage("Id not found",false,null));
            var resultDto=ConvertEmployeeSalary.ConvertSalaryEntityToDto(result);
            return Ok(new ResponseMessage("result", true, resultDto));
        }

        [HttpPost("AddEmployeeSalary")]
        public async Task<ActionResult<ResponseMessage>> AddEmployeeSalary([FromBody] EmployeeSalaryDto salary)
        {
            if (salary.PFAccount=="string") return BadRequest(new ResponseMessage("Invalid PF account num provided", false, null));
            var EmployeeSal= ConvertEmployeeSalary.ConvertSalaryDtoToEntity(salary);
            var result=await employeeSalary.CreateAsync(EmployeeSal);
            if(!result.flag) throw new Exception("Error happened please see details!"+result.Message);
            return Ok(new ResponseMessage("result", true, result));
        }


        [HttpPost("AddEmployeeAllowance")]
        public async Task<ActionResult<ResponseMessage>> AddEmployeeAllowance([FromBody] EmployeeAllowancesDto employeeAllowance)
        {
            if (employeeAllowance.EmployeeId<= 0||employeeAllowance.AllowanceTypeId<=0) return BadRequest(new ResponseMessage("Invalid data", false, null));
            var allowanceEntity = ConvertEmployeeSalary.ConvertAllowanceDtoToEntity(employeeAllowance);
            var result = await employeeSalary.AddEmployeeAllowanceAsync(allowanceEntity);
            if (!result.flag) throw new Exception("Error happened please see details!" + result.Message);
            return Ok(new ResponseMessage("result", true, result));
        }

        [HttpPost("AddEmployeeDeductions")]
        public async Task<ActionResult<ResponseMessage>> AddEmployeeDeductions([FromBody] TaxDeductionsDto deductionsDto)
        {
            if (deductionsDto.EmployeeId <= 0 || deductionsDto is null) return BadRequest(new ResponseMessage("Invalid data", false, null));
            var deductionsEntity = ConvertEmployeeSalary.ConvertTaxDeductionsDtoToEntity(deductionsDto);
            var result = await employeeSalary.CreateTaxDeductionsAsync(deductionsEntity);
            if (!result.flag) throw new Exception("Error happened please see details!" + result.Message);
            return Ok(new ResponseMessage("result", true, result));
        }
       
    }
}
