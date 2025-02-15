using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagementSystem.Web.Services
{
    public class EmailSender (IConfiguration _configuration): IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_configuration["EmailSettings:DefaultEmailAddress"]),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using var client = new SmtpClient(_configuration["EmailSettings:Server"], Convert.ToInt32(_configuration["EmailSettings:Port"]));
            await client.SendMailAsync(message);
        }
    }
}
