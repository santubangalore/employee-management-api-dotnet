namespace EmployeeManagement.Domain.Entities
{
    public class Setup
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime SetupDate { get; set; }
        public string SetupBy { get; set; }
        public string AdminUserId { get; set; }  //emailId
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string SuperAdminUserId { get; set; } //email Id
        public string SuperAdminUserName { get; set; }
        public string SuperAdminPassword { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdationDate { get; set; }
    }
}
