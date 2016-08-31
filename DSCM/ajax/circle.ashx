<%@ WebHandler Language="C#" Class="circle" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using dscm.Tools.Sql;

public class circle : IHttpHandler, IReadOnlySessionState
{
    Dictionary<string, object> result = new Dictionary<string, object>();
    public void ProcessRequest(HttpContext context)
    {
        string act = context.Request["act"];
        switch (act)
        {
            case "like":
                Like(context);
                break;
            case "getInfo":
                GetInfo(context);
                break;
            case "follow":
                Follow(context);
                break;
            case "del":
                Deleted(context);
                break;
            case "review":
                Review(context);
                break;
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }

    private void Review(HttpContext context)
    {
        string userid = getUserId(context), aid = context.Request["aid"], content = context.Request["con"];

        if (userid.Length == 0 || (aid + "").Length == 0)
        {
            result.Add("success", false);
            result.Add("msg", "非法操作");
        }
        else
        {
            int resultCode = 0;
            string guid = "";
            resultCode = Circle_DAL.LikeAdd(aid, userid, 0, content, out guid);

            if (resultCode > 0)
            {
                var model = SQL.Read<DSCM.ds_tbl_user.tbl_user>("tbl_user", "user_id = '" + userid + "'");
                result.Add("success", true);
                result.Add("msg", "操作成功");
                result.Add("guid", guid);
                result.Add("user", model);
            }
            else
            {
                result.Add("success", false);
                result.Add("msg", "操作失败");
            }
        }
        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        context.Response.End();
    }

    private void Deleted(HttpContext context)
    {
        string userid = getUserId(context), aid = context.Request["aid"];
        if (userid.Length == 0 || (aid + "").Length == 0)
        {
            result.Add("success", false);
            result.Add("msg", "非法操作");
        }
        else
        {
            var model = SQL.Read<DSCM.ds_tbl_article.tbl_article>("tbl_article", "article_id = '" + aid + "'");
            if (null != model)
            {
                if (userid.Equals(model.User_Id))
                {
                    if (SQL.Delete("tbl_article", "article_id = '" + aid + "'") > 0)
                    {
                        result.Add("success", true);
                        result.Add("msg", "删除成功");
                    }
                    else
                    {
                        result.Add("success", false);
                        result.Add("msg", "删除失败");
                    }
                }
                else
                {
                    result.Add("success", false);
                    result.Add("msg", "非法操作");
                }
            }
        }
        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        context.Response.End();
    }

    private void Follow(HttpContext context)
    {
        string userid = getUserId(context), uid = context.Request["uid"];
        int resultCode = 0;
        if ((uid + "").Length == 0)
        {
            result.Add("success", false);
            result.Add("msg", "非法操作");
        }
        else
        {
            if (uid.Equals(userid))
            {
                result.Add("success", false);
                result.Add("msg", "自己不能关注自己");
            }
            else
            {
                var friend = SQL.Read("tbl_friend", "friend_user_id = '" + uid + "' and user_id = '" + userid + "'");

                resultCode = 0 == friend ? Circle_DAL.FollowAdd(uid, userid) : Circle_DAL.FollowUpdate(uid, userid);

                if (resultCode > 0)
                {
                    result.Add("success", true);
                    result.Add("msg", "操作成功");
                }
                else
                {
                    result.Add("success", false);
                    result.Add("msg", "操作失败");
                }
            }
        }

        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        context.Response.End();
    }

    private void GetInfo(HttpContext context)
    {
        string userid = getUserId(context), uid = context.Request["uid"];

        if ((uid + "").Length == 0)
        {
            result.Add("success", false);
            result.Add("msg", "非法操作");
        }
        else
        {
            var user = SQL.Read<DSCM.ds_tbl_user.tbl_user>("tbl_user", new string[] { "User_Id", "User_Name", "User_Img" }, "and user_id='" + uid + "'");
            if (null != user)
            {
                result.Add("success", true);
                //关注与否
                user.Guanzhu = userid.Equals(uid) ? -1 : SQL.Read("tbl_friend", "friend_user_id = '" + uid + "' and if_friend = 1 and user_id = '" + userid + "'");
                //用户信息
                result.Add("user", user);
                //获取用户的文章
                var list = SQL.ReadAll<DSCM.ds_tbl_article.tbl_article>("select article_id,article_title,article_contents,article_pic from tbl_article where user_id='" + uid + "' order by article_times desc");
                result.Add("count", list.Length);
                if (list.Length > 0)
                {
                    var article = new List<DSCM.ds_tbl_article.tbl_article>();
                    int i = 0;
                    while (i < 3)
                    {
                        article.Add(list[i]);
                        i++;
                    }

                    result.Add("article", article);
                }

                //获取前三个标签相同的用户 
                var alike = SQL.ReadAll<DSCM.ds_tbl_user.tbl_user>(@"SELECT u.User_Name FROM tbl_user u INNER JOIN 
                                                                    (SELECT TOP 3 b.* FROM 
                                                                    (SELECT  user_id,biaoqian_name,COUNT(biaoqian_name) hotTag FROM tbl_user_biaoqian WHERE user_id <> '" + uid + @"' GROUP BY biaoqian_name,user_id) b
                                                                    INNER JOIN 
                                                                    (SELECT TOP 3 user_id,biaoqian_name,COUNT(biaoqian_name) hotTag FROM tbl_user_biaoqian WHERE user_id = '" + uid + @"' GROUP BY biaoqian_name,user_id
                                                                    ORDER BY hotTag DESC) b1 ON b.biaoqian_name = b1.biaoqian_name
                                                                    ORDER BY b.hotTag DESC) b ON u.user_id = b.user_id");
                if (alike.Length > 0)
                {
                    result.Add("alike", alike);
                }
            }
            else
            {
                result.Add("success", false);
                result.Add("msg", "用户不存在");
            }
        }

        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        context.Response.End();
    }

    private void Like(HttpContext context)
    {
        string userid = getUserId(context), articleId = context.Request["aid"], on = context.Request["o"];

        if (userid.Length == 0 || (articleId + "").Length == 0)
        {
            result.Add("success", false);
            result.Add("msg", "非法操作");
        }
        else
        {
            int resultCode = 0;
            if (SQL.Read("tbl_article", " and article_id='" + articleId + "' and user_id='" + userid + "'") == 0)
            {
                var model = SQL.Read<DSCM.ds_tbl_article_pl.tbl_article_pl>("tbl_article_pl", " and article_id='" + articleId + "' and type = 1 and user_id='" + userid + "'");
                if (0 == model.Article_Pl_Id.Length)
                {
                    string guid = "";
                    resultCode = Circle_DAL.LikeAdd(articleId, userid, 1, "", out guid);
                }
                else
                {
                    int opt = 1;
                    if ((on + "").Length > 0 && "1".Equals(on))
                    {
                        opt = -1;
                    }

                    resultCode = Circle_DAL.LikeUpdate(model.Article_Pl_Id, userid, opt, model.Article_Id);
                }

                if (resultCode > 0)
                {
                    result.Add("success", true);
                    result.Add("msg", "操作成功");
                }
                else
                {
                    result.Add("success", false);
                    result.Add("msg", "操作失败");
                }
            }
            else
            {
                result.Add("success", false);
                result.Add("msg", "自己不能给自己点赞");
            }
        }
        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        context.Response.End();
    }

    private string getUserId(HttpContext context)
    {
        string user_id = "";
        if ((context.Session["user_id"] + "").Length > 0)
        {
            user_id = context.Session["user_id"].ToString();
        }

        return user_id;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}