using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace UtilitySpace
{

    public class DigitalShopReporter : IDisposable
    {

        static DigitalShopReporter()
        {

        }
        public DigitalShopReporter()
        {

        }
        public bool SendReport(ReportViewModel rvm)
        {
            SendEmailViewModel mail = new SendEmailViewModel();

            string Template = BugReporter.Template;
            Template = Template
                .Replace("[Title]", rvm.Ex.HResult.ToString())
                .Replace("[Date]", rvm.Date.ToString())
                .Replace("[Message]", rvm.Ex.Message)
                .Replace("[ErrorMsgInerEx]", rvm.Ex.InnerException != null ? rvm.Ex.InnerException.Message : "")
                .Replace("[HelpLink]", rvm.Ex.HelpLink)
                .Replace("[Controler]", rvm.Controller)
                .Replace("[Action]", rvm.Action)
                .Replace("[UserName]", rvm.UserID);

            mail.IsHtml = true;
            mail.Message = Template;
            mail.Subject = "یک باگ جدید";
            mail.To = "behzad.b.i.g@gmail.com";
            mail.Smtp = EmailConst.Smtp;
            mail.UseSsl = EmailConst.UseSsl;
            mail.Port = EmailConst.Port;
            mail.UserName = EmailConst.UserName;
            mail.Password = EmailConst.Password;

            if (new Email().Send(mail))
                return true;
            else
                return false;

        }

        ~DigitalShopReporter()
        {
            Dispose();
        }

        public void Dispose()
        {

        }
    }

}
