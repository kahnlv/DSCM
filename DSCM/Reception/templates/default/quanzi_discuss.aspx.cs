using DSCM.ds_tbl_article;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_discuss :Page
{
    public string article_id = "";
    public tbl_article article = new tbl_article();
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            article_id = dscmSave.QueryString("id");
            if (Save("user_id").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 1)
            {
                article = al[0] as tbl_article;
            }
        }

    }
}