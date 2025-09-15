using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IParentDepartment parentDeptInterface, IChildDepartment childDeptInterface) : ControllerBase
    {
        [HttpGet("GetParentDepartments")]
        public async Task<ActionResult<ResponseMessage>> GetParentDeprtments()
        {
            var result=await parentDeptInterface.GetAllAsync();
            var response = ConvertDepts.ConvertToParentDeptsDto(result);
            return response is null? NotFound(new ResponseMessage("Not Found", false, result!)) : Ok(new ResponseMessage("Parent department",true,response));
        }

        [HttpGet("GetParentDepartment/{DepartmentId}")]
        public async Task<ActionResult<ResponseMessage>> GetParentDept(int DepartmentId)
        {
            if (DepartmentId <= 0) return BadRequest("DepartmentId cannot be 0 or less");    
            var department=await parentDeptInterface.FindByIdAsync(DepartmentId);
            if(department == null) return NotFound("Dept Not Found");
            var result = ConvertDepts.ConvertToParentDeptDto(department);
            return result is null ? NotFound(new ResponseMessage("Not Found",false,result!)) : Ok(new ResponseMessage("Parent Department",true, result));
        }

        [HttpPost("CreateParentDepartment")]
        public async Task<ActionResult> AddParentDepartment(ParentDeptDTO parentDeptDto)
        {
            if (!ModelState.IsValid) { return BadRequest("Invalid Data"); }
            if (parentDeptDto == null) { return BadRequest(); }
            var ParentDept = ConvertDepts.ConvertToParentDepartment(parentDeptDto);
            var response=await parentDeptInterface.CreateAsync(ParentDept);
            return response.flag ? Ok(new ResponseMessage("Parent Department created ", true, response)) : BadRequest(response);
        }

        [HttpGet("GetChildDepartments")]
        public async Task<ActionResult<ResponseMessage>> GetChildDeprtments()
        {
            var result = await childDeptInterface.GetAllAsync();
            var parentDepts = await parentDeptInterface.GetAllAsync();
            var response = ConvertDepts.ConvertToChildDeptsDto(result,parentDepts);

            return Ok(new ResponseMessage("Child Departments",true,response));
        }

        [HttpGet("GetChildDeptByParentDept/{ParentDepartmentId}")]
        public async Task<ActionResult<ResponseMessage>> GetChildDeptByParentDept(int ParentDepartmentId)
        {
            if (ParentDepartmentId <= 0) return BadRequest("ParentDeptId cannot be 0 or less");
            var department = await childDeptInterface.GetChildDepartmentsByParent(ParentDepartmentId);
            if (department is null || department.Count()<=0 ) return BadRequest("No child dept found");
            var parentDepts=await parentDeptInterface.GetAllAsync();
            var result = ConvertDepts.ConvertToChildDeptsDto(department,parentDepts);
            return result is null ? BadRequest(new ResponseMessage("Not Found", false, result!)) : Ok(new ResponseMessage("Child Departments", true, result));
        }

        [HttpGet("GetChildDepartment/{ChildDeptId}")]
        public async Task<ActionResult<ResponseMessage>> GetChildDept(int ChildDeptId)
        {
            if (ChildDeptId <= 0) return BadRequest("ChildDept Id cannot be 0 or less");
            var department = await childDeptInterface.FindByIdAsync(ChildDeptId);
            if (department is null) return BadRequest("Child Dept not found");
            var parentDept = await parentDeptInterface.FindByIdAsync(department.ParentDeptId);
            if(parentDept is null) return BadRequest("Parent Dept not found");
            var result = ConvertDepts.ConvertToChildDeptDto(department,parentDept.DepartmentName);
            return result is null ? BadRequest(new ResponseMessage("Not Found",false,result!)) : Ok(new ResponseMessage("Child Departments", true, result));
        }

        [HttpPost("CreateChildDepartment")]
        public async Task<ActionResult> CreateChildDepartment(ChildDeptDTO childDeptDto)
        {
            if (!ModelState.IsValid) { return BadRequest("Invalid Data"); }

            var ParentDept = ConvertDepts.ConvertToChildDepartment(childDeptDto);
            var response = await childDeptInterface.CreateAsync(ParentDept);
            return response.flag ? Ok(new ResponseMessage("Child Departments", true, response)) : BadRequest(new ResponseMessage("Unable to create child department", false, response));
        }

        [HttpPut("UpdateParentDept")]
        public async Task<ActionResult<ResponseMessage>> UpdateParentDept(ParentDeptDTO parentDeptDto)
        {
            if (parentDeptDto.DepartmentName.Trim() == "" || parentDeptDto.DepartmentName ==null) { return BadRequest("dept name cannot be blank"); }
            if (!ModelState.IsValid) { return BadRequest("Invalid Employee object"); }
            var dept = ConvertDepts.ConvertToParentDepartment(parentDeptDto);
            var result = await parentDeptInterface.UpdateAsync(dept);
            return result.flag? Ok(new ResponseMessage("Updated",true,result)):BadRequest(new ResponseMessage("Error updating",false,result));
        }


        [HttpPut("UpdateChildDept")]
        public async Task<ActionResult<ResponseMessage>> UpdateChildDept( ChildDeptDTO childDeptDto)
        {
            if (childDeptDto.DepartmentName.Trim() == "" || childDeptDto.DepartmentName==null) { return BadRequest("dept name cannot be blank"); }
            if (!ModelState.IsValid) { return BadRequest("Invalid Employee object"); }
            var dept = ConvertDepts.ConvertToChildDepartment(childDeptDto);
            var result = await childDeptInterface.UpdateAsync(dept);
            return result.flag ? Ok(new ResponseMessage("Updated", true, result)) : BadRequest(new ResponseMessage("Error updating", false, result));

        }


    }
}
