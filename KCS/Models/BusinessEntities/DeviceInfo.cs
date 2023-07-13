using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public class DeviceInfo : DeviceBrief
    {

        //public int SlaveSID { get; set; }
        
        public int ID {get;set;}
       // public string IP {get;set;}
        public string IP_Internal {get;set;}
      
        
        //public string SlaveName{get;set;}
        
        //public string SlaveDescription{get;set;}
        public bool IsSyncOrNot { get; set; }
        public bool UserIsReplicated { get; set; }
        public bool Finger1IsReplicated { get; set; }
        public bool Finger2IsReplicated { get; set; }

        public DeviceInfo()
        {
            this.SlaveSID = 0;
            this.ID = 0;
            this.IP = "";
            this.IP_Internal = "";
            this.SlaveName = "";
            this.SlaveDescription = "";
                

        }
        public DeviceInfo(DeviceInfo device)
        {

            this.SlaveSID = device.SlaveSID;
            this.ID = device.ID;
            this.IP = device.IP;
            this.IP_Internal = device.IP_Internal;
            this.SlaveName = device.SlaveName;
            this.SlaveDescription = device.SlaveDescription;
            
           

        }
        public DeviceInfo(int salveid,int id, string ip, string IP_Internal, string SlaveName, string SlaveDescription)
        {

            this.SlaveSID = salveid;
            this.ID = id;
            this.IP = ip;
            this.IP_Internal = IP_Internal;
            this.SlaveName = SlaveName;
            this.SlaveDescription = SlaveDescription;
           
            
        }
        public override int GetHashCode()
        {
            return this.IP.GetHashCode() | this.SlaveSID;
        }
    }
}
