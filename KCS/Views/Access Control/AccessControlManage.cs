using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using KCS.Common.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Mvvm;
using DevExpress.XtraSpellChecker;

namespace KCS.Views
{
    public partial class AccessControlManage : BaseViewControl, IRibbonModule
    {

        // Add:         2024/02/19
        // Ver:         1.1.5.17
        bool m_SupervisorIsReadOnly;

        public AccessControlManage()
            : base(typeof(AccessControlManageViewModel))
        {
            InitializeComponent();//bbiHolidaySet
        }
        
        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);
            // gridControl.Load += gridControl_Load;

            // Add:         2024/02/19
            // Ver:         1.1.5.17
            m_SupervisorIsReadOnly = KCS.Models.CredentialsSource.GetLoginSupervisorIsReadOnly();



            if (!DesignMode)
                InitBindings();
            InitViewDisplay();
        }
        void InitViewDisplay()
        {
            bbiHolidaySet.Caption = LanguageResource.GetDisplayString("HolidaySetText");
            bbiTimeSet.Caption = LanguageResource.GetDisplayString("TimeSetSetText");
            bbiTimeZone.Caption = LanguageResource.GetDisplayString("TimeZoneSetText");
            treeListcolNodeName.Caption = LanguageResource.GetDisplayString("UserGroupText");
            treeListcolNodeValue.Caption = LanguageResource.GetDisplayString("NodeValueText");
            treeListcolStartTime.Caption = LanguageResource.GetDisplayString("StartTime");
            treeListcolEndTime.Caption = LanguageResource.GetDisplayString("EndTime");
            treeListcolDiscription.Caption = LanguageResource.GetDisplayString("DescriptionText");
            ribbonPageGroupUserGoup.Text = LanguageResource.GetDisplayString("UserGroupText");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSaveUserGroup");
            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");


            // Add:     2024/02/19
            // Ver:     1.1.5.17
            if (m_SupervisorIsReadOnly == true)
            {
                bbiHolidaySet.Enabled = false;
                bbiTimeSet.Enabled = false;
                bbiTimeZone.Enabled = false;

                bbiSave.Enabled = false;
            }

        }
        void RebindDataSource()
        {
            try
            {
               // var ids = new List<object>();
               // treeList.GetNodeList().FindAll(n => n.Expanded).ForEach(n => { ids.Add(n.GetValue("KeyFieldName")); }); 
                var fluentAPI = mvvmContext.OfType<AccessControlManageViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSourceUserGroup,
                x => x.UserGroupDateSet);

               // ids.ForEach(id => { treeList.FindNodeByKeyID(id).Expanded = true; });  
            }
            catch { }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<AccessControlManageViewModel>();

            fluentAPI.SetObjectDataSourceBinding(bindingSourceUserGroup,
                x => x.UserGroupDateSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceTimeZone,
                x => x.AcTimeZoneDataSet);
            
            fluentAPI.BindCommand(bbiHolidaySet, x => x.HolidaySet());
            fluentAPI.BindCommand(bbiTimeSet, x => x.TimeSetSet());
            fluentAPI.BindCommand(bbiTimeZone, x => x.TimeZoneSet());
            fluentAPI.BindCommand(bbiSave, x => x.SaveUserGroup());
            //fluentAPI.SetBinding(repositoryItemLookUpEdit1, x => x.ed, x => x.SelectSetValue);
            Messenger.Default.Register<RebindMessage<AccessControlManageViewModel>>(this, x => RebindDataSource());
            // fluentAPI.WithEvent<FocusedNodeChangedEventArgs>(treeList, "FocusedNodeChanged")
            //.EventToCommand(x => x.Save(null), new Func<FocusedNodeChangedEventArgs, object>(e => e.Node.GetDisplayText("NodeName")));

            // Modified:     2024/02/19
            // Ver:     1.1.5.17
            //fluentAPI.WithEvent<CellValueChangedEventArgs>(treeList, "CellValueChanging")
            //    .EventToCommand(x => x.Save(null), new Func<CellValueChangedEventArgs, object>(e => e));
            if (m_SupervisorIsReadOnly == false)
            {
                fluentAPI.WithEvent<CellValueChangedEventArgs>(treeList, "CellValueChanging")
                .EventToCommand(x => x.Save(null), new Func<CellValueChangedEventArgs, object>(e => e));
            }
            


            //treeList.TextChanged
           // treeList.TreeListMenuItemClick
            treeList.ShowingEditor += (sender, e) =>
            {
                TreeList currentTreeList = sender as TreeList;

                if (currentTreeList != null)
                {
                    TreeListNode node = currentTreeList.FocusedNode;
                    DevExpress.XtraTreeList.Columns.TreeListColumn column = currentTreeList.FocusedColumn;

                    if (column.FieldName == "NodeValue" && !string.IsNullOrEmpty(node.GetDisplayText("NodeValue")))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            };
            //treeList.TreeListMenuItemClick += (sender, e) =>
            //    {
            //        object item = this.treeList.sele;
            //    };
            treeList.CustomDrawNodeCell += (sender, e) =>
            {
                //int cellIndex = e.Column.AbsoluteIndex + e.Node.Id;
                //if (cellIndex % 2 != 0 && !e.Node.Selected)
                //    e.Appearance.BackColor = Color.LightYellow;
                if (e.Node.GetDisplayText("NodeName").Contains("VIP"))
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                if(!string.IsNullOrEmpty(e.Node.GetDisplayText("NodeValue")))
                {
                    e.Appearance.BackColor = Color.Honeydew;
                }
            };
        }

        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion
    }
}
