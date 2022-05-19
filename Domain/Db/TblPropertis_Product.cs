
using Common.Extensions.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblPropertis_Product
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int PropertiseID { get; set; }

        [Display(Name ="قیمت افزوده")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public decimal Price { get; set; }


        [ForeignKey(nameof(PropertiseID))]
        public virtual TblPropertis TblPropertis { get; set; }

        [ForeignKey(nameof(ProductID))]
        public virtual TblProducts TblProducts { get; set; }
    }
}
