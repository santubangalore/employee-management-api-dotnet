using EmployeeManagement.Application.Interfaces;
using System.Net;
using System.Net.Mail;

namespace EmployeeManagement.Infrastructure.Services
{
    public class MailService:IMailService
    {
        public async Task<bool> SendEmail(object sender, string email)
        {
            var fromAddress = new MailAddress("santutsk@gmail.com", "Santu Ghosh");
            var toAddress = new MailAddress("johnalexander@maildrop.cc", "john Name");
            const string fromPassword = "Intricate1@";
            const string subject = "Reset password";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 465,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                try
                {
                        smtp.Send(message);
                }
                catch (Exception ex)
                {
                    throw;
                }
            return true;
        }
    }
}
