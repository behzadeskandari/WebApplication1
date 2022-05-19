using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class VmProductDetails
    {
        public int ID { get; set; }
        public string TitleFa { get; set; }
        public string TitleEn { get; set; }
        public int Star { get; set; }
        public string RatingAvg { get; set; }
        public string GuruntyName { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Evaluation { get; set; }
        public string StatusTitle { get; set; }
        public string StatusImgUrl { get; set; }
        public string Price { get; set; }
        public string SavePrice { get; set; }
        public string CountBoonUsed { get; set; }

        public bool Favo { get; set; }
        public bool Noti { get; set; }


        public List<ProductProperty> ListProperty { get; set; }
        public List<ProductImage> ListProductImg { get; set; }
        public List<TechnicalProperty> ListTechnicalProperty { get; set; }
        public List<OtherProduct> ListOtherProduct { get; set; }
        public LstComment ListComment { get; set; }
        public LstAsks ListAsks { get; set; }
    }

}
