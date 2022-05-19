using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UtilitySpace
{
    public class Utility
    {
        public string RemoveHtmlTag(string HtmlCode)
        {
            Regex reg = new Regex("<(.*?)>");
            var maches = reg.Matches(HtmlCode);

            foreach (Match item in maches)
            {
                HtmlCode = HtmlCode.Replace(item.Value, "");
            }

            return HtmlCode;
        }

        public string GetSafeHtml(string Html)
        {
            Regex reg = new Regex(@"<[\s]*script(.*?)>(.*?)<(.*?)script>", RegexOptions.Multiline);
            var q = reg.Matches(Html);

            foreach (Match item in q)
            {
                Html = Html.Replace(item.Value, "");
            }

            return Html;
        }
    }

}
