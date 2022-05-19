using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblMenus
    {
        [Key]
        public int ID { get; set; }
        public int ParrentID { get; set; }
        public string Title { get; set; }
        public int Sort { get; set; }
    }
}
