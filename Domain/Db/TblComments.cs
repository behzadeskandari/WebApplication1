
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblComments
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_\-]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Title { get; set; }

        [Display(Name = "متن نظر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(1000, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        public string Text { get; set; }

        [Display(Name = "ارزش خرید به نسبت قیمت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Item1 { get; set; }

        [Display(Name = "نوآوری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Item2 { get; set; }

        [Display(Name = "کیفیت ساخت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Item3 { get; set; }

        [Display(Name = "امکانات و قابلیت ها")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Item4 { get; set; }

        [Display(Name = "سهولت استفاده")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Item5 { get; set; }

        [Display(Name = "طراحی ظاهر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Item6 { get; set; }

        [Display(Name = "نقاط قوت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(400, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(5, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_,]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Best { get; set; }

        [Display(Name = "نقاط ضعف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(400, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(5, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_,]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Bad { get; set; }

        [Display(Name ="می پسندم")]
        public int Like { get; set; }

        [Display(Name = "نمی پسندم")]
        public int DisLike { get; set; }

        public string Ip { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }
        public bool Confirm { get; set; }



        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUsers { get; set; }

    }
}
