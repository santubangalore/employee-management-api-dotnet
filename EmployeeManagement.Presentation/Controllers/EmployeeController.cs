using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployee employeeInterface, IChildDepartment childDeptInterface) : ControllerBase
    {
        [HttpGet("GetEmployees")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<ResponseMessage>> GetEmployees()
        {
            var employees=await employeeInterface.GetAllAsync();
            var childDepts = await childDeptInterface.GetAllAsync();
            var empsDto = ConvertEmployee.ConvertToDtoList(employees,childDepts);
            return empsDto is null ? NotFound(new ResponseMessage("Not Found", false, null!)): Ok(new ResponseMessage("Employee Record", true, empsDto));
        }

        [HttpGet("GetEmployee/{Id}")]
        public async Task<ActionResult<ResponseMessage>> GetEmployee(int Id)
        {
            var employee = await employeeInterface.FindByIdAsync(Id);
            if (employee is null)
                return NotFound("Employee not found");
            var childDept = await childDeptInterface.FindByIdAsync(employee.DeptId);

            var empDto = ConvertEmployee.ConvertToDto(employee, childDept);
            return empDto is null ? NotFound(new ResponseMessage("Not Found", false, null!)) : Ok(new ResponseMessage("Employee Record", true, empDto));
        }

        [HttpPost("CreateEmployee")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage>> CreateEmployee(EmployeeDTO employee)
        {
            if (employee.EmployeeName.Trim() == "" | employee.EmployeeName== null) { return BadRequest(employee); }
            if(!ModelState.IsValid) { return BadRequest("Invalid Employee object"); }
            var empl=ConvertEmployee.ConvertToEntity(employee);

            var res=await employeeInterface.CreateAsync(empl);
            return res.flag ? Ok(new ResponseMessage("Employee Added", true, res)) : BadRequest(new ResponseMessage("Error Occurred", false, res)); 
        }

        [HttpPut("UpdateEmployee")]
        [Authorize]
        public async Task<ActionResult> UpdateEmployee(EmployeeDTO employee)
        {
            if (employee.EmployeeName.Trim() == "" | employee.EmployeeName== null) { return BadRequest("Employee name cannot be blank"); }
            if (!ModelState.IsValid) { return BadRequest("Invalid Employee object"); }
            var empl = ConvertEmployee.ConvertToEntity(employee);
            var res =await employeeInterface.UpdateAsync(empl);
            return res.flag ? Ok(new ResponseMessage("Employee Updated", true, res)) : BadRequest(new ResponseMessage("Error Occurred", false, res));
        }

        [HttpDelete("DeleteEmployee/{EmployeeId}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> DeleteEmployee(int EmployeeId )
        {
            var employee = await employeeInterface.FindByIdAsync(EmployeeId);
            if (employee is null)
                return NotFound("Employee not found");
            var res = await employeeInterface.DeleteAsync(employee);
            return res.flag ? Ok(new ResponseMessage("Employee deleted", true, res)) : BadRequest(new ResponseMessage("Error Occurred", false, res));
        }
    }
}
