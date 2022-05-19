
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblSlider
    {
        [Key]
        public int ID { get; set; }

        public int ImageID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_\-]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Title { get; set; }

        [Display(Name ="ترتیب")]
        public int Sort { get; set; }

        [Display(Name ="لینک")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrMsg.RequierdMsg)]
        public string Link { get; set; }


        [ForeignKey(nameof(ImageID))]
        public virtual TblImage TblImage { get; set; }
    }
}
