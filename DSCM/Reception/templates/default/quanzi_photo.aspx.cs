using dscm.Tools.Sql;
using DSCM.ds_tbl_biaoqian;
using DSCM.ds_tbl_user;
using DSCM.Library;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_photo : Page
{
    public string username = "";
    public tbl_biaoqian[] tbqs = new tbl_biaoqian[] { };
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);

            if (Save("user_id").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }

            tbqs = SQL.ReadAll<tbl_biaoqian>("tbl_biaoqian", " and biaoqian_type=2");
        }

    }
}