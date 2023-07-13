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
using KCS.Models;
using DevExpress.Mvvm;

namespace KCS.Views
{
    public partial class TimeSet : DevExpress.XtraEditors.XtraUserControl
    {
        public TimeSet()
        {
            InitializeComponent();
        }
        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);

            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

        }
        void InitViewDisplay()
        {
            colTimeSetID.Caption = LanguageResource.GetDisplayString("SystemCode");
            colStartTime.Caption = LanguageResource.GetDisplayString("StartTime");
            colEndTime.Caption = LanguageResource.GetDisplayString("EndTime");
            colDescription.Caption = LanguageResource.GetDisplayString("DescriptionText");
            gridView.BestFitColumns();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<TimeSetViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.TimeSetDataSet);
            }
            catch { }
            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row));
            Messenger.Default.Register<RebindMessage<TimeSetViewModel>>(this, x => RebindDataSource());
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedAcTimeSet,
                   args => args.Row as AcTimeSet,
                   (gView, slaveCategory) => gView.FocusedRowHandle = gView.FindRow(slaveCategory));
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<TimeSetViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.TimeSetDataSet);
            }
            catch { }
        }
    }
}
