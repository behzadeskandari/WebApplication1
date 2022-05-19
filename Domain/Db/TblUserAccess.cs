using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Db
{
    public class TblUserAccess
    {

        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public int AcccessID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser TblUser { get; set; }

        [ForeignKey(nameof(AcccessID))]
        public virtual TblAccess TblAccess { get; set; }
    }
}
