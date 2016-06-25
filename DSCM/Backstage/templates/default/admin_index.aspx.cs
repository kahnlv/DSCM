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
using DSCM.ds_tbl_admin;
using dscm.Tools.Sql;

public partial class Backstage_templates_default_admin_index : Page
{
    public tbl_admin[] admin = new tbl_admin[] { };
    public string adminname = "";
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
                string page = dscmSave.QueryString("page");
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                adminname = dscmSave.Form("adminname");
                if (adminname != "")
                {
                    adminname = " and admin_name like '%" + adminname + "%'";
                }
                string[] colm = new string[] { "admin_id", "admin_name", "admin_pwd", "admin_type" };
                admin = SQL.ReadAll<tbl_admin>("tbl_admin", colm, adminname, p, 20, "admin_id", true);
                allcount = SQL.AllCount;
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
                count = pl.Count;
            }
        }
    }
}