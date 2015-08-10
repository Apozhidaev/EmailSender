using System;
using System.Text.RegularExpressions;

namespace Ap.EmailSender
{
    public class ViewEngine : IViewEngine
    {
        public string Render<T>(T model, string template) where T : class 
        {
            if (model != null)
            {
                foreach (var propertyInfo in model.GetType().GetProperties())
                {
                    var token = String.Format("{{{{\\s*{0}\\s*}}}}", propertyInfo.Name);
                    template = Regex.Replace(template, token, propertyInfo.GetValue(model).ToString());
                }
            }
            return template;
        }
    }
}