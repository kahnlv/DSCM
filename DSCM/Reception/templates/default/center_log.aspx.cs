/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:15:53 
* File name：center_log 
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
using DSCM.ds_tbl_user_log;
using System.Collections;

public partial class Reception_templates_default_center_log : Page
{
    public tbl_user_log[] user_log = new tbl_user_log[] { };
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 4)
            {
                user_log = al[0] as tbl_user_log[];
                allcount = (int)al[1];
                pagestr = al[2] as string;
                count = (int)al[3];
            }
        }
    }
}
