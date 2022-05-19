using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class AddToCartEntity
    {
        [RegularExpression(@"[\d\-]+")]
        public string ProductID { get; set; }

        [RegularExpression(@"[\d,]*")]
        public string Prop { get; set; }

        [RegularExpression("[t|f]")]
        public string JustRefresh { get; set; }
    }

}
