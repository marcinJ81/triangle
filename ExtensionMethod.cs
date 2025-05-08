using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3
{
    public static class StringExtensions
    {
       
        public static string ReplaceDotWithComma(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            return input.Replace('.', ',');
        }
    }
}
