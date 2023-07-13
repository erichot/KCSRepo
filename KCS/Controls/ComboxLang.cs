using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Controls
{
    class ComboxLang
    {
        public string Text { set; get; }

        public string Value { set; get; }

        public ComboxLang()
        {
        }
        public ComboxLang(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }
        public override string ToString()
        {

            return Text;

        }
    }
}
