using KCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Sync
{
    public class BridgeUtility
    {
        #region LOCKERS
        public static readonly object insertTransLocker = new object();
        #endregion
        protected static List<Transactions> ReadTransList = new List<Transactions>();
        

        protected static int _portNumber = 1868;
        protected static TerminalsCollection _terminalList = new TerminalsCollection();

        public static List<Transactions> GetReadTransactionsLists()
        {
            return ReadTransList;
        }
        public static void RefreshTerminalSyncStasus()
        {
            foreach (var terminal in _terminalList)
            {
                terminal.RefreshSyncStasus();
            }
        }
        public static void RefreshDeviceFingerStatus()
        {
            foreach (var terminal in _terminalList)
            {
                terminal.RefreshFingerStatus();
            }
        }
        public static void ReleaseAllDevice()
        {
            foreach (var terminal in _terminalList)
            {
                terminal.Dispose();
            }
        }
        public static void AddTerminalToList(Terminal terminal)
        {
            _terminalList.Add(terminal);
        }
        public static void RemoveTerminalFromList(Terminal terminal)
        {
            _terminalList.Remove(terminal);
        }
        public static List<Terminal> GetDeviceLists()
        {
            return _terminalList.GetDeviceLists();
        }
        public static void DeleteTerminal(Devices device)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == device.SlaveSID);
            _terminalList.Remove(terminal);
            terminal.Dispose();
        }
        public static void RefreshTerminal(Devices device)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == device.SlaveSID);
            terminal.RefreshSyncStasus();
            
        }
        public static DoorPIN GetOpenDoorPin(int deviceSid)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == deviceSid);
            return terminal.GetOpenDoorPin();
        }
        public static bool SetOpenDoorPin(int deviceSid, DoorPIN pin)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == deviceSid);
            return terminal.UpdateDoorPIN(pin);
        }
        public static void SetOpenDoorPinOk(int deviceSid)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == deviceSid);
            terminal.SetDoorPINOk();
        }
        public static void OpenDoor(int deviceSid)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == deviceSid);
            terminal.OpenDoor();
        }
        public static void ReReadDeviceTrans(int deviceSid, DateTime dateStart, DateTime dateEnd, DateTime timeStart, DateTime timeEnd)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == deviceSid);
            terminal.ReReadTransactions(dateStart, dateEnd, timeStart, timeEnd);
        }
        public static void UpdateTerminal(Devices device)
        {
            Terminal terminal = _terminalList.FirstOrDefault(f => f.deviceContext.SlaveSID == device.SlaveSID);

            //工作模式切换 
            if (terminal.deviceContext.IsServerMode != device.IsServerMode)
            {
                if (device.IsServerMode)
                {
                    if (terminal.Client != null)
                        terminal.Client.Disconnect();
                    terminal.SwitchToServerMode();
                }
                else
                {
                    terminal.SwitchToClientMode();
                }
            }

            if (!terminal.deviceContext.IP.Equals(device.IP))
            {
                terminal.deviceContext.IP = device.IP;
                if (terminal.Client != null)
                terminal.Client.Disconnect();
            }
            
            terminal.deviceContext.IsServerMode = device.IsServerMode;
            terminal.deviceContext.SlaveCategoryID = device.SlaveCategoryID;
            terminal.deviceContext.SlaveName = device.SlaveName;
            terminal.deviceContext.SlaveDescription = device.SlaveDescription;
            terminal.deviceContext.IsEnabled = device.IsEnabled;
            terminal.deviceContext.ResetToDefault = device.ResetToDefault;
            terminal.RefreshSyncStasus();
            
        }
        
        
     }
    public class TerminalsCollection : IEnumerable<Terminal>
    {
        private List<Terminal> m_terminals;

        internal TerminalsCollection()
        {
            m_terminals = new List<Terminal>();
        }
        public List<Terminal> GetDeviceLists()
        {
            return m_terminals;
        }
        public IEnumerator<Terminal> GetEnumerator()
        {
            return m_terminals.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_terminals.GetEnumerator();
        }

        internal void Add(Terminal terminal)
        {
            m_terminals.Add(terminal);
        }
        internal void Remove(Terminal terminal)
        {
            m_terminals.Remove(terminal);
        }

        

        public int Count
        {
            get { return m_terminals.Count; }
        }
    }
}
