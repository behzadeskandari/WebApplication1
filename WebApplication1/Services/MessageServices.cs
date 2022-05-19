using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            MailMessage msg = new MailMessage();
            msg.Body = message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress("zankotvtest9025@gmail.com", "ZankoTv.com", Encoding.UTF8);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.Sender = msg.From;
            msg.Subject = subject;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.To.Add(new MailAddress(email, email, Encoding.UTF8));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587; //465; 
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("zankotvtest9025@gmail.com", "Reza9025");

            smtp.Send(msg);
            return Task.FromResult(0);
        }


        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
