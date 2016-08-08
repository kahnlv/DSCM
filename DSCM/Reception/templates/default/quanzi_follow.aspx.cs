using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_user_biaoqian;
using DSCM.Library;
using System;
using System.Collections;

public partial class Reception_templates_default_quanzi_follow : Page
{
    protected tbl_user[] Recommend { get; set; }
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
                        case "tbl_user[]":
                            Recommend = a as tbl_user[];
                            break;
                    }
                }
            }
        }
    }
}