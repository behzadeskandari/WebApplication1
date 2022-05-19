using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Db
{
    public class TblPropertiseTitle
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblPropertis> TblPropertis { get; set; }
    }
}
