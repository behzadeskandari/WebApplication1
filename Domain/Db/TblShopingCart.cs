using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblShopingCart
    {
        [Key]
        public int ID { get; set; }
        public string ShopingCartGroupID { get; set; }
        public string UserID { get; set; }
        public string CookieID { get; set; }
        public int ProductID { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }


        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }


        public virtual ICollection<TblPropertiseProduct_ShopingCart> TblPropertiseProduct_ShopingCart { get; set; }

    }
}
