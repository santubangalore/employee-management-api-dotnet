using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class LeaveApprovalStep
    {
        [Key]
        public int ApprovalStepId {  get; set; }
        public string ApprovalStepName { get; set; } = string.Empty;
    }
}
