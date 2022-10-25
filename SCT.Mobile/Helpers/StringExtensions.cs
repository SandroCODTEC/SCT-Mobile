using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCT.Mobile.Helpers
{
    public static class StringExtensions
    {
        public static string GetFirstsLetter(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            var words = value.Split(" ");
            var wordlength = words.Length > 1 ? 2 : 1;
            var fl = "";
            if (wordlength > 1)
            {
                for (int i = 0; i < wordlength; i++)
                {
                    fl = string.Concat(fl, words[i].AsSpan(0, 1));
                }
            }
            else
            {
                if (value.Length > 1)
                    fl = string.Concat(fl, value.AsSpan(0, 2));
                else
                    fl = string.Concat(fl, value.AsSpan(0, 1));

            }
            return fl.ToUpper();
        }
    }
}
