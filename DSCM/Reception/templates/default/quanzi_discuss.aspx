<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_discuss.aspx.cs" Inherits="Reception_templates_default_quanzi_discuss" %>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>

<div class="type_nav">
    <ul class="clearfix">
<%--        <li style="border-left: 0;"><a href="#">浏览</a></li>
        <li class="hover"><a href="/Reception/index.aspx?ds=quanzi&cm=biaoqian">标签</a></li>
        <li><a href="#">品牌</a></li>
        <li><a href="#">话题</a></li>
        <li><a href="#">专题</a></li>--%>
        <li><a href="/Reception/index.aspx?ds=quanzi&cm=daren">达人</a></li>
      <%--  <li style="border-right: 0; width: 125px;"><a href="#">模板</a></li>--%>
    </ul>
</div>
<div id="container" class="clearfix">
    <div class="main fl">
        <ul class="part">
            <li class="clearfix" style="margin-bottom: 0;">
                <div class="part_face fl">
                    <img src="<%=article.user.User_Img.Replace("/big/","/saml/") %>" alt="" width="80" height="80" />
                </div>
                <div class="part_con fr">
                    <div class="part_bg"></div>
                    <div class="part_title"><%=article.Article_Title %><span>-众漫推荐</span></div>
                    <div class="part_p">
                        <img src="<%=article.Article_Pic %>" alt="" class="mr25 mb40 fl" width="160" height="200" />
                        <%=System.Web.HttpUtility.UrlDecode(article.Article_Contents) %>
                    </div>
                    <a class="part_more fl" href="/Reception/index.aspx?ds=quanzi&cm=arcdetail&id=<%=article.Article_Id%>">展开</a>
                    <div class="part_bottom fl">
                        <div class="type fl clearfix">
                            <span></span>
                            <%foreach (string bq in article.bqs)
                              {%>
                            <a href="#" class="grey"><%=bq %></a>
                            <%} %>
                        </div>
                        <ul class="discuss fr clearfix">
                            <li><a href="#">热度(0)</a></li>
                            <%-- <%=article.Article_Hot %>--%>
                            <li><a href="javascript:void(0)">评论(<%=article.plnum %>)</a></li>
                            <li><a href="/Reception/index.aspx?ds=quanzi&cm=share&id=<%=article.Article_Id %>">分享</a></li>
                            <li><a href="#">推荐</a></li>
                            <li style="padding: 0;"><a href="#" style="display: block; width: 30px; height: 30px;"></a></li>
                        </ul>
                    </div>
                </div>
            </li>
            <li>
                <div class="comment fr">
                    <div>
                        <ul>
                            <%foreach (DSCM.ds_tbl_article_pl.tbl_article_pl item in article.pl)
                              {%>
                            <li><%=item.user.User_Relname %>：<%=item.Article_Pl_Content %></li>
                            <% } %>
                        </ul>

                    </div>
                    <div class="comment_bg"></div>
                    <form name="mpostform" action="/Reception/index.aspx?ds=quanzi&cm=dscominsert" method="post">
                        <input type="text" class="comment_text" name="article_pl_content" />
                        <input name="article_id" type="hidden" value="<%=article_id %>" />
                        <input type="submit" value="发布" class="comment_btn ml10" />
                    </form>
                </div>
            </li>
        </ul>
    </div>
</div>
</div>
</body>
</html>
