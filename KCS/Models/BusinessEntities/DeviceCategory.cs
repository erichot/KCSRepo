using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class SlaveCategory : ISlaveCategory
    {
        public int SlaveCategoryID { get; set; }
        public string SlaveCategoryName { get; set; }
        public string ListFiled {
            get
            {
                return SlaveCategoryID.ToString() + ":" + SlaveCategoryName;
            }
        }
    }
}
