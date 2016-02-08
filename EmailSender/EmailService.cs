namespace EmailSender
{
    public class EmailService
    {
        readonly IEmailRenderer _emailBodyRenderer;
        readonly IEmailRenderer _emailSubjectRenderer;
        readonly ISmtpService _smtpService;

        public EmailService(IEmailRenderer emailBodyRenderer, IEmailRenderer emailSubjectRenderer, ISmtpService smtpService)
        {
            _emailBodyRenderer = emailBodyRenderer;
            _emailSubjectRenderer = emailSubjectRenderer;
            _smtpService = smtpService;
        }

        public void Send<T>(string[] recipients, T model, string[] attachments = null) where T : class 
        {
            string subject = _emailSubjectRenderer.Render(model);
            string body = _emailBodyRenderer.Render(model);
            _smtpService.Send(recipients, subject, body, attachments);
        }
    }
}