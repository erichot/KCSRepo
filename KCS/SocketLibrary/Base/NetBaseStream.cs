using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


using System.Diagnostics;
namespace NetSockets
{
    public abstract class NetBaseStream<T>
    {
        protected Thread thread = null;
        protected NetworkStream stream;
        private IPEndPoint serverInfo;
        private Socket serverSocket;
        private Thread serverThread;
        private Socket[] clientSocket;
        private int clientNum;
        private byte[] msgBuffer;


        private readonly static object locker = new object();

        public event NetStreamStartedEventHandler OnStarted;

        public event NetStreamStoppedEventHandler OnStopped;

        public event NetStreamReceivedEventHandler<T> OnReceived;

        public Guid Guid
        {
            get;
            private set;
        }

        public long DataSent
        {
            get;
            private set;
        }

        public long DataReceived
        {
            get;
            private set;
        }

        public bool IsActive
        {
            get;
            private set;
        }

        public EndPoint EndPoint
        {
            get;
            private set;
        }

        public int TickRate
        {
            get;
            set;
        }
        public int TickActive
        {
            get;
            set;
        }
        public NetBaseStream(NetworkStream stream, EndPoint endpoint)
        {
            Guid = System.Guid.NewGuid();
            IsActive = false;
            EndPoint = endpoint;
            TickRate = 1;
            //stream.SetLength(6 * 1024 * 1024);


            this.stream = stream;
        }

        public void Start()
        {
            IsActive = true;

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
            thread = new Thread(new ThreadStart(ThreadedReceive));
            thread.Start();

            if (OnStarted != null)
                OnStarted(this, new NetStreamStartedEventArgs(Guid));
        }

        public void StartAsync()
        {
            try
            {
                while (true)
                {
                    clientSocket[clientNum] = serverSocket.Accept();
                    clientSocket[clientNum].BeginReceive(msgBuffer, 0, msgBuffer.Length, 0, new AsyncCallback(ThreadedReceiveAsync), clientSocket[clientNum]);
                    clientNum++;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Stop()
        {
            Stop(NetStoppedReason.Manually);
        }

        protected void Stop(NetStoppedReason reason)
        {
            if (!IsActive)
                return;

            IsActive = false;
            
            stream.Close();

            if (OnStopped != null)
                OnStopped(this, new NetStreamStoppedEventArgs(Guid, reason));
        }

        public abstract void Send(T data);

        protected void SendRaw(byte[] data)
        {
            byte[] bytes = data;
            if (IsActive && stream.CanWrite)
            {
               // string r = Encoding.ASCII.GetString(bytes);
                try
                {
                    //stream.Flush();
                    //stream.Write(bytes, 0, bytes.Length);
                     Write(bytes, bytes.Length);
                    //stream.Flush();
                    DataSent += bytes.LongLength;
                }
                catch /*(SocketException ex)*/
                {
                    Stop(NetStoppedReason.Remote);
                    return;
                }
            }
        }
        /// <summary>  
        /// 异步写状态对象  
        /// </summary>  
        internal class AsyncWriteStateObject
        {
            public ManualResetEvent eventDone;
            public NetworkStream Stream;
            public Exception exception;
        }  
        /// <summary>  
        /// 异步写入回调函数  
        /// </summary>  
        /// <param name="ar">异步操作结果</param>  
        private static void AsyncWriteCallback(IAsyncResult ar)
        {
            AsyncWriteStateObject State = ar.AsyncState as AsyncWriteStateObject;
            try
            {   // 异步写入结束  
                State.Stream.EndWrite(ar);
            }

            catch (Exception e)
            {   // 异步连接异常  
                State.exception = e;
            }

            finally
            {   // 将事件状态设置为终止状态，线程继续  
                State.eventDone.Set();
            }
        }  
        public void Write(Byte[] buffer,  Int32 size)
        {
            // 用户定义对象  
            AsyncWriteStateObject State = new AsyncWriteStateObject
            {   // 将事件状态设置为非终止状态，导致线程阻止  
                eventDone = new ManualResetEvent(false),
                Stream = stream,
                exception = null,
            };


           
            // 写入加长度信息头的数据  
            stream.BeginWrite(buffer, 0, size, new AsyncCallback(AsyncWriteCallback), State);

            // 等待操作完成信号  
            if (State.eventDone.WaitOne(stream.WriteTimeout, false))
            {   // 接收到信号  
                if (State.exception != null) throw State.exception;
            }
            else
            {   // 超时异常  
                throw new TimeoutException();
            }
        }  
        protected abstract void ReceivedRaw(byte[] bytes);

        protected void ThreadedReceive()
        {

           // MemoryStream _ms = null;
            //StringBuilder _sb = null;

            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            while (IsActive && stream.CanRead)
            {
                 Thread.Sleep(TickRate);
                byte[] buffer = new byte[10*1024];
                int recv = 0;
               // string response = String.Empty;

                //if (_ms == null)
                //{
                //    _ms = new System.IO.MemoryStream();   

                //}
                //if (_sb == null)
                //{
                //    _sb = new StringBuilder();
                //}


                try
                {
                   
                    recv = stream.Read(buffer, 0, buffer.Length);
                    if (recv == 0)
                    {
                        Stop(NetStoppedReason.Remote);
                        return;
                    }
                    
                    byte[] bufferRcv = new byte[recv];
                    Array.Copy(buffer, bufferRcv, recv);
                    ReceivedRaw(bufferRcv);
                   // DataReceived += recv;

                   // _sb.Append(Encoding.ASCII.GetString(buffer, 0, buffer.Length));
                   // response = _sb.ToString();
                   // _sb.Clear();

                }
                catch (System.IO.IOException ioex)
                {
                    if (ioex.InnerException is System.Net.Sockets.SocketException)
                    {

                        //DataSync.Program.WriteLog("Close Tcp 2" + ioex.Message + "\r\n");
                        Stop(NetStoppedReason.Remote);
                    }
                    break;//2018 5 22 return 改为 break
                }
                catch (Exception ex)
                {
                    Stop(NetStoppedReason.Exception);
                    //throw ex;
                    break;//2018 5 22 return 改为 break
                }
               // _ms.WriteAsync(buffer, 0, response.Length);
               // ReceivedRaw(_ms.ToArray());
                //try
                //{
                //    _ms.Dispose();
                //    _ms = null;
                //}
                //catch (Exception) { }
                //if (response.Contains("<END>"))
                //{

                //    int finishIndex = response.ToString().IndexOf("<END>") + 5;

                //    string next = response.Substring(finishIndex, response.Length - finishIndex);
                //    string next2 = PrepandString("\0", response.Length - finishIndex);

                //    if (next == next2)
                //    {
                //        _ms.WriteAsync(buffer, 0, finishIndex);
                //        ReceivedRaw(_ms.ToArray());
                //    }
                //    else
                //    {

                //        _ms.WriteAsync(buffer, 0, finishIndex);
                //        ReceivedRaw(_ms.ToArray());

                //        _ms.Dispose();
                //        _ms = null;
                //        _ms = new MemoryStream();
                //        _ms.WriteAsync(buffer, finishIndex, recv - finishIndex);
                //        continue;
                //    }

                //    try
                //    {
                //        _ms.Dispose();
                //        _ms = null;
                //    }
                //    catch (Exception) { }
                //}
                //else
                //{
                //    _ms.WriteAsync(buffer, 0, recv);
                //    continue;
                //}
            }

            //stream.Close();
            
            Stop(NetStoppedReason.Manually);
        }

        protected void ThreadedReceiveAsync(IAsyncResult ar)
        {
            MemoryStream _ms = null;
            StringBuilder _sb = null;

            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            byte[] buffer = new byte[65535];
            int recv = 0;
            string response = String.Empty;
            string sendData;

            if (_ms == null) _ms = new System.IO.MemoryStream();
            if (_sb == null) _sb = new StringBuilder();

            try
            {

                Socket rSocket = (Socket)ar.AsyncState;
                int rEnd = rSocket.EndReceive(ar);

                for (int i = 0; i < clientNum; i++)
                {
                    if (clientSocket[i].Connected)
                    {
                        byte[] byteData = null;/// = Encoding.ASCII.GetBytes(sendData);

                        response = Encoding.ASCII.GetString(msgBuffer);

                        //if (response.Contains("<END>"))
                        //{

                        //    int finishIndex = response.ToString().IndexOf("<END>") + 5;

                        //    string next = response.Substring(finishIndex, response.Length - finishIndex);
                        //    string next2 = PrepandString("\0", response.Length - finishIndex);

                        //    if (next == next2)
                        //    {
                        //        /// Küçük Onay Mesajları
                        //        ///
                        //        _ms.WriteAsync(buffer, 0, finishIndex);
                        //        ReceivedRaw(_ms.ToArray());
                        //    }
                        //    else
                        //    {

                        //        _ms.WriteAsync(buffer, 0, finishIndex);
                        //        ReceivedRaw(_ms.ToArray());

                        //        _ms.Dispose();
                        //        _ms = null;
                        //        _ms = new MemoryStream();
                        //        _ms.WriteAsync(buffer, finishIndex, recv - finishIndex);
                        //        continue;
                        //    }

                        //    _ms.Dispose();
                        //    _ms = null;
                        //}
                        //else
                        {
                            _ms.WriteAsync(buffer, 0, recv);
                            continue;
                        }

                        clientSocket[i].Send(byteData, 0, byteData.Length, 0);
                    }
                    rSocket.BeginReceive(msgBuffer, 0, msgBuffer.Length, 0, new AsyncCallback(ThreadedReceiveAsync), rSocket);
                }


                recv = stream.Read(buffer, 0, buffer.Length);
                if (recv == 0)
                {
                    Stop(NetStoppedReason.Remote);
                    return;
                }
                DataReceived += recv;

                _sb.Append(Encoding.ASCII.GetString(buffer, 0, buffer.Length));
                response = _sb.ToString();
                _sb.Clear();

            }
            catch (System.IO.IOException ioex)
            {
                Stop(NetStoppedReason.Remote);
                return;
            }
            catch (Exception ex)
            {
                Stop(NetStoppedReason.Exception);
                //throw ex;
            }

            Stop(NetStoppedReason.Manually);
        }

        /// <summary>
        /// Raises the OnReceived event.
        /// </summary>
        /// <param name="data">The data associated with the event.</param>
        protected void RaiseOnReceived(T data)
        {
            if (OnReceived != null)
                OnReceived(this, new NetStreamReceivedEventArgs<T>(Guid, data));
        }

        private string PrepandString(string str, int lenght)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lenght; i++)
            {
                sb.Insert(i, str);
            }

            return sb.ToString();
        }


    }
}
