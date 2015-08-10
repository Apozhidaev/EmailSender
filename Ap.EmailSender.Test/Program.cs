using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap.EmailSender.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var viewEngine = new ViewEngine();
            var bodyProvider = new TemplateProvider(new[] { new EmailTemplate(typeof(TestMail), "<b>{{Value}}</b>") });
            var subjectProvider = new TemplateProvider(new[] { new EmailTemplate(typeof(TestMail), "{{Title}}") });
            var emailSender = new EmailSender(new EmailRenderer(bodyProvider, viewEngine), new EmailRenderer(subjectProvider, viewEngine), new TestSmtpService());
            emailSender.Send(new[] { "tt" }, new TestMail { Value = "777", Title = "555"});
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
        public void Send(string[] recipients, string subject, string body, string[] attachments = null)
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
