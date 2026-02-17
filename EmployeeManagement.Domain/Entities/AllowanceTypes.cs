using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class AllowancesTypes
    {
        [Key]
        public int AllowanceTypeId { get; set; }
        public string AllowanceName { get; set; } = string.Empty;
        public string AllowanceDescription { get; set; }=string.Empty;
        public string AllowanceType {  get; set; } = string.Empty; // per year or per month
    }

    public class EmployeeAllowances
    {
        [Key]
        public int EployeeAllowancesId { get; set; }
        public int EmployeeId { get; set; }
        public int FinYear {  get; set; }
        public int AllowanceTypeId { get; set; } // percentage or flat amnt per employee
        public int AllowanceAmount {  get; set; }
    }
}
