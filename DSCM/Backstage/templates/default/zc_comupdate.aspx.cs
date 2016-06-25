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
using DSCM.Backstage;
using dscm.Tools.Sql;
using DSCM.ds_tbl_object_pl;

public partial class Backstage_templates_default_zc_comupdate :Page
{
    public tbl_object_pl tobj_pl = new tbl_object_pl();
    public string obj_pl_id = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            UserLogin ul = new UserLogin();
            if (ul.Login())
            {
                //获取传参
                string act = dscmSave.QueryString("ds");
                object obj = dscmSave.GetObject(act);
                obj_pl_id = dscmSave.QueryString("id");
                tobj_pl = SQL.Read<tbl_object_pl>("tbl_object_pl", " and object_pl_id='" + obj_pl_id + "'");
            }
        }

    }
}