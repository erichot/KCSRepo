using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCS.Common.DAL;

namespace KCS.Models
{
    class ElevatorControlDataSource
    {
        public static IList<ElevatorController> GetElevatorControllerList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetElevatorControllerList();
            return KCS.Common.Utils.ModelConvertHelper<ElevatorController>.ConvertToModel(dt);
        }
        static public bool UpdateElevator(Elevator elevator)
        {
            return KCSDatabaseHelper.Instance.UpdateElevator(elevator);
        }
        static public bool ElevatorControllerExitOrNot(Elevator elevator)
        {
            return KCSDatabaseHelper.Instance.ElevatorControllerExitOrNot(elevator);
        }
        static public bool NewElevator(Elevator elevator)
        {

            return KCSDatabaseHelper.Instance.InsertElevator(elevator);
        }
        static public bool DeleteElevator(ElevatorController elevator)
        {

            return KCSDatabaseHelper.Instance.DeleteElevator(elevator);
        }
        
    }
}
