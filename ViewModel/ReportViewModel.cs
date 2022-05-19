using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class ReportViewModel
    {
        public Exception Ex { get; set; }
        public DateTime Date { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string UserID { get; set; }
    }
}
