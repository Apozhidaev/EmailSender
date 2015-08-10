namespace Ap.EmailSender
{
    public interface ISmtpService
    {
        void Send(string[] recipients, string subject, string body, string[] attachments = null);
    }
}