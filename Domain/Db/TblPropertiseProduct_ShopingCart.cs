using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Db
{
    public class TblPropertiseProduct_ShopingCart
    {
        [Key]
        public int ID { get; set; }
        public int ShopingCartID { get; set; }
        public int PropertiseProductID { get; set; }


        [ForeignKey(nameof(ShopingCartID))]
        public virtual TblShopingCart TblShopingCart { get; set; }

        [ForeignKey(nameof(PropertiseProductID))]
        public virtual TblPropertis_Product TblPropertis_Product { get; set; }
    }
}
