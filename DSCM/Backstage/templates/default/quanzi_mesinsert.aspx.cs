using dscm.Tools.Sql;
using DSCM.Backstage;
using DSCM.ds_tbl_message_class;
using DSCM.Library;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Backstage_templates_default_quanzi_mesinsert :Page
{
    public tbl_message_class[] tbl_mesclas = new tbl_message_class[] { };
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
                tbl_mesclas = SQL.ReadAll<tbl_message_class>("tbl_message_class", "");
            }
        }
    }
}