using System;

namespace EmailSender.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var viewEngine = new ViewEngine();
            var bodyProvider = new TemplateProvider(new[] { new EmailTemplate(typeof(TestMail), "<b>{{Value}}</b>") });
            var subjectProvider = new TemplateProvider(new[] { new EmailTemplate(typeof(TestMail), "{{Title}}") });
            var emailService = new EmailService(new EmailRenderer(bodyProvider, viewEngine), new EmailRenderer(subjectProvider, viewEngine), new TestSmtpService());
            emailService.Send(new[] { "tt" }, new TestMail { Value = "777", Title = "555"});
            Console.ReadKey();
        }
    }

    public class TestMail
    {
        public string Title { get; set; }
        public string Value { get; set; }
    }

    public class TestSmtpService : ISmtpService
    {
        public void Send(string[] recipients, string subject, string body, params string[] attachments)
        {
            foreach (var recipient in recipients)
            {
                Console.WriteLine(recipient);
            }
            Console.WriteLine(subject);
            Console.WriteLine(body);
        }
    }
}
