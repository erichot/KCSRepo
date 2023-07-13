using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public interface ISlaveCategory
    {
        int SlaveCategoryID { get; set; }
        string SlaveCategoryName { get; set; }
    }
}
