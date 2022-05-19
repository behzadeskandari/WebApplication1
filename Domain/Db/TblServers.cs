
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblServers
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(50, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Title { get; set; }

        [Display(Name = "ادرس سرور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(150, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[\w\._\:]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Ip { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[\w_\-\@\.]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string UserName { get; set; }

        [Display(Name = "کلمه ی عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)] 
        [MinLength(6, ErrorMessage = ErrMsg.MinLenghtMsg)]
        public string Password { get; set; }


        [Display(Name = "مسیر")]
        [MaxLength(500, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        public string Path { get; set; }

        [Display(Name = "نوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Type { get; set; }

        [Display(Name = "دامین")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"((H|http://)|(Hhttps://))[\wا-ی\-_\./]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string HttpDomain { get; set; }


        public virtual ICollection<TblImage> TblImages { get; set; }
    }
}
