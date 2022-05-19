
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblTechnicalProp_Products
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int TechnicalPropID { get; set; }

        [Display(Name ="مقدار")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrMsg.RequierdMsg)]
        [MaxLength(100,ErrorMessage =ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_\-\*]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Value { get; set; }



        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }

        [ForeignKey(nameof(TechnicalPropID))]
        public virtual TblTechnicalProp TblTechnicalProp { get; set; }
    }
}
