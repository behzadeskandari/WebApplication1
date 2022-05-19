﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblOrders
    {
        [Key]
        public int ID { get; set; }
        public int PostID { get; set; }
        public string UserID { get; set; }
        public string BoonGroupID { get; set; }
        public string ShopingCartGroupID { get; set; }

        [Display(Name = "قیمت")]
        public string Price { get; set; }

        [Display(Name = "قیمت با تخفیف")]
        public string PriceBoon { get; set; }

        [Display(Name = "وضعیت سفارش")]
        public int Status { get; set; }

        [Display(Name = "شناسه ی بانکی")]
        [MaxLength(50)]
        public string BankGetNumber { get; set; }

        [Display(Name = "شماره تراکنش بانکی")]
        [MaxLength(50)]
        public string BankTransNumber { get; set; }

        [Display(Name = "کد رهگیری پستی")]
        [MaxLength(50)]
        public string PostBarCode{ get; set; }



        [ForeignKey(nameof(PostID))]
        public virtual TblTypePost TblTypePost { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }
    }
}
