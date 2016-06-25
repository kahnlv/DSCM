using dscm.Tools.Sql;
using DSCM.Backstage;
using DSCM.ds_tbl_message_class;
using DSCM.Library;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Backstage_templates_default_quanzi_mesclaupdate : Page
{
    public tbl_message_class tmescla = new tbl_message_class();
    public tbl_message_class[] tbl_mespraclas = new tbl_message_class[] { };
    public string mescla_id = "";
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
                mescla_id = dscmSave.QueryString("id");
                tmescla = SQL.Read<tbl_message_class>("tbl_message_class", " and message_class_id='" + mescla_id + "'");
                tbl_mespraclas = SQL.ReadAll<tbl_message_class>("tbl_message_class", " and message_class_type='" + tmescla.Message_Class_Type+ "' and message_class_parentid='0'");
            }
        }

    }
}