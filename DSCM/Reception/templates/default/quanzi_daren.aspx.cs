using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_daren : Page
{
    public tbl_user[] users = new tbl_user[] { };
    public tbl_user[] usersBiaoqian = new tbl_user[] { };
    public tbl_user[] usersGuanzhu = new tbl_user[] { };  
    public tbl_user[] userList = new tbl_user[] { };

    public int Count = 0;
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);

            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 3)
            {
                users = al[0] as tbl_user[];
                usersBiaoqian = al[1] as tbl_user[];
                usersGuanzhu = al[2] as tbl_user[];
            }

            userList = SQL.ReadAll<tbl_user>("tbl_user", " and user_recommend=1");
            Count = SQL.Read("tbl_friend", " and user_id='" + Save("user_id").ToString() + "'");
        }
    }
}