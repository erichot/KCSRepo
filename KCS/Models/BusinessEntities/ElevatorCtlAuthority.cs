using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class ElevatorCtlAuthority
    {
        public string UserID { get; set; }
        public string DepartmentID { get; set; }        //[Required]
        public string DepartmentName { get; set; }
        public string UserName { get; set; }
        public string CardID { get; set; }

        public byte AllowTimeStartHour { get; set; }
        public byte AllowTimeStartMinute { get; set; }
        public byte AllowTimeEndHour { get; set; }
        public byte AllowTimeEndMinute { get; set; }
        public byte GroupID { get; set; }

        public bool Authority_B1
        {
            get
            {
                if ((GroupID & 0x80) == 0x80)
                    return (GroupID & 0x01) == 0x01;
                else
                    return false;
            }
        }
        public bool Authority_F1
        {
            get
            {
                if ((GroupID & 0x80) == 0x80)
                    return (GroupID & 0x02) == 0x02;
                else
                    return false;
            }
        }
        public bool Authority_F2
        {
            get
            {
                if ((GroupID & 0x80) == 0x80)
                    return (GroupID & 0x04) == 0x04;
                else
                    return false;
            }
        }
        public bool Authority_F3
        {
            get
            {
                if ((GroupID & 0x80) == 0x80)
                    return (GroupID & 0x08) == 0x08;
                else
                    return false;
            }
        }
        public bool Authority_F4
        {
            get
            {
                if ((GroupID & 0x80) == 0x80)
                    return (GroupID & 0x10) == 0x10;
                else
                    return false;
            }
        }
        public bool Authority_F5
        {
            get
            {
                if ((GroupID & 0x80) == 0x80)
                    return (GroupID & 0x20) == 0x20;
                else
                    return false;
            }
        }
        public string StartTime
        {
            get
            {
                return AllowTimeStartHour.ToString() + ":" + AllowTimeStartMinute.ToString();
            }
        }
        public string EndTime
        {
            get
            {
                return AllowTimeEndHour.ToString() + ":" + AllowTimeEndMinute.ToString();
            }
        }
    }
}
