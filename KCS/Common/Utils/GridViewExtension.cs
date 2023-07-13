using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace KCS.Common.Utils
{
    public static class GridViewExtension
    {

        
        /// <summary>
        /// CustomColumnDisplayText Helper
        /// </summary>
        /// <param name="girdview">GridView</param>
        /// <param name="fieldNameHandler">委托</param>
        /// <param name="dispalyTextHandler">展现文字</param>
        /// <param name="e">CustomColumnDisplayTextEventArgs</param>
        public static void CusColDisplayTextHelper(this GridView girdview, Predicate<string> fieldNameHandler, Func<object, string> dispalyTextHandler, CustomColumnDisplayTextEventArgs e)
        {
            if (fieldNameHandler(e.Column.FieldName))
            {
                e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.DisplayText = dispalyTextHandler(e.Value);
            }
        }
        /// <summary>
        /// CustomColumnDisplayText Helper
        /// </summary>
        /// <param name="girdview">GridView</param>
        /// <param name="valueHandler">委托</param>
        /// <param name="dispalyTextHandler">委托</param>
        /// <param name="e">CustomColumnDisplayTextEventArgs</param>
        public static void CusColDisplayTextHelper(this GridView girdview, Func<object, Type, bool> valueHandler, Func<object, string> dispalyTextHandler, CustomColumnDisplayTextEventArgs e)
        {
            if (valueHandler(e.Value, e.Value.GetType()))
            {
                e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.DisplayText = dispalyTextHandler(e.Value);
            }
        }
        /// <summary>
        ///CustomColumnDisplayText Helper
        /// </summary>
        /// <param name="girdview">GridView</param>
        /// <param name="valueHandler">委托</param>
        /// <param name="curdispalyText">展现文字</param>
        /// <param name="e">CustomColumnDisplayTextEventArgs</param>
        public static void CusColDisplayTextHelper(this GridView girdview, Func<object, Type, bool> valueHandler, string curdispalyText, CustomColumnDisplayTextEventArgs e)
        {
            if (valueHandler(e.Value, e.Value.GetType()))
            {
                e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.DisplayText = curdispalyText;
            }
        }
    }
}
