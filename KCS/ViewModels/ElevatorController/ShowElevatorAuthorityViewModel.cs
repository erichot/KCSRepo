using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.ViewModels;
using System.Collections.Generic;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ShowElevatorAuthorityViewModel : KcsDocument
    {
        IList<ElevatorCtlAuthority> elevatorAuthorityList = null;
        public static ShowElevatorAuthorityViewModel Create()
        {

            return ViewModelSource.Create(() => new ShowElevatorAuthorityViewModel());
        }
        public static ShowElevatorAuthorityViewModel Create(int  slaveId)
        {

            return ViewModelSource.Create(() => new ShowElevatorAuthorityViewModel(slaveId));
        }
        protected ShowElevatorAuthorityViewModel()
        {
            
        }
        protected ShowElevatorAuthorityViewModel(int slaveId)
        {
            elevatorAuthorityList = EmployeesDataSource.GetElevatorAuthorityList(slaveId);
        }

        public object ElevatorAuthorityDataSet
        {
            get
            {
                
                return elevatorAuthorityList;
            }

        }
    }
}