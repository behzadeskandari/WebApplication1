using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UtilitySpace
{
    public static class StringEx
    {
        public static string Replace(this string val,string Pattern,string NewValue) 
        {
            Regex reg = new Regex(Pattern);

            string MyValue = val;

            var Matches = reg.Matches(val);
            foreach (Match item in Matches)
            {
                MyValue = MyValue.Replace(item.Value,NewValue);
            }
            return MyValue;
        } 
    }
}
