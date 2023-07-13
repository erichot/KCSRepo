using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class TrunWorkBase : DatabaseObject
    {
        [Required]
        public string TURNWORK_GRP { get; set; }
        public string TURNWORK_DESC { get; set; }
    }
}
