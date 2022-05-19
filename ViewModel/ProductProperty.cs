using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class ProductProperty
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<ProductPropertyDetails> ProductPropertyDetails { get; set; }
    
    }

}
