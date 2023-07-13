using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetSockets
{

    public abstract class NetBaseClient<T>
    {
        protected TcpClient tcp;
        protected NetBaseStream<T> stream;

        public event NetReceivedEventHandler<T> OnReceived;

        public event NetConnectedEventHandler OnConnected;

        public event NetDisconnectedEventHandler OnDisconnected;

        public string RemoteHost
        {
            get;
            private set;
        }

        public int RemotePort
        {
            get;
            private set;
        }

        public bool IsConnected
        {
            get;
            private set;
        }

        public NetBaseClient()
        {
            IsConnected = false;
        }

        public void Connect(string host, int port)
        {
            if (IsConnected)
                Disconnect(NetStoppedReason.Manually);

            RemoteHost = host;
            RemotePort = port;

            if( stream != null)
            stream.Stop();
            
            if (tcp != null)
                tcp.Close();
            tcp = new TcpClient();
           
            tcp.ReceiveTimeout = 9000;
            tcp.SendTimeout = 9000;
            tcp.SendBufferSize = 6 * 1024 * 1024;
            //tcp.Client.IOControl(IOControlCode.KeepAliveValues, BitConverter.GetBytes(120), null);
            tcp.Connect(host, port);
            


            IsConnected = true;
            if (OnConnected != null)
                OnConnected(this, new NetConnectedEventArgs());

            NetworkStream ns = tcp.GetStream();
            

            EndPoint ep = tcp.Client.RemoteEndPoint;
            //ns.ReadTimeout =12000;
            //ns.WriteTimeout = 12000;
            
            stream = CreateStream(ns, ep);   
            stream.OnReceived += new NetStreamReceivedEventHandler<T>(stream_OnReceived);
            stream.OnStopped += new NetStreamStoppedEventHandler(stream_OnStopped);
            stream.Start();
        }

        public bool TryConnect(string host, int port)
        {
            try
            {
                Connect(host, port);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
           Disconnect(NetStoppedReason.Manually);
        }

        protected void Disconnect(NetStoppedReason reason)
        {
            if (!IsConnected)
                return;

            stream.Stop();
            stream = null;
            tcp.Close();
            tcp = null;
            
            //tcp.Client.Shutdown(SocketShutdown.Both);
            
            IsConnected = false;
            if (OnDisconnected != null) 
                OnDisconnected(this, new NetDisconnectedEventArgs(reason));
           
        }

        public void Send(T data)
        {
            stream.Send(data);
        }

        protected abstract NetBaseStream<T> CreateStream(NetworkStream ns, EndPoint ep);

        protected void stream_OnReceived(object sender, NetStreamReceivedEventArgs<T> e)
        {
            if (OnReceived != null)
                OnReceived(this, new NetReceivedEventArgs<T>(e.Data));
        }

        protected void stream_OnStopped(object sender, NetStreamStoppedEventArgs e)
        {
            Disconnect(e.Reason);
        }
    }
}
