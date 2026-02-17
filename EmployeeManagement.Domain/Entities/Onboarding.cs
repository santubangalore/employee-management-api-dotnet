using System.ComponentModel.DataAnnotations.Schema;

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
        public int OnboardingBy {  get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public virtual List<WorkExperience> WorkExperiences { get; set; }
        public virtual List<Education> Educations { get; set; }
        public string VerificationStage { get; set; } = string.Empty;
        public DateTime VerifiedOn {  get; set; }
        public bool OnBoardingCompleted { get; set; }
    }

    public class Education
    {
        public int Id { get; set; }
        public string DegreeCertificateName { get; set; } = string.Empty;
        public string FromYear { get; set; } = string.Empty;
        public string ToYear { get; set; } = string.Empty;
        public string UniversityName { get; set; } = string.Empty;

    }

    public class WorkExperience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
