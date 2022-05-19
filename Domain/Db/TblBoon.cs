using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblBoon
    {
        //[Key]
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string BoonGroupID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }

        [Display(Name = "وضعیت")]
        public bool Status { get; set; }


        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual TblOrders TblOrders { get; set; }
    }
}
