using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using DevExpress.XtraGrid.Views.Base;
using System.Data.Common;
using DevExpress.Mvvm;
using KCS.Common.Utils;
using KCS.Models;

namespace KCS.Views
{
    public partial class DeviceCategory : DevExpress.XtraEditors.XtraUserControl
    {
        public DeviceCategory()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
           
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

        }
        void RebindDataSource()
        {
            try
            {
                var fluentAPI = mvvmContext.OfType<DeviceCategoryViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.DeviceCategoryDataSet);
            }
            catch { }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<DeviceCategoryViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.DeviceCategoryDataSet);
            }
            catch { }
            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row));
            Messenger.Default.Register<RebindMessage<DeviceCategoryViewModel>>(this, x => RebindDataSource());
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedSlaveCategory,
                   args => args.Row as SlaveCategory,
                   (gView, slaveCategory) => gView.FocusedRowHandle = gView.FindRow(slaveCategory));
            bbiNew.ItemClick += (s, e) =>
                {
                    gridView.AddNewRow();
                };
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedSlaveCategory);
            //gridView.RowUpdated += (s, e) =>
            //    {
            //        MessageBox.Show("1");
            //    };
        }
        void InitViewDisplay()
        {
            
            ribbonPageGroupEdit.Text = LanguageResource.GetDisplayString("ToolBarGroupEdit");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
           
            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiNew.Caption = LanguageResource.GetDisplayString("ToolBarNew");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            colSlaveCategoryName.Caption = LanguageResource.GetDisplayString("DeviceCategoryName");
        }
    }
}
