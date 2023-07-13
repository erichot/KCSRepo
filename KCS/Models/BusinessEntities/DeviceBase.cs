using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class DeviceBase : DatabaseObject
    {
        [Key]
        public int SlaveSID { get; set; }
        public string IP { get; set; }
        [StringLength(30)]
        public string SlaveName { get; set; }
        [StringLength(255)]
        public string SlaveDescription { get; set; }

        public string Details
        {
            get
            {
                return SlaveSID + "," + IP + "," + SlaveName;
            }
        }
    }
}
