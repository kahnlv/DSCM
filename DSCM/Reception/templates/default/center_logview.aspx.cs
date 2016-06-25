/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:27:31 
* File name：center_logview 
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
using System.Collections;
using DSCM.ds_tbl_user_log;
using DSCM.ds_tbl_user_message;

public partial class Reception_templates_default_center_logview : Page
{
    public tbl_user_log user_log = new tbl_user_log();
    public tbl_user_message[] message = new tbl_user_message[] { };
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 5)
            {
                user_log = al[0] as tbl_user_log;
                if (user_log == null) user_log = new tbl_user_log();
                message = al[1] as tbl_user_message[];
                if (message == null) message = new tbl_user_message[] { };
                //allcount = (int)al[2];
                pagestr = al[3] as string;
               //count = (int)al[4];
            }
            
        }
    }
}
