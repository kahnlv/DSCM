/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 15:51:38 
* File name：user_letter 
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
using DSCM.ds_tbl_letter;
using System.Collections;
using DSCM.ds_tbl_user_space;
using dscm.Tools.Sql;

public partial class Reception_templates_default_user_letter : Page
{
    public tbl_letter[] user_log = new tbl_letter[] { };
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
                user_log = al[0] as tbl_letter[];
                if (user_log == null) user_log = new tbl_letter[] { };
                allcount = (int)al[1];
                pagestr = al[2].ToString();
                count = (int)al[3];
            }
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
        }
    }
}
