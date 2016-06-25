/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/1 12:02:31 
* File name：heard 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Web;
using DSCM.Library;
using System.Web.UI.WebControls;
using DSCM.Tool.Tools;
using DSCM.Backstage;
using DSCM.BLL;

public partial class Backstage_templates_default_public_heard : Page
{
    public dscm_nav DSCM_NAV = new dscm_nav();
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            string str = "";
            if (Save("admin_type").ToString().Equals("2"))
            {
                str = Config.Admin_Agent;
            }
            else
            {
                str = Config.Admin_Navigation;
            }
            DSCM_NAV = Json.Read<dscm_nav>(str);
        }
    }
}
