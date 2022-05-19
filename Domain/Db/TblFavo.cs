using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblFavo
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }


        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProduct { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }
    }
}
