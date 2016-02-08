namespace EmailSender
{
    public interface IViewEngine
    {
        string Render<T>(T model, string template) where T : class;
    }
}