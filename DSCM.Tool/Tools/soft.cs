using dscm.Library.MD5JM;
using System;
using System.Collections.Generic;
using System.Text;

namespace dscm.Library.self
{
    public class soft
    {
        /*
        md5 m5 = new md5();
        public YzConfig yc = new YzConfig();
        SoftReg sr = new SoftReg();
        public bool yz()
        {
            read();
            if (YzConfig.SoftReg.Equals(""))
            {
                YzConfig.SoftReg = sr.getRNum();
            }
            if (yc.JQM.Equals(""))
            {
                yc.JQM = sr.getRNum();
                dscm.Tools.Properties.Settings.Default.Properties["JQM"].DefaultValue = yc.JQM;
                dscm.Tools.Properties.Settings.Default.Properties["Success"].DefaultValue = true;
                dscm.Tools.Properties.Settings.Default.Save();
            }
            if (!yc.Success)
            {
                return false;
            }
            //string sss = m5.EncryptDES(yc.YZ);
            if (yc.YZ.Equals("") || yc.TIME.ToShortDateString().Equals(DateTime.Now.ToShortDateString()) || !yc.JQM.ToString().Trim().Equals(YzConfig.SoftReg.ToString().Trim()))
            {
                return false;
            }
            else
            {
                yc.YZ = m5.DecryptDES(yc.YZ);
                if (yc.YZ.Equals(""))
                {
                    ///name|url|time
                    return false;
                }
                else
                {
                    ///name|url|time
                    string[] s = yc.YZ.Split('|');
                    if (s.Length == 3)
                    {
                        DateTime t;
                        if (DateTime.TryParse(s[2], out t))
                        {
                            if (t.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                            {
                                return false;
                            }
                            else
                            {
                                if (t.ToShortDateString().Equals(yc.TIME.ToShortDateString()))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        void read()
        {
            yc.USER_NAME = dscm.Tools.Properties.Settings.Default.Properties["USER_NAME"].DefaultValue.ToString();
            yc.USER_PWD = dscm.Tools.Properties.Settings.Default.Properties["USER_PWD"].DefaultValue.ToString();
            yc.URL = dscm.Tools.Properties.Settings.Default.Properties["URL"].DefaultValue.ToString();
            yc.SqlConfig = dscm.Tools.Properties.Settings.Default.Properties["SqlConfig"].DefaultValue.ToString();
            yc.YZ = dscm.Tools.Properties.Settings.Default.Properties["YZ"].DefaultValue.ToString();
            yc.MD5KEY = dscm.Tools.Properties.Settings.Default.Properties["MD5KEY"].DefaultValue.ToString();
            yc.DCKEY = dscm.Tools.Properties.Settings.Default.Properties["DCKEY"].DefaultValue.ToString();
            yc._DCKEY = dscm.Tools.Properties.Settings.Default.Properties["_DCKEY"].DefaultValue.ToString();
            yc.TIME = DateTime.Parse(dscm.Tools.Properties.Settings.Default.Properties["TIME"].DefaultValue != null ? dscm.Tools.Properties.Settings.Default.Properties["TIME"].DefaultValue.ToString() : "2014-01-01");
            yc.JQM = dscm.Tools.Properties.Settings.Default.Properties["JQM"].DefaultValue.ToString();
            yc.Success = bool.Parse(dscm.Tools.Properties.Settings.Default.Properties["Success"].DefaultValue!=null?dscm.Tools.Properties.Settings.Default.Properties["Success"].DefaultValue.ToString():"false") ;
        }
         * */
    }
}
