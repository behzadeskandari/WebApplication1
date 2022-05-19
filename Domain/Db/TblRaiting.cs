using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblRaiting
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }

        [Display(Name ="امتیاز")]
        public int Star { get; set; }



        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }
    }
}
