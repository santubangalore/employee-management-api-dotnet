namespace EmployeeManagement.Application.Interfaces
{
    public interface IEncryption
    {
        Task<string> Encrypt(string text);
        Task<string> Decrypt(string encryptedText);
    }
}
