namespace Ap.EmailSender
{
    public interface ISmtpService
    {
        void Send(string[] recipients, string subject, string body, params string[] attachments);
    }
}