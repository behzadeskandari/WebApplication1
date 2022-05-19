using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{

    public class LstComment
    {
        public int Take { get; set; }
        public int CountAllPage { get; set; }
        public int CurrentPage { get; set; }
        public int AvgItem1 { get; set; }
        public int AvgItem2 { get; set; }
        public int AvgItem3 { get; set; }
        public int AvgItem4 { get; set; }
        public int AvgItem5 { get; set; }
        public int AvgItem6 { get; set; }
        public List<Comment> Comments { get; set; }
    }

}
