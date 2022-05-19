using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Db
{
    public class TblException
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message  { get; set; }
        public string UserName { get; set; }
        public string Ex { get; set; }
        public DateTime Date { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string UserID { get; set; }
    }
}
