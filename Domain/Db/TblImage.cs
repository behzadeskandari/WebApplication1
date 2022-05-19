
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblImage
    {
        [Key]
        public int ID { get; set; }
        public int ServerID { get; set; }
        public int? ProductID { get; set; }

        [Display(Name = "عنوان")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Title { get; set; }

        [Display(Name = "نام فیزیکی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        public string FileName { get; set; }

        [Display(Name = "متن جایگزین")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        //[RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Alt { get; set; }


        [ForeignKey(nameof(ServerID))]
        public virtual TblServers TblServer { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }

        public virtual ICollection<TblSlider> TblSlider { get; set; }

        public virtual ICollection<TblBrands> TblBrands { get; set; }
    }
}
