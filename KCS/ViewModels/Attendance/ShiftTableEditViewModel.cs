using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Linq;
using System.Collections.Generic;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ShiftTableEditViewModel : KcsDocument
    {
        public IList<WorkShiftItem> workShiftItemList = new List<WorkShiftItem>();
        public virtual int SelectYear { get; set; }
        
        public static ShiftTableEditViewModel Create()
        {
            return ViewModelSource.Create(() => new ShiftTableEditViewModel());
        }
        protected ShiftTableEditViewModel()
        {
            workShiftItemList = WorkShiftDataSource.GetWorkShifItemstList();
            SelectYear = DateTime.Now.Year;
        }
        public virtual WorkList SelectedWorkListItem
        {
            get;
            set;
        }
        public object AnnualShiftTableDataSet
        {
            get
            {
                return TaDataSource.GetChkWorkList(SelectYear);
            }
        }
        public object WorkShiftItemDataSet
        {
            get
            {

                return workShiftItemList;
            }

        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<ShiftTableEditViewModel>(this));
        }
        protected void OnSelectYearChanged()
        {
            RebindDataSource();
        }
        public void Save(object workListItem)
        {
            string shiftCode = ((DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)workListItem).Value.ToString();
            if (string.IsNullOrEmpty(shiftCode))
                return;
            switch (((DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)workListItem).Column.Name)
            {
                case "colCLASS_CODE":
                    if (!shiftCode.Equals(SelectedWorkListItem.CLASS_CODE))
                    {
                        if (TaDataSource.UpdateWorkListShiftCode(SelectedWorkListItem.WORK_DATE_Dis, SelectedWorkListItem.TURNWORK_GRP, shiftCode) > 0)
                        {
                            WorkShiftItem workShiftItem = workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(shiftCode));
                            if (workShiftItem != null)
                            {
                                SelectedWorkListItem.WORK_TIME_START = workShiftItem.WORK_TIME_START;
                                SelectedWorkListItem.WORK_TIME_END = workShiftItem.WORK_TIME_END;
                                SelectedWorkListItem.CLASS_DESC = workShiftItem.CLASS_DESC;
                                SelectedWorkListItem.HolidayType = "";
                            }
                            RebindDataSource();
                        }
                    }
                    break;
                case "colHolidayType":
                    if (!shiftCode.Equals(SelectedWorkListItem.HolidayType))
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
                        if (TaDataSource.UpdateWorkListHolidayType(SelectedWorkListItem.WORK_DATE_Dis, SelectedWorkListItem.TURNWORK_GRP, LIST_GRP) > 0)
                        {
                            SelectedWorkListItem.CLASS_CODE = "";
                            SelectedWorkListItem.WORK_TIME_START = "";
                            SelectedWorkListItem.WORK_TIME_END = "";
                            SelectedWorkListItem.CLASS_DESC = "";
                            RebindDataSource();
                        }
                    }
                    break;
                default:
                    break;
            }
           
            
        }
        
        
    }
}