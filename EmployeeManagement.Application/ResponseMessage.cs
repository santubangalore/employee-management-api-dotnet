namespace EmployeeManagement.Application
{
    public record ResponseMessage (string message, bool result, dynamic data);
}
