using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class LstAsks
    {
        public int Take { get; set; }
        public int CountAllPage { get; set; }
        public int CurrentPage { get; set; }
        public List<Asks> Asks { get; set; }
    }

}
