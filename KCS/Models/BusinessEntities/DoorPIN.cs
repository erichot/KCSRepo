using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class DoorPIN : DatabaseObject
    {
        [Key]
        public int SlaveSID {get;set;}
        [Required]
        public string PIN1Name { get; set; }
        public byte PIN1Code { get; set; }
        [Required]
        public string PIN1StartDate { get; set; }
        [Required]
        public int PIN1StartHour { get; set; }
        [Required]
        public int PIN1StartMinute { get; set; }
        [Required]
        public string PIN1EndDate { get; set; }
        [Required]
        public int PIN1EndHour { get; set; }
        [Required]
        public int PIN1EndMinute { get; set; }
       
        public string PIN1 { get; set; }
 
        public string PIN2Name { get; set; }
        public byte PIN2Code { get; set; }

        public string PIN2StartDate { get; set; }

        public int PIN2StartHour { get; set; }
        
        public int PIN2StartMinute { get; set; }

        public string PIN2EndDate { get; set; }

        public int PIN2EndHour { get; set; }
       
        public int PIN2EndMinute { get; set; }
      
        public string PIN2 { get; set; }

        public DoorPIN()
        {

            this.SlaveSID = 0;
            this.PIN1Name = "1";
            this.PIN1Code = 1;
            this.PIN1StartDate = "2019-07-30";
            this.PIN1StartHour = 0;
            this.PIN1StartMinute = 0;
            this.PIN1EndDate = "2019-07-30";
            this.PIN1EndHour = 23;
            this.PIN1EndMinute = 59;
            this.PIN1 = "";
            this.PIN2Name = "2";
            this.PIN2Code = 2;
            this.PIN2StartDate = "";
            this.PIN2StartHour = 0;
            this.PIN2StartMinute = 0;
            this.PIN2StartDate = "";
            this.PIN2EndHour = 0;
            this.PIN2EndMinute = 0;
            this.PIN2 = "";


        }

        public DoorPIN(DoorPIN pin)
        {

            this.SlaveSID = pin.SlaveSID;
            this.PIN1Name = pin.PIN1Name;
            this.PIN1Code = pin.PIN1Code;
            this.PIN1StartDate = pin.PIN1StartDate;
            this.PIN1StartHour = pin.PIN1StartHour;
            this.PIN1StartMinute = pin.PIN1StartMinute;
            this.PIN1EndDate = pin.PIN1EndDate;
            this.PIN1EndHour = pin.PIN1EndHour;
            this.PIN1EndMinute = pin.PIN1EndMinute;
            this.PIN1 = pin.PIN1;
            this.PIN2Name = pin.PIN2Name;
            this.PIN2Code = pin.PIN2Code;
            this.PIN2StartDate = pin.PIN2StartDate;
            this.PIN2StartHour = pin.PIN2StartHour;
            this.PIN2StartMinute = pin.PIN2StartMinute;
            this.PIN2EndDate = pin.PIN2EndDate;
            this.PIN2EndHour = pin.PIN2EndHour;
            this.PIN2EndMinute = pin.PIN2EndMinute;
            this.PIN2 = pin.PIN2;
           

        }
    }
}
