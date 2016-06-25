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
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_province;
using System.Collections;
using DSCM.ds_tbl_user;

public partial class Backstage_templates_default_zc_index :Page
{

    public tbl_object[] tbl_obj = new tbl_object[] { };
    public tbl_province[] province = new tbl_province[] { };
    public string obj_class = "";
    public string obj_title = "";
    public string obj_username = "";
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

                province = SQL.ReadAll<tbl_province>("tbl_province", "");
                obj_class = dscmSave.Form("obj_class");
                obj_title = dscmSave.Form("obj_title");
                obj_username = dscmSave.Form("obj_username");

                ArrayList al = obj as ArrayList;
                if (al != null && al.Count == 4)
                {
                    tbl_obj = al[0] as tbl_object[];
                    allcount = (int)al[1];
                    pagestr = al[2] as string;
                    count = (int)al[3];
                }
            }
        }
    }
}