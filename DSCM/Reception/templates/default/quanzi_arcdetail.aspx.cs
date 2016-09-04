using dscm.Tools.Sql;
using DSCM.ds_tbl_article;
using DSCM.ds_tbl_user;
using DSCM.Library;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Reception_templates_default_quanzi_arcdetail : Page
{
    public string hot = "";
    public tbl_article article = new tbl_article();
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            string article_id = dscmSave.QueryString("id");
            article = SQL.Read<tbl_article>("tbl_article", " and article_id='" + article_id + "'");
            article.bqs = article.Article_Biaoqian.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            article.plnum = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "'");
            article.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + article.User_Id + "'");
            //hot = (int.Parse(article.Article_Hot) + 1).ToString();
            string[] colm = new string[] { "article_hot" };
            string[] value = new string[] { hot };
            //更新文章热度值
            //SQL.Update("tbl_article", colm, value, " and article_id='" + article_id + "'");
        }

    }
}