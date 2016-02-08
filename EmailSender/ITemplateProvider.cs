namespace EmailSender
{
    public interface ITemplateProvider
    {
        string GetTemplateFor<T>(T model) where T : class;
    }
}