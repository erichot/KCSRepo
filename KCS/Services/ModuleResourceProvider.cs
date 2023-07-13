using KCS.Common.DAL;
using KCS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Services
{
    public interface IModuleResourceProvider
    {
        string GetCaption(ModuleType moduleType);
        object GetModuleImage(ModuleType moduleType, bool smallImage = false);
    }
    public class ModuleResourceProvider : IModuleResourceProvider
    {
        public string GetCaption(ModuleType moduleType)
        {
            switch (moduleType)
            {
                case ModuleType.Unknown:
                    return null;
                case ModuleType.Employees:
                case ModuleType.DeviceSetting:
                case ModuleType.AccessControl:
                case ModuleType.Supervisor:
                case ModuleType.TimeAttendance:

                    return LanguageResource.GetDisplayString("Navi" + moduleType.ToString());
                default:
                    return LanguageResource.GetDisplayString("NaviItem" + moduleType.ToString());
                    //return moduleType.ToString();
            }
        }
        public virtual object GetModuleImage(ModuleType moduleType, bool smallImage = false)
        {
            switch (moduleType)
            {
                
                case ModuleType.Unknown:
                    return null;
                default:
                    return null;
            }
        }
    }
}
