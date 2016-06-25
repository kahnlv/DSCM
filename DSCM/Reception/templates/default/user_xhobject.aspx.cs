/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：daohang 
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
using System.Collections;
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_user_space;
using dscm.Tools.Sql;

public partial class Reception_templates_default_user_xhobject : Page
{
    public tbl_object[] tbl_obj = new tbl_object[] { };
    public tbl_user_space user_space = new tbl_user_space();
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
                tbl_obj = al[0] as tbl_object[];
                if (tbl_obj == null) tbl_obj = new tbl_object[] { };
                allcount = (int)al[1];
                pagestr = al[2].ToString();
                count = (int)al[3];
            }
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
        }
    }
}