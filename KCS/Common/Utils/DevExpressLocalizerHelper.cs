using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler.Localization;

namespace KCS.Common.Utils
{//:DevExpress.XtraEditors.Controls.Localizer
    public class DevExpressLocalizerHelper
    {
        public static void DevExpressLocalizer()
        {
            DevExpress.XtraEditors.Controls.Localizer.Active = new DevControlsLocalizer();
            DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new SchedulerLocalizer();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new GridControlLocalizer();
        }
        

    }
    public class GridControlLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
        {
            switch (id)
            {
                case DevExpress.XtraGrid.Localization.GridStringId.EditFormUpdateButton:
                    return LanguageResource.GetDisplayString("GridContrlUpdateText");
                case DevExpress.XtraGrid.Localization.GridStringId.EditFormCancelButton:
                    return LanguageResource.GetDisplayString("DialogCancelButtonText");
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
    public class SchedulerLocalizer : DevExpress.XtraScheduler.Localization.SchedulerLocalizer
    {
        public override string GetLocalizedString(SchedulerStringId id)
        {

            switch (id)
            {
                case SchedulerStringId.MenuCmd_GotoDate:
                    return LanguageResource.GetDisplayString("SchedulerGotoDateText");
                case SchedulerStringId.MenuCmd_GotoToday:
                    return LanguageResource.GetDisplayString("SchedulerGotoTodayText");
                //case SchedulerStringId.Form
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
    public class DevControlsLocalizer : DevExpress.XtraEditors.Controls.Localizer
    {
        public override string GetLocalizedString(DevExpress.XtraEditors.Controls.StringId id)
        {

            switch (id)
            {
                case StringId.XtraMessageBoxCancelButtonText:
                    return LanguageResource.GetDisplayString("DialogCancelButtonText");
                case StringId.XtraMessageBoxOkButtonText:
                    return LanguageResource.GetDisplayString("DialogOkButtonText");
                case StringId.XtraMessageBoxYesButtonText:
                    return LanguageResource.GetDisplayString("DialogYesButton");
                case StringId.XtraMessageBoxNoButtonText:
                    return LanguageResource.GetDisplayString("DialogNoButtonText");
                case StringId.XtraMessageBoxIgnoreButtonText:
                    return LanguageResource.GetDisplayString("DialogIgnoreButtonText");
                case StringId.XtraMessageBoxAbortButtonText:
                    return LanguageResource.GetDisplayString("DialogAbortButtonText");
                case StringId.XtraMessageBoxRetryButtonText:
                    return LanguageResource.GetDisplayString("DialogRetryButtonText");
                case DevExpress.XtraEditors.Controls.StringId.DateEditToday:
                    return LanguageResource.GetDisplayString("DateEditTodayText");
                
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
    
}
