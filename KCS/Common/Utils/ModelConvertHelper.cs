using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace KCS.Common.Utils
{
      public class ModelConvertHelper<T> where T : new()
        {
            public static IList<T> ConvertToModel(DataTable dt)
            {
                // 定义集合    
                IList<T> ts = new List<T>();

                // 获得此模型的类型   
                Type type = typeof(T);
                string tempName = "";

                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    // 获得此模型的公共属性      
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;  // 检查DataTable是否包含此列    

                        if (dt.Columns.Contains(tempName))
                        {
                            // 判断此属性是否有Setter      
                            if (!pi.CanWrite) continue;

                            object value = dr[tempName];
                            if (value != DBNull.Value)
                            {
                                if (typeof(DateTime).IsAssignableFrom(pi.PropertyType))
                                {
                                    pi.SetValue(t, Convert.ToDateTime(value), null);
                                }
                                else if (typeof(Image).IsAssignableFrom(pi.PropertyType))
                                {
                                    try
                                    {
                                        byte[] mybyte = null;
                                        //读取数据保存到数组中  
                                        mybyte = (byte[])value;
                                        Image image;
                                        //读取数组数据成为文件流  
                                        MemoryStream mymemorystream = new MemoryStream(mybyte);
                                        //转换成为图片格式。  
                                        image = Image.FromStream(mymemorystream, true);
                                        pi.SetValue(t, image, null);
                                        mymemorystream.Close();  //关闭流  
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        pi.SetValue(t, value, null);
                                    }
                                    catch
                                    {
                                        pi.SetValue(t, value.ToString(), null);
                                    }

                                }
                                
                            }
                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
        }    
    
}
