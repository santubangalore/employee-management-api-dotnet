namespace EmployeeManagement.Domain.Entities
{
    public class Onboarding
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Documents { get; set; }
        public DateTime OnBoardingDate { get; set; }
        public int OnboardingBy {  get; set; }
        public Employee Employee { get; set; }
        public string VerificationDone { get; set; }
        public DateTime VerifiedOn {  get; set; }

    }
}
