using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class CartVm
    {
        public string Count { get; set; }
        public string TotalPrice { get; set; }
        public List<ProductInCartVM> ProductInCartVM { get; set; }
    }
}
