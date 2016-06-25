using dscm.Tools.Sql;
using DSCM.ds_tbl_biaoqian;
using DSCM.ds_tbl_message_class;
using DSCM.Library;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_setup : Page
{
    public tbl_biaoqian[] tbqs = new tbl_biaoqian[] { };
    public tbl_message_class[] mescla1 = new tbl_message_class[] { };
    public tbl_message_class[] mescla2 = new tbl_message_class[] { };
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
            tbqs = SQL.ReadAll<tbl_biaoqian>("tbl_biaoqian", " and biaoqian_type=0");
            mescla1 = SQL.ReadAll<tbl_message_class>("tbl_message_class", " and message_class_type=0 and message_class_parentid='0'");
            foreach (tbl_message_class mc in mescla1)
            {
                mc.mescla = SQL.ReadAll<tbl_message_class>("tbl_message_class", " and message_class_parentid='" + mc.Message_Class_Id + "'");
            }
            mescla2 = SQL.ReadAll<tbl_message_class>("tbl_message_class", " and message_class_type=1");
        }
    }
}