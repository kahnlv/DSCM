/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 14:16:49 
* File name：hongbao 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;
using dscm.Library.self;
using dscm.Tools.Sql;

namespace DSCM.Backstage
{
    public class UserLogin : DSCMSave
    {        
        public bool Login()
        {
            string admin_id = Save("admin_id") != null ? Save("admin_id").ToString() : "";
            if (admin_id.Equals(""))
            {
                Response.Write("<script>parent.location='/Backstage/templates/default/login.aspx'</script>");
                return false;
            }
            return true;
        }
        public void Loglog(string user_id, string user_name, string center)
        {
            try
            {
                string[] colm = new string[] { "log_id", "user_id", "user_name", "center", "time" };
                string[] value = new string[] { Guid, user_id, user_name, center, DateTime.Now.ToString() };
                int i = SQL.Insert("dbo.tbl_log", colm, value);
            }
            catch { }
        }
    }
}
