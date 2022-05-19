using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblSettings
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان سایت")]
        [MaxLength(100)]
        public string SiteTitle { get; set; }

        [Display(Name = "توضیحات سایت")]
        [MaxLength(200)]
        public string SiteDescreption { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(100)]
        public string SiteKeyWords { get; set; }

        [Display(Name = "ایکن سایت")]
        [MaxLength(100)]
        public string FavoIcon { get; set; }

        [Display(Name = "لوگوی سایت")]
        [MaxLength(100)]
        public string Brand { get; set; }

        [Display(Name = "مقدار تخفیف")]
        public int BoonValue { get; set; }

        [Display(Name = "مدت زمان اعتبار تخفیف")]
        public int ValidBoonPerDay { get; set; }

        [Display(Name = "تعداد نظر در صفحه")]
        public int CountCommentPerPage { get; set; }

        [Display(Name = "تعداد پرسش در صفحه")]
        public int CountAskPerPage { get; set; }

        [Display(Name = "فقط نمایش نظرات تایید شده")]
        public bool OnlyShowConfirmedComment { get; set; }

    }
}
