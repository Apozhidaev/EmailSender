using System;

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
                    var token = String.Format("{{{{{0}}}}}", propertyInfo.Name);
                    template = template.Replace(token, propertyInfo.GetValue(model).ToString());
                }
            }
            return template;
        }
    }
}