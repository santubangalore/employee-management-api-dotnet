namespace EmployeeManagement.Application.Records
{
    public record ResponseMessage (string message, bool result, dynamic data);
}
