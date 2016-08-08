using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_user_biaoqian;
using DSCM.Library;
using System;
using System.Collections;

public partial class Reception_templates_default_quanzi_daren : Page
{
    protected tbl_user_biaoqian[] tag { get; set; }
    protected tbl_user[] user { get; set; }

    public int Count = 0;
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);

            ArrayList al = obj as ArrayList;
            if (al != null)
            {
                string alType = "";
                foreach (var a in al)
                {
                    alType = a.GetType().Name;
                    switch (alType)
                    {
                        case "tbl_user_biaoqian[]":
                            tag = a as tbl_user_biaoqian[];
                            break;
                        case "tbl_user[]":
                            user = a as tbl_user[];
                            break;
                    }
                }
            }

            //userList = SQL.ReadAll<tbl_user>("tbl_user", " and user_recommend=1");
            Count = SQL.Read("tbl_friend", " and user_id='" + Save("user_id").ToString() + "'");
        }
    }
}