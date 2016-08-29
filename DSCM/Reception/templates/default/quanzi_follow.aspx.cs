using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_user_biaoqian;
using DSCM.Library;
using System;
using System.Collections;

public partial class Reception_templates_default_quanzi_follow : Page
{
    protected tbl_user[] Recommend { get; set; }
    protected tbl_user[] friend { get; set; }

    public int Count = 0;
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Save("user_id").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            else
            {
                string act = dscmSave.QueryString("ds");
                object obj = dscmSave.GetObject(act);

                ArrayList al = obj as ArrayList;
                if (al != null)
                {
                    string alType = "";
                    int i = 0;
                    foreach (var a in al)
                    {
                        alType = a.GetType().Name;
                        switch (alType)
                        {
                            case "tbl_user[]":
                                if (i == 0)
                                {
                                    friend = a as tbl_user[];
                                }
                                else
                                {
                                    Recommend = a as tbl_user[];
                                }
                                break;
                        }
                        i++;
                    }
                }

                Count = SQL.Read("tbl_friend tf", "  [tf].[if_friend] = 1 and  user_id='" + Save("user_id").ToString() + "'");
            }
        }
    }
}