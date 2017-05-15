namespace Sitecore.Mvp.Services
{
    using System.Net.Mail;

    using ServiceModels;

    public class EmailService : IEmailService
    {
        public bool SendEmail(string from, string to, string subject, string body)
        {
            var mailMessage = new MailMessage(from, to) { Subject = subject, Body = body };

            var smtpClient = new SmtpClient();

            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {
                //todo log error
                return false;
            }
        }
    }
}
