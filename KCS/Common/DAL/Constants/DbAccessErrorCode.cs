using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Common.DAL.Constants
{
    public enum DataBaseAccessErrorCode
    {
        Success = 0,
        OperationError = -1,
        ExisitedUserId = -2,
        ExisitedCardId = -3
    }
}
