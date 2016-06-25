/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/25 10:59:32 
* File name：photo_insert 
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
using DSCM.ds_tbl_photo_img;
using System.Collections;
using DSCM.ds_tbl_user_space;
using dscm.Tools.Sql;

public partial class Reception_templates_default_photo_img : Page
{
    public tbl_photo_img[] user_log = new tbl_photo_img[] { };
    public tbl_user_space user_space = new tbl_user_space();
    public string photo_id = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            photo_id = dscmSave.QueryString("id");
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 4)
            {
                user_log = al[0] as tbl_photo_img[];
                if (user_log == null) user_log = new tbl_photo_img[] { };
                allcount = (int)al[1];
                pagestr = al[2] as string;
                count = (int)al[3];
            }
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
    
        }
    }
}
