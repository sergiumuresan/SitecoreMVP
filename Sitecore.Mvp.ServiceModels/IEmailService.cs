namespace Sitecore.Mvp.ServiceModels
{
    public interface IEmailService
    {
        bool SendEmail(string from, string to, string subject, string body);
    }
}
