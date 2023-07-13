using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class RegDevice
    {
        public string DeviceType { get; set; }
        public string DeviceVersion { get; set; }
        public int SlaveSID { get; set; }       
        public string IP { get; set; }
        public bool Registered { get; set; }
        public RegDevice(string DeviceType, string DeviceVersion,int id, string ip)
        {
            this.DeviceType = DeviceType;
            this.DeviceVersion = DeviceVersion;
            this.SlaveSID = id;
            this.IP = ip;
            this.Registered = false;
        }
        public static bool operator ==(RegDevice op1, RegDevice op2)
        {
            if (op1.IP == op2.IP && op1.SlaveSID == op2.SlaveSID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(RegDevice op1, RegDevice op2)
        {

            return !(op1 == op2);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is RegDevice)
            {
                var op1 = obj as RegDevice;
                if (op1.IP == this.IP && op1.SlaveSID == this.SlaveSID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        public override int GetHashCode()
        {
            return this.IP.GetHashCode() | SlaveSID;
        }
    }
}
