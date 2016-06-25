/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 13:44:06 
* File name：object_sendout 
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
using DSCM.ds_tbl_object_zc_pes;
using System.Collections;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_user_space;
using dscm.Tools.Sql;

public partial class Reception_templates_default_object_sendout : Page
{
    //public tbl_object_zc_pes[] object_zc_pes = new tbl_object_zc_pes[] { };
    public tbl_order[] user_log = new tbl_order[] { };
    public tbl_user_space user_space = new tbl_user_space();
    public string start = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            start = dscmSave.QueryString("start");
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 4)
            {
                //object_zc_pes = al[0] as tbl_object_zc_pes[];
                user_log = al[0] as tbl_order[];
                allcount = (int)al[1];
                pagestr = al[2] as string;
                count = (int)al[3];
            }
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
        }
    }
}
