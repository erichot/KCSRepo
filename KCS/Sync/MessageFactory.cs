using KCS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace KCS.Sync
{
    public enum CommandMode { TcpClient = 0, TcpServer }
    public class MessageFactory
    {
        
        private int CommunicationPin = 0;
        public byte[] TerminalRequestMessage { get; set; }
        public byte[] RequestMessageHeader =  new byte[7];
        public MessageFactory()
        {
            CommunicationPin = 0;
        }
        public MessageFactory(int pin)
        {
            CommunicationPin = pin;
        }
        public void SetCommunicationPin(int pin)
        {
            CommunicationPin = pin;
        }
        private bool ConvertIntToByteArray(UInt32 m, ref byte[] arry)
        {
            if (arry == null) return false;
            if (arry.Length < 4) return false;

            arry[0] = (byte)(m & 0xFF);
            arry[1] = (byte)((m & 0xFF00) >> 8);
            arry[2] = (byte)((m & 0xFF0000) >> 16);
            arry[3] = (byte)((m >> 24) & 0xFF);

            return true;
        }
        private bool ConvertIntToByteArray(Int32 m, ref byte[] arry)
        {
            if (arry == null) return false;
            if (arry.Length < 4) return false;

            arry[0] = (byte)(m & 0xFF);
            arry[1] = (byte)((m & 0xFF00) >> 8);
            arry[2] = (byte)((m & 0xFF0000) >> 16);
            arry[3] = (byte)((m >> 24) & 0xFF);

            return true;
        }  
        private void CreateMesageHeader(byte command, int datalen)
        {
            RequestMessageHeader[0] = (byte)0xa5;      //头
            RequestMessageHeader[1] = (byte)(CommunicationPin & 0xff); //通讯密码
            RequestMessageHeader[2] = (byte)((CommunicationPin >> 8) & 0xff);
            RequestMessageHeader[3] = (byte)((CommunicationPin >> 16) & 0xff);
            RequestMessageHeader[4] = (byte)command;   //命令字
            RequestMessageHeader[5] = (byte)(datalen & 0xff); //数据长度，
            RequestMessageHeader[6] = (byte)((datalen >>8) & 0xff);
        }
        public byte[] DeleteReplicatedTransAndFingerMessage(int TransId,UInt32 CardSn,int FingerId)
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[16];
            byte[] Int32ByteBuf = new byte[4];
            byte SendFlag = 0;
            int  SendDataLen = 1;
            

           
            if (TransId != 0)
            {
                ConvertIntToByteArray(TransId, ref Int32ByteBuf);
                Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                SendDataLen += 4;
                SendFlag += 1;
            }
            if (CardSn != 0)
            {
                ConvertIntToByteArray(CardSn, ref Int32ByteBuf);
                Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                SendDataLen += 4;
                ConvertIntToByteArray(FingerId, ref Int32ByteBuf);
                Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                SendDataLen += 4;
                SendFlag += 4;
            }
            CreateMesageHeader((byte)SyncServerCommand.UpdateReadedFinger, SendDataLen);
            SendData[0] = SendFlag;
            CheckResult[0] =  0x00;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendDataLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendDataLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] CreateHeartbeatMessage()
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[1];


            CreateMesageHeader((byte)SyncServerCommand.WriteBell, 1);
            CheckResult[0] = SendData[0] = 50;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 1);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] RebootDeviceMessage(CommandMode commandMode)
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[1];

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_RebootDevice, 1);
            else
                CreateMesageHeader((byte)SyncServerCommand.RebootDevice, 1);
            CheckResult[0] = SendData[0] = 0x01;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 1);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] ResetDeviceMessage(CommandMode commandMode)
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[1];

            if( commandMode == CommandMode.TcpClient )
                CreateMesageHeader((byte)SyncClientCommand.Com_ResetDevice, 1);
            else
                CreateMesageHeader((byte)SyncServerCommand.ResetDevice, 1);
            CheckResult[0] = SendData[0] = 0x01;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 1);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] CreateSetDoorPinMessage(CommandMode commandMode,DoorPIN pin)
        {//SetDoorPin
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[38];
            byte[] tempBuf = new byte[16];

            SendData[0] = (byte)pin.PIN1Code;
            SendData[1] = (byte)pin.PIN1StartHour;
            SendData[2] = (byte)pin.PIN1StartMinute;
            SendData[3] = (byte)pin.PIN1EndHour;
            SendData[4] = (byte)pin.PIN1EndMinute;
            for (int i = 0; i < 6; i++)
            {
                SendData[5 + i] = 0;
            }
            tempBuf = Encoding.ASCII.GetBytes(pin.PIN1);
            Array.Copy(tempBuf, 0, SendData, 5, pin.PIN1.Length > 6 ? 6 : pin.PIN1.Length);
            SendData[11] = (byte)pin.PIN2Code;
            SendData[12] = (byte)pin.PIN2StartHour;
            SendData[13] = (byte)pin.PIN2StartMinute;
            SendData[14] = (byte)pin.PIN2EndHour;
            SendData[15] = (byte)pin.PIN2EndMinute;


            for (int i = 0; i < 6; i++)
            {
                SendData[16 + i] = 0;
            }
            tempBuf = Encoding.ASCII.GetBytes(pin.PIN2);
            Array.Copy(tempBuf, 0, SendData, 16, pin.PIN2.Length > 6 ? 6 : pin.PIN2.Length);
            //PIN1开始日期
            DateTime dt = Convert.ToDateTime(pin.PIN1StartDate);
            SendData[22] = (byte)((dt.Year >> 8)&0xff);
            SendData[23] = (byte)((dt.Year) & 0xff);
            SendData[24] = (byte)(dt.Month);
            SendData[25] = (byte)(dt.Day);
            //PIN1 结束日期
            dt = Convert.ToDateTime(pin.PIN1EndDate);
            SendData[26] = (byte)((dt.Year >> 8) & 0xff);
            SendData[27] = (byte)((dt.Year) & 0xff);
            SendData[28] = (byte)(dt.Month);
            SendData[29] = (byte)(dt.Day);
            //PIN2 开始日期
            dt = Convert.ToDateTime(pin.PIN2StartDate);
            SendData[30] = (byte)((dt.Year >> 8) & 0xff);
            SendData[31] = (byte)((dt.Year) & 0xff);
            SendData[32] = (byte)(dt.Month);
            SendData[33] = (byte)(dt.Day);
            //PIN2 结束日期
            dt = Convert.ToDateTime(pin.PIN2EndDate);
            SendData[34] = (byte)((dt.Year >> 8) & 0xff);
            SendData[35] = (byte)((dt.Year) & 0xff);
            SendData[36] = (byte)(dt.Month);
            SendData[37] = (byte)(dt.Day);
            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_SetDoorPin, 38);
            else
                CreateMesageHeader((byte)SyncServerCommand.SetDoorPin, 38);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendData.Length; i++)
            {
                CheckResult[0] ^= SendData[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 38);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();
            }

        }
        public byte[] CreateOpenDoorMessage(CommandMode commandMode)
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[1];


            

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_OpenDoor, 1);
            else
                CreateMesageHeader((byte)SyncServerCommand.OpenDoor, 1);
            CheckResult[0] = SendData[0] = 0x00;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 1);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();
            }
        }
        public byte[] CreateReadTransAgainMessage(CommandMode commandMode,DateTime dateStart,DateTime dateEnd,DateTime timeStart,DateTime timeEnd)
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[10];


            SendData[0] = (byte)(dateStart.Year > 2000 ? (dateStart.Year - 2000) : 0);
            SendData[1] = (byte)dateStart.Month;
            SendData[2] = (byte)dateStart.Day;
            SendData[3] = (byte)timeStart.Hour;
            SendData[4] = (byte)timeStart.Minute;
            SendData[5] = (byte)(dateEnd.Year > 2000 ? (dateEnd.Year - 2000) : 0);
            SendData[6] = (byte)dateEnd.Month;
            SendData[7] = (byte)dateEnd.Day;
            SendData[8] = (byte)timeEnd.Hour;
            SendData[9] = (byte)timeEnd.Minute;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_ReadTransAgain, 10);
            else
                CreateMesageHeader((byte)SyncServerCommand.ReadTransAgain, 10);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendData.Length; i++)
            {
                CheckResult[0] ^= SendData[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 10);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();
            }
        }
        public byte[] CreateWriteTimeMessage(CommandMode commandMode)
        {
            byte[] CheckResult = new byte[1];
            byte[] CurTime = new byte[7];
            DateTime dt = DateTime.UtcNow;

            CurTime[0] = (byte)(dt.Year > 2000 ? (dt.Year - 2000) : 0);
            CurTime[1] = (byte)dt.Month;
            CurTime[2] = (byte)dt.Day;
            CurTime[3] = (byte)dt.DayOfWeek;
            CurTime[4] = (byte)dt.Hour;
            CurTime[5] = (byte)dt.Minute;
            CurTime[6] = (byte)dt.Second;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteTime, 7);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteUTCTime, 7);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < CurTime.Length; i++)
            {
                CheckResult[0] ^= CurTime[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {
                
                m.WriteAsync(RequestMessageHeader,0,7);
                m.WriteAsync(CurTime, 0, 7);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();
            }

           
        }
        public byte[] CreateWriteTimeMessageOld(CommandMode commandMode)
        {
            byte[] CheckResult = new byte[1];
            byte[] CurTime = new byte[7];
            DateTime dt = DateTime.Now;

            CurTime[0] = (byte)(dt.Year > 2000 ? (dt.Year - 2000) : 0);
            CurTime[1] = (byte)dt.Month;
            CurTime[2] = (byte)dt.Day;
            CurTime[3] = (byte)dt.DayOfWeek;
            CurTime[4] = (byte)dt.Hour;
            CurTime[5] = (byte)dt.Minute;
            CurTime[6] = (byte)dt.Second;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteTime_Old, 7);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteTime, 7);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < CurTime.Length; i++)
            {
                CheckResult[0] ^= CurTime[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(CurTime, 0, 7);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();
            }


        }
        public byte[] CreateReadDeviceMessage()
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[1];

           
            CreateMesageHeader((byte)SyncClientCommand.Com_ReadTransaction, 1);
            
            CheckResult[0] = SendData[0] = 0x01;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 1);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] CreateDleteTransactioMessage()
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[8];

            
            CreateMesageHeader((byte)SyncClientCommand.Com_DelReadTransaction, 1);
            CheckResult[0] = SendData[0] = 0x06;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 1);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
           
        }
        public byte[] CreateDeleteReadFingerMessage(UInt32 CardId,int FingerNo)
        {
            byte[] CheckResult = new byte[1];
            byte[] SendData = new byte[8];
            byte[] Int32ByteBuf = new byte[4];
            int SendDataLen = 0;

            ConvertIntToByteArray(CardId, ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
            SendDataLen += 4;
            ConvertIntToByteArray(FingerNo, ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
            SendDataLen += 4;
            
            CreateMesageHeader((byte)SyncClientCommand.Com_DevicePushFingerOk, SendDataLen);
            CheckResult[0] =  0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendDataLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendDataLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        string ImageFile2Base64(String imageFile)
        {
            try
            {
                Image image = Image.FromFile(imageFile);
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                byte[] byteArray = ms.ToArray();
                ms.Close();
                return Convert.ToBase64String(byteArray);
            }
            catch (Exception e)
            {
               
                return null;
            }
           
        }
        public byte[] CreateDeleteUserWithFaceMessage(CommandMode commandMode, IUserInfoDel deleteUser)
        {
            int SendDataLen = 0;
            byte[] SendData = new byte[256];
            byte[] CheckResult = new byte[1];
            byte[] Int32ByteBuf = new byte[4];

            SendData[0] = 0x00;
            SendDataLen++;
            
            if ((object)deleteUser != null)
            {
                if (0 == SendData[0])
                {
                    SendData[0] = (byte)SyncUserCommand.Sync_DeleteUser;
                }

                ConvertIntToByteArray(Convert.ToUInt32(deleteUser.CardID), ref Int32ByteBuf);
                Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                SendDataLen += 4;
                //SendDataLen += 4;
            }
            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteUser, SendDataLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteUserInfo, SendDataLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendDataLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendDataLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] CreateEnrollUserWithFaceMessage(IUserInfoAdd addUser,string phtoPath)
        {
            int UserGroup = (byte)((addUser.Group1 << 4) + addUser.Group2);
            string utf8UserName = "";
            if (!string.IsNullOrEmpty(addUser.UserName))
            {
                byte[] tempBuf = new byte[65];
                tempBuf = Encoding.Unicode.GetBytes(addUser.UserName);
                byte[] utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, tempBuf);

                for (int i = 0; i < utf8Bytes.Length; i++)
                   utf8UserName += utf8Bytes[i].ToString("X2");
               
                //utf8UserName =  System.Text.Encoding.Default.GetString(utf8Bytes);
                //Array.Copy(utf8Bytes, 0, SendData, SendDataLen, utf8Bytes.Length);
            }
            //格式 CardId;SID;Group;Valid_Data;User_Pwd;User_Name;User_No;DepartmentId;StartTime;EndTime;length
            string sendData = "EnrollUser" + ";" + addUser.CardID + ";" + addUser.UserSID.ToString() + ";"
                + UserGroup.ToString() + ";" + addUser.ValidDate + ";"
                + addUser.UserPin + ";" + utf8UserName + ";" + addUser.UserID + ";"
                + addUser.DepartmentID + ";" + addUser.StartTime + ";"
                + addUser.EndTime + ";";

            string strBase64 = ImageFile2Base64(phtoPath);
            sendData += strBase64.Length.ToString() + ";";
            sendData += strBase64;
            sendData += "<END>";

            byte[] byteData = Encoding.ASCII.GetBytes(sendData);


            return byteData;

        }

        public byte[] CreateSyncUserMessage(CommandMode commandMode,IUserInfoAdd addUser, IUserInfoDel deleteUser)
        {
            int SendDataLen = 0;
            byte[] SendData = new byte[256];
            byte[] CheckResult = new byte[1];
            byte[] Int32ByteBuf = new byte[4];

            SendData[0] = 0x00;
            SendDataLen++;
            if ((object)addUser != null)
            {
    //            int            Card_Sn;         
    //int            User_SID; 	
    //unsigned char  Group12; 
    //unsigned char  Group34; 
    //char           Valid_Data[7];   
    //char           User_Pwd[7];     	
    //char           User_Name[65];    
    //char           User_No[13];              
    //char           DepartmentId[11];
    //int            Finger_Print1;   //Fp1
    //int            Finger_Print2;   //Fp1
    //unsigned int   StartTime;
    //unsigned int    EndTime;
                SendData[0] = (byte)SyncUserCommand.Sync_WriteUser;
                try
                {
                    //CardId 4 bytes 
                    ConvertIntToByteArray(Convert.ToUInt32(addUser.CardID), ref Int32ByteBuf);                    
                    Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen,4);
                    SendDataLen += 4;
                    //User_SID 4 bytes 
                    ConvertIntToByteArray(Convert.ToInt32(addUser.UserSID), ref Int32ByteBuf);
                    Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                    SendDataLen += 4;
                    //Group12
                    SendData[SendDataLen++] = (byte)((addUser.Group1 << 4) + addUser.Group2);
                    //Group34
                    SendData[SendDataLen++] = 0;
                    byte[] tempBuf =  new byte[65];
                    //Valid_Data
                    tempBuf = Encoding.ASCII.GetBytes(addUser.ValidDate);
                    Array.Copy(tempBuf, 0, SendData, SendDataLen, addUser.ValidDate.Length);
                    SendDataLen += 7;
                    //User_Pwd
                    tempBuf = Encoding.ASCII.GetBytes(addUser.UserPin);
                    Array.Copy(tempBuf, 0, SendData, SendDataLen, addUser.UserPin.Length);
                    SendDataLen += 7;
                    //User_Name

                    if (!string.IsNullOrEmpty(addUser.UserName))
                    {
                        tempBuf = Encoding.Unicode.GetBytes(addUser.UserName);
                        byte[] utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, tempBuf);
                        Array.Copy(utf8Bytes, 0, SendData, SendDataLen, utf8Bytes.Length);
                    }
                    else
                    {
                        for (int i = 0; i < 65; i++)
                        {
                            SendData[SendDataLen+i] = 0;
                        }
                        
                    }
                    SendDataLen += 65;
                    //User_No
                    if (!string.IsNullOrEmpty(addUser.UserID))
                    {
                        tempBuf = Encoding.ASCII.GetBytes(addUser.UserID);
                        Array.Copy(tempBuf, 0, SendData, SendDataLen, addUser.UserID.Length);
                    }
                    else
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            SendData[SendDataLen + i] = 0;
                        }

                    }
                    SendDataLen += 13;
                    //DepartmentId
                    tempBuf = Encoding.ASCII.GetBytes(addUser.DepartmentID);
                    Array.Copy(tempBuf, 0, SendData, SendDataLen, addUser.DepartmentID.Length);
                    SendDataLen += 11;
                    SendDataLen += 3;
                    //Finger_Print1
                    ConvertIntToByteArray(Convert.ToInt32(addUser.FingerPrint1), ref Int32ByteBuf);
                    Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                    SendDataLen += 4;
                    //Finger_Print2
                    ConvertIntToByteArray(Convert.ToInt32(addUser.FingerPrint2), ref Int32ByteBuf);
                    Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                    SendDataLen += 4;
                    //StartTime
                    ConvertIntToByteArray(Convert.ToInt32(addUser.StartTime), ref Int32ByteBuf);
                    Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                    SendDataLen += 4;
                    //EndTime
                    ConvertIntToByteArray(Convert.ToInt32(addUser.EndTime), ref Int32ByteBuf);
                    Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                    SendDataLen += 4;
                    //SendDataLen = 133;
                }
                catch (Exception ex){
                    throw new Exception("Exception card:" + addUser.CardID + ex.Message);
                    return null;
                }
                //SendDataLen += 132;
            }
            if ((object)deleteUser != null)
            {
                if (0 == SendData[0])
                {
                    SendData[0] = (byte)SyncUserCommand.Sync_DeleteUser;
                }

                ConvertIntToByteArray(Convert.ToUInt32(deleteUser.CardID), ref Int32ByteBuf);
                Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
                SendDataLen += 4;
                //SendDataLen += 4;
            }
            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteUser, SendDataLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteUserInfo, SendDataLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendDataLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendDataLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }

            
        }
        public byte[] CreateAddUserFingerMessage(CommandMode commandMode,IUserFingerAdd addFinger)
        {
            int SendDataLen = 0;
            byte[] SendData = new byte[1024];
            byte[] Int32ByteBuf = new byte[4];
            byte[] CheckResult = new byte[1];

            ConvertIntToByteArray(Convert.ToUInt32(addFinger.CardID), ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
            SendDataLen += 4;
            SendData[SendDataLen++] = (byte)addFinger.FPNo;
            SendData[SendDataLen++] = 0;
            SendData[SendDataLen++] = 0;
            SendData[SendDataLen++] = 0;
            SendData[SendDataLen++] = 0;
            Array.Copy(addFinger.FingerData, 0, SendData, SendDataLen, addFinger.FingerData.Length);
            SendDataLen += addFinger.FingerData.Length;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_AddUserFinger, SendDataLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.EnrollFinger, SendDataLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendDataLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }
            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendDataLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] CreateDeleteUserFingerMessage(CommandMode commandMode,IUserFingerDel deleteFinger)
        {
            int SendDataLen = 0;
            byte[] SendData = new byte[640];
            byte[] Int32ByteBuf = new byte[4];
            byte[] CheckResult = new byte[1];

            ConvertIntToByteArray(Convert.ToUInt32(deleteFinger.CardID), ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
            SendDataLen += 4;
            SendData[SendDataLen++] = (byte)deleteFinger.FPNo;
            SendData[SendDataLen++] = 0;
            SendData[SendDataLen++] = 0;
            SendData[SendDataLen++] = 0;
            SendData[SendDataLen++] = 0;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_DeleteUserFinger, SendDataLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.DeleteFinger, SendDataLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendDataLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendDataLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
            
        }
        //Device parameters
        public byte[] CreateSyncDeviceParaMessage(CommandMode commandMode, SyncParameter syncDev)
        {
            byte[] SendData = new byte[32];
            byte[] CheckResult = new byte[1];
            byte[] tempBuf = new byte[16];
            int sendLen = 1;

            for (int i = 0; i < 6; i++)
            {
                SendData[1 + i] = 0;
            }
            SendData[0] = 0;
            if (syncDev.SyncMenuPwdFlag)
            {
                SendData[0] += 0x01;
                tempBuf = Encoding.ASCII.GetBytes(syncDev.MenuPwd);
                Array.Copy(tempBuf, 0, SendData, sendLen, syncDev.MenuPwd.Length > 6 ? 6 : syncDev.MenuPwd.Length);
                sendLen += 6;
            }
            if (syncDev.SyncLanguageFlag)
            {
                SendData[0] += 0x02;
                SendData[sendLen] = (byte)syncDev.Language;
                sendLen += 1;
            }
            if (syncDev.SyncWorkModeFlag)
            {
                SendData[0] += 0x04;
                SendData[sendLen] = (byte)syncDev.WorkMode;
                sendLen += 1;
            }

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_SetDevPara, sendLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteDevicePara, sendLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < sendLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, sendLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }

        }
        //Time Set Message
        public byte[] CreateSyncTimeSetMessage(CommandMode commandMode,IAcTimeSet acTimeSet)
        {
            byte[] SendData = new byte[32];
            byte[] CheckResult = new byte[1];

            SendData[0] = acTimeSet.DoorID;
            SendData[1] = acTimeSet.TimeSetID;
            SendData[2] = acTimeSet.StartHour;
            SendData[3] = acTimeSet.StartMin;
            SendData[4] = acTimeSet.EndHour;
            SendData[5] = acTimeSet.EndMin;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteTimeSet, 6);
            else
                CreateMesageHeader((byte)SyncServerCommand.WrtieTimeSet, 6);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < 6; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 6);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        //Time Zone
        public byte[] CreateSyncTimeZoneMessage(CommandMode commandMode,IAcTimeZone acTimeZone)
        {
            byte[] SendData = new byte[32];
            byte[] CheckResult = new byte[1];

            SendData[0] = acTimeZone.DoorID;
            SendData[1] = acTimeZone.TimeZoneID;
            SendData[2] = acTimeZone.Frame01;
            SendData[3] = acTimeZone.Frame02;
            SendData[4] = acTimeZone.Frame03;
            SendData[5] = acTimeZone.Frame04;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteTimeZone, 6);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteTimeZone, 6);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < 6; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, 6);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        //User Group
        public byte[] CreateSyncUserGroupMessage(CommandMode commandMode,IAcUserGroupSet acUserGroup)
        {
            byte[] SendData = new byte[32];
            byte[] CheckResult = new byte[1];
            int SendLen = 17;
            SendData[0] = acUserGroup.DoorID;
            SendData[1] = acUserGroup.GroupID;
            SendData[2] = acUserGroup.Sun;
            SendData[3] = acUserGroup.Mon;
            SendData[4] = acUserGroup.Tue;
            SendData[5] = acUserGroup.Wed;
            SendData[6] = acUserGroup.Thu;
            SendData[7] = acUserGroup.Fri;
            SendData[8] = acUserGroup.Sat;
            SendData[9] = acUserGroup.Holi1Group;
            SendData[10] = acUserGroup.Holi2Group;
            SendData[11] = acUserGroup.Holi3Group;
            SendData[12] = acUserGroup.Holi4Group;
            SendData[13] = acUserGroup.Holi5Group;
            SendData[14] = acUserGroup.Holi6Group;
            SendData[15] = acUserGroup.Holi7Group;
            SendData[16] = acUserGroup.Holi8Group;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteUserGroup, SendLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.WrtieUserGroup, SendLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        public byte[] CreateSyncChangeCardIdMessage(CommandMode commandMode, ChangeCardIDCls changeCardId)
        {
            byte[] SendData = new byte[32];
            byte[] CheckResult = new byte[1];
            byte[] Int32ByteBuf = new byte[4];
            int SendDataLen = 0;

            ConvertIntToByteArray(changeCardId.ChangeID, ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
            SendDataLen += 4;

            ConvertIntToByteArray(Convert.ToUInt32(changeCardId.OldCardID), ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
            SendDataLen += 4;
            ConvertIntToByteArray(Convert.ToUInt32(changeCardId.NewCardID ), ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, SendDataLen, 4);
            SendDataLen += 4;

           

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_ChangeCardId, SendDataLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.ChangeCardId, SendDataLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendDataLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendDataLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        //Holidy Set
        public byte[] CreateSyncHolidaySetMessage(CommandMode commandMode,IAcHolidaySet acHolidaySet)
        {
            byte[] SendData = new byte[32];
            byte[] CheckResult = new byte[1];
            int SendLen = 6;
            SendData[0] = acHolidaySet.DoorID;
            SendData[1] = (byte)(acHolidaySet.DoorHoliID >> 8);
            SendData[2] = (byte)(acHolidaySet.DoorHoliID & 0xff);
            SendData[3] = acHolidaySet.HoliMonth;
            SendData[4] = acHolidaySet.HoliDay;
            SendData[5] = acHolidaySet.HoliType;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteHolidaySet, SendLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteHoliday, SendLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        //Access Control
        public byte[] CreateSyncUserAuthorityMessage(CommandMode commandMode,IAcAuthority acAuthority)
        {
            byte[] SendData = new byte[32];
            byte[] CheckResult = new byte[1];
            byte[] Int32ByteBuf = new byte[4];
            int SendLen = 9;

            ConvertIntToByteArray(Convert.ToUInt32(acAuthority.CardID), ref Int32ByteBuf);
            Array.Copy(Int32ByteBuf, 0, SendData, 0, 4);

            SendData[4] = acAuthority.AllowTimeStartHour;
            SendData[5] = acAuthority.AllowTimeStartMinute;
            SendData[6] = acAuthority.AllowTimeEndHour;
            SendData[7] = acAuthority.AllowTimeEndMinute;
            SendData[8] = acAuthority.GroupID;

            if (commandMode == CommandMode.TcpClient)
                CreateMesageHeader((byte)SyncClientCommand.Com_WriteUserAuthority, SendLen);
            else
                CreateMesageHeader((byte)SyncServerCommand.WriteAcParaAdv, SendLen);
            CheckResult[0] = 0;
            for (int i = 0; i < RequestMessageHeader.Length; i++)
            {
                CheckResult[0] ^= RequestMessageHeader[i];
            }
            for (int i = 0; i < SendLen; i++)
            {
                CheckResult[0] ^= SendData[i];
            }

            using (System.IO.MemoryStream m = new System.IO.MemoryStream())
            {

                m.WriteAsync(RequestMessageHeader, 0, 7);
                m.WriteAsync(SendData, 0, SendLen);
                m.WriteAsync(CheckResult, 0, 1);
                return m.ToArray();

            }
        }
        

    }
}
