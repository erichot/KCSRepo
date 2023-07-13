using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class DeviceBrief : DeviceBase
    {
        

        public string MenuPwd { get; set; }
        public int WorkMode { get; set; }
        public int Language { get; set; }

        public string LanguageText
        {
            get
            {
                DeviceLanguage devLang = new DeviceLanguage();
                return devLang[Language];
            }
            set
            {
                DeviceLanguage devLang = new DeviceLanguage();
                Language = devLang[value];

            }
        }
        public string WorkModeText
        {
            get
            {
                DeviceWorkMode devWorkMode = new DeviceWorkMode();
                return devWorkMode[WorkMode];
            }
            set
            {
                DeviceWorkMode devWorkMode = new DeviceWorkMode();
                WorkMode = devWorkMode[value];
            }
        }
    }
}
