using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailSender
{
    public class TemplateProvider : ITemplateProvider
    {
        readonly IEnumerable<EmailTemplate> _templates;

        public TemplateProvider(IEnumerable<EmailTemplate> templates)
        {
            _templates = templates;
        }

        public string GetTemplateFor<T>(T model) where T : class 
        {
            var emailTemplate = _templates.FirstOrDefault(x => x.ForType == model.GetType());

            if (emailTemplate == null)
                throw new ArgumentException($"No template available for model type '{model.GetType()}'.");

            return emailTemplate.Template;
        }

    }
}