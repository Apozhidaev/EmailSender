namespace Ap.EmailSender
{
    public class EmailSender
    {
        readonly IEmailRenderer _emailBodyRenderer;
        readonly IEmailRenderer _emailSubjectRenderer;
        readonly ISmtpService _smtpService;

        public EmailSender(IEmailRenderer emailBodyRenderer, IEmailRenderer emailSubjectRenderer, ISmtpService smtpService)
        {
            _emailBodyRenderer = emailBodyRenderer;
            _emailSubjectRenderer = emailSubjectRenderer;
            _smtpService = smtpService;
        }

        public void Send<T>(string[] emailAddress, T model, params string[] attachments)
        {
            string subject = _emailSubjectRenderer.Render(model);
            string body = _emailBodyRenderer.Render(model);
            _smtpService.Send(emailAddress, subject, body, attachments);
        }
    }
}