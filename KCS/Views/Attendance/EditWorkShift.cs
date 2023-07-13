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
using KCS.ViewModels;
using KCS.Models;

namespace KCS.Views
{
    public partial class EditWorkShift : DevExpress.XtraEditors.XtraUserControl
    {
        public EditWorkShift()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EditWorkShiftViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());



            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EditWorkShift);
            mvvmContext.SetBinding<TextEdit, EditWorkShiftViewModel, bool>(ShiftCodeTextEdit, c => c.ReadOnly, x => x.ShiftCodeReadOnly);



            foreach (Control control in dataLayoutControl1.Controls)
            {
                BaseEdit edit = control as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                EditorHelpers.ApplyBindingSettings<WorkShift>(edit, dataLayoutControl1);

            }
        }
        void InitViewDisplay()
        {

            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            ItemForShiftCode.Text = LanguageResource.GetDisplayString("WorkShiftCode");
            ItemForShiftName.Text = LanguageResource.GetDisplayString("WorkShiftName");
            ItemForStartTimeHour.Text = LanguageResource.GetDisplayString("WorkShiftStartTime");
            ItemForEndTimeHour.Text = LanguageResource.GetDisplayString("WorkShiftEndTime");
            ItemForDeductBreakMinute.Text = LanguageResource.GetDisplayString("WorkShiftBreakTime");
            ItemForIsDefault.Text = LanguageResource.GetDisplayString("WorkShiftIsDefault");
            ItemForByMin.Text = LanguageResource.GetDisplayString("BreakTimeByMinute");
            ItemForTotalTimeString.Text = LanguageResource.GetDisplayString("WorkShiftTotalTime");


        }
    }
}
