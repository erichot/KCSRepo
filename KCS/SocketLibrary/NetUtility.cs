using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using KCS.Common.DAL;

namespace NetSockets
{
    public static class NetUtility
    {
        public static int ParsePort(string s)
        {
            return int.Parse(s);
        }
        public static bool TryParsePort(string s, out int port)
        {
            try
            {
                port = ParsePort(s);
                return true;
            }
            catch
            {
                port = 0;
                return false;
            }
        }
        public static bool Ping(string ip)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "Test Data!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000; // Timeout 时间，单位：毫秒  
            System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                return true;
            else
                return false;
        }  
        public static bool Ping(string host, int port)
        {
            return Ping(host, port, TimeSpan.MaxValue);
        }
        public static bool Ping(string host, int port, out TimeSpan elapsed)
        {
            return Ping(host, port, TimeSpan.MaxValue, out elapsed);
        }
        public static bool Ping(string host, int port, TimeSpan timeout)
        {
            TimeSpan elapsed;
            return Ping(host, port, timeout, out elapsed);
        }
        public static bool Ping(string host, int port, TimeSpan timeout, out TimeSpan elapsed)
        {
            using (TcpClient tcp = new TcpClient())
            {
                DateTime start = DateTime.Now;
                IAsyncResult result = tcp.BeginConnect(host, port, null, null);
                WaitHandle wait = result.AsyncWaitHandle;
                bool ok = true;

                try
                {
                    if (!result.AsyncWaitHandle.WaitOne(timeout, false))
                    {
                        tcp.Close();
                        ok = false;
                    }

                    tcp.EndConnect(result);
                }
                catch
                {
                    ok = false;
                }
                finally
                {
                    wait.Close();
                }

                DateTime stop = DateTime.Now;
                elapsed = stop.Subtract(start);
                return ok;
            } 
        }
        public static void BroadCastToAllDevices()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//初始化一个Scoket实习,采用UDP传输

            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, 9106);//初始化一个发送广播和指定端口的网络端口实例

            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);//设置该scoket实例的发送形式

            string request = SystemConfigure.ServerIP + "," + SystemConfigure.ServerPort.ToString();//初始化需要发送而的发送数据

            byte[] buffer = Encoding.Unicode.GetBytes(request);

            sock.SendTo(buffer, iep);

            sock.Close();
        }
        
    }
}
