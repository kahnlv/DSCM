/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/3/17 14:10:13 
* File name：DSCMSeting 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DSCM.Library
{
    public class DSCMSeting
    {
        public string Access_Token
        {
            get { return Settings.Default.Properties["Access_Token"].DefaultValue.ToString(); }
        }

        static string ds_Url = "";

        public static string Ds_Url
        {
            get { return Settings.Default.Properties["DSCM_URL"].DefaultValue ==null ? "" :Settings.Default.Properties["DSCM_URL"].DefaultValue.ToString(); }
        }
        /// <summary>
        /// 0:验证错误，1：验证成功，2：授权过期，3：域名没有授权，4：请购买正版授权
        /// </summary>
        /// <returns></returns>
        public static int ReadSet()
        {
            return 1;
            try
            {
                int reg = 0;
                string ds_time = Settings.Default.Properties["DSCM_TIME"].DefaultValue.ToString();
                string ds_reg = Settings.Default.Properties["DSCM_REGEDIT"].DefaultValue.ToString();
                string[] sArr = ds_reg.Split('|');
                if (sArr.Length == 2)
                {
                    string host = HttpContext.Current.Request.Url.Host;

                    string[] Arrhost =  sArr[0].Replace("[", "").Replace("]", "").Split(',');

                    for (int i = 0; i < Arrhost.Length; i++)
                    {
                        if ((Arrhost[i]).ToLower().Equals(host.ToLower()))
                        {
                            if (ds_time.Equals("0"))
                            {
                                return 1;
                            }
                            else
                            {
                                DateTime dt1 = new DateTime();
                                DateTime dt2 = new DateTime();
                                if (DateTime.TryParse(sArr[1], out dt2))
                                {
                                    if (DateTime.TryParse(ds_time, out dt1))
                                    {
                                        if (dt1 == dt2)
                                        {
                                            if (dt1 < DateTime.Now)
                                            {
                                                reg = 2;
                                            }
                                            else
                                            {
                                                return 1;
                                            }
                                        }
                                    }
                                }
                            }
                            reg = 4;
                        }
                        else
                        {
                            reg = 3;
                        }
                    }
                    reg = 0;
                }
                else
                {
                    reg = 4;
                }
                return reg;
            }
            catch { return 0; }
        }

        public static void WriteSet(string key , string value)
        {
            try
            {
                Settings.Default.Properties[key].DefaultValue = value;
                Settings.Default.Save();
            }
            catch { }
        }
    }
}
