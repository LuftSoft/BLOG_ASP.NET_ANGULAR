namespace BlogAppAPI.Services
{
    public interface ISendMailService
    {
        Task<string> SendMail(MailContent content);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
