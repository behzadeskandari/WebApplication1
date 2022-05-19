using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class MainSearchVM
    {
        public List<Brand> Brands { get; set; }
        public List<PropertyTitle> LstPropertyTitles { get; set; }
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
    }
}
