using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.Common
{
    public static class StringExtention
    {
        public static string AutoEllipses(this string str, int lenght)
        {
            if (str.Length > lenght)
            {
                return string.Format("{0}...", str.Substring(0, lenght));
            }
            return str;
        }
    }
}
