using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class Elevator : DatabaseObject
    {
        [Key]
        public int EleavatorID { get; set; }
        [Required]
        public int SlaveSID { get; set; }

        public string EleavatorName { get; set; }
        public string EleavatorDes { get; set; }

        public Elevator()
        {
            this.EleavatorID = 0;
            this.SlaveSID = 0;
            this.EleavatorName = "";
            this.EleavatorDes = "";


        }
        public Elevator(Elevator elevator)
        {
            this.EleavatorID = elevator.EleavatorID;
            this.SlaveSID = elevator.SlaveSID;
            this.EleavatorName = elevator.EleavatorName;
            this.EleavatorDes = elevator.EleavatorDes;
        }
    }
}
