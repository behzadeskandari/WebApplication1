using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Db
{
    public class TblAccess
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblUserAccess> TblUserAccess { get; set; }
    }
}
