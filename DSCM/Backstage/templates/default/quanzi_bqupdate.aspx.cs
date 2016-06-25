using dscm.Tools.Sql;
using DSCM.Backstage;
using DSCM.ds_tbl_biaoqian;
using DSCM.Library;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Backstage_templates_default_quanzi_bqupdate : Page
{
    public tbl_biaoqian tbq = new tbl_biaoqian();
    public string biaoqian_id = "";
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
                biaoqian_id = dscmSave.QueryString("id");
                tbq = SQL.Read<tbl_biaoqian>("tbl_biaoqian", " and biaoqian_id='" + biaoqian_id + "'"); 
            }
        }

    }
}