using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using System.Linq;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class EditPersonalShiftTableViewModel : KcsDocument
    {
        public virtual int SelectYear { get; set; }
        public IList<WorkShiftItem> workShiftItemList = new List<WorkShiftItem>();
        public IList<WorkShift> workShiftList = new List<WorkShift>();
        public static EditPersonalShiftTableViewModel Create()
        {

            return ViewModelSource.Create(() => new EditPersonalShiftTableViewModel());
        }
        protected EditPersonalShiftTableViewModel()
        {
            workShiftItemList = WorkShiftDataSource.GetWorkShifItemstList();
            workShiftList = WorkShiftDataSource.GetWorkShiftList();
            SelectYear = DateTime.Now.Year;
        }
        public virtual PerShiftTable SelectedPerShiftTable
        {
            get;
            set;
        }
        public object WorkShiftItemDataSet
        {
            get
            {

                return workShiftItemList;
            }

        }
        public object PersonalShiftTableDataSet
        {
            get
            {
                return TaDataSource.GetPerShiftTable(SelectYear);
            }
        }
        void RebindDataSource(int type)
        {
            Messenger.Default.Send(new RebindMessage<EditPersonalShiftTableViewModel>(this, type));
        }
        protected void OnSelectYearChanged()
        {
            RebindDataSource(2);
        }
        public void Save(object objShiftItem)
        {
            string shiftCode = ((DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)objShiftItem).Value.ToString();
            if (string.IsNullOrEmpty(shiftCode))
                return;
            switch (((DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)objShiftItem).Column.Name)
            {
                case "colCLASS_CODE":
                    if (!shiftCode.Equals(SelectedPerShiftTable.CLASS_CODE))
                    {
                        if (TaDataSource.UpdatePersonShiftTableShiftCode(SelectedPerShiftTable.EMP_CODE, SelectedPerShiftTable.CHK_DATE.ToShortDateString(), shiftCode) > 0)
                        {
                            WorkShift workShift = workShiftList.FirstOrDefault(f => f.CLASS_CODE.Equals(shiftCode));
                            if (workShift != null)
                            {
                                SelectedPerShiftTable.WORK_TIME_START = workShift.WORK_TIME_START;
                                SelectedPerShiftTable.WORK_TIME_END = workShift.WORK_TIME_END;
                                SelectedPerShiftTable.WORK_TIME_LATE = workShift.WORK_TIME_LATE;
                                SelectedPerShiftTable.WORK_TIME_OVERTIME = workShift.WORK_TIME_OVERTIME;
                                SelectedPerShiftTable.TURN_OVERTIME = workShift.TURN_OVERTIME;
                                SelectedPerShiftTable.RELAX_TIME1 = workShift.RELAX_TIME1;
                                SelectedPerShiftTable.RELAX_TIME2 = workShift.RELAX_TIME2;
                                SelectedPerShiftTable.RELAX_TIME3 = workShift.RELAX_TIME3;
                                SelectedPerShiftTable.RELAX_TIME4 = workShift.RELAX_TIME4;
                                SelectedPerShiftTable.CLASS_DESC = workShift.CLASS_DESC;
                                SelectedPerShiftTable.HolidayType = "";
                            }
                            RebindDataSource(1);
                        }
                    }
                    break;
                case "colCLOCK_CK":
                    break;
                case "colHolidayType":
                    if (!shiftCode.Equals(SelectedPerShiftTable.HolidayType))
                    {
                        int LIST_GRP;
                        if (shiftCode.Equals(KCS.Common.Utils.LanguageResource.GetDisplayString("RestDayText")))
                        {
                            LIST_GRP = 1;
                        }
                        else if (shiftCode.Equals(KCS.Common.Utils.LanguageResource.GetDisplayString("LegalHolidayText")))
                        {
                            LIST_GRP = 3;
                        }
                        else
                        {
                            LIST_GRP = 0;
                        }
                        if (TaDataSource.UpdatePersonShiftTableHolidayType(SelectedPerShiftTable.EMP_CODE, SelectedPerShiftTable.CHK_DATE.ToShortDateString(), LIST_GRP) > 0)
                        {
                            SelectedPerShiftTable.CLASS_CODE = "";
                            SelectedPerShiftTable.WORK_TIME_START = "";
                            SelectedPerShiftTable.WORK_TIME_END = "";
                            SelectedPerShiftTable.CLASS_DESC = "";
                            SelectedPerShiftTable.WORK_TIME_LATE = "";
                            SelectedPerShiftTable.WORK_TIME_OVERTIME = "";
                            SelectedPerShiftTable.TURN_OVERTIME = 0;
                            SelectedPerShiftTable.RELAX_TIME1 = "";
                            SelectedPerShiftTable.RELAX_TIME2 = "";
                            SelectedPerShiftTable.RELAX_TIME3 = "";
                            SelectedPerShiftTable.RELAX_TIME4 = "";

                            RebindDataSource(1);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}