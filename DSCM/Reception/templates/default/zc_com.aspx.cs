/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 14:31:01 
* File name：zc_com 
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
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_object_pl;
using DSCM.ds_tbl_user;
using dscm.Tools.Sql;

public partial class Reception_templates_default_zc_com : Page
{
    public string object_id = "";
    public tbl_object tbl_obj = new tbl_object();
    public tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
    public tbl_object_pl[] obj_pl = new tbl_object_pl[] { };
    //public tbl_user tbl_us = new tbl_user();
    public int zhichi = 0;
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            object_id = dscmSave.QueryString("id");
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 7)
            {
                tbl_obj = al[3] as tbl_object;
                obj_zc = al[4] as tbl_object_zc[];
                obj_pl = al[5] as tbl_object_pl[];
               // tbl_us = al[7] as tbl_user;
                if(tbl_obj == null)tbl_obj = new tbl_object();
                if (obj_zc == null) obj_zc = new tbl_object_zc[] { };
                if (obj_pl == null) obj_pl = new tbl_object_pl[] { };
                //if (tbl_us == null) tbl_us = new tbl_user();
                allcount = (int)al[0];
                pagestr = al[1] as string;
                count = (int)al[2];
                zhichi = (int)al[6];
            }
        }
    }
}
