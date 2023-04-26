using System.Net.Mail;
using System.Net;
using System.Text;

namespace BlogAppAPI.Services.Sendmail
{
    public class SendMailSMTP
    {
        public static async Task<string> SendMail(string _from, string _to, string _subject, string _body,
            string _gmail, string _pasword)
        {
            //get config


            MailMessage mailMessage = new MailMessage(_from, _to, _subject, _body);
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            mailMessage.ReplyToList.Add(new MailAddress(_from));
            mailMessage.Sender = new MailAddress(_from);
            //mailMessage.Body = _body;
            //mailMessage.Subject = _subject;

            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_gmail, _pasword);
            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                return "Gui mail thanh cong";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Gui mail that bai";
            }
        }
    }
}
