using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Conversions
{
    public class ConvertOnBoarding
    {
        public static Onboarding ConvertToEntity(OnboardingDTO onboardingDto)
        {
            if (onboardingDto is null) return null;
            var onboarding = new Onboarding()
            {
                Name = onboardingDto.CandidateName,  
                Address  = onboardingDto.Address,
                PhoneNumber = onboardingDto.PhoneNumber,
                EmailId = onboardingDto.EmailId,
                OnboardingBy=onboardingDto.OnboardingBy,
                OnboardingStartDate = onboardingDto.OnboardingStartDate,
                DOB=onboardingDto.DateOfBirth,
                UploadedDocuments = onboardingDto.UploadedDocuments,
                VerificationStage=onboardingDto.VerificationStage,
                VerifiedOn=onboardingDto.VerifiedOn,
                EmployeeId=onboardingDto.EmployeeId,
                OnBoardingCompleted= onboardingDto.OnBoardingCompleted,
            };
            return onboarding;
        }

        public static OnboardingDTO ConvertToDto(Onboarding onboarding)
        {
            if (onboarding is null) return null;
            var onboardingDto = new OnboardingDTO()
            {
                CandidateName = onboarding.Name,
                Address = onboarding.Address,
                PhoneNumber = onboarding.PhoneNumber,
                EmailId = onboarding.EmailId,
                OnboardingBy = onboarding.OnboardingBy,
                OnboardingStartDate = onboarding.OnboardingStartDate,
                DateOfBirth = onboarding.DOB,
                UploadedDocuments = onboarding.UploadedDocuments,
                VerificationStage = onboarding.VerificationStage,
                VerifiedOn = onboarding.VerifiedOn,
                EmployeeId = onboarding.EmployeeId,
                OnBoardingCompleted=onboarding.OnBoardingCompleted,
            };
            return onboardingDto;
        }
    }
}
