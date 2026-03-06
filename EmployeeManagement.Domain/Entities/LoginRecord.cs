using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class LoginRecord
    {
        [Key]
        public int Id {  get; set; }
        public int EmployeeId { get; set; }
        public DateTime LoginDate { get; set; }
        public int LoginCount { get; set; } = 0;
    }
}
