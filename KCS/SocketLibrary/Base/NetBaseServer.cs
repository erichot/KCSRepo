using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Concurrent;

namespace NetSockets
{
    /// <summary>
    /// Echo modes.
    /// </summary>
    public enum NetEchoMode 
    { 
        None, 
        EchoAll, 
        EchoAllExceptSender, 
        EchoSender 
    };

    public abstract class NetBaseServer<T>
    {
        protected List<Guid> clients;
        protected ConcurrentDictionary<Guid, NetBaseStream<T>> streams;
        protected TcpListener tcp;
        protected Thread thread;
        protected bool active;

        public event NetStartedEventHandler OnStarted;

        public event NetStoppedEventHandler OnStopped;

        public event NetExceptionEventHandler OnError;

        public event NetClientConnectedEventHandler OnClientConnected;

        public event NetClientAcceptedEventHandler OnClientAccepted;

        public event NetClientRejectedEventHandler OnClientRejected;

        public event NetClientDisconnectedEventHandler OnClientDisconnected;

        public event NetClientReceivedEventHandler<T> OnReceived;

        public int MaxClients
        {
            get;
            private set;
        }

        public int Port
        {
            get;
            private set;
        }

        public bool IsOnline
        {
            get { return active; }
        }

        public int TickRate
        {
            get;
            set;
        }

        public IPAddress[] LocalAddresses
        {
            get { return Dns.GetHostAddresses(Dns.GetHostName()); }
        }

        public IPAddress DefaultAddress
        {
            get
            {
                if (LocalAddresses.Length > 0)
                    return LocalAddresses[0];
                else
                    return IPAddress.None;
            }
        }

        public IPAddress Address
        {
            get;
            private set;
        }

        public Guid[] Clients
        {
            get { return clients.ToArray(); }
        }

        public int ClientCount
        {
            get { return clients.Count; }
        }

        public ConcurrentDictionary<Guid, NetBaseStream<T>> ClientStreams
        {
            get { return streams; }
        }

        public NetEchoMode EchoMode
        {
            get;
            set;
        }
        
        public NetBaseServer()
        {
            this.clients = new List<Guid>();
            this.streams = new ConcurrentDictionary<Guid, NetBaseStream<T>>();
            this.TickRate = 1;
            this.EchoMode = NetEchoMode.None;
        }

        public void Start(int port)
        {
            Start(port, 0);
        }

        public void Start(int port, int maxClients)
        {
            Start(DefaultAddress, port);
        }

        public void Start(IPAddress address, int port)
        {
            Start(address, port, 65535);
            //StartAsync(address, port, 65535);
        }

        public void Start(IPAddress address, int port, int maxClients)
        {
            if (active)
            {
                throw new Exception("Server already started.");
            }
            else
            {
                this.Address = address;
                this.Port = port;
                this.MaxClients = maxClients;
                this.active = true;

                tcp = new TcpListener(address, port);
                tcp.Start();

                if (OnStarted != null)
                    OnStarted(this, new NetStartedEventArgs());

                thread = new Thread(new ThreadStart(ThreadedAccept));
                thread.Start();
            }
        }

        public void StartAsync(IPAddress address, int port, int maxClients)
        {
            if (active)
            {
                throw new Exception("Server already started.");
            }
            else
            {
                this.Address = address;
                this.Port = port;
                this.MaxClients = maxClients;
                this.active = true;

                tcp = new TcpListener(address, port);
                tcp.Start();

                if (OnStarted != null)
                    OnStarted(this, new NetStartedEventArgs());

                thread = new Thread(new ThreadStart(ThreadedAcceptAsync));
                thread.Start();
            }
        }

        public void Stop()
        {
            Stop(NetStoppedReason.Manually);
        }

        protected void Stop(NetStoppedReason reason)
        {
            if (!active) 
                return;

            DisconnectAll();
            tcp.Stop();

            active = false;

            if (OnStopped != null)
                OnStopped(this, new NetStoppedEventArgs(reason));
        }

        public void DisconnectClient(Guid guid)
        {
            if (!streams.ContainsKey(guid))
                throw new Exception("Client ID not found.");
            else
            {
                streams[guid].Stop();
            }
        }

        public void DisconnectAll()
        {
            while (clients.Count > 0)
                streams[clients[0]].Stop();
        }

        public void DispatchTo(Guid guid, T data)
        {
            if (!streams.ContainsKey(guid))
                throw new Exception("Client ID not found.");
            else
            {
                streams[guid].Send(data);
                

                /*if (OnDispatched != null)
                    OnDispatched(this, guid, data);*/
            }
        }

        //public void GetClientConnected(Guid guid)
        //{
        //    if (!streams.ContainsKey(guid))
        //        throw new Exception("Client ID not found.");
        //    else
        //    {
        //        streams[guid].EndPoint.AddressFamily.Send(data);
        //        /*if (OnDispatched != null)
        //            OnDispatched(this, guid, data);*/
        //    }
        //}
 
        public void DispatchTo(Guid[] guid, T data)
        {
            foreach (Guid i in guid)
                DispatchTo(i, data);
        }

        public void DispatchAll(T data)
        {
            foreach (Guid i in clients)
                DispatchTo(i, data);
        }

        public void DispatchAllExcept(Guid guid, T data)
        {
            foreach (Guid i in clients)
                if (i != guid)
                    DispatchTo(i, data);
        }

        protected void ThreadedAccept()
        {
            while (active)
            {
                Thread.Sleep(TickRate);
                NetBaseStream<T> stream = null;
                TcpClient tcpClient = null;
                NetworkStream ns = null;

                try
                {
                    tcpClient = tcp.AcceptTcpClient();
                    tcpClient.SendTimeout = 9000;
                    tcpClient.ReceiveTimeout = 9000;
                    ns = tcpClient.GetStream();
                    ns.ReadTimeout = 9000;
                    ns.WriteTimeout = 8000;
                }
                catch (SocketException ex)
                {
                    if (OnError != null)
                        OnError(this, new NetExceptionEventArgs(ex));

                    if (ns != null)
                        ns.Close();

                    if (tcpClient != null)
                        tcpClient.Close();
                    continue;
                }

                //try
                {
                    stream = CreateStream(ns, tcpClient.Client.RemoteEndPoint);
                    stream.OnStopped += new NetStreamStoppedEventHandler(OnClientStopped);
                    stream.OnReceived += new NetStreamReceivedEventHandler<T>(OnClientReceived);

                    stream.Start();


                    clients.Add(stream.Guid);
                    streams.TryAdd(stream.Guid, stream);

                    NetClientConnectedEventArgs e = new NetClientConnectedEventArgs(stream.Guid, false);
                    if (OnClientConnected != null)
                        OnClientConnected(this, e);

                    if ((ClientCount < MaxClients || MaxClients == 0) && !e.Reject)
                    {
                        //Raise the accepted event
                        if (OnClientAccepted != null)
                            OnClientAccepted(this, new NetClientAcceptedEventArgs(stream.Guid));
                    }
                    else
                    {
                        //Raise the rejected event
                        if (OnClientRejected != null)
                            OnClientRejected(this, new NetClientRejectedEventArgs(stream.Guid, NetRejectedReason.Other));

                        ns.Close();
                        tcpClient.Close();
                        continue;
                    }
                }
                //catch (Exception ex)
                //{
                //    Program.WriteLog("ThreadedAccept Exception:" +ex.Message + "\r\n");
                //}
            }

            Stop(NetStoppedReason.Manually);
        }

        protected async void ThreadedAcceptAsync()
        {




            while (active)
            {
                Thread.Sleep(TickRate);
                NetBaseStream<T> stream = null;
                TcpClient tcpClient = null;
                NetworkStream ns = null;

                try
                {
                    tcpClient = await tcp.AcceptTcpClientAsync();
                    ns = tcpClient.GetStream();
                }
                catch (SocketException ex)
                {
                    if (OnError != null)
                        OnError(this, new NetExceptionEventArgs(ex));

                    if (ns != null)
                        ns.Close();

                    if (tcpClient != null)
                        tcpClient.Close();
                    continue;
                }


                stream = CreateStream(ns, tcpClient.Client.RemoteEndPoint);
                stream.OnStopped += new NetStreamStoppedEventHandler(OnClientStopped);
                stream.OnReceived += new NetStreamReceivedEventHandler<T>(OnClientReceived);
                stream.Start();

                clients.Add(stream.Guid);
                streams.TryAdd(stream.Guid, stream);

                NetClientConnectedEventArgs e = new NetClientConnectedEventArgs(stream.Guid, false);
                if (OnClientConnected != null)
                    OnClientConnected(this, e);

                if ((ClientCount < MaxClients || MaxClients == 0) && !e.Reject)
                {
                    //Raise the accepted event
                    if (OnClientAccepted != null)
                        OnClientAccepted(this, new NetClientAcceptedEventArgs(stream.Guid));
                }
                else
                {
                    //Raise the rejected event
                    if (OnClientRejected != null)
                        OnClientRejected(this, new NetClientRejectedEventArgs(stream.Guid, NetRejectedReason.Other));

                    ns.Close();
                    tcpClient.Close();
                    continue;
                }
            }

            Stop(NetStoppedReason.Manually);
        }

        protected void OnClientReceived(object sender, NetStreamReceivedEventArgs<T> e)
        {
            NetClientReceivedEventArgs<T> args = new NetClientReceivedEventArgs<T>(e.Data, EchoMode, e.Guid);
            streams[e.Guid].TickActive = 0;
            if (OnReceived != null)
                OnReceived(this, args);

            switch(args.EchoMode)
            {
                case NetEchoMode.EchoAll:
                    DispatchAll(e.Data);
                    break;
                case NetEchoMode.EchoAllExceptSender:
                    DispatchAllExcept(e.Guid, e.Data);
                    break;
                case NetEchoMode.EchoSender:
                    DispatchTo(e.Guid, e.Data);
                    break;
                case NetEchoMode.None:
                    break;
            }
        }

        protected void OnClientStopped(object sender, NetStreamStoppedEventArgs e)
        {
            if (OnClientDisconnected != null)
                OnClientDisconnected(this, new NetClientDisconnectedEventArgs(e.Guid, e.Reason));

            clients.Remove(e.Guid);
            NetBaseStream<T> streamRemove;
            streams.TryRemove(e.Guid, out streamRemove);
        }

        protected abstract NetBaseStream<T> CreateStream(NetworkStream ns, EndPoint ep);
    }
}
