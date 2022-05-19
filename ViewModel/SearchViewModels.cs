using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class SearchViewModels
    {
        public List<STopics> LstTopic { get; set; }
        public List<SProduct> LstProduct { get; set; }
    }

    public class STopics
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }

    public class SProduct
    {
        public int ID { get; set; }
        public string TitleEn { get; set; }
        public string TitleFa { get; set; }
        public string ImageUrl { get; set; }
    }

}
