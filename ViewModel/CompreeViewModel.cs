using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class CompreeViewModel
    {
        public int ID { get; set; }
        public string TitleEn { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<CompreeTecnicalViewModel> LstProp { get; set; }
    }
}
