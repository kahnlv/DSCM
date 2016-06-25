using DSCM.ds_tbl_message;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_message : Page
{
    public tbl_message[] messages = new tbl_message[] { };
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
                if (al != null && al.Count == 4)
                {
                    messages = al[0] as tbl_message[];
                    allcount = (int)al[1];
                    pagestr = al[2] as string;
                    count = (int)al[3];
                }
            }
        }
    }
}