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
using dscm.Tools.Sql;
using DSCM.Library;
using DSCM.Backstage;
using DSCM.ds_tbl_object_zc;

public partial class Backstage_templates_default_zc_zcupdate : Page
{
    public tbl_object_zc tobj_zc = new tbl_object_zc();
    public string obj_zc_id = "";
    public string raiseprice = "";
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
                obj_zc_id = dscmSave.QueryString("id");
                raiseprice = dscmSave.QueryString("raiseprice");
                tobj_zc = SQL.Read<tbl_object_zc>("tbl_object_zc", " and object_zc_id='" + obj_zc_id + "'");
            }
        }

    }
}