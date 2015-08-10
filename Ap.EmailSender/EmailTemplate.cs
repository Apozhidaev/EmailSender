using System;

namespace Ap.EmailSender
{
    public class EmailTemplate
    {
        public EmailTemplate(Type forType, string template)
        {
            Template = template;
            ForType = forType;
        }

        public Type ForType { get; private set; }
        public string Template { get; private set; }
    }
}