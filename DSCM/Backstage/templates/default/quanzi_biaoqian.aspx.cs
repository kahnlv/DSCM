using DSCM.Backstage;
using DSCM.ds_tbl_biaoqian;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Backstage_templates_default_quanzi_biaoqian : Page
{
    public tbl_biaoqian[] tbl_bqs = new tbl_biaoqian[] { };
    public string bqtype = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserLogin ul = new UserLogin();
            if (ul.Login())
            {
                //获取传参
                string act = dscmSave.QueryString("ds");
                object obj = dscmSave.GetObject(act);
                bqtype = dscmSave.Form("biaoqian_type");
                ArrayList al = obj as ArrayList;
                if (al != null && al.Count == 4)
                {
                    tbl_bqs = al[0] as tbl_biaoqian[];
                    allcount = (int)al[1];
                    pagestr = al[2] as string;
                    count = (int)al[3];
                }
            }
        }
    }
}