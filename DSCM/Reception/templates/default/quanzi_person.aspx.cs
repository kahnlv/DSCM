using DSCM.ds_tbl_article;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_person : Page
{
    public tbl_article[] articles = new tbl_article[] { };
    public tbl_article art1 = new tbl_article();
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
                if (al != null && al.Count == 1)
                {
                    articles = al[0] as tbl_article[];
                    for (int i = 0; i < articles.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                art1 = articles[0];
                                break;
                        }
                    }
                }
            }
        }
    }
}