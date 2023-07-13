using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Common.Utils
{
    class LoginPwdCryption
    {
        static string std_str = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ!@$^*()_+-/|`:{}[]";
        static string[] en_str = new string[]{ 
     "{}[]16Z!@$7CDY^*ESJKTU)_+-V(W8F2GHIL345MNOPQR90ABX/|`:", 
     "$7GHIL3{QR9BX/|}[16Z!@CDTU(Y^*ESJ:K)_+-VW8F2]45MNOP`0A", 
     "FGP`0A2]45M$7HIL3{QR916^*ESJ:K)_+-VWBX/|}[8NOZ!@CDTU(Y", 
     "8F2]HI45MN`0$7DT/|}[16Z!XCU(Y^@L3{QR9B*EGASJ:K)_+-VWOP", 
     "XCWU(Y^6Z!EGA5MS8F2]HIB*OP4N`0$7DT/|}[1J:K)_+-V@L3{QR9", 
     "`0$7DT/|}[1XCW8QR9U(Y^F2]HIB*OP45MNJ:K)_+-V@L3{6Z!EGAS", 
     "NJ:K)_+-V@L3`0$8QR]HIB*O9U(Y^F245M{6Z!EGAPS7DT/|}[1XCW", 
     "^F24NR]HIB*OJ:K)_+-V@L3`0$8Q9U(S7D1XCWT/|}[Y5M{6Z!EGAP", 
     "CWT/|}[Y5M{6Z24N$8Q9U(S7D1XA!EG^FPR]HIB*OJ:K)_+-V@L3`0", 
     "T3`09U(S7|}[Y5M8QG^FPR]HIB*OJ:K)_2/LCW{6Z4N$+-V@D1XA!E"
      };

        static string st_str = "acdhjklmnopqrstuvwxy";
        static string in_str = "befgiz";
        static string dc_sort = "LXQPAZDBCH";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scode"></param>
        /// <returns></returns>
        public static string EnCode(string scode)
        {
            string ecode = "";
            string tmpstr = "";
            Random rnd = new Random();
            int hcnt = 0, encnt = 0, cnt = 0, incnt = 0, zcnt = 0;

            if (string.IsNullOrEmpty(scode))
            {
                return "";
            }
            hcnt = rnd.Next(1, 4);

            for (cnt = 0; cnt < hcnt; cnt++)
            {
                encnt = rnd.Next(0, 20);
                ecode += st_str.Substring(encnt, 1);
            }

            encnt = rnd.Next(0, 10);
            ecode += dc_sort.Substring(encnt, 1);

            cnt = 0;
            char[] charArray = scode.ToCharArray();
            for (int i = 0; i < scode.Length; i++)
            {
                char cdata = charArray[i];
                zcnt = cnt % 54;
                cnt += 1;
                if (0 == cnt % 7)
                {
                    hcnt = rnd.Next(0, 6);
                    ecode += in_str.Substring(hcnt, 1);
                    if (rnd.Next(0, 10) > 4)
                    {
                        hcnt = rnd.Next(0, 6);
                        ecode += in_str.Substring(hcnt, 1);
                    }
                }

                tmpstr = String.Format("{0:X2}", Convert.ToInt32(cdata));
                if (tmpstr.Length < 4)
                {
                    hcnt = rnd.Next(0, 20);
                    ecode += st_str.Substring(hcnt, 1);

                    hcnt = rnd.Next(0, 20);
                    ecode += st_str.Substring(hcnt, 1);
                }

                char[] charArrayTmp = tmpstr.ToCharArray();
                for (int j = 0; j < tmpstr.Length; j++)
                {
                    char mchar = charArrayTmp[j];
                    incnt = std_str.IndexOf(mchar);
                    incnt = (incnt + zcnt) % 54;

                    ecode += en_str[encnt].Substring(incnt, 1);
                }
            }


            return ecode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ecode"></param>
        /// <returns></returns>
        public static string DeCode(string ecode)
        {
            string scode = "", tmpstr = "", workstr = "", codestr = "";
            int hcnt = 0, cnt = 0, encnt = 0, xcnt = 0, ycnt = 0, zcnt = 0;


            if (string.IsNullOrEmpty(ecode))
                return "";
            if (ecode.Length > 3)
            {
                tmpstr = ecode.Substring(0, 4);
                char[] charArray = tmpstr.ToCharArray();
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    char mchar = charArray[i];
                    cnt += 1;
                    if (st_str.IndexOf(mchar) < 0 && hcnt == 0)
                    {
                        hcnt = cnt;
                        encnt = dc_sort.IndexOf(mchar);
                    }
                }

                if (hcnt != 0 && encnt > -1 && encnt < 10)
                {
                    tmpstr = ecode.Substring(hcnt);
                    charArray = in_str.ToCharArray();
                    for (int i = 0; i < in_str.Length; i++)
                    {
                        char mchar = charArray[i];
                        tmpstr = tmpstr.Replace(mchar.ToString(), "");
                    }

                    hcnt = Convert.ToInt32(tmpstr.Length / 4) * 4;

                    ycnt = 0;

                    for (cnt = 0; cnt < hcnt; cnt += 4)
                    {
                        zcnt = ycnt % 54;
                        codestr = "";
                        workstr = tmpstr.Substring(cnt, 4);
                        charArray = workstr.ToCharArray();
                        for (int i = 0; i < workstr.Length; i++)
                        {
                            char mchar = charArray[i];
                            if (st_str.IndexOf(mchar) < 0)
                            {
                                xcnt = en_str[encnt].IndexOf(mchar);
                                if (xcnt > -1)
                                {
                                    if (xcnt >= zcnt)
                                    {
                                        xcnt = xcnt - zcnt;
                                    }
                                    else
                                    {
                                        xcnt = 54 + xcnt - zcnt;
                                    }
                                    codestr += std_str.Substring(xcnt, 1);
                                }
                            }
                        }
                        //
                        try
                        {
                            scode += Convert.ToChar(Convert.ToInt32("0x" + codestr, 16));
                        }
                        catch
                        {
                            scode = "";
                            cnt = hcnt;
                        }
                        ycnt += 1;
                    }

                }
            }
            return scode;
        }
    }
}
