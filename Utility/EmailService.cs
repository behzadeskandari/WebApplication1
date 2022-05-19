using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace UtilitySpace
{
    public class EmailService
    {
        public bool Send(string To, string Subject, string Text)
        {
            MailMessage msg = new MailMessage();
            msg.Body = Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress("behzad.b.i.g@gmail.com", "digitalshop.com", Encoding.UTF8);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.Sender = msg.From;
            msg.Subject = Subject;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.To.Add(new MailAddress(To, To, Encoding.UTF8));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587; //465; 
            smtp.EnableSsl = true;
             smtp.Credentials = new NetworkCredential("behzad.b.i.g@gmail.com", "Joker123qwe*^%");

            smtp.Send(msg);

            return true;
        }

    }
}
