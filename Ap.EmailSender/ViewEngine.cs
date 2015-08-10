using System;

namespace Ap.EmailSender
{
    public class ViewEngine : IViewEngine
    {
        public string Render(object model, string formattedString)
        {
            if (model != null)
            {
                foreach (var propertyInfo in model.GetType().GetProperties())
                {
                    var token = String.Format("[{0}]", propertyInfo.Name);
                    formattedString = formattedString.Replace(token, propertyInfo.GetValue(model).ToString());
                }
            }
            return formattedString;
        }
    }
}