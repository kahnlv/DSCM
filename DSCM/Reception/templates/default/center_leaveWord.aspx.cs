/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：center_leaveWord 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using DSCM.Library;
using DSCM.ds_tbl_user_message;
using System.Collections;

public partial class Reception_templates_default_center_leaveWord : Page
{
    public tbl_user_message[] message = new tbl_user_message[] { };
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 4)
            {
                message = al[0] as tbl_user_message[];
                if (message == null) message = new tbl_user_message[] { };
                pagestr = al[2] as string;
            }
        }
    }
}