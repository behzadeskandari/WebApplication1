using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class SendEmailViewModel
    {
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsHtml { get; set; }


    }

}
