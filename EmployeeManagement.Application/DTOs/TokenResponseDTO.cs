namespace EmployeeManagement.Application.DTOs
{
    public class TokenResponseDto
    {
        public string EmailId { get; set; } =string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Role {  get; set; }= string.Empty;
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public int ReporteeCount { get; set; }
    }

}
