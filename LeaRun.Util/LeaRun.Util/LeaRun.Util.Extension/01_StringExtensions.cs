using System;
using System.Text.RegularExpressions;

namespace LeaRun.Util.Extension
{
    public static class StringExtensions
    {
        public static bool Eq(this string input, string toCompare, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            if (input == null)
            {
                return toCompare == null;
            }
            return input.Equals(toCompare, comparison);
        }
        
        public static Guid? ToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            Guid id;
            if (Guid.TryParse(str, out id))
            {
                return id;
            }
            return null;
        }

        public static int? ToInt32(this string str)
        {
            int value;
            if (int.TryParse(str, out value))
            {
                return value;
            }
            return null;
        }
        
        public static bool IsEmail(this string value)
        {
            var reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return string.IsNullOrEmpty(value) == false && reg.IsMatch(value);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsNullOrEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool EqualsIgnoreCase(this string v1, string v2)
        {
            return string.Equals(v1, v2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
