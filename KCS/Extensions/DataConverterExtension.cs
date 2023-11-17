using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Text.RegularExpressions;

namespace KCS.Extensions
{
    public static class DataConverterExtension
    {





        public static bool ToBool(this bool? _value)
        {
            return (_value != null) ? (bool)_value : false;
        }


        public static bool ToBool(this string _value)
        {
            var result = false;
            if (!string.IsNullOrEmpty(_value))
            {
                if (int.TryParse(_value, out int num))
                {
                    if (num != 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    if (_value.ToString().ToLower() == "true")
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        public static bool ToBoolWithNull(this string _value)
        {
            return (_value == null) ? false : ToBool(_value);
        }




        public static short ToShort(this short _value)
        {
            return (_value != null) ? (short)_value : (short)0;
        }

        public static int ToInt(this int _value)
        {
            return (_value != null) ? (int)_value : 0;
        }
        public static int ToInt(this short _value)
        {
            return (_value != null) ? (int)_value : 0;
        }

        public static int ToInt(this string _value)
        {
            if (string.IsNullOrEmpty(_value) == false)
            {
                if (int.TryParse(_value, out int _outValue))
                {
                    return _outValue;
                }
            }

            return 0;
        }

        public static int ToInt(this object _value)
        {
            if (_value != null && string.IsNullOrEmpty(_value.ToString()) == false)
            {
                if (int.TryParse(_value.ToString(), out int _outValue))
                {
                    return _outValue;
                }
            }

            return 0;
        }





















        public static DateTime ToDate(this DateTime? _value)
        {
            return (_value != null) ? ((DateTime)_value).Date : DateTime.MaxValue;
        }






        //public static string ToSimpleTaiwanDate(this DateTime? _datetime)
        //{
        //    if (_datetime == null)
        //        return string.Empty;

        //    TaiwanCalendar taiwanCalendar = new TaiwanCalendar();

        //    var datetime = (DateTime)_datetime;
        //    return string.Format("{0}//{1}/{2}",
        //                         taiwanCalendar.GetYear(datetime),
        //                         datetime.Month.ToString("00"),
        //                         datetime.Day.ToString("00"));
        //}














        public static bool IsNullOrDefault(this int _value)
        {
            if ((int)_value == default(int))
                return true;

            return false;
        }
        public static bool IsNullOrDefault(this int? _value)
        {
            if (_value == null)
                return true;

            if ((int)_value == default(int))
                return true;

            return false;
        }
        public static bool IsNullOrDefault(this short? _value)
        {
            if (_value == null)
                return true;

            if ((short)_value == default(short))
                return true;

            return false;
        }
        public static bool IsNullOrDefault(this short _value)
        {
            if ((short)_value == default(short))
                return true;

            return false;
        }
        public static bool IsNullOrDefault(this byte? _value)
        {
            if (_value == null)
                return true;

            if ((byte)_value == default(byte))
                return true;

            return false;
        }
        public static bool IsNullOrDefault(this byte _value)
        {
            if ((byte)_value == default(byte))
                return true;

            return false;
        }




        public static bool IsNullOrDefault(this DateTime? _value)
        {
            if (_value == null)
                return true;

            if ((DateTime)_value == default(DateTime))
                return true;

            return false;
        }
        public static bool IsNullOrDefault(this DateTime _value)
        {
            if ((DateTime)_value == default(DateTime))
                return true;

            return false;
        }















        public static string RemoveSpecialChars(this string _value)
        {
            return Regex.Replace(_value, "[^0-9A-Za-z _-]", "");
        }

        public static string ToJSMessage(this string _value)
        {
            return Regex.Replace(_value, "[^0-9A-Za-z _-]", "");
        }

        /// <summary>
        ///     A char extension method that repeats a character the specified number of times.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="repeatCount">Number of repeats.</param>
        /// <returns>The repeated char.</returns>
        public static string Repeat(this char @this, int repeatCount)
        {
            return new string(@this, repeatCount);
        }




        //public static string Left(this string input, int count)
        //{
        //    return input.Substring(0, Math.Min(input.Length, count));
        //}
        ///// <summary>
        ///// Returns the right part of the string instance.
        ///// </summary>
        ///// <param name="count">Number of characters to return.</param>
        //public static string Right(this string input, int count)
        //{
        //    return input.Substring(Math.Max(input.Length - count, 0), Math.Min(count, input.Length));
        //}
        /// <summary>
        /// Returns the mid part of this string instance.
        /// </summary>
        /// <param name="start">Character index to start return the midstring from.</param>
        /// <returns>Substring or empty string when start is outside range.</returns>
        public static string Mid(this string input, int start)
        {
            return input.Substring(Math.Min(start, input.Length));
        }
        /// <summary>
        /// Returns the mid part of this string instance.
        /// </summary>
        /// <param name="start">Starting character index number.</param>
        /// <param name="count">Number of characters to return.</param>
        /// <returns>Substring or empty string when out of range.</returns>
        public static string Mid(this string input, int start, int count)
        {
            return input.Substring(Math.Min(start, input.Length), Math.Min(count, Math.Max(input.Length - start, 0)));
        }


























        public static ICollection<T> Clone<T>(this ICollection<T> _list) where T : ICloneable
        {
            return (
                from item in _list
                select (T)item.Clone()
                ).ToList();
        }
        public static List<T> Clone<T>(this List<T> _list) where T : ICloneable
        {
            return (
                from item in _list
                select (T)item.Clone()
                ).ToList();
        }
        //public static ICollection<T> DeepClone<T>(this ICollection<T> _list) where T : BOPCMSData.Interfaces.IDataCloneable<T>
        //{
        //    return (
        //        from item in _list
        //        select (T)item.Clone()
        //        ).ToList();
        //}
        //public static List<T> DeepClone<T>(this List<T> _list) where T : BOPCMSData.Interfaces.IDataCloneable<T>
        //{
        //    return (
        //        from item in _list
        //        select (T)item.Clone()
        //        ).ToList();
        //}














        public static TOut ParseOrDefault<TOut>(this string input)
        {
            return input.ParseOrDefault(default(TOut));
        }
        public static TOut ParseOrDefault<TOut>(this string input, TOut defaultValue)
        {
            Type type = typeof(TOut);
            MethodInfo parseMethod = type.GetMethod("Parse", new Type[] { typeof(string) });

            if (parseMethod != null)
            {
                var value = parseMethod.Invoke(null, new string[] { input });
                return (value is TOut ? (TOut)value : defaultValue);
            }
            else { return defaultValue; }
        }











    }
}
