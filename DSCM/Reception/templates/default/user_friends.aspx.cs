/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 13:10:58 
* File name：user_friends 
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
using DSCM.ds_tbl_friend;
using System.Collections;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_user_space;
using dscm.Tools.Sql;

public partial class Reception_templates_default_user_friends : Page
{
    public tbl_friend[] friends = new tbl_friend[] { };
    public tbl_user_space user_space = new tbl_user_space();
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count ==4)
            {
                friends = al[0] as tbl_friend[];
                allcount = (int)al[1];
                pagestr = al[2] as string;
                count = (int)al[3];
                if (friends == null) friends = new tbl_friend[] { };
            } 
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
    
        }
    }
}
