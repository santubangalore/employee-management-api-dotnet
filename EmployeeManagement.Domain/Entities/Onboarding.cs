namespace EmployeeManagement.Domain.Entities
{
    public class Onboarding
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public string EmailId { get; set; } =string.Empty;
        public int Age { get; set; }
        public List<string> Documents { get; set; } = new List<string>();
        public DateTime OnBoardingDate { get; set; }
        public int OnboardingBy {  get; set; }
        public Employee Employee { get; set; } 
        public string VerificationDone { get; set; } = string.Empty;
        public DateTime VerifiedOn {  get; set; }

    }
}
