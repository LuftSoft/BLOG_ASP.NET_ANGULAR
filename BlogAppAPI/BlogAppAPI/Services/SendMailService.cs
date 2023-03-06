using BlogAppAPI.Services.Static;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BlogAppAPI.Services
{
    public class SendMailService : ISendMailService
    {
        IConfigurationSection _mailConfig;
        public SendMailService() { 
            this._mailConfig = StaticMethod.GetConfiguration().GetSection("MailSettings");
        }

        public async Task<string> SendMail(MailContent content)
        {
                var email = new MimeMessage();
                email.Sender = new MailboxAddress("TANNGOC", "luffschloss@gmail.com");
                email.From.Add(new MailboxAddress("TANNGOC", "luffschloss@gmail.com"));
                email.To.Add(new MailboxAddress("factyel.bttn@gmail.com", "factyel.bttn@gmail.com"));

                var builder = new BodyBuilder();
                builder.HtmlBody = content.Body;

                email.Body = builder.ToMessageBody();

                using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("luffschloss@gmail.com", "lbftgfrkyxjcudvu");
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Gui mail that bai";
            }

            smtp.Disconnect(true);
            return "Gui mail thanh cong";

        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
        
    }
    

    public class MailContent
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
