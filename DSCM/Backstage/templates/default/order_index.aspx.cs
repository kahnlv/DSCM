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
using dscm.Tools.Sql;
using DSCM.ds_tbl_province;
using DSCM.ds_tbl_order;

public partial class Backstage_templates_default_order_index : Page
{
    public tbl_order[] tbl_order = new tbl_order[] { };
    public string obj_class = "";
    public string obj_title = "";
    public string username = "";
    public string ordertime = "";
    public string endordertime = "";
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

                obj_class = dscmSave.Form("obj_class");
                obj_title = dscmSave.Form("obj_title");
                username = dscmSave.Form("username");
                ordertime = dscmSave.Form("ordertime");
                endordertime = dscmSave.Form("endordertime");

                ArrayList al = obj as ArrayList;
                if (al != null && al.Count == 4)
                {
                    tbl_order = al[0] as tbl_order[];
                    allcount = (int)al[1];
                    pagestr = al[2] as string;
                    count = (int)al[3];
                }
            }
        }
    }
}