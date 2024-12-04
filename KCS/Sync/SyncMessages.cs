using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Sync
{
    public class SyncMessages
    {
    }
    public enum ProtocolType
    {

        ResetDevice = 1,
        DeleteTransaction = 2,
        UpdatePushedFinger = 3,
        WriteTimeset = 4,
        WriteTimeZone = 5,
        WriteUserGroup = 6,
        WriteHoliday = 7,
        ReadTransactions = 8,
        WriteDeviceTime = 9,
        WriteUser = 10,
        WriteUserFinger = 11,
        WriteUserAuthority = 12,
       
    }
    public enum SyncClientCommand
    {
        Com_WriteTime_Old = 0xA7,
        Com_WriteTime = 0xee,
        Com_ResetDevice = 0xb4,
        Com_DelReadTransaction = 0xe0,
        Com_DevicePushFingerOk = 0xe4,
        Com_WriteTimeSet = 0xe7,
        Com_WriteTimeZone = 0xe8,
        Com_WriteUserGroup = 0xe9,
        Com_WriteHolidaySet = 0xea,
        Com_ReadTransaction = 0xe5,
        Com_WriteUser = 0xe0,
        Com_DeleteUserFinger = 0xe2,
        Com_AddUserFinger = 0xe1,
        Com_WriteUserAuthority = 0xed,
        Com_ReadTransAgain = 0xef,
        Com_ChangeCardId = 0xf0, // change card 2017 11 17
        Com_SetDevPara = 0xf1,//set device para 2018 3 5
        Com_RebootDevice = 0xf2,
        Com_OpenDoor = 0xb5,
        Com_SetDoorPin = 0xf9,//set open door  pin 2019 7 1
        Com_DelReadTransactionWithId = 0xfb,
    }
    public enum SyncUserCommand
    {
        Sync_WriteUser = 0x02,
        Sync_DeleteUser = 0x03

    }
    public enum ReturnCode
    {
        WriteTimeOrReSetDeviceOk = 0x01,
        WriteUserOkByChar = 0x11,
        WriteUserOk    = 0x01,
        WriteUserFingerOkByChar = 0x12,
        WriteUserFingerOk = 0x02,
        DeleteUserFingerOkByChar = 0x13,
        DeleteUserFingerOk = 0x03,
        ReadSalveOkByChar = 0x14,
        ReadSalveOk = 0x04,
        WriteUserAuthorityOkByChar = 0x15,
        WriteUserAuthorityOk = 0x05,
        WriteTimeSetOk = 0x06,
        WriteTimeZoneOk = 0x07,
        WriteUserGroupOk = 0x08,
        WriteHolidayOk = 0x09,
        ReadDeviceVersionOk = 0x0b,
        ChangeCardIdOk = 0x0c,
        WriteDeviceParaOk = 0x0d,
        WriteDoorPINOk = 0x0e,
        WriteTimeOk = 0x20,
        RCV_FACE_PHOTO = 0x40,

        // Add: 2024/03/29      若KCS 執行 "Open Door" 之後，且relay順利啟動。 OR_Transaction 有收到 !SOFTOPEN!紀錄然後就開始持續收到 returnCode 0xF5 
        //                      刚查了一下，如果数据通信错误或者设备收到未识别的指令 就好返回F5。这个回传11 应该没事，可能是粘包了 或者啥的
        //                      这个应该是记录类型的问题 datasync 和 OR_Tans 不匹配 那kcs把这个错误屏蔽, 这个主要是调试用的
        ReadSlaveOkException = 0xF5
    }
    public enum SyncServerCommand
    {
        WriteTime = 0x70,
        WriteUTCTime = 0x91,
        ResetDevice = 0x71,
        WrtieAcPara = 0x72,
        WriteAcParaAdv = 0x79,
        WrtieTimeSet = 0x80,
        WriteTimeZone = 0x81,
        WrtieUserGroup = 0x82,
        WriteHoliday = 0x83,
        WriteDoorPara = 0x84,
        WriteBell= 0x85,
        ReadTransAgain = 0x86,
        WriteUserInfo = 0x73,
        DeleteFinger = 0x75,
        EnrollFinger = 0x76,
        UpdateReadedFinger = 0x78,
        ChangeCardId = 0x92,
        WriteDevicePara = 0x93,
        OpenDoor = 0x94,
        SetDoorPin = 0x95,
        RebootDevice = 0x96        
    }
    public enum RequestCommand
    {
        RequestTime = 0x37,
        RequestData = 0x66,
        PushDeviceData= 0x68,
        PushDeviceDataByChar = 0x58,
        ResetDeviceReturn = 0x31,
        WriteAcParaReturn = 0x32,
        WriteTimeSetReturn = 0x41,
        WriteTimeZoneReturn = 0x42,
        WriteUserGroupReturn = 0x43,
        WriteHolidaySetReturn = 0x44,
        WriteDoorParaReturn = 0x45,
        WriteBellParaReturn = 0x46,
        WriteUserInfoReturn = 0x33,
        DeleteFingerReturn = 0x26,
        EnrollFingerReturn = 0x36,
        ChangeCardIdReturn = 0x38,
        WriteDeviceReturn = 0x39,
        OpenDoorReturn = 0x40,
        DoorPinReturn = 0x47,
        TransFaceImage = 0x52

    }
    
}
