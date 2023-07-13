using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Extensions
{
    /* Add: 2023/01/22
    * By:  Eric
    * Ver: 1.1.5.7
    */
    public static class DataBasedExtension
    {


        /* Add: 2023/01/22
        * By:  Eric
        * Ver: 1.1.5.7
        */
        /// Returns the last few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// the string to process/// Number of characters to return/// 
        public static string Right(this string s, int length)
        {
            length = Math.Max(length, 0);

            if (s.Length > length)
            {
                return s.Substring(s.Length - length, length);
            }
            else
            {
                return s;
            }
        }



        public static string GetStdString(this DateTime _dateValue)
        {
            return _dateValue.ToString("yyyy-MM-dd");
        }







    }
}
