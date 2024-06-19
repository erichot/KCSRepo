using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("KCS")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("KCS")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("c20b63ff-4512-4b80-90d8-b7e90d7a9328")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
/*
 * 
 * 1.0.0.4 fix 同步门禁权限 1.0.0.2,fix手动导出
 * 1.0.0.5 考勤跨天
 * 1.0.0.6 考勤跨天 Relase
 * 2018 3 16 1.0.0.7 修正同步指纹数量不相等 pc 和 设备
 * 2018 3 21 1.0.0.8 下载参赛卡住
 * 2018 3 23 1.0.0.9 不开启同步，无法初始化门禁设置参数
 * 2018 3 27 1.0.1.0 考勤记录照片异常引起kcs问题
 *  * 2018 3 27 1.0.1.1 设置参数错误
 *  2018 4 2 1.0.1.2 节假日打卡记录算为加班,不显示请假时间
 *  2018 4 8 1.0.1.3修改報表數據源，提升報表生成速度
 *   2018 4 20 1.0.1.4修改无法enable cardid忘记加 ''
 *    2018 5 16 1.0.1.5 删除指纹后刷新显示
 *    2018 7 4 1.0.1.6 远端开门
 *    2018 8 1 1.0.1.7 请假时间计算
 *    2018 8 14 1.0.1.8 请假条加姓名
 *    2018 8 14 1.0.1.9假期设置错误
 *    2018 9 5 1.0.2.0将截止字符串或二进制数据 错误
 *    2018 9 18 1.0.2.1 CHK_WORKLIST alter column WORK_WEEK* 
 *    2018 11 14 1.0.2.2 设备同步设定 
 *    2018 12 18 1.0.2.3导出文件格式增加CSV
 *    2018 12 24 1.0.2.4导出栏位增加device Name
 *    2019 1 2 1.0.2.5 编辑个人出勤历可以查看以前信息
 *    2019 1 19 1.0.2.6 导出文件有错
 *    2019 3 1  1.0.2.7 编辑个人出勤历 缩回
 *    2019 3 31  1.0.2.8 应savy需要修改出勤报表，增加假期，并且不现实离职人员报表
 *    2019 4 4  1.0.2.9 数据库维护
 *    2019 5 23  1.0.3.0 导出数据
 *    SELECT TOP (100) PERCENT [CardID], TranDateTime,IsByTranType,TranType,DataType,SlaveSID FROM [OR_Transactions]  WHERE TranDateTime >=@BeginDate AND TranDateTime <=@EndDate AND (((IsByTranType = 1) AND (TranType&240 = 0  OR TranType = 161 OR TranType = 162 OR TranType&240 = 16  OR TranType&240 = 96))    OR ((IsByTranType = 0) AND (TranType&240 <> 32 AND TranType&240 <> 48 AND TranType&240 <> 64 AND TranType&240 <> 80 AND TranType&240 <> 144)) ) ORDER BY  TranDateTime
    改为SELECT TOP (100) PERCENT [CardID], TranDateTime,IsByTranType,TranType,DataType,SlaveSID FROM [OR_Transactions]  WHERE TranDateTime >=@BeginDate AND TranDateTime <=@EndDate AND (((IsByTranType = 1) AND (TranType&240 = 0  OR TranType = 161 OR TranType = 162 OR TranType&240 = 160  OR TranType&240 = 96))    OR ((IsByTranType = 0) AND (TranType&240 <> 32 AND TranType&240 <> 48 AND TranType&240 <> 64 AND TranType&240 <> 80 AND TranType&240 <> 144)) ) ORDER BY  TranDateTime
    TranType&240 = 16  有误
 * 2019 5 30 fix 710记录类型是 D0 E0 无法导出
 * 2019 06 17   kcs sync作为server增加延时，防止占用cpu
 * 2019 07 05  1.0.3.3增加开门密码设置功能
 * 2019 09 10  1.0.3.4修正bug
 * * 2019 12 3  1.0.3.5简易报表日期排序
 * 2019 12 17 1.0.3.6 增加customtext2  customtext3
 * 2020 02 03 1.0.3.7 修正简易报表时间问题
 * 2020 06 09 1.0.3.8 增加Excel导出
 * 2020 06 22 1.0.3.9 电梯控制权限查询
 * 2020 09 18 1.0.4.0 导出访问禁止记录
 * 2020 10 29 1.0.4.1 人脸设备支持
 * * 2020 10 29 1.0.4.2 自动读取人脸照片
 * 2021 2 24 1.0.4.3 修改人脸找文件夹名称为Staff photos
 * 2021 2 26 1.0.4.4 增加重新同步门禁参数功能，增加人脸照片导入功能
 * * 2021 3 10 1.1.4.4 savy定制导出加3个空格
 *  * * 2021 3 15 1.0.4.5 手动导出当天记录
 *  [assembly: AssemblyVersion("1.0.4.6")]// fix 同步门禁权限 1.0.0.2,fix手动导出
 */
[assembly: AssemblyVersion("1.1.5.23")]         // 2024-06-19          原本Transaction Report 遺漏體溫欄位。
//[assembly: AssemblyVersion("1.1.5.22")]         // 2024-05-09          Device 在100%正常Windows字體大小時，IP與Slave兩排文字互相擠壓。
//[assembly: AssemblyVersion("1.1.5.21")]         // 2024-04-23          Employees > Access Control Parameters [StartTimeStr], [EndTimeStr] 這個地方無法正常顯示
//[assembly: AssemblyVersion("1.1.5.20")]          // 2024-04-04          Toyota AllowTime Report add DoorName, Allow time is 00:00-00:00 by default while create employee
//[assembly: AssemblyVersion("1.1.5.19")]          // 2024-04-04          Exception  : Error - ReadSalveOk將資料類型從 numeric 轉換到 decimal 時發生錯誤。KCS 嘗試在DB建立一筆OR_Transaction卡號：!SOFTOPEN! TranType: 144 體溫：38174.8
//[assembly: AssemblyVersion("1.1.5.18")]          // 2024-03-29          这个应该是记录类型的问题 datasync 和 OR_Tans 不匹配 那kcs把这个错误屏蔽, 这个主要是调试用的
//[assembly: AssemblyVersion("1.1.5.17")]          // 2024-03-11          KCS.command.DAL.DataBase.Query Timeouit設定60
//[assembly: AssemblyVersion("1.1.5.16")]          // 2024-01-19          KCS.command.DAL.DataBase.Query Timeouit設定60
//[assembly: AssemblyVersion("1.1.5.15")]          // 2023-12-01          Transaction Report增加IP，並隱藏Photo、體溫欄位
//[assembly: AssemblyVersion("1.1.5.14")]          // 2023-11-16          Toyota 部分UI改善
//[assembly: AssemblyVersion("1.1.5.13")]          // 2023-10-22          Toyota 避開管理員權限要求
//[assembly: AssemblyVersion("1.1.5.12")]          // 2023-10-17          Toyota 允許進出時間報表
//[assembly: AssemblyVersion("1.1.5.11")]          // 2023-07-30          Toyota
//[assembly: AssemblyVersion("1.1.5.10")]          // 2023-06-28         Only DB: UDF_DS_BF_FP_Add_BySlaveSID 要加一个限制，必须是DeviceType=Finger 的设备 才会有指纹数据列表
//[assembly: AssemblyVersion("1.1.5.9")]          // 2023-06-27       IsServerMode => Push Sync／張工調整ClientSync
//[assembly: AssemblyVersion("1.1.5.8")]          // 2023-03-20       新增AttendenceReport FlexShift，排除Tran_PHOTO引起刷卡紀錄重複問題
//[assembly: AssemblyVersion("1.1.5.7")]          // 2023-01-26       新增AttendenceReport FlexShift
//[assembly: AssemblyVersion("1.1.5.6")]          // 2023-01-11       調整DeviceSettingManage的gridControl.RefreshDataSource()導致selection change的問題
//[assembly: AssemblyVersion("1.1.5.5")]      // 2022-12-19       KCS.Common.DAL.ExportData adding TranType from Export data
//[assembly: AssemblyVersion("1.1.5.4")]      // 2022-12-09       TxtExportSetting set to Day/Month/Year not work (CY)
//[assembly: AssemblyVersion("1.1.5.3")]      // 2022-11-23
//[assembly: AssemblyVersion("1.1.5.2")]      // 2022-08-29   那我就要勞煩Eric在主程式上改一下並且把版本升到1151
//[assembly: AssemblyFileVersion("1.1.5.5")]  // Hi YG, KACS.exe 上頭的Kizone logo 我能自己換成IDCOM的嗎? 還是必須你來換?
[assembly: AssemblyFileVersion("1.1.5.23")]
