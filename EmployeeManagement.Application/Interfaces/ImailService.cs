namespace EmployeeManagement.Application.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendEmail(object sender, string name);
    }
}
