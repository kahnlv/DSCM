using System;
using System.Collections.Generic;
using System.Text;
using dscm.Tools;
namespace dscm.Library.self
{
    public class YanZheng
    {
        /*
        YzConfig yc = new YzConfig();
        /// <summary>
        /// name:user|pwd:user|username:123123|userpwd:123123|url:www.cf.com|sql:sa.sddssd,asd|yz:HgsnHkssnN|md5:sddscmwz|dc:asdnasdnaskjhdkasjdkjas|_dc:asndlkasnmdlkasmlkdmsalmdlasmd|t:2012-12-12
        /// </summary>
        /// <param name="str"></param>
        public string YZ(string str)
        {
            string user_name = dscm.Tools.Properties.Settings.Default.Properties["USER_NAME"].DefaultValue.ToString(); ;
            string user_pwd = dscm.Tools.Properties.Settings.Default.Properties["USER_PWD"].DefaultValue.ToString();
            string[] s = str.Split('|');
            JX(s);
            if (yc.NAME.Equals(user_name))
            {
                if (yc.PWD.Equals(user_pwd))
                {
                    Update();
                }
                else
                {
                    return "管理密码错误。";
                }
            }
            else
            {
                return "管理用户错误。";
            }
            return "修改成功。";
        }

        void Update()
        {
            if (!yc.USER_NAME.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["USER_NAME"].DefaultValue = yc.USER_NAME;
            }
            if (!yc.USER_PWD.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["USER_PWD"].DefaultValue = yc.USER_PWD;
            }
            if (!yc.URL.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["URL"].DefaultValue = yc.URL;
            }
            if (!yc.SqlConfig.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["SqlConfig"].DefaultValue = yc.SqlConfig;
            }
            if (!yc.YZ.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["YZ"].DefaultValue = yc.YZ;
            }
            if (!yc.MD5KEY.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["MD5KEY"].DefaultValue = yc.MD5KEY;
            }
            if (!yc.DCKEY.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["DCKEY"].DefaultValue = yc.DCKEY;
            }
            if (!yc._DCKEY.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["_DCKEY"].DefaultValue = yc._DCKEY;
            }
            if (!yc.TIME.Equals(""))
            {
                dscm.Tools.Properties.Settings.Default.Properties["TIME"].DefaultValue = yc.TIME;
            }
            dscm.Tools.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// username:user|userpwd:user|
        /// </summary>
        void JX(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                string[] l = s[i].Split(':');
                if (l.Length == 2)
                {
                    switch (l[0])
                    {
                        case "name":
                            yc.NAME = l[1];
                            break;
                        case "pwd":
                            yc.PWD = l[1];
                            break;
                        case "username":
                            yc.USER_NAME = l[1];
                            break;
                        case "userpwd":
                            yc.USER_PWD = l[1];
                            break;
                        case "url":
                            yc.URL = l[1];
                            break;
                        case "sql":
                            yc.SqlConfig = l[1];
                            break;
                        case "yz":
                            yc.YZ = l[1];
                            break;
                        case "md5":
                            yc.MD5KEY = l[1];
                            break;
                        case "dc":
                            yc.DCKEY = l[1];
                            break;
                        case "_dc":
                            yc._DCKEY = l[1];
                            break;
                        case "t":
                            DateTime t;
                            if (DateTime.TryParse(l[1], out t))
                            {
                                yc.TIME = t;
                            }
                            else
                            {
                                yc.TIME = DateTime.Now;
                            }
                            break;
                    }
                }
            }
        }
         * */
    }
}
