using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Common.Utils;
using System.Data;
using KCS.Sync;
using DevExpress.XtraTreeList.Nodes;
using KCS.Models;
using DevExpress.XtraTreeList;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class AccessControlManageViewModel
    {
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        DataTable TreeListTable = null;
        string[] WeekDayItemName = new string[]
        {
            LanguageResource.GetDisplayString("SundayText"),
            LanguageResource.GetDisplayString("MondayText"),
            LanguageResource.GetDisplayString("TuesdayText"),
            LanguageResource.GetDisplayString("WednesdayText"),
            LanguageResource.GetDisplayString("ThursdayText"),
            LanguageResource.GetDisplayString("FridayText"),
            LanguageResource.GetDisplayString("SaturdayText")
        };
        
        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }
        public static AccessControlManageViewModel Create()
        {
            
         return ViewModelSource.Create(() => new AccessControlManageViewModel());
        }
        public AccessControlManageViewModel()
        {
            TreeListTable = new DataTable();
        }
        public object UserGroupDateSet
        {
            get
            {
                //TreeListTable.Clear();
                CreateTreeListTable();
                return TreeListTable;
            }
        }

        public object AcTimeZoneDataSet
        {
            get
            {


                return SyncManage.TimeZoneList;
            }
        }
        private void CreateTreeListTable()
        {

            TreeListTable.Columns.Clear();

            TreeListTable.Clear();

            DataColumn dcOID = new DataColumn("KeyFieldName", Type.GetType("System.Int32"));

            DataColumn dcParentOID = new DataColumn("ParentFieldName", Type.GetType("System.Int32"));

            DataColumn dcNodeName = new DataColumn("NodeName", Type.GetType("System.String"));

            DataColumn dcNodeCode = new DataColumn("NodeValue", Type.GetType("System.String"));

            DataColumn dcStartTime = new DataColumn("StartTime", Type.GetType("System.String"));

            DataColumn dcEndTime = new DataColumn("EndTime", Type.GetType("System.String"));

            DataColumn dcDiscription = new DataColumn("Discription", Type.GetType("System.String"));

            TreeListTable.Columns.Add(dcOID);

            TreeListTable.Columns.Add(dcParentOID);

            TreeListTable.Columns.Add(dcNodeName);

            TreeListTable.Columns.Add(dcNodeCode);

            TreeListTable.Columns.Add(dcStartTime);
            TreeListTable.Columns.Add(dcEndTime);
            TreeListTable.Columns.Add(dcDiscription);
            for (int i = 1,j=1; i < 16; i++)
            {
                if (i == 14)
                    continue;
                DataRow dr = TreeListTable.NewRow();

                dr["KeyFieldName"] = j++;

                dr["ParentFieldName"] = DBNull.Value;

                dr["NodeName"] = LanguageResource.GetDisplayString("UserGroupText") + " " + i.ToString();

                dr["NodeValue"] = DBNull.Value;
                if (i == 13)
                    dr["NodeName"] += "(VIP)";

                dr["StartTime"] = DBNull.Value;

                dr["EndTime"] = DBNull.Value;
                dr["Discription"] = SyncManage.UserGroupList[i].Description;
                TreeListTable.Rows.Add(dr);
                DataRow drSon = TreeListTable.NewRow();

                drSon["KeyFieldName"] = j++;

                drSon["ParentFieldName"] = dr["KeyFieldName"];

                drSon["NodeName"] = LanguageResource.GetDisplayString("WeekPlayText");

                drSon["NodeValue"] = DBNull.Value;

                drSon["StartTime"] = DBNull.Value;

                drSon["EndTime"] = DBNull.Value;
                drSon["Discription"] = DBNull.Value;
                TreeListTable.Rows.Add(drSon);

                int k = 0;
                for (k = 0; k < 7; k++)
                {
                    DataRow drSon1 = TreeListTable.NewRow();

                    drSon1["KeyFieldName"] = j++;

                    drSon1["ParentFieldName"] = dr["KeyFieldName"];

                    drSon1["NodeName"] = WeekDayItemName[k];

                    drSon1["NodeValue"] = SyncManage.UserGroupList[i].WeekSet(k).ToString();

                    drSon1["StartTime"] = DBNull.Value;

                    drSon1["EndTime"] = DBNull.Value;
                    drSon1["Discription"] = SyncManage.TimeZoneList[SyncManage.UserGroupList[i].WeekSet(k)].Description;
                    TreeListTable.Rows.Add(drSon1);

                    for (int m = 0; m < 4; m++)
                    {
                        DataRow drSon2 = TreeListTable.NewRow();

                        drSon2["KeyFieldName"] = j++;

                        drSon2["ParentFieldName"] = drSon1["KeyFieldName"];

                        drSon2["NodeName"] = LanguageResource.GetDisplayString("TimeFrameText") + m.ToString();

                        drSon2["NodeValue"] = DBNull.Value;

                        drSon2["StartTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[SyncManage.UserGroupList[i].WeekSet(k)].FrameSet(m)].StartTimeStr;

                        drSon2["EndTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[SyncManage.UserGroupList[i].WeekSet(k)].FrameSet(m)].EndTimeStr;

                        drSon2["Discription"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[SyncManage.UserGroupList[i].WeekSet(k)].FrameSet(m)].Description;
                        TreeListTable.Rows.Add(drSon2);
                    }
                }

                drSon = TreeListTable.NewRow();

                drSon["KeyFieldName"] = j++;

                drSon["ParentFieldName"] = dr["KeyFieldName"];

                drSon["NodeName"] = LanguageResource.GetDisplayString("HolidayPlanText");

                drSon["NodeValue"] = DBNull.Value;

                drSon["StartTime"] = DBNull.Value;

                drSon["EndTime"] = DBNull.Value;
                drSon["Discription"] = DBNull.Value;
                TreeListTable.Rows.Add(drSon);
                for (k = 0; k < 8; k++)
                {
                    DataRow drSon1 = TreeListTable.NewRow();

                    drSon1["KeyFieldName"] = j++;

                    drSon1["ParentFieldName"] = dr["KeyFieldName"];

                    drSon1["NodeName"] = LanguageResource.GetDisplayString("AccessControlHoliType") + (k + 1).ToString();

                    drSon1["NodeValue"] = SyncManage.UserGroupList[i].HolidaySet(k).ToString();

                    drSon1["StartTime"] = DBNull.Value;

                    drSon1["EndTime"] = DBNull.Value;
                    drSon1["Discription"] = SyncManage.TimeZoneList[SyncManage.UserGroupList[i].HolidaySet(k)].Description;
                    TreeListTable.Rows.Add(drSon1);

                    for (int m = 0; m < 4; m++)
                    {
                        DataRow drSon2 = TreeListTable.NewRow();

                        drSon2["KeyFieldName"] = j++;

                        drSon2["ParentFieldName"] = drSon1["KeyFieldName"];

                        drSon2["NodeName"] = LanguageResource.GetDisplayString("FrameText") + m.ToString();

                        drSon2["NodeValue"] = DBNull.Value;

                        drSon2["StartTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[SyncManage.UserGroupList[i].HolidaySet(k)].FrameSet(m)].StartTimeStr;

                        drSon2["EndTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[SyncManage.UserGroupList[i].HolidaySet(k)].FrameSet(m)].EndTimeStr;
                        drSon2["Discription"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[SyncManage.UserGroupList[i].HolidaySet(k)].FrameSet(m)].Description;
                        TreeListTable.Rows.Add(drSon2);
                    }
                }

            }

            
        }
        public void TimeSetSet()
        {
            DialogService.ShowDialog(MessageButton.OK, LanguageResource.GetDisplayString("TimeSetSetText"), "TimeSet", TimeSetViewModel.Create());
            //var document = DocumentManagerService.CreateDocument("TimeSet", TimeSetViewModel.Create());
           // document.Show();
        }
        public void TimeZoneSet()
        {
            DialogService.ShowDialog(MessageButton.OK, LanguageResource.GetDisplayString("TimeZoneSetText"), "TimeZone", TimeZoneViewModel.Create());
            //var document = DocumentManagerService.CreateDocument("TimeZone", TimeZoneViewModel.Create());
            //document.Show();
        }
        public void HolidaySet()
        {
            DialogService.ShowDialog(MessageButton.OK, LanguageResource.GetDisplayString("HolidaySetText"), "HolidaySet", HolidaySetViewModel.Create());
            //var document = DocumentManagerService.CreateDocument("HolidaySet", HolidaySetViewModel.Create());
            //document.Show();
        }
        public void SaveUserGroup()
        {
            bool bChanged = false;
            foreach (AcUserGroupSet UserGroupSet in SyncManage.UserGroupList)
            {
                foreach (AcUserGroupSet UserGroupSetBck in SyncManage.UserGroupListBack)
                {
                    if (UserGroupSet.GroupID == UserGroupSetBck.GroupID)
                    {
                        if (UserGroupSet != UserGroupSetBck)
                        {
                            AccessControlDataSource.UpdateUserGroupSet(UserGroupSet);
                            bChanged = true;
                        }
                    }
                }

                
            }
            if (bChanged)
                SyncManage.RefreshUserGroupListBack();
            Messenger.Default.Send(new RebindMessage<AccessControlManageViewModel>(this));
        }
        public void Save(object cellValue)
        {
            //DataRowView rov = cellValue as DataRowView;
            //DataRow row = rov.Row;
            // int userGroup = int.Parse(row["ParentFieldName"].ToString());

            var cellEventArgs = cellValue as CellValueChangedEventArgs;
           // string str = cellEventArgs.Value.ToString();
            TreeListNode node = cellEventArgs.Node  as TreeListNode;


            int setValue = int.Parse(cellEventArgs.Value.ToString());
            int userGroup = int.Parse(System.Text.RegularExpressions.Regex.Replace(node.ParentNode.GetDisplayText("NodeName"), @"[^0-9]+", ""));
            if (userGroup > 15)
                return;
            if (setValue > 63)
                return;
            string KeyName = node["KeyFieldName"].ToString();
            string NodeName = node["NodeName"].ToString();
            
                if( NodeName.Equals(LanguageResource.GetDisplayString("SundayText")))
                {
                    SyncManage.UserGroupList[userGroup].Sun = (byte)setValue;
                }
                else if( NodeName.Equals(LanguageResource.GetDisplayString("MondayText")))
                {
                    SyncManage.UserGroupList[userGroup].Mon = (byte)setValue;
                }
            else if( NodeName.Equals(LanguageResource.GetDisplayString("TuesdayText")))
                {
                    SyncManage.UserGroupList[userGroup].Tue = (byte)setValue;
                }
            else if( NodeName.Equals(LanguageResource.GetDisplayString("WednesdayText")))
                {
                    SyncManage.UserGroupList[userGroup].Wed = (byte)setValue;
                }
            else if( NodeName.Equals(LanguageResource.GetDisplayString("ThursdayText")))
                {
                    SyncManage.UserGroupList[userGroup].Thu = (byte)setValue;
                }
            else if( NodeName.Equals(LanguageResource.GetDisplayString("FridayText")))
                {
                    SyncManage.UserGroupList[userGroup].Fri = (byte)setValue;
                }
            else if( NodeName.Equals(LanguageResource.GetDisplayString("SaturdayText")))
                {
                    SyncManage.UserGroupList[userGroup].Sat = (byte)setValue;
                }
                else if (NodeName.Equals(LanguageResource.GetDisplayString("AccessControlHoliType")+"1"))
                {
                    SyncManage.UserGroupList[userGroup].Holi1Group = (byte)setValue;
                }
                else if (NodeName.Equals(LanguageResource.GetDisplayString("AccessControlHoliType") + "2"))
                {
                    SyncManage.UserGroupList[userGroup].Holi2Group = (byte)setValue;
                }
                else if (NodeName.Equals(LanguageResource.GetDisplayString("AccessControlHoliType") + "3"))
                {
                    SyncManage.UserGroupList[userGroup].Holi3Group = (byte)setValue;
                }
                else if (NodeName.Equals(LanguageResource.GetDisplayString("AccessControlHoliType") + "4"))
                {
                    SyncManage.UserGroupList[userGroup].Holi4Group = (byte)setValue;
                }
                else if (NodeName.Equals(LanguageResource.GetDisplayString("AccessControlHoliType") + "5"))
                {
                    SyncManage.UserGroupList[userGroup].Holi5Group = (byte)setValue;
                }
                else if (NodeName.Equals(LanguageResource.GetDisplayString("AccessControlHoliType") + "6"))
                {
                    SyncManage.UserGroupList[userGroup].Holi6Group = (byte)setValue;
                }
                else if (NodeName.Equals(LanguageResource.GetDisplayString("AccessControlHoliType") + "7"))
                {
                    SyncManage.UserGroupList[userGroup].Holi7Group = (byte)setValue;
                }
                else
                {
                    SyncManage.UserGroupList[userGroup].Holi8Group = (byte)setValue;
                }
                
            node["Discription"] = SyncManage.TimeZoneList[setValue].Description;
           
            if (TreeListTable != null)
            {
                for (int i = 0; i < TreeListTable.Rows.Count; i++)
                {
                    if (TreeListTable.Rows[i]["ParentFieldName"].ToString().Equals(KeyName))
                    {
                        TreeListTable.Rows[i]["StartTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(0)].StartTimeStr;
                        TreeListTable.Rows[i]["EndTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(0)].EndTimeStr;
                        TreeListTable.Rows[i]["Discription"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(0)].Description;

                        TreeListTable.Rows[i+1]["StartTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(1)].StartTimeStr;
                        TreeListTable.Rows[i + 1]["EndTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(1)].EndTimeStr;
                        TreeListTable.Rows[i + 1]["Discription"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(1)].Description;

                        TreeListTable.Rows[i + 2]["StartTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(2)].StartTimeStr;
                        TreeListTable.Rows[i + 2]["EndTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(2)].EndTimeStr;
                        TreeListTable.Rows[i + 2]["Discription"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(2)].Description;

                        TreeListTable.Rows[i + 3]["StartTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(3)].StartTimeStr;
                        TreeListTable.Rows[i + 3]["EndTime"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(3)].EndTimeStr;
                        TreeListTable.Rows[i + 3]["Discription"] = SyncManage.TimeFrameList[SyncManage.TimeZoneList[setValue].FrameSet(3)].Description;
                        break;
                    }
                }
            }
            //node.getc
            //TreeListNode nodeSon = node.NextNode;
            
            //string Cell = cellValue as string;
            //if (Cell.Contains(LanguageResource.GetDisplayString("UserGroupText")))
            {
                //int userGroup = int.Parse(System.Text.RegularExpressions.Regex.Replace(Cell, @"[^0-9]+", ""));
                //var userGroupSetViewModel = UserGroupSetViewModel.Create(userGroup);
                //userGroupSetViewModel.SetParentViewModel(this);
                //var document = DocumentManagerService.CreateDocument("UserGroupSet", userGroupSetViewModel);
                //document.Show();
            }

            //TreeListTable.curren
        }
    }
    
}