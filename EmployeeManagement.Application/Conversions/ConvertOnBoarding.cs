using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertOnBoarding
    {
        public static Onboarding ConvertToEntity(OnboardingDTO orboardingDto)
        {
            if (orboardingDto is null) return null;
            var onboarding = new Onboarding()
            {
                Name = orboardingDto.Name,  
                Address  = orboardingDto.Address,
                PhoneNumber = orboardingDto.PhoneNumber,
                ClientName = orboardingDto.ClientName,
                EmailId = orboardingDto.EmailId,
                OnboardingBy=orboardingDto.OnboardingBy,
                OnboardingStartDate = orboardingDto.OnboardingStartDate,
                DOB=orboardingDto.DOB,
                Documents = orboardingDto.Documents,
                VerificationDone=orboardingDto.VerificationDone,
                VerifiedOn=orboardingDto.VerifiedOn,
                EmployeeId=orboardingDto.EmployeeId,
            };
            return onboarding;
        }

        public static OnboardingDTO ConvertToDto(Onboarding orboarding)
        {
            if (orboarding is null) return null;
            var onboardingDto = new OnboardingDTO()
            {
                Name = orboarding.Name,
                Address = orboarding.Address,
                PhoneNumber = orboarding.PhoneNumber,
                ClientName = orboarding.ClientName,
                EmailId = orboarding.EmailId,
                OnboardingBy = orboarding.OnboardingBy,
                OnboardingStartDate = orboarding.OnboardingStartDate,
                DOB = orboarding.DOB,
                Documents = orboarding.Documents,
                VerificationDone = orboarding.VerificationDone,
                VerifiedOn = orboarding.VerifiedOn,
                EmployeeId = orboarding.EmployeeId,
            };
            return onboardingDto;
        }
    }
}
