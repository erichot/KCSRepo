using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KCS.Common.DAL;
using System.Threading;
using DevExpress.XtraEditors;

namespace KCS.Sync
{
    public class SyncServer : BridgeUtility, IDisposable
    {
        protected static Dictionary<Guid, ClientOfServer> ConnectClientLists;
        protected static Dictionary<int, Guid> OverdueConnectClientLists;

        private delegate void OnTerminaleMessageReceived(Guid guid, byte[] rawReceivedData);
        private OnTerminaleMessageReceived onTerminalReceived = null;
        private Thread threadMonitor;
        public static object lockerDicClientList = new object();
        #region SOCKETS INSTANCES
        protected static NetSockets.NetServer server = null;
        protected static NetSockets.NetStream stream = null;

        #endregion
        private String ServerIP = String.Empty;
        private int ServerPort = 9008;
        private CancellationTokenSource cts = new CancellationTokenSource();

        public void StartServerApplication()
        {
            InitiliaseServerApplication();
            IPAddress ipAddress = IPAddress.Parse(SystemConfigure.ServerIP);
            ServerPort = SystemConfigure.ServerPort;
            try
            {
                //_logger.Write("Server IP : " + ServerIP);
                // _logger.Write("Server Port : " + ServerPort.ToString());
                IPEndPoint listenEndPoint = new IPEndPoint(ipAddress, ServerPort);
                server.Start(listenEndPoint.Address, ServerPort);
                server.TickRate = 10;
                threadMonitor = new Thread(new ThreadStart(ThreadedMonitor));
                threadMonitor.Start();
                //_logger.Write("Terminal Bağdaştırıcı Server Uygulaması Baslatıldı");

            }
            catch (System.Exception ex)
            {
                //_logger.Write("Error Occurd While Binding Adress On Server : " + ex.Message);
                //_logger.Write("====  Application will be closed. ===");
                XtraMessageBox.Show(ex.Message, "Port Error");
                Environment.Exit(0);
            }
        }
        protected void ThreadedMonitor()
        {

            try
            {
                while (!this.cts.Token.IsCancellationRequested)
                {
                    for (int i = 0; i < server.ClientCount; i++)
                    {
                        server.ClientStreams[server.Clients[i]].TickActive++;
                        //if (!ConnectClientLists.ContainsKey(server.Clients[i]))
                        if (server.ClientStreams[server.Clients[i]].TickActive >= 80)
                        {
                            server.ClientStreams[server.Clients[i]].TickActive = 0;
                            server.DisconnectClient(server.Clients[i]);
                        }
                    }
                    Thread.Sleep(200);
                }
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.Message,"Read Device");
            }

            threadMonitor = null;
        }
        public void Dispose()
        {
            cts.Cancel();
            StopServerApplication();
        }
        public void StopServerApplication()
        {

            try
            {
                if (server != null)
                {
                    for (int i = 0; i < server.ClientCount; i++)
                    {
                        if (ConnectClientLists.ContainsKey(server.Clients[i]))
                        {
                            ConnectClientLists[server.Clients[i]].Dispose();
                            ConnectClientLists.Remove(server.Clients[i]);
                        }
                    }
                    if (server.ClientCount > 0)
                        server.DisconnectAll();

                    server.Stop();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Stop Server");
                //_logger.Write("Error Occurd While Server Stopped  :  " + ex.Message);
            }
        }

        private void InitiliaseServerApplication()
        {
            ConnectClientLists = new Dictionary<Guid, ClientOfServer>();
            OverdueConnectClientLists = new Dictionary<int, Guid>();
            onTerminalReceived = new OnTerminaleMessageReceived(OnTerminalRequestRecieved);
            server = new NetSockets.NetServer();

            server.OnClientAccepted += Server_OnClientAccepted;
            server.OnClientConnected += Server_OnClientConnected;
            server.OnClientDisconnected += Server_OnClientDisconnected;
            server.OnClientRejected += Server_OnClientRejected;
            server.OnError += Server_OnError;
            server.OnReceived += Server_OnReceived;
            server.OnStarted += Server_OnStarted;
            server.OnStopped += Server_OnStopped;



        }


        private void Server_OnStopped(object sender, NetSockets.NetStoppedEventArgs e)
        {
            //_logger.Write("Terminal Bağdaştırıcı Server Duruduruldu");
            //StopServerApplication();
        }

        private void Server_OnStarted(object sender, NetSockets.NetStartedEventArgs e)
        {

            //_logger.Write("Terminal Bağdaştırıcı Server Started");
        }

        private void Server_OnReceived(object sender, NetSockets.NetClientReceivedEventArgs<byte[]> e)
        {
            if (e.Data.Length > 0)
            {
                Task.Factory.StartNew(() =>
                {
                    onTerminalReceived.Invoke(e.Guid, e.Data);
                }, TaskCreationOptions.LongRunning);

            }
        }

        private void Server_OnError(object sender, NetSockets.NetExceptionEventArgs e)
        {
            //_logger.Write("SERVER ERROR OCCURD");
        }
        private void OnClientDisconnectEvent(Guid guid)
        {
            try
            {
                // lock (lockerDicClientList)
                {
                    if (ConnectClientLists.ContainsKey(guid))
                    {
                        ConnectClientLists[guid].UpdateTerminalSatus(false, ((IPEndPoint)server.ClientStreams[guid].EndPoint).Address.ToString());
                        ConnectClientLists[guid].Dispose();
                        ConnectClientLists.Remove(guid);
                    }
                }
            }
            catch
            {
            }
        }
        private void Server_OnClientRejected(object sender, NetSockets.NetClientRejectedEventArgs e)
        {
            //_logger.Write("Terminal Bağlantı isteği reddedildi");
            OnClientDisconnectEvent(e.Guid);
        }

        private void Server_OnClientDisconnected(object sender, NetSockets.NetClientDisconnectedEventArgs e)
        {//设备断开
            OnClientDisconnectEvent(e.Guid);
            //_logger.Write("Teminal Uygulaması ile bağlantı koptu,  Lütfen  bağlantı durumunu kontrol edin");
            //断开连接
        }

        private void Server_OnClientConnected(object sender, NetSockets.NetClientConnectedEventArgs e)
        {//设备连入
            //_logger.Write("Terminal -> Server Bağlantısı Başarlı");
            //connectedClientGuidList.Add(e.Guid);
            int i = 0;
        }

        private void Server_OnClientAccepted(object sender, NetSockets.NetClientAcceptedEventArgs e)
        {
            //_logger.Write("Terminal - Server bağlantı Isteği alındı");
            int i = 0;
        }
        private void OnTerminalRequestRecieved(Guid guid, byte[] rawReceivedData)
        {
            byte rcvCheck, check = 0;
            int validDataLen = 0;
            int rcvDeviceId = 0;


            if (rawReceivedData[0] == 0xa5)
            {//收到帧头
                validDataLen = rawReceivedData[5] + rawReceivedData[6] * 256 + 9;
                if (validDataLen != rawReceivedData.Length)
                    return;
                check = 0;
                for (int i = 0; i < validDataLen - 1; i++)
                {
                    check ^= rawReceivedData[i];
                }
                rcvCheck = rawReceivedData[validDataLen - 1];
                if (check != rcvCheck)
                    return;
                rcvDeviceId = rawReceivedData[7] + rawReceivedData[8] * 256;
                if (SyncManage.GetTerminalByID(rcvDeviceId) == null)
                {
                    return;
                }
                try
                {

                    // lock (lockerDicClientList)
                    {
                        if (!ConnectClientLists.ContainsKey(guid))
                        {
                            //if (OverdueConnectClientLists.ContainsKey(rcvDeviceId))
                            //{
                            //    //ConnectClientLists[OverdueConnectClientLists[rcvDeviceId]].UpdateTerminalSatus(false, ((IPEndPoint)server.ClientStreams[guid].EndPoint).Address.ToString());
                            //    ConnectClientLists[OverdueConnectClientLists[rcvDeviceId]].Dispose();
                            //    ConnectClientLists.Remove(OverdueConnectClientLists[rcvDeviceId]);
                            //    server.DisconnectClient(OverdueConnectClientLists[rcvDeviceId]);

                            //    OverdueConnectClientLists.Remove(rcvDeviceId);
                            //}
                            //OverdueConnectClientLists.Add(rcvDeviceId,guid);
                           
                            ConnectClientLists.Add(guid, new ClientOfServer(SyncManage.GetTerminalByID(rcvDeviceId), server.ClientStreams[guid]));
                            ConnectClientLists[guid].UpdateTerminalSatus(true, ((IPEndPoint)server.ClientStreams[guid].EndPoint).Address.ToString());
                           
                           
                        }
                        if (ConnectClientLists.ContainsKey(guid))
                        {
                            if (ConnectClientLists[guid] != null)
                            {
                                ConnectClientLists[guid].ClentsDataReceived(rawReceivedData);

                            }
                        }

                    }


                }

                catch (Exception ex)
                {
                    //Program.WriteLog("OnTerminalRequestRecieved Exception"+ex.Message + "\r\n");
                }


            }

        }
    }
}
