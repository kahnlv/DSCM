using DSCM.ds_tbl_letter;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_letter : Page
{
    public tbl_letter[] letters = new tbl_letter[] { };
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
            else
            {
                ArrayList al = obj as ArrayList;
                if (al != null)
                {
                    letters = al[0] as tbl_letter[];
                }
            }
        }
    }
}