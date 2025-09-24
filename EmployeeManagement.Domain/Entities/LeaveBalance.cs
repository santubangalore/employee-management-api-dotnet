using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class LeaveBalance
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveType { get; set; }
        public decimal BalanceLeave {  get; set; }
        public int ToYear { get; set; }
        public int FromYear { get; set; }
        public int CreatedByUser { get; set; }
        public DateTime CreatedDate{ get; set; }
    }
}
