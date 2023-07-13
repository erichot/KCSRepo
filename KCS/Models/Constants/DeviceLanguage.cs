using KCS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class DeviceLanguage
    {
        static int iLanguageCN = 0;
        static int iLanguageTW = 1;
        static int iLanguageEnglish = 2;
        static int iLanguageItalian = 3;
        static int iLanguageSpanish = 4;
        static int iLanguagePortuguese = 5;
        static int iLanguageThai = 6;
        static int iLanguageBrazilian = 7;
        static int iLanguageCorean = 8;

        static string LangLanguageCN = LanguageResource.GetDisplayString("LanguageCN");
        static string LangLanguageTW = LanguageResource.GetDisplayString("LanguageTW");
        static string LangLanguageEnglish = LanguageResource.GetDisplayString("LanguageEnglish");
        static string LangLanguageItalian = LanguageResource.GetDisplayString("LanguageItalian");
        static string LangLanguageSpanish = LanguageResource.GetDisplayString("LanguageSpanish");
        static string LangLanguagePortuguese = LanguageResource.GetDisplayString("LanguagePortuguese");
        static string LangLanguageThai = LanguageResource.GetDisplayString("LanguageThai");
        static string LangLanguageBrazilian = LanguageResource.GetDisplayString("LanguageBrazilian");
        static string LangLanguageCorean = LanguageResource.GetDisplayString("LanguageCorean");

        public int this[string name]
        {
            get
            {
                if (name.Equals(LangLanguageCN))
                {
                    return iLanguageCN;
                }
                else if (name.Equals(LangLanguageTW))
                {
                    return iLanguageTW;
                }
                else if (name.Equals(LangLanguageEnglish))
                {
                    return iLanguageEnglish;
                }
                else if (name.Equals(LangLanguageItalian))
                {
                    return iLanguageItalian;
                }
                else if (name.Equals(LangLanguageSpanish))
                {
                    return iLanguageSpanish;
                }
                else if (name.Equals(LangLanguagePortuguese))
                {
                    return iLanguagePortuguese;
                }
                else if (name.Equals(LangLanguageThai))
                {
                    return iLanguageThai;
                }
                else if (name.Equals(LangLanguageBrazilian))
                {
                    return iLanguageBrazilian;
                }
                else if (name.Equals(LangLanguageCorean))
                {
                    return iLanguageCorean;
                }
                else
                {
                    return iLanguageCN;
                }
            }
        }

        public string this[int LangSel]
        {
            get
            {
                if (LangSel == iLanguageCN)
                {
                    return LangLanguageCN;
                }
                else if (LangSel == iLanguageTW)
                {
                    return LangLanguageTW;
                }
                else if (LangSel == iLanguageEnglish)
                {
                    return LangLanguageEnglish;
                }
                else if (LangSel == iLanguageItalian)
                {
                    return LangLanguageItalian;
                }
                else if (LangSel == iLanguageSpanish)
                {
                    return LangLanguageSpanish;
                }
                else if (LangSel == iLanguagePortuguese)
                {
                    return LangLanguagePortuguese;
                }
                else if (LangSel == iLanguageThai)
                {
                    return LangLanguageThai;
                }
                else if (LangSel == iLanguageBrazilian)
                {
                    return LangLanguageBrazilian;
                }
                else if (LangSel == iLanguageCorean)
                {
                    return LangLanguageCorean;
                }
                else
                {
                    return LangLanguageCN;
                }
            }
        }


    }
}
