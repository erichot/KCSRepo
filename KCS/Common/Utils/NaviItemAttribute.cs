using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KCS.Common.Utils
{
    public class NaviGroupAttribute : Attribute
    {
        private string naviGroupName;
        public NaviGroupAttribute(string groupName)
        {
            naviGroupName = groupName;
        }
        public string NaviGroupName { get { return naviGroupName; } set { naviGroupName = value; } }
        public static string GetEnumGroupName(Enum val)
        {
            Type type = val.GetType();
            FieldInfo fd = type.GetField(val.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(NaviGroupAttribute), false);
            string name = string.Empty;
            foreach (NaviGroupAttribute attr in attrs)
            {
                name = attr.NaviGroupName;
            }
            return name;
        }
    }
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举的备注信息
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string GetGroupName(this Enum em)
        {
            Type type = em.GetType();
            FieldInfo fd = type.GetField(em.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(NaviGroupAttribute), false);
            string name = string.Empty;
            foreach (NaviGroupAttribute attr in attrs)
            {
                name = attr.NaviGroupName;
            }
            return name;
        }
    }
}
