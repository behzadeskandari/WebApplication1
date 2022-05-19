using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblTypePost
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Title { get; set; }


        public virtual ICollection<TblOrders> TblOrders { get; set; }
    }
}
