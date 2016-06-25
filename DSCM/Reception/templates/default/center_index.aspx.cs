/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 11:53:37 
* File name：center_index 
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
using DSCM.ds_tbl_photo;
using DSCM.ds_tbl_user_log;
using DSCM.ds_tbl_user_message;
using DSCM.ds_tbl_object;

public partial class Reception_templates_default_center_index : Page
{
    public tbl_photo[] photo = new tbl_photo[] { };
    public tbl_user_log log = new tbl_user_log();
    public tbl_user_message[] message = new tbl_user_message[] { };
    public tbl_object[] tbl_obj = new tbl_object[] { };
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
                photo = al[0] as tbl_photo[];
                log = al[1] as tbl_user_log;
                message = al[2] as tbl_user_message[];
                tbl_obj = al[3] as tbl_object[];
                if (photo == null) photo = new tbl_photo[] { };
                if (log == null) log = new tbl_user_log();
                if (message == null) message = new tbl_user_message[] { };
                if (tbl_obj == null) tbl_obj = new tbl_object[] { };

            }
        }
    }
}
