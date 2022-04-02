using ep.Service.Email;

namespace ep.Service.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage message);
        Task SendEmailAsync(EmailMessage message);
    }
}
