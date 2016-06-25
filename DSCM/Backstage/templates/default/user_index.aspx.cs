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
using DSCM.Backstage;
using DSCM.ds_tbl_province;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user;

public partial class Backstage_templates_default_user_index : Page
{

    public tbl_user[] tbl_user = new tbl_user[] { };
    public tbl_province[] province = new tbl_province[] { };
    public string user_sex = "";
    public string user_name = "";
    public string user_relname = "";
    public DSCMtools dtools = new DSCMtools();
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
                user_sex = dscmSave.Form("user_sex");
                user_name = dscmSave.Form("user_name");
                user_relname = dscmSave.Form("user_relname");

                ArrayList al = obj as ArrayList;
                if (al != null && al.Count == 4)
                {
                    tbl_user = al[0] as tbl_user[];
                    allcount = (int)al[1];
                    pagestr = al[2] as string;
                    count = (int)al[3];
                }
            }
        }
    }
}