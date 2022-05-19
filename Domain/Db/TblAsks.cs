
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblAsks
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public int ProductID { get; set; }

        public int AskID { get; set; }

        [Display(Name = "متن")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(1000, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        public string Text { get; set; }

        [Display(Name = "ای پی کاربر")]
        [MaxLength(50)]
        public string Ip { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }

        [Display(Name = "مرا خبر کن")]
        public bool Noti { get; set; }

        [Display(Name = "می پسندم")]
        public int Like { get; set; }

        [Display(Name = "نمی پسندم")]
        public int DisLike { get; set; }


        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }
    }
}
