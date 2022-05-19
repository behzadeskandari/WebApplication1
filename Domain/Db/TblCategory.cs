﻿using Common.Extensions.Consts;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblCategory
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ParrentID { get; set; }

        [Display(Name ="عنوان")]
        [Required(AllowEmptyStrings =false,ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(50,ErrorMessage =ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*",ErrorMessage =ErrMsg.RegexMsg)]
        public string Title { get; set; }


        public virtual ICollection<TblProducts> TblProducts { get; set; }

    }
}
