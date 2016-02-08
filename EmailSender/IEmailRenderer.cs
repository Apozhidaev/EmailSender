namespace EmailSender
{
    public interface IEmailRenderer
    {
        string Render<T>(T model) where T : class;
    }
}