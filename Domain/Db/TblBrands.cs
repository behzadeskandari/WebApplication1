using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblBrands
    {
        public int ID { get; set; }

        public int? TopicID { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string  Title { get; set; }
        public int ImageID { get; set; }


        [ForeignKey(nameof(ImageID))]
        public virtual TblImage TblImage { get; set; }

        [ForeignKey(nameof(TopicID))]
        public virtual TblTopic TblTopic { get; set; }

        public virtual ICollection<TblProducts> TblProducts { get; set; }
    }
}