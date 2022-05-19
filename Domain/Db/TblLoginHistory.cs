using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblLoginHistory
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public string CookieID { get; set; }

        [Display(Name = "بازدید کرده")]
        [MaxLength(500)]
        public string Url { get; set; }


        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }
    }
}
