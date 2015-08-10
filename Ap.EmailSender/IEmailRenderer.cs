namespace Ap.EmailSender
{
    public interface IEmailRenderer
    {
        string Render<T>(T model);
    }
}