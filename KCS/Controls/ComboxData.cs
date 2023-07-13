using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Controls
{
    class ComboxData
    {

        public string Text { set; get; }

        public int Value { set; get; }

        public ComboxData()
        {
        }
        public ComboxData(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString()
        {

            return Text;

        }
    }
}
