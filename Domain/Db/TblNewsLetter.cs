
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblNewsLetter
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[\w_\-\.]+[@][\w_\-\.]+[\.][\w]{2,7}", ErrorMessage = ErrMsg.RegexMsg)]
        public string Email { get; set; }

        
        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }
    }
}
