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
using DSCM.ds_tbl_log;
using DSCM.Library;
using dscm.Tools.Sql;
using DSCM.Backstage;

public partial class Backstage_templates_default_log_index : Page
{
    public tbl_log[] logs = new tbl_log[] { };
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
                logs = SQL.ReadAll<tbl_log>("tbl_log", " ", p, 20, "time", false);
                allcount = SQL.AllCount;
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
                count = pl.Count;
            }
        }
    }
}