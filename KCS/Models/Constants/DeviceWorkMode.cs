using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class DeviceWorkMode
    {
        public static string TaMode = "TA";
        public static string AcMode = "AC";
        public static string Ta6Mode = "TA 6";

        public int this[string name]
        {
            get
            {
                if (name.Equals(TaMode))
                {
                    return 2;
                }
                else if (name.Equals(AcMode))
                {
                    return 1;
                }
                else if (name.Equals(Ta6Mode))
                {
                    return 6;
                }
                else
                {
                    return 0;
                }
            }
         
        }
        public string this[int workmode]
        {
            get
            {
                if (workmode == 2)
                {
                    return TaMode;
                }
                else if (workmode == 1)
                {
                    return AcMode;
                }
                else if (workmode == 6)
                {
                    return Ta6Mode;
                }
                else
                {
                    return AcMode;
                }
            }
        }
    }
}
