using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblMessages
    {
        [Key]
        public int ID { get; set; }
        public string AdminID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Name = "متن اصلی")]
        public string Text { get; set; }

        [Display(Name = "خوانده شده")]
        public bool Read { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }

        [Display(Name = "ای پی کاربر")]
        [MaxLength(50)]
        public string Ip { get; set; }


        //[ForeignKey(nameof(AdminID))]
        [NotMapped]
        public virtual ApplicationUser TblUserAdmin { get; set; }

        //[ForeignKey(nameof(UserID))]
        [NotMapped]
        public virtual ApplicationUser TblUserClaint { get; set; }
    }
}
