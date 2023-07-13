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
using KCS.Common.Utils;
using DevExpress.XtraGrid.Views.Base;
using KCS.ViewModels;
using DevExpress.Mvvm;
using KCS.Models;

namespace KCS.Views
{
    public partial class EmployeeJobCodecs : DevExpress.XtraEditors.XtraUserControl
    {
        public EmployeeJobCodecs()
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
                var fluentAPI = mvvmContext.OfType<EmployeeJobCodecsViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.JobCodeDataSet);
            }
            catch { }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeJobCodecsViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.JobCodeDataSet);
            }
            catch { }
            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row));
            Messenger.Default.Register<RebindMessage<EmployeeJobCodecsViewModel>>(this, x => RebindDataSource());
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedJobCode,
                   args => args.Row as EmployeeJobCode,
                   (gView, JobCode) => gView.FocusedRowHandle = gView.FindRow(JobCode));
            bbiNew.ItemClick += (s, e) =>
            {
                gridView.AddNewRow();
            };
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedJobCode);
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

            colTranType.Caption = LanguageResource.GetDisplayString("TransactionType");
            colJobName.Caption = LanguageResource.GetDisplayString("JobNameText");
            colRemark.Caption = LanguageResource.GetDisplayString("RemarkText");
            colListField.Caption = LanguageResource.GetDisplayString("Details");
           // colSlaveCategoryName.Caption = LanguageResource.GetDisplayString("DeviceCategoryName");
        }
    }
}
