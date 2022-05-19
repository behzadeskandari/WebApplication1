using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using ViewModel;

namespace UtilitySpace
{
    public class Email
    {
        public bool Send(SendEmailViewModel p)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.Body = p.Message;
                msg.BodyEncoding = Encoding.UTF8;
                msg.From = new MailAddress(p.UserName, "behzad.b.i.g@gmail.com");
                msg.IsBodyHtml = p.IsHtml;
                msg.Priority = MailPriority.Normal;
                msg.Sender = msg.From;
                msg.Subject = p.Subject;
                msg.SubjectEncoding = Encoding.UTF8;
                msg.To.Add(p.To);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = p.Smtp;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(p.UserName, p.Password);
                smtp.EnableSsl = p.UseSsl;
                smtp.Port = p.Port;
                // smtp.Timeout = 60;
                smtp.Send(msg);
                smtp.Dispose();

                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
    }

}
