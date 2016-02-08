namespace EmailSender
{
    public class EmailRenderer : IEmailRenderer
    {
        readonly ITemplateProvider _templateProvider;
        readonly IViewEngine _viewEngine;

        public EmailRenderer(ITemplateProvider templateProvider, IViewEngine viewEngine)
        {
            _templateProvider = templateProvider;
            _viewEngine = viewEngine;
        }

        public string Render<T>(T model) where T : class 
        {
            return _viewEngine.Render(model, _templateProvider.GetTemplateFor(model));
        }
    }
}