using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KCS.Common
{
    public abstract class RegexAttributeBase : DataTypeAttribute
    {
        protected const RegexOptions DefaultRegexOptions = RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase;

        readonly Regex regex;

        public RegexAttributeBase(string regex, string defaultErrorMessage, DataType dataType)
            : this(new Regex(regex, DefaultRegexOptions), defaultErrorMessage, dataType)
        {
        }
        public RegexAttributeBase(Regex regex, string defaultErrorMessage, DataType dataType)
            : base(dataType)
        {
            this.regex = (Regex)regex;
            this.ErrorMessage = defaultErrorMessage;
        }
        public sealed override bool IsValid(object value)
        {
            if (value == null)
                return true;
            string input = value as string;
            return input != null && regex.Match(input).Length > 0;
        }
    }
    public sealed class CardIDAttribute : RegexAttributeBase
    {
        static readonly Regex regex = new Regex(@"^\d{1,10}$", DefaultRegexOptions);
        const string Message = "The {0} field is not a valid card id.";
        public CardIDAttribute()
            : base(regex, Message, DataType.Custom)
        {
        }
    }
}
