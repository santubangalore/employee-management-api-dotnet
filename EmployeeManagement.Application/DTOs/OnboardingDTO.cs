using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.DTOs
{
    public class OnboardingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public List<string> Documents { get; set; } = new List<string>();
        public DateTime OnBoardingDate { get; set; }
        public int OnboardingBy { get; set; }
        public Employee Employee { get; set; }
        public string VerificationDone { get; set; } = string.Empty;
        public DateTime VerifiedOn { get; set; }
    }
}
