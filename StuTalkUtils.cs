using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UoLSitsFunctions
{
    public static class StuTalkUtils
    {
        public static IEnumerable<string> splitStuTalkResults(this string results, string firstFieldCode)
        {
            return Regex.Split(results, @"\d\d\d\d\d\d=" + firstFieldCode + "=");
        }
    }
}
