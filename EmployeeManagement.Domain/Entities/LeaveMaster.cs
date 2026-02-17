using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    internal class LeaveMaster
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public int EarnedLeaves {  get; set; }
        public int CasualLeaves { get; set; }
        public int MedicalLeave {  get; set; }
        public int CarryForward {  get; set; }
    }
}
