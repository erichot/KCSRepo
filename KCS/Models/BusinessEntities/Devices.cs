using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public delegate void DeviceTraceDelegate(int slaveID,string traceMessage);
    public delegate void AddTransactionDelegate();
    public delegate void DeviceStatusDelegate();
    public delegate void DeviceGetFingerDelegate();
    public class Devices :  DeviceBrief
    {
        public DeviceTraceDelegate DeviceTraceEvent;
        public AddTransactionDelegate AddTransactionEvent;
        public DeviceStatusDelegate DeviceStatusEvent;
        public DeviceGetFingerDelegate DeviceGetFingerEvent;
        //[Key]
        //public int SlaveSID {get;set;}
        
        //public string IP {get;set;}
        public string IP_Internal {get;set;}
        public string ListField {get;set;}
       // [StringLength(30)]
        //public string SlaveName{get;set;}
       // [StringLength(255)]
       // public string SlaveDescription{get;set;}
        public bool IsEnabled{get;set;}
        public bool RebootDeviceFlag{get;set;}
        public bool ResetToDefault{get;set;}
        public int SlaveCategoryID{get;set;}
        public string SlaveCategoryName{get;set;}
        public bool IsServerMode{get;set;}
        public bool NotPropagateWithUsersByDefault { get; set; }
        
        public int UserCounts { get; set; }
        public int UserReplicatedCount { get; set; }
        public int FingersCounts { get; set; }
        public int FingersReplicatedCounts { get; set; }
        public bool OnlineOrNot { get; set; }

        public string DeviceType { get; set; }

        // public Queue<string> TraceQuene { get; set; }
        public Image DeviceStatsImage
        {
            get
            {
                if (IsEnabled)
                {
                    if (OnlineOrNot )
                    {
                        return Properties.Resources.device_online;
                    }
                    else
                    {
                        return Properties.Resources.device_offline;
                    }
                }
                else
                {
                    return Properties.Resources.device_disable;
                }
                return null;
            }
        }
        public string ServerMode
        {
            get
            {
                if (!IsServerMode)
                {
                    // Modified:    2023/06/27
                    // Ver:         1.1.5.9
                    //return "Server Mode";
                    return "Pull Sync";
                }
                else
                {
                    // Modified:    2023/06/27
                    // Ver:         1.1.5.9
                    //return "Client Mode";
                    return "Push Sync";
                }
            }
        }

        
       
        public Devices()
        {
            this.SlaveSID = 0;
           // this.ID = 0;
            this.IP = "";
            this.IP_Internal = "";
            this.SlaveName = "";
            this.SlaveDescription = "";
            this.IsEnabled = true;
            this.ResetToDefault = false;
            this.SlaveCategoryID = 0;
            this.SlaveCategoryName = "";
            this.IsServerMode = false;
            this.NotPropagateWithUsersByDefault = false;
            this.DeviceType = "Finger";



        }
        public Devices(Devices device)
        {
            
            this.SlaveSID = device.SlaveSID;
            //this.ID = device.ID;
            this.IP = device.IP;
            this.IP_Internal = device.IP_Internal;
            this.SlaveName = device.SlaveName;
            this.SlaveDescription = device.SlaveDescription;
            this.IsEnabled = device.IsEnabled;
            this.ResetToDefault = device.ResetToDefault;
            this.SlaveCategoryID = device.SlaveCategoryID;
            this.SlaveCategoryName = device.SlaveCategoryName;
            this.IsServerMode = device.IsServerMode;
            this.NotPropagateWithUsersByDefault = device.NotPropagateWithUsersByDefault;
            this.Language = device.Language;
            this.WorkMode = device.WorkMode;
            this.MenuPwd = device.MenuPwd;
            this.DeviceType = device.DeviceType;
            
           

        }
        public Devices(int sid, string ip,string IP_Internal, string SlaveName,string SlaveDescription,bool IsEnabled,bool ResetToDefault,
            int SlaveCategoryID, string SlaveCategoryName, bool IsServerMode, bool NotPropagateWithUsersByDefault)
        {

            this.SlaveSID = sid;
            //this.ID = id;
            this.IP = ip;
            this.IP_Internal = IP_Internal;
            this.SlaveName = SlaveName;
            this.SlaveDescription = SlaveDescription;
            this.IsEnabled = IsEnabled;
            this.ResetToDefault = ResetToDefault;
            this.SlaveCategoryID = SlaveCategoryID;
            this.SlaveCategoryName = SlaveCategoryName;
            this.IsServerMode = IsServerMode;
            this.NotPropagateWithUsersByDefault = NotPropagateWithUsersByDefault;
            
            
        }
        public void InitDevice()
        {
           // this.TraceQuene = new Queue<string>();
            this.OnlineOrNot = false;
        }
        //public void PushTraceMessage(string message)
        //{
        //    TraceQuene.Enqueue(message);
        //    if (TraceQuene.Count >= 100)
        //    {
        //        TraceQuene.Dequeue();
        //    }
        //}
        public override int GetHashCode()
        {
            return this.IP.GetHashCode() | this.SlaveSID;
        }
       
    }
}
