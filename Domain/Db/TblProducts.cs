
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblProducts
    {
        [Key]
        public int ID { get; set; }
        public int? BrandID { get; set; }
        public string UserID { get; set; }
        public int GuruntyID { get; set; }
        public int CateID { get; set; }

        [Display(Name = "عنوان فارسی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_\-]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string TitleFa { get; set; }

        [Display(Name = "عنوان لاتین")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_\-]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string TitleEn { get; set; }

        [Display(Name = "معرفی اجمالی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [Column(TypeName = "nvarchar(max)")]
        public string Text { get; set; }

        [Display(Name = "نقد و برسی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [Column(TypeName = "nvarchar(max)")]
        public string Evaluation { get; set; }

        [Display(Name = "تاریخ")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "وضعیت")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [Range(0, 10, ErrorMessage = ErrMsg.RangeMsg)]
        public int Status { get; set; }

        [Display(Name = "موجودی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Count { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "وزن")]
        public int Wight { get; set; }

        [Display(Name = "ابعاد")]
        public string Size { get; set; }
        public int? spID { get; set; }


        public virtual ICollection<TblPrices> TblPrices { get; set; }
        public virtual ICollection<TblImage> TblImages { get; set; }

        [ForeignKey(nameof(GuruntyID))]
        public virtual TblGurunty TblGurunty { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }

        [ForeignKey(nameof(CateID))]
        public virtual TblCategory TblCategory { get; set; }

        public virtual ICollection<TblComments> TblComments { get; set; }

        public virtual ICollection<TblAsks> TblAsks { get; set; }

        public virtual ICollection<TblPropertis_Product> TblPropertis_Product { get; set; }
        public virtual ICollection<TblTechnicalProp_Products> TblTechnicalProp_Products { get; set; }

        public virtual ICollection<TblRaiting> TblRaiting { get; set; }
        public virtual ICollection<TblNoti> TblNoti { get; set; }

        public virtual ICollection<TblShopingCart> TblShopingCart { get; set; }

        public virtual ICollection<TblFavo> TblFavos { get; set; }

        [ForeignKey(nameof(spID))]
        public virtual TblSpical TblSpical { get; set; }

        [ForeignKey(nameof(BrandID))]
        public virtual TblBrands TblBrands { get; set; }
    }
}
