using EmployeeManagement.Application;
using EmployeeManagement.Application.Conversions;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController (IOnboarding onboardingRepo) : ControllerBase
    {
        [HttpPost("AddOnboardingRecord")]
        public async Task<ActionResult<ResponseMessage>> PostOnboarding(OnboardingDTO onboardingDTO)
        {
            if (onboardingDTO == null) 
            { return BadRequest(); }
            var entity=ConvertOnBoarding.ConvertToEntity(onboardingDTO);
            var response=await onboardingRepo.CreateAsync(entity);
            if(response == null) { return BadRequest(); }
            return Ok(new ResponseMessage("",true,response));
        }

    }
}
