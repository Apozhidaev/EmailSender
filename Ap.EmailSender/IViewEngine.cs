namespace Ap.EmailSender
{
    public interface IViewEngine
    {
        string Render(object model, string formattedString);
    }
}