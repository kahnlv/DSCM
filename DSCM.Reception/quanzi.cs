using dscm.Library.self;
using dscm.Tools.Sql;
using DSCM.ds_tbl_article;
using DSCM.ds_tbl_article_pl;
using DSCM.ds_tbl_letter;
using DSCM.ds_tbl_letter_conten;
using DSCM.ds_tbl_message;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_user_biaoqian;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DSCM.Reception
{
    public class quanzi : DSCMSave
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        string user_id = "";
        public quanzi()
        {
            user_id = Save("user_id") != null ? Save("user_id").ToString() : "";
        }

        public ArrayList index_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_article[] articles = SQL.ReadAll<tbl_article>("tbl_article", " order by article_times desc", 10);
            foreach (tbl_article article in articles)
            {
                article.plnum = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "' and type = 0");
                article.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + article.User_Id + "'");
                article.bqs = article.Article_Biaoqian.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                article.hot = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "' and type = 1 and IsDelete = 0");
                article.isLike = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "' and type = 1 and IsDelete = 0 and user_id='" + user_id + "'") > 0;
            }

            al.Add(articles);
            return al;
        }

        public ArrayList arcticle_DSCM()
        {
            string order = "article_times";
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_article[] articles = SQL.ReadAll<tbl_article>("tbl_article", "", p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            foreach (tbl_article article in articles)
            {
                article.plnum = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "'");
                article.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + article.User_Id + "'");
                article.bqs = article.Article_Biaoqian.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }

            al.Add(articles);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);

            return al;
        }

        public ArrayList biaoqian_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_article[] articles = SQL.ReadAll<tbl_article>("tbl_article", " order by article_times desc", 2);
            foreach (tbl_article article in articles)
            {
                article.plnum = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "'");
                article.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + article.User_Id + "'");
                article.bqs = article.Article_Biaoqian.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }

            al.Add(articles);
            return al;
        }

        public ArrayList daren_DSCM()
        {
            ArrayList al = new ArrayList();
            string tagName = QueryString("name"),
                _pageindex = QueryString("i"),
                _pagesize = QueryString("s");

            int pageIndex = 1, pageSize = 10;

            if ((_pageindex + "").Length > 0)
            {
                int.TryParse(_pageindex, out pageIndex);
            }

            if ((_pagesize + "").Length > 0)
            {
                int.TryParse(_pagesize, out pageSize);
            }

            GetCircleMaster(al, tagName, pageIndex, pageSize);
            tag_DSCM(al);
            return al;
        }

        private tbl_user[] GetCircleMaster(ArrayList al, string tagName, int pageIndex = 0, int pageSize = 10)
        {
            tbl_user[] user = null;
            string strSql = "";
            if ((tagName + "").Length == 0)
            {
                tagName = "hot";
            }

            pageSize = pageIndex * pageSize;
            pageIndex = (pageIndex - 1) * pageSize;

            switch (tagName)
            {
                case "hot":
                    strSql = string.Format(@"SELECT  u2.n,u.*
                            FROM tbl_user u ,
                                (SELECT TOP {0}
                                        ROW_NUMBER() OVER(ORDER BY(SELECT ISNULL((SELECT
                                                     SUM(a.article_hot)
                                                     FROM tbl_article a
                                                     WHERE
                                                     a.user_id = u.user_id 
                                                     ), 0)
                                        ) DESC ) n ,
                                u.user_id
                                FROM tbl_user u 
                                WHERE u.user_id <> '{2}'
                            ) u2
                            WHERE   u.user_id = u2.user_id
                            AND u2.n > {1}
                            ORDER BY u2.n;", pageSize, pageIndex, user_id);
                    break;
                case "like":
                    break;
                case "friend":
                    strSql = string.Format(@"SELECT  tu.* , tu2.n
                                                FROM    [tbl_user] [tu] ,
                                                        ( SELECT TOP {0}
                                                                    ROW_NUMBER() OVER ( ORDER BY ( SELECT   tu.[user_id]
                                                                                                   FROM     [tbl_friend] [tf]
                                                                                                            INNER JOIN [tbl_user] [tu] ON [tu].[user_id] = [tf].[friend_user_id]
                                                                                                   WHERE    tf.[user_id] = '{1}'
                                                                                                 ) DESC ) n ,
                                                                    tu2.[user_id]
                                                          FROM      [tbl_user] [tu2]
                                                        ) [tu2]
                                                WHERE   tu.[user_id] = tu2.[user_id]
                                                        AND tu2.n > {2};", pageSize, user_id, pageIndex);
                    break;
                default:
                    strSql = string.Format(@"SELECT * FROM [tbl_user] [tu],
                                                (SELECT TOP {0} t.[user_id] FROM
                                                    (SELECT TOP {2}  [tu].*
                                                        FROM    [tbl_user_biaoqian] [tub]
                                                        INNER JOIN [tbl_user] [tu] ON [tu].[user_id] = [tub].[user_id]
                                                        WHERE   [tub].[biaoqian_name] = '{1}'
                                                    AND tub.user_id <> '{3}') t) t WHERE
                                            tu.[user_id] = t.[user_id]", pageSize, tagName, pageIndex, user_id);
                    break;
            }

            user = SQL.ReadAll<tbl_user>(strSql);
            
            if (null != user)
            {
                foreach (var u in user)
                {
                    u.Guanzhu = user_id.Equals(u.User_Id) ? -1 : SQL.Read("tbl_friend", "friend_user_id = '" + u.User_Id + "' and if_friend = 1 and user_id = '" + user_id + "'");
                    u.tbl_article = SQL.ReadAll<tbl_article>("select TOP 4 article_id,article_title,article_contents,article_pic from tbl_article where user_id='" + u.User_Id + "' order by article_times desc");
                    u.tbl_user_biaoqian = SQL.ReadAll<tbl_user_biaoqian>("select TOP 4 biaoqian_name from tbl_user_biaoqian where user_id = '" + u.User_Id + "' group by biaoqian_name order by NEWID ()");
                }
            }

            al.Add(user);
            return user;
        }

        private void tag_DSCM(ArrayList al)
        {
            string strSql = "SELECT TOP 10 biaoqian_name,COUNT(1) hot FROM tbl_user_biaoqian GROUP BY biaoqian_name ORDER BY hot DESC";
            tbl_user_biaoqian[] tag = SQL.ReadAll<tbl_user_biaoqian>(strSql);
            al.Add(tag);
        }

        public ArrayList follow_DSCM()
        {
            ArrayList al = new ArrayList();
            string strSql = @" SELECT tu.*, tf.[friend_id],(SELECT TOP 1 [ta].[article_times] FROM [tbl_article] [ta] WHERE ta.[user_id] =  tu.[user_id] 
                                    ORDER BY [ta].[article_times]) update_time FROM [tbl_friend] [tf]
                                    INNER JOIN [tbl_user] [tu] ON tf.[friend_user_id] = tu.[user_id]
                                    WHERE [tf].[user_id] = '" + user_id + "' and [tf].[if_friend] = 1 ORDER BY tf.[friend_id] DESC";

            al.Add(SQL.ReadAll<tbl_user>(strSql));

            strSql = @"SELECT TOP 4 * FROM [tbl_user] [tu]
                                WHERE
                                [tu].[user_id] NOT IN (SELECT[tf].[friend_user_id] FROM[tbl_friend][tf] WHERE[tf].[user_id] = '" + user_id + @"' and [tf].[if_friend] = 1 ')
                                AND
                                tu.[user_id] <> '" + user_id + "' ORDER BY NEWID()";

            al.Add(SQL.ReadAll<tbl_user>(strSql));

            return al;
        }

        public void GetList_DSCM()
        {
            string name = QueryString("name"),
                pageIndex = QueryString("pi"),
                pageSize = QueryString("ps");

            int _pageIndex = 0,
                _pageSize = 0;

            int.TryParse(pageIndex, out _pageIndex);
            int.TryParse(pageSize, out _pageSize);

            ArrayList al = new ArrayList();
            GetCircleMaster(al, name, _pageIndex, _pageSize);

            if (al.Count > 0)
            {
                PageWrite(Newtonsoft.Json.JsonConvert.SerializeObject(al[0]), "STR");
            }
            else {
                if ((user_id + "").Length == 0) {

                }
            }
        }

        public tbl_user[] userList = new tbl_user[] { };
        public void PageList_DSCM()
        {
            string type = QueryString("type");



            string biaoqian = string.Empty;
            ArrayList al = new ArrayList();

            switch (type)
            {
                case "renqi":
                    renqi_DSCM(al);
                    break;
                case "biaoqian":
                    biaoqianDaren_DSCM(al);
                    break;
                case "guanzhu":
                    guanzhu_DSCM(al);
                    break;
            }



            if (al != null)
            {
                userList = al[0] as tbl_user[];

                int length = userList.Length;

                for (int i = 0; i < length; i++)
                {
                    biaoqian += " <li class='mastt-paging' style='background-image:url(" + userList[i].User_Img + ")'>";
                    biaoqian += " <div class='mastt-eject'>";
                    biaoqian += "  <div class='mastt-eject-top'>";
                    foreach (var item in userList[i].tbl_article)
                    {
                        biaoqian += "  <a href='#' class='eject-top-link'> <img src='" + item.Article_Pic + "' alt='' width='130' height='95' /></a>";
                    }
                    biaoqian += " </div>";
                    biaoqian += "<div class='mastt-eject-bottom' style='background-image:url(" + userList[i].User_Img + ")'>";
                    biaoqian += "<div class='mastt-eject-pagup'>" + userList[i].User_Relname + "</div>";
                    biaoqian += " <div class='mastt-eject-pagdn'>文章" + userList[i].artnum
                        + "&nbsp;&nbsp;&nbsp;&nbsp;喜欢" + userList[i].xihuanNum + "&nbsp;&nbsp;&nbsp;&nbsp;关注" + userList[i].guanzhu + "</div>";
                    biaoqian += "<div class='masst-attention'>";
                    if (userList[i].guanzhu)
                    {
                        biaoqian += "<a href='#' class='mastt-down'></a><span>已关注</span>";
                    }
                    else
                    {
                        biaoqian += "<a href='/Reception/index.aspx?ds=quanzi&cm=guanzhuinsert&id=" + userList[i].User_Id + "' class='mastt-down'></a><span>关注</span>";
                    }
                    biaoqian += "</div>";
                    biaoqian += "<div class='mastt-delta'></div>";
                    biaoqian += "</div>";
                    biaoqian += " </div>";
                    biaoqian += " <div class='mastt-txt'>";
                    biaoqian += " <div class='mastt-pagup'>" + userList[i].User_Relname + "</div>";
                    biaoqian += " <div class='mastt-pagdn'>";
                    foreach (DSCM.ds_tbl_user_biaoqian.tbl_user_biaoqian item in userList[i].tbl_user_biaoqian)
                    {
                        biaoqian += "<a href='#' class='grey'>" + item.biaoqian_Name + "</a>";
                    }
                    biaoqian += "   </div>";
                    biaoqian += "  </div>";
                    biaoqian += " </li>";
                }
            }

            PageWrite(biaoqian, "STR");
        }

        public ArrayList biaoqianDaren_DSCM(ArrayList al)
        {
            string page = QueryString("page").ToString();

            if (string.IsNullOrEmpty(page))
            {
                page = "0";
            }

            string user_rlName = Form("searchName");

            string sql = @"select top 5 *,(select COUNT(distinct bq.biaoqian_name) bianqianNum from tbl_user_biaoqian bq 
            where bq.user_id=u.user_id) as bianqianNum from tbl_user u where (user_id not in(select top " + Convert.ToInt32(page) * 5 + " user_id from tbl_user order by user_id))";

            if (!string.IsNullOrEmpty(user_rlName))
            {
                sql += " and u.user_relname like '%" + user_rlName + "%'";
            }

            sql += " order by bianqianNum desc";
            tbl_user[] users = SQL.ReadAll<tbl_user>(sql);

            foreach (tbl_user item in users)
            {
                item.artnum = SQL.Read("tbl_article", " and user_id='" + item.User_Id + "'");
                item.tbl_user_biaoqian = SQL.ReadAll<tbl_user_biaoqian>("tbl_user_biaoqian", " and user_id='" + item.User_Id + "'");
                //item.xihuanNum = SQL.Read("tbl_article", " and user_id='" + item.User_Id + "'");
                item.guanzhuNum = SQL.Read("tbl_friend", " and user_id='" + item.User_Id + "'");
                item.tbl_article = SQL.ReadAll<tbl_article>("select top(3)* from tbl_article where user_id='" + item.User_Id + "' and article_type=2 order by article_times desc");
                item.guanzhu = SQL.Read("tbl_friend", " and friend_user_id='" + item.User_Id + "' and user_id='" + user_id + "'") > 0 ? true : false;
            }

            al.Add(users);
            return al;
        }
        public ArrayList renqi_DSCM(ArrayList al)
        {
            string page = QueryString("page").ToString();

            if (string.IsNullOrEmpty(page))
            {
                page = "0";
            }
            string user_rlName = Form("searchName");

            string sql = @"select TOP 5 *,(select COUNT(distinct fr.friend_id) from tbl_friend fr where fr.friend_user_id=u.user_id) as guanzhuNum 
                        from tbl_user u where (user_id not in(select top " + Convert.ToInt32(page) * 5 + " user_id from tbl_user order by user_id))";

            if (!string.IsNullOrEmpty(user_rlName))
            {
                sql += " and u.user_relname like '%" + user_rlName + "%'";
            }

            sql += " order by guanzhuNum desc";

            tbl_user[] users = SQL.ReadAll<tbl_user>(sql);

            foreach (tbl_user item in users)
            {
                item.artnum = SQL.Read("tbl_article", " and user_id='" + item.User_Id + "'");
                item.tbl_user_biaoqian = SQL.ReadAll<tbl_user_biaoqian>("tbl_user_biaoqian", " and user_id='" + item.User_Id + "'");
                //item.xihuanNum = SQL.Read("tbl_article", " and user_id='" + item.User_Id + "'");
                item.guanzhuNum = SQL.Read("tbl_friend", " and friend_user_id='" + item.User_Id + "'");
                item.tbl_article = SQL.ReadAll<tbl_article>("select top(3)* from tbl_article where user_id='" + item.User_Id + "' and article_type=2 order by article_times desc");
                item.guanzhu = SQL.Read("tbl_friend", " and friend_user_id='" + item.User_Id + "' and user_id='" + user_id + "'") > 0 ? true : false;
            }

            al.Add(users);
            return al;
        }

        public ArrayList guanzhu_DSCM(ArrayList al)
        {
            string page = QueryString("page").ToString();

            if (string.IsNullOrEmpty(page))
            {
                page = "0";
            }

            string user_rlName = Form("searchName");

            string sql = @"select TOP 5 u.* from tbl_user u inner join tbl_friend fr on u.user_id=fr.friend_user_id where (u.user_id not in(select top " + Convert.ToInt32(page) * 5 + " user_id from tbl_user order by user_id)) and fr.user_id='" + user_id + "'";

            if (!string.IsNullOrEmpty(user_rlName))
            {
                sql += " and u.user_relname like '%" + user_rlName + "%'";
            }

            tbl_user[] users = SQL.ReadAll<tbl_user>(sql);

            foreach (tbl_user item in users)
            {
                item.artnum = SQL.Read("tbl_article", " and user_id='" + item.User_Id + "'");
                item.tbl_user_biaoqian = SQL.ReadAll<tbl_user_biaoqian>("tbl_user_biaoqian", " and user_id='" + item.User_Id + "'");
                //item.xihuanNum = SQL.Read("tbl_article", " and user_id='" + item.User_Id + "'");
                item.guanzhuNum = SQL.Read("tbl_friend", " and user_id='" + item.User_Id + "'");
                item.tbl_article = SQL.ReadAll<tbl_article>("select top(3)* from tbl_article where user_id='" + item.User_Id + "' and article_type=2 order by article_times desc");
                item.guanzhu = SQL.Read("tbl_friend", " and friend_user_id='" + item.User_Id + "' and user_id='" + user_id + "'") > 0 ? true : false;
            }

            al.Add(users);
            return al;
        }

        public ArrayList discuss_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_article article = new tbl_article();
            string id = QueryString("id").ToString();
            article = SQL.Read<tbl_article>("tbl_article", " and article_id='" + id + "'");
            article.plnum = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "'");
            article.pl = SQL.ReadAll<tbl_article_pl>("tbl_article_pl", " and article_id='" + article.Article_Id + "'");
            foreach (var item in article.pl)
            {
                item.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + item.User_Id + "'");
            }
            article.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + article.User_Id + "'");
            article.bqs = article.Article_Biaoqian.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            al.Add(article);
            return al;
        }

        public void dscominsert_DSCM()
        {
            try
            {
                string article_id = Form("article_id");
                string content = Form("article_pl_content");

                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    int i = SQL.Read("tbl_article", " and article_id='" + article_id + "' and user_id='" + user_id + "'");
                    if (i == 1)
                    {
                        showPage("您不能评论自己的文章。", LastPage());
                    }
                    else
                    {
                        string[] colm = new string[] { "article_pl_id", "article_pl_content", "article_pl_time", "article_id", "user_id" };
                        string[] value = new string[] { Guid, content, DateTime.Now.ToString(), article_id, user_id };
                        i = SQL.Insert("tbl_article_pl", colm, value);
                        if (i == 1)
                        {
                            Jump(LastPage());
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void dsarcinsert_DSCM()
        {
            try
            {
                string arc_title = Form("arc_title"),
                        arc_content = Form("arc_content"),
                        arc_pic = Form("arc_pic"),
                        arc_biaoqian = Form("arc_biaoqian"),
                        arc_type = Form("acr_type"),
                        photos = Form("photos"),
                        arc_id = Guid;

                if ((user_id + "").Length == 0)
                {
                    result.Add("success", false);
                    result.Add("msg", "登录超时或未登录，请重新登录");
                    //showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    string[] colm = new string[] { "article_id", "article_pic", "article_title", "article_contents", "article_times", "user_id", "article_biaoqian", "article_type", "article_pics" };
                    string[] value = new string[] { arc_id, arc_pic, arc_title, arc_content, DateTime.Now.ToString(), user_id, arc_biaoqian, arc_type, photos };
                    int i = SQL.Insert("tbl_article", colm, value);

                    if ("2".Equals(arc_type) && (photos + "").Length > 0)
                    {
                        foreach (var s in photos.Split(','))
                        {
                            string[] colmPhotos = new string[] { "photo_id", "photo_path", "photo_time", "user_id", "article_id" };
                            string[] valuePhotos = new string[] { Guid, s, DateTime.Now.ToString(), user_id, arc_id };
                            SQL.Insert("tbl_quanzi_photo", colmPhotos, valuePhotos);
                        }
                    }

                    if ((arc_biaoqian + "").Length > 0)
                    {
                        foreach (var s in arc_biaoqian.Split(','))
                        {
                            if (SQL.Read("select * from tbl_user_biaoqian", string.Format("user_id = '{0}' and biaoqian_name = '{1}'", user_id, s)) <= 0)
                            {
                                string[] colmBianqian = new string[] { "user_id", "biaoqian_name" };
                                string[] valueBianqian = new string[] { user_id, s };
                                SQL.Insert("tbl_user_biaoqian", colmBianqian, valueBianqian);
                            }
                        }
                    }

                    if (i == 1)
                    {
                        result.Add("success", true);
                        result.Add("msg", Guid);
                    }
                    else
                    {
                        result.Add("success", false);
                        result.Add("msg", "提交失败");
                    }


                }
            }
            catch (Exception e)
            {
                result.Add("success", false);
                result.Add("msg", e.Message);
                throw;
            }

            Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }

        public void dsphotoinsert_DSCM()
        {
            try
            {
                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    string arc_title = Form("arc_title"), arc_content = Form("arc_content"), arc_pic = Form("arc_pic"), arc_biaoqian = Form("arc_biaoqian");
                    if (user_id.Equals(""))
                    {
                        showPage("登录超时或未登录，请重新登录", LastPage());
                    }
                    else
                    {
                        string[] colm = new string[] { "article_id", "article_pic", "article_title", "article_contents", "article_times", "user_id", "article_biaoqian", "article_type", "article_pics" };
                        string[] value = new string[] { Guid, arc_pic, arc_title, arc_content, DateTime.Now.ToString(), user_id, arc_biaoqian, "2" };
                        int i = SQL.Insert("tbl_article", colm, value);

                        if (!string.IsNullOrEmpty(arc_biaoqian))
                        {
                            int length = arc_biaoqian.Split(',').Length;
                            for (int j = 0; j < length; j++)
                            {
                                string[] colmBianqian = new string[] { "user_id", "biaoqian_name" };
                                string[] valueBianqian = new string[] { user_id, arc_biaoqian.Split(',')[j] };
                                SQL.Insert("tbl_user_biaoqian", colmBianqian, valueBianqian);
                            }
                        }

                        if (i == 1)
                        {
                            Jump("/Reception/index.aspx?ds=quanzi");
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public ArrayList message_DSCM()
        {
            string order = "message_time";
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_message[] messages = SQL.ReadAll<tbl_message>("tbl_message", "", p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(messages);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList person_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_article[] articles = SQL.ReadAll<tbl_article>("tbl_article", " order by article_times ", 1);
            foreach (tbl_article article in articles)
            {
                article.plnum = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "'");
                article.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + article.User_Id + "'");
                article.bqs = article.Article_Biaoqian.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }

            al.Add(articles);
            return al;
        }

        public ArrayList share_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_article article = new tbl_article();
            string id = QueryString("id").ToString();
            article = SQL.Read<tbl_article>("tbl_article", " and article_id='" + id + "'");
            article.plnum = SQL.Read("tbl_article_pl", " and article_id='" + article.Article_Id + "'");
            article.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + article.User_Id + "'");
            article.bqs = article.Article_Biaoqian.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            al.Add(article);
            return al;
        }

        public ArrayList letter_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_letter[] letter = SQL.ReadAll<tbl_letter>("tbl_letter", " and letter_user_id='" + user_id + "'");
            foreach (var item in letter)
            {
                item.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + item.User_Id + "'");
                item.letter_conten = SQL.Read<tbl_letter_conten>("tbl_letter_conten", " and letter_id='" + item.Letter_Id + "'");
            }

            al.Add(letter);

            return al;
        }

        public void guanzhuinsert_DSCM()
        {
            try
            {
                string id = QueryString("id");
                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    string[] colm = new string[] { "friend_id", "user_id", "friend_user_id", "if_friend", "friend_time" };
                    string[] value = new string[] { Guid, user_id, id, "0", DateTime.Now.ToString() };
                    int i = SQL.Insert("tbl_friend", colm, value);

                    if (i == 1)
                    {
                        Jump("/Reception/index.aspx?ds=quanzi&cm=daren");
                    }
                    else
                    {
                        showPage("提交失败", LastPage());
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

    }
}
