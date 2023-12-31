﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetSockets
{
    public class NetObjectStream : NetBasePayloadStream<NetObject>
    {
        public NetObjectStream(NetworkStream stream, EndPoint endpoint)
            : base(stream, endpoint)
        {
        }

        public override void Send(NetObject netObj)
        {
            //Serialize the object
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, netObj);

            //Send bytes
            byte[] data = ms.ToArray();
            SendPayload(data);
            ms.Close();
            ms.Dispose();
        }

        protected override void ReceivedPayload(byte[] data)
        {
            //Deserialize object
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();
            NetObject obj = (NetObject)bf.Deserialize(ms);

            //Raise on received with NetObject
            RaiseOnReceived(obj);
            ms.Close();
            ms.Dispose();
        }
    }
}
