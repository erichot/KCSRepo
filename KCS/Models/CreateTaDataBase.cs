using KCS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    static class CreateTaDataBase
    {
        
        /*
        /// <summary>
        /// CLASS_CODE nvarchar(5) not null,
            CLASS_DESC nvarchar(20),
            WORK_TIME_START nchar(4),
            WORK_TIME_END nchar(4),
            WORK_TIME_LATE nchar(4),
            WORK_TIME_OVERTIME nchar(4),
            TURN_OVERTIME float,
            RELAX_TIME1 nchar(4),
            RELAX_TIME2 nchar(4),
            RELAX_TIME3 nchar(4),
            RELAX_TIME4 nchar(4),
            TURN_TIME int,
            CREATE_NAME nvarchar(30),
            CREATE_TIME datetime,
            BUILD_NAME nvarchar(30),
            BUILD_TIME datetime,
            CLASS_AMT int,
            LEAVE_CK bit,
            LEAVE_HOURS float,
        /// </summary>
         * */
        const string ELEVATOR_CONTROL  = "ElevatorControl";
        const string CREATE_ELEVATOR_CONTROL = @"CREATE TABLE ElevatorControl (
                    EleavatorID [int] IDENTITY(1,1) NOT NULL,
                    SlaveSID [int] NOT NULL,
                    EleavatorName nvarchar(30),
                    EleavatorDes  nvarchar(255),
                    CONSTRAINT [PK_ElevatorControl] PRIMARY KEY CLUSTERED 
            (
	            [EleavatorID] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";

        
        const string EMPLOYEES_PHOTO = "PHOTO_SYNC";
        const string CREATE_PHOTO_SYNC = @"CREATE TABLE PHOTO_SYNC (
                    PhotoID [int] IDENTITY(1,1) NOT NULL,
                    SlaveSID [int] NOT NULL,
                    CardID nvarchar(14) not null,
                    IsReplicated [bit] NOT NULL,
                    CONSTRAINT [PK_PhotoSync] PRIMARY KEY CLUSTERED 
            (
	            [PhotoID] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";




        const string DOOR_PWD  = "DOOR_PWD";
        const string CREATE_DOOR_PWD = @"CREATE TABLE DOOR_PWD ( 
	            [SlaveSID] [int] NOT NULL,
                PIN1_NAME nvarchar(30),
                PIN1_CODE tinyint,
                PIN1_START_DATE date,
                PIN1_START_HOUR tinyint,
                PIN1_START_MIN tinyint,
                PIN1_END_DATE date,
                PIN1_END_HOUR tinyint,
                PIN1_END_MIN tinyint,
                PIN1 VARBINARY(MAX),
                PIN2_NAME nvarchar(30),
                PIN2_CODE tinyint,
                PIN2_START_DATE date,
                PIN2_START_HOUR tinyint,
                PIN2_START_MIN tinyint,
                PIN2_END_DATE date,
                PIN2_END_HOUR tinyint,
                PIN2_END_MIN tinyint,
                PIN2 VARBINARY(MAX),
                IsReplicated [bit] NOT NULL,
                CONSTRAINT [PK_DOOR_PWD] PRIMARY KEY CLUSTERED 
            (
	            [SlaveSID] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
       
        const string CHK_CLASS = "CHK_CLASS"; //班别设定名称
        //创建班别设定表
        const string CREATE_CHK_CLASS = @"CREATE TABLE CHK_CLASS (
            CLASS_CODE nvarchar(10) not null,
            CLASS_DESC nvarchar(20),
            WORK_TIME_START time(0),
            WORK_TIME_END time(0),
            WORK_TIME_LATE time(0),
            WORK_TIME_OVERTIME time(0),
            TURN_OVERTIME float,
            RELAX_TIME1 time(0),
            RELAX_TIME2 time(0),
            RELAX_TIME3 time(0),
            RELAX_TIME4 time(0),
            TURN_TIME int,
            CREATE_NAME nvarchar(30),
            CREATE_TIME datetime,
            BUILD_NAME nvarchar(30),
            BUILD_TIME datetime,
            CLASS_AMT int,
            LEAVE_CK bit,
            LEAVE_HOURS float,
            CONSTRAINT [PK_CLASS_CODE] PRIMARY KEY CLUSTERED 
            (
	            [CLASS_CODE] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        const string CHK_TURNWORK = "CHK_TURNWORK"; //周班表，出勤历维护
        const string CREATE_CHK_TURNWORK = @"CREATE TABLE CHK_TURNWORK (
            TURNWORK_GRP nvarchar(10) not null,
            TURNWORK_DESC nvarchar(20),
            CLASS_CODE1 nvarchar(10),
            CLASS_CODE2 nvarchar(10),
            CLASS_CODE3 nvarchar(10),
            CLASS_CODE4 nvarchar(10),
            CLASS_CODE5 nvarchar(10),
            CLASS_CODE6 nvarchar(10),
            CLASS_CODE7 nvarchar(10),
            CREATE_NAME nvarchar(30),
            CREATE_TIME datetime,
            BUILD_NAME nvarchar(30),
            BUILD_TIME datetime,
            CONSTRAINT [PK_CHK_TURNWORK] PRIMARY KEY CLUSTERED 
            (
	            [TURNWORK_GRP] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        //请假类别
        const string CHK_LEAVE = "CHK_LEAVE";
        const string CREATE_CHK_LEAVE = @"CREATE TABLE CHK_LEAVE (
                LEAVE_CODE nvarchar(10) not null,
                LEAVE_DESC  nvarchar(20),
                CUT_MODE tinyint,
                CREATE_NAME nvarchar(30),
                CREATE_TIME datetime,
                BUILD_NAME nvarchar(30),
                BUILD_TIME datetime,
                CUT_ABS bit,
                CONSTRAINT [PK_CHK_LEAVE] PRIMARY KEY CLUSTERED 
            (
	            [LEAVE_CODE] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";

        const string CHK_HOLIDAY = "CHK_HOLIDAY";//假日设定
        const string CREATE_CHK_HOLIDAY = @"CREATE TABLE CHK_HOLIDAY (
            HOLIDAY nchar(4) not null,
            HOLIDAY_DESC nvarchar(20),
            CREATE_NAME nvarchar(30),
            CREATE_TIME datetime,
            BUILD_NAME nvarchar(30),
            BUILD_TIME datetime,
            CONSTRAINT [PK_CHK_HOLIDAY] PRIMARY KEY CLUSTERED 
            (
	            [HOLIDAY] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        //行事历设定
        const string CHK_CALENDAR = "CHK_CALENDAR";
        const string CREATE_CHK_CALENDAR = @"CREATE TABLE CHK_CALENDAR (
            REST_GRP tinyint not null,
            HOLIDAY_CK bit,
            CREATE_NAME nvarchar(30),
            CREATE_TIME datetime,
            BUILD_NAME nvarchar(30),
            BUILD_TIME datetime,
        
        CONSTRAINT [PK_CHK_CALENDAR] PRIMARY KEY CLUSTERED 
            (
	            REST_GRP ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        //行事历 Calendar
        const string CHK_DOLIST = "CHK_DOLIST";
        const string CREATE_CHK_DOLIST = @"CREATE TABLE CHK_DOLIST (
            LIST_YEAR int not null,
            LIST_DATE DateTime not null,
            LIST_WEEK nvarchar(4),
            LIST_MEMO nvarchar(20),
            HOLIDAY_CK bit,
            CREATE_NAME nvarchar(30),
            CREATE_TIME datetime,
            BUILD_NAME nvarchar(30),
            BUILD_TIME datetime,
            LIST_GRP tinyint
        
        CONSTRAINT [PK_CHK_DOLIST] PRIMARY KEY CLUSTERED 
            (
	            LIST_YEAR ASC,
                LIST_DATE ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        //年度出勤历
        const string CHK_WORKLIST = "CHK_WORKLIST";
        const string CREATE_CHK_WORKLIST = @"CREATE TABLE CHK_WORKLIST (
            WORK_YEAR int not null,
            TURNWORK_GRP nvarchar(10) not null,
            WORK_DATE DateTime not null,
            WORK_WEEK nvarchar(4),
            CLASS_CODE nvarchar(20),
            CREATE_NAME nvarchar(30),
            CREATE_TIME datetime,
            BUILD_NAME nvarchar(30),
            BUILD_TIME datetime,
            LIST_GRP tinyint
        
        CONSTRAINT [PK_CHK_WORKLIST] PRIMARY KEY CLUSTERED 
            (
	            WORK_YEAR ASC,
                TURNWORK_GRP ASC,
                WORK_DATE ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        //个人年度出勤历，PER_CHK
        const string PER_CHK = "PER_CHK";
        const string CREATE_PER_CHK = @"CREATE TABLE PER_CHK (
        EMP_CODE nvarchar(16) not null,
        CardID nvarchar(14) not null,
        CHK_DATE DateTime not null,
        CLASS_CODE nvarchar(20),
        CLOCK_CK bit,
        LEAVE_CODE nvarchar(10),
        CHK bit,
        CREATE_NAME nvarchar(30),
        CREATE_TIME datetime,
        BUILD_NAME nvarchar(30),
        BUILD_TIME datetime,
        LIST_GRP tinyint
       CONSTRAINT [PK_PER_CHK] PRIMARY KEY CLUSTERED 
            (
	            EMP_CODE ,
                CardID ,
                CHK_DATE ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        // view
        const string VPER_CHK = "VPER_CHK";
        const string CREATE_VPER_CHK = @"CREATE VIEW VPER_CHK AS 
        SELECT TOP (100) PERCENT C.[DepartmentID],C.DepartmentName,C.UserName,[EMP_CODE],A.[CardID],year([CHK_DATE]) AS CheckYear,[CHK_DATE],A.[CLASS_CODE],[CLOCK_CK],[LEAVE_CODE],[CHK],A.[CREATE_NAME],A.[CREATE_TIME],A.[BUILD_NAME],A.[BUILD_TIME],[LIST_GRP],[WORK_TIME_START],[WORK_TIME_END],[WORK_TIME_LATE],[WORK_TIME_OVERTIME],
        [RELAX_TIME1],[RELAX_TIME2],[RELAX_TIME3],[RELAX_TIME4],[TURN_OVERTIME],[TURN_TIME],[CLASS_DESC] from [PER_CHK]  AS A Left join [CHK_CLASS] AS B ON A.CLASS_CODE=B.CLASS_CODE 
         Left join [VBF_User] AS C ON A.EMP_CODE=C.UserID Order BY CHK_DATE ASC";

       
        const string VCHANGE_CARD = "VCHANGE_CARD";
        const string CREATE_VCHANGE_CARD = @"CREATE VIEW VCHANGE_CARD AS 
        SELECT TOP (100) PERCENT ChangeID,SlaveSID,OldCardID,NewCardID from [CHANGE_CARD]  where IsReplicated=0 Order BY ChangeID ASC";
        //Valid Transactions View 
        const string PER_LEAVE = "PER_LEAVE";
        const string CREATE_PER_LEAVE = @"CREATE TABLE PER_LEAVE (
        NUM nvarchar(20) not null,
        USE_DATE datetime,
        EMP_CODE nvarchar(20),
        SPHOLIDAY bit,
        OVERDAY bit,
        LEAVE_CODE nvarchar(5),
        LEAVE_DATE1 datetime,
        LEAVE_DATE2 datetime,
        LEAVE_TIME1 time(0),
        LEAVE_TIME2 time(0),
        SUM_TIME float,
        AGENT nvarchar(20),
        STATUS nvarchar(20),
        CFM_NAME nvarchar(20),
        CFM_TIME datetime,        
        CREATE_NAME nvarchar(30),
        CREATE_TIME datetime,
        BUILD_NAME nvarchar(30),
        BUILD_TIME datetime
       CONSTRAINT [PK_PER_LEAVE] PRIMARY KEY CLUSTERED 
            (
	            NUM
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";

        const string PER_LEAVE_D = "PER_LEAVE_D";
        const string CREATE_PER_LEAVE_D = @"CREATE TABLE PER_LEAVE_D (
        NUM nvarchar(20) not null,
        SN int not null,        
        LEAVE_DATE datetime,
        TURN_HOUR float,
        SUM_TIME float,             
        CREATE_NAME nvarchar(30),
        CREATE_TIME datetime,
        BUILD_NAME nvarchar(30),
        BUILD_TIME datetime
       CONSTRAINT [PK_PER_LEAVE_D] PRIMARY KEY CLUSTERED 
            (
	            NUM,
                SN ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
        

        const string SALVE_FACE_VIEW = "VS_SlaveFace";
        const string CREATE_SLAVE_FACE_VIEW = @"CREATE VIEW VS_SlaveFace
AS
SELECT  ID, IP, IP_Internal, SlaveSID, NotPropagateWithUsersByDefault, DeviceType, SlaveName
FROM      dbo.S_SlaveIP
WHERE   (DeviceType = 'Face')";
        //Function
        const string FUNC_VALID_TRANSACTIONS_New = "UVALID_TRANSACTIONS_New";
        const string CREATE_FUNC_VALID_TRANSACTIONS_New = @"FUNCTION [dbo].[UVALID_TRANSACTIONS_New]
(	
	
	@BeginDate VARCHAR(20),
	@EndDate VARCHAR(20)
	
	
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT TOP (100) PERCENT [CardID], TranDateTime,IsByTranType,TranType,DataType,SlaveSID FROM [OR_Transactions]  WHERE TranDateTime >=@BeginDate AND TranDateTime <=@EndDate AND (((IsByTranType = 1) AND (TranType&240 = 0  OR TranType = 161 OR TranType = 162 OR TranType&240 = 160  OR TranType&240 = 96))    OR ((IsByTranType = 0) AND (TranType&240 <> 32 AND TranType&240 <> 48 AND TranType&240 <> 64 AND TranType&240 <> 80 AND TranType&240 <> 144)) ) ORDER BY  TranDateTime
)";
        //Function
        const string FUNC_VALID_TRANSACTIONS_New1 = "UVALID_TRANSACTIONS_New1";
        const string CREATE_FUNC_VALID_TRANSACTIONS_New1 = @"FUNCTION [dbo].[UVALID_TRANSACTIONS_New1]
(	
	
	@BeginDate VARCHAR(20),
	@EndDate VARCHAR(20)
	
	
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT TOP (100) PERCENT [CardID], TranDateTime,IsByTranType,TranType,DataType,SlaveSID,convert(varchar(10),TranDateTime,120) AS CHK_DATE FROM [OR_Transactions]  WHERE TranDateTime >=@BeginDate AND TranDateTime <=@EndDate AND (((IsByTranType = 1) AND (TranType&240 = 0  OR TranType = 161 OR TranType = 162 OR TranType&240 = 160  OR TranType&240 = 96))    OR ((IsByTranType = 0) AND (TranType&240 <> 32 AND TranType&240 <> 48 AND TranType&240 <> 64 AND TranType&240 <> 80 AND TranType&240 <> 144)) ) ORDER BY  TranDateTime
)";
        const string FUNC_PER_CHECK_SECTION = "UPER_CHECK_SECTION";
        const string CREATE_FUNC_PER_CHECK_SECTION = @"Create FUNCTION [dbo].[UPER_CHECK_SECTION]
(	
	
	@BeginDate VARCHAR(10),
	@EndDate VARCHAR(10)
	
	
)
RETURNS TABLE 
AS
RETURN 
(
    SELECT TOP (100) PERCENT * from VPER_CHK where CHK_DATE>=@BeginDate AND CHK_DATE <=@EndDate
)";
        const string FUNC_PER_LEAVE_ITEMS = "UPER_LEAVE_ITEMS";
        const string CREATE_FUNC_PER_LEAVE_ITEMS = @"Create FUNCTION [dbo].[UPER_LEAVE_ITEMS]
(	
	
	@BeginDate VARCHAR(10),
	@EndDate VARCHAR(10)
	
	
)
RETURNS TABLE 
AS
RETURN 
(
    SELECT TOP (100) PERCENT [LEAVE_DATE],B.[LEAVE_CODE],C.[LEAVE_DESC],A.[SUM_TIME],B.EMP_CODE,B.LEAVE_TIME1,B.LEAVE_TIME2 from [PER_LEAVE_D] AS A left join [PER_LEAVE] AS B ON A.NUM=B.NUM
        Left Join [CHK_LEAVE] AS C ON B.LEAVE_CODE = C.LEAVE_CODE 
        where LEAVE_DATE>=@BeginDate AND LEAVE_DATE <=@EndDate
)";

    //用户照片同步
        const string DS_User_Face_Add = "DS_User_Face_Add";
        const string CREATE_DS_User_Face_Add = @"CREATE TABLE [dbo].[DS_User_Face_Add](
	[FaceAddSID] [int] IDENTITY(1,1) NOT NULL,
    [UserSID] [int] NOT NULL,    
	[CardID] [nvarchar](14) NOT NULL,
	[SlaveSID] [int] NOT NULL,
	[InActive] [bit] NOT NULL CONSTRAINT [DS_USER_FACE_Add_InActive]  DEFAULT ((0)),
	[TimeAddNew] [datetime] NOT NULL CONSTRAINT [DS_USER_FACE_Add_TimeAddNew]  DEFAULT (getdate()),
	[UserAddNewSID] [int] NOT NULL CONSTRAINT [DS_USER_FACE_Add_UserAddNewSID]  DEFAULT ((0)),
	[TimeModifyLast] [datetime] NULL,
	[UserModifyLastSID] [int] NULL,
	[IsReplicated] [bit] NOT NULL CONSTRAINT [DS_USER_FACE_Add_IsReplicated]  DEFAULT ((0)),
	[ReplicateReturnID] [int] NOT NULL CONSTRAINT [DS_USER_FACE_Add_ReplicateReturnID]  DEFAULT ((0)),
	[TimeReplicated] [datetime] NULL,
 CONSTRAINT [PK_DS_USER_FACE_Add] PRIMARY KEY CLUSTERED 
(
	[FaceAddSID] ASC,
	[SlaveSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]";//

        
const string DS_User_Face_Del = "DS_User_Face_Del";
        const string CREATE_DS_User_Face_Del = @"CREATE TABLE [dbo].[DS_User_Face_Del](
	[FaceDelSID] [int] IDENTITY(1,1) NOT NULL,
	[UserSID] [int] NOT NULL,    
	[CardID] [nvarchar](14) NOT NULL,
	[SlaveSID] [int] NOT NULL,
	[InActive] [bit] NOT NULL CONSTRAINT [DS_USER_FACE_Del_InActive]  DEFAULT ((0)),
	[TimeAddNew] [datetime] NOT NULL CONSTRAINT [DS_USER_FACE_Del_TimeAddNew]  DEFAULT (getdate()),
	[UserAddNewSID] [int] NOT NULL CONSTRAINT [DS_USER_FACE_Del_UserAddNewSID]  DEFAULT ((0)),
	[TimeModifyLast] [datetime] NULL,
	[UserModifyLastSID] [int] NULL,
	[IsReplicated] [bit] NOT NULL CONSTRAINT [DS_USER_FACE_Del_IsReplicated]  DEFAULT ((0)),
	[ReplicateReturnID] [int] NOT NULL CONSTRAINT [DS_USER_FACE_Del_ReplicateReturnID]  DEFAULT ((0)),
	[TimeReplicated] [datetime] NULL,
 CONSTRAINT [PK_DS_USER_FACE_Del] PRIMARY KEY CLUSTERED 
(
	[FaceDelSID] ASC,
	[SlaveSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]";//

        //修改卡号表
        const string CHANGE_CARD = "CHANGE_CARD";
        const string CREATE_CHANGE_CARD = @"CREATE TABLE CHANGE_CARD (
    [ChangeID] [int] IDENTITY(1,1) NOT NULL,
    [SlaveSID] [int] NOT NULL,
    [OldCardID] [nvarchar](14) NULL,
    [NewCardID] [nvarchar](14) NULL,
    [IsReplicated] [bit] NOT NULL,
    CREATE_NAME nvarchar(30),
    CREATE_TIME datetime,
    CONSTRAINT [PK_CHANGE_CARD] PRIMARY KEY CLUSTERED 
            (
	            ChangeID ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
       //考勤照片表
        const string TRANS_PHOTO = "TRANS_PHOTO";
        const string CREATE_TRANS_PHOTO = @"CREATE TABLE TRANS_PHOTO (
            [PhotoID] [int] IDENTITY(1,1) NOT NULL,
            [SlaveSID] [int] NOT NULL,
            [CardID] nvarchar(14) not null,
            [TransTime] [datetime] NULL,
            [SyncTime] [datetime] NULL,
            [Photos] [Image] NULL,
            CONSTRAINT [PK_TRANS_PHOTO] PRIMARY KEY CLUSTERED 
            (
	            PhotoID ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";
     //存储过程
        const string SP_STORE_PHOTO = "SP_store_TRANS_PHOTO";
        const string CREATE_SP_STORE_PHOTO = @"CREATE PROCEDURE SP_store_TRANS_PHOTO 
@slaveId INT,
@cardId NVARCHAR(14),
	@transTime DATETIME,
	@photos IMAGE
AS
BEGIN
    INSERT INTO [TRANS_PHOTO]([SlaveSID],[CardID],[TransTime],[SyncTime],[Photos]) VALUES (@slaveId, @cardId,@transTime,CURRENT_TIMESTAMP,@photos )
RETURN @@ROWCOUNT
END";
        public static void CreateTimeAttendanceDataBase()
        {
            try
            {
                if (!KCSDatabaseHelper.Instance.IsTableExist(DOOR_PWD))//
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_DOOR_PWD);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHK_CLASS))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHK_CLASS);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHK_LEAVE))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHK_LEAVE);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHK_TURNWORK))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHK_TURNWORK);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHK_HOLIDAY))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHK_HOLIDAY);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHK_CALENDAR))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHK_CALENDAR);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHK_DOLIST))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHK_DOLIST);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHK_WORKLIST))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHK_WORKLIST);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(PER_CHK))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_PER_CHK);
                }                
                
                if (!KCSDatabaseHelper.Instance.IsTableExist(PER_LEAVE))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_PER_LEAVE);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(PER_LEAVE_D))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_PER_LEAVE_D);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(CHANGE_CARD))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_CHANGE_CARD);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(TRANS_PHOTO))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_TRANS_PHOTO);
                }
                if (!KCSDatabaseHelper.Instance.IsTableExist(ELEVATOR_CONTROL))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_ELEVATOR_CONTROL);
                }
                //if (!KCSDatabaseHelper.Instance.IsTableExist(EMPLOYEES_PHOTO))
                //{
                //    KCSDatabaseHelper.Instance.CreateTable(CREATE_PHOTO_SYNC);
                //}

                //if (!KCSDatabaseHelper.Instance.IsTableExist(DS_User_Face_Add))
                //{
                //    KCSDatabaseHelper.Instance.CreateTable(CREATE_DS_User_Face_Add);
                //}
                //if (!KCSDatabaseHelper.Instance.IsTableExist(DS_User_Face_Del))
                //{
                //    KCSDatabaseHelper.Instance.CreateTable(CREATE_DS_User_Face_Del);
                //}




                if (KCSDatabaseHelper.Instance.IsTableColumnExist("BF_User", "ShiftCategory") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table BF_User add ShiftCategory varchar(10)");
                }

                if (KCSDatabaseHelper.Instance.IsTableColumnExist("BF_User", "RegPhoto") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table BF_User add RegPhoto varchar(128)");
                }


                //增加工作模式，密码 default(
                if (KCSDatabaseHelper.Instance.IsTableColumnExist("S_SlaveIP", "WorkMode") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table S_SlaveIP add WorkMode smallint");
                }
                if (KCSDatabaseHelper.Instance.IsTableColumnExist("S_SlaveIP", "WorkModeSync") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table S_SlaveIP add WorkModeSync bit  NOT NULL Default 0");
                }
                if (KCSDatabaseHelper.Instance.IsTableColumnExist("S_SlaveIP", "Language") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table S_SlaveIP add Language smallint");
                }
                if (KCSDatabaseHelper.Instance.IsTableColumnExist("S_SlaveIP", "LanguageSync") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table S_SlaveIP add LanguageSync bit  NOT NULL Default 0");
                }
                if (KCSDatabaseHelper.Instance.IsTableColumnExist("S_SlaveIP", "MenuPwd") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table S_SlaveIP add MenuPwd VARCHAR(6)");
                }
                if (KCSDatabaseHelper.Instance.IsTableColumnExist("S_SlaveIP", "MenuPwdSync") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table S_SlaveIP add MenuPwdSync bit  NOT NULL Default 0");
                }
                if (KCSDatabaseHelper.Instance.IsTableColumnExist("S_SlaveIP", "DeviceType") <= 0)
                {
                    KCSDatabaseHelper.Instance.CreateTable("alter table S_SlaveIP add DeviceType VARCHAR(16) NOT NULL Default 'Finger'");
                }
               


                KCSDatabaseHelper.Instance.CreateTable("alter table CHK_DOLIST alter column LIST_WEEK nvarchar(20)");
                KCSDatabaseHelper.Instance.CreateTable("alter table CHK_WORKLIST alter column WORK_WEEK nvarchar(20)");
                //创建视图
                if (!KCSDatabaseHelper.Instance.IsViewExist(VPER_CHK))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_VPER_CHK);
                }
                if (!KCSDatabaseHelper.Instance.IsViewExist(VCHANGE_CARD))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_VCHANGE_CARD);
                }
                if (!KCSDatabaseHelper.Instance.IsViewExist(SALVE_FACE_VIEW))
                {
                    KCSDatabaseHelper.Instance.CreateTable(CREATE_SLAVE_FACE_VIEW);
                }
                                               
            
                //创建函数 
                if (!KCSDatabaseHelper.Instance.IsFunctionExist(FUNC_VALID_TRANSACTIONS_New))
                {
                    KCSDatabaseHelper.Instance.CreateFunction("CREATE " + CREATE_FUNC_VALID_TRANSACTIONS_New);
                }
                else
                {
                    KCSDatabaseHelper.Instance.CreateFunction("ALTER " + CREATE_FUNC_VALID_TRANSACTIONS_New);
                }
                if (!KCSDatabaseHelper.Instance.IsFunctionExist(FUNC_VALID_TRANSACTIONS_New1))
                {
                    KCSDatabaseHelper.Instance.CreateFunction("CREATE " + CREATE_FUNC_VALID_TRANSACTIONS_New1);
                }
                else
                {
                    KCSDatabaseHelper.Instance.CreateFunction("ALTER " + CREATE_FUNC_VALID_TRANSACTIONS_New1);
                }
                if (!KCSDatabaseHelper.Instance.IsFunctionExist(FUNC_PER_CHECK_SECTION))
                {
                    KCSDatabaseHelper.Instance.CreateFunction(CREATE_FUNC_PER_CHECK_SECTION);
                }
                if (!KCSDatabaseHelper.Instance.IsFunctionExist(FUNC_PER_LEAVE_ITEMS))
                {
                    KCSDatabaseHelper.Instance.CreateFunction(CREATE_FUNC_PER_LEAVE_ITEMS);
                }
                //存储过程 
                if (!KCSDatabaseHelper.Instance.IsStoreProcedureExist(SP_STORE_PHOTO))
                {
                    KCSDatabaseHelper.Instance.CreateFunction(CREATE_SP_STORE_PHOTO);
                }
            }
            catch (Exception ex)
            {
                KCS.Common.Utils.PopHintDialog.ShowMessage("Create timeattendance error! " + ex.Message);
            }
        }
    }
}
