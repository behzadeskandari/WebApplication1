using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblSpical
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }


        public virtual ICollection<TblProducts> TblProducts { get; set; }
    }
}
