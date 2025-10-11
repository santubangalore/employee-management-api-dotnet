namespace EmployeeManagement.Domain.Entities
{
    public class Onboarding
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string EmailId { get; set; } =string.Empty;
        public DateTime DOB { get; set; }
        public List<string> UploadedDocuments { get; set; } = new List<string>();
        public DateTime OnboardingStartDate { get; set; }
        public string ClientName {  get; set; }=string.Empty;
        public int OnboardingBy {  get; set; }
        public virtual Employee Employee { get; set; } 
        public int EmployeeId { get; set; }
        public string VerificationStage { get; set; } = string.Empty;
        public DateTime VerifiedOn {  get; set; }
        public bool OnBoardingCompleted { get; set; }

    }
}
