/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 11:19:24 
* File name：user_log 
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
using DSCM.ds_tbl_user_space;
using dscm.Tools.Sql;

public partial class Reception_templates_default_user_log : Page
{
    public tbl_user_log[] user_log = new tbl_user_log[] { };
    public tbl_user_space user_space = new tbl_user_space();
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
            ArrayList al = new ArrayList();
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            al = obj as ArrayList;
            if (al != null && al.Count == 4)
            {
                user_log = al[0] as tbl_user_log[];
                allcount = (int)al[1];
                pagestr = al[2] as string;
                count = (int)al[3];

            }
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
        }
    }
}
