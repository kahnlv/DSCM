using System;
using System.Collections.Generic;
using System.Text;

namespace DSCM.Config
{
    public class PageConfig
    {
        public static string PageCode = System.Web.Configuration.WebConfigurationManager.AppSettings["PageCode"];
        public static string SqlCon = System.Web.Configuration.WebConfigurationManager.AppSettings["SqlServerData"];
        public static string Md5Str = System.Web.Configuration.WebConfigurationManager.AppSettings["MD5STR"];
        public static string DCKEY = System.Web.Configuration.WebConfigurationManager.AppSettings["DCKEY"];
        public static string _DCKEY = System.Web.Configuration.WebConfigurationManager.AppSettings["_DCKEY"];
        public static string _COOKIE = System.Web.Configuration.WebConfigurationManager.AppSettings["COOKIE"];
        public static string DEBUG = System.Web.Configuration.WebConfigurationManager.AppSettings["DEBUG"];
        public static List<string> SessionID = new List<string>();
        public static string Access_Token = "";
    }
}
