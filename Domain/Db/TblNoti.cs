using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    /// <summary>
    /// این جدول همان جدول ؛خبرم کن؛ در دیجی کالا می باشد
    /// </summary>
    public class TblNoti
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }

        [Display(Name ="تاریخ")]
        public DateTime Date { get; set; }

        [Display(Name ="وضعیت")]
        public bool Status { get; set; }


        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }
    }
}
