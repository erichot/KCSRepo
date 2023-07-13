using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class ElevatorController : Elevator
    {
        
        public string IP { get; set; }
        public string SlaveName { get; set; }
        
    }
}
