using System;
using System.Text.RegularExpressions;

namespace EmailSender
{
    public class ViewEngine : IViewEngine
    {
        public string Render<T>(T model, string template) where T : class 
        {
            if (model != null)
            {
                foreach (var propertyInfo in model.GetType().GetProperties())
                {
                    var token = $"{{{{\\s*{propertyInfo.Name}\\s*}}}}";
                    template = Regex.Replace(template, token, propertyInfo.GetValue(model).ToString());
                }
            }
            return template;
        }
    }
}