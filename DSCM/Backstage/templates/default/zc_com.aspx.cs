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
using System.Collections;
using DSCM.Library;
using DSCM.Backstage;
using DSCM.ds_tbl_object_pl;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object;

public partial class Backstage_templates_default_zc_com : Page
{
    public tbl_object_pl[] obj_pl = new tbl_object_pl[] { };
    public string objname = "";
    public string username = "";
    public string plcontent = "";
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
                objname = dscmSave.Form("objname");
                username = dscmSave.Form("username");
                plcontent = dscmSave.Form("plcontent");
                ArrayList al = obj as ArrayList;
                if (al != null && al.Count == 4)
                {
                    obj_pl = al[0] as tbl_object_pl[];
                    allcount = (int)al[1];
                    pagestr = al[2] as string;
                    count = (int)al[3];
                }
            }
        }
    }
}