<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_daren.aspx.cs" Inherits="Reception_templates_default_quanzi_daren" %>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>
<div class="secondNav">
    <ul class="viewNav clearfix">
        <li><a href="/Reception/index.aspx?ds=quanzi&cm=daren" class="on">达人</a></li>
    </ul>
</div>
<div class="wrapper">
    <div class="nav2">
        <ul class="clearfix">
            <li class="current"><a href="javascript:;" title="">领域达人</a></li>
            <li><a href="/Reception/index.aspx?ds=quanzi&cm=follow" title="">我关注的人（<%=Count %>）</a></li>
        </ul>
    </div>
    <div class="blogBox clearfix">
        <div class="blogLeft">
            <ul class="blogUL">
                <%if (null != user)
                    {
                        if (user.Count() > 0)
                        {
                            foreach (var u in user)
                            {%>
                <li class="blogitm">
                    <div class="m-info clearfix">
                        <a href="javascript:;" class="m-head">
                            <img src="<%=u.User_Img %>" alt="">
                        </a>
                        <%if (u.Guanzhu == 0)
                            { %>
                        <a class="focusBtn" href="javascript:;" data-user="<%=u.User_Id %>"><b>+</b><span>关注</span></a>
                        <%}
                            else
                            {%>
                        <a class="focusBtn nofocusBtn" href="javascript:;" data-user="<%=u.User_Id %>">取消关注</a>
                        <%} %>
                        <h3>
                            <a class="ttl" href="javascript:;" target="_blank"><%=u.User_Name %></a>
                        </h3>
                        <div class="tags">
                            <% if (null != u.tbl_user_biaoqian)
                                {
                                    foreach (var t in u.tbl_user_biaoqian)
                                    {%>
                            <%=t.biaoqian_Name %>
                            <%}
                                } %>
                        </div>
                    </div>
                    <div class="postlist">
                        <ul>
                            <%if (null != u.tbl_article)
                                {
                                    foreach (var a in u.tbl_article)
                                    {%>
                            <li class="m-post m-post-img">
                                <a class="fullnk" href="javascript:;" target="_blank">
                                    <%if (a.Article_Pic.Length == 0)
                                        { %>
                                    <span class="pic"><%=a.Article_Title %><%=HttpUtility.UrlDecode(a.Article_Contents) %></span><span class="layer"></span>
                                    <%}
                                        else
                                        { %>
                                    <span class="pic" style="background: url(<%=a.Article_Pic %>) center center no-repeat;"></span><span class="layer"></span>
                                    <%} %>
                                </a>
                            </li>
                            <%}
                                } %>
                        </ul>
                    </div>
                </li>
                <%}
                    }
                    else
                    { %>
                <li class="blogitm">暂无领域达人</li>
                <%}
                    }
                    else
                    { %>
                <li class="blogitm">暂无领域达人</li>
                <%}
                %>
            </ul>
        </div>
        <div class="blogRight">
            <ul>
                <li class="hot-tag"><a href="javasrcipt:;" data-name="hot">热门</a></li>
                <%--<li><a href="javasrcipt:;" data-name="like">猜你喜欢</a></li>--%>
                <%if (null != tag)
                    {
                        foreach (var t in tag)
                        { %>
                <li><a href="javascript:;" data-name="<%=t.biaoqian_Name %>"><%=t.biaoqian_Name %></a></li>
                <%}
                    } %>
            </ul>
        </div>
    </div>
</div>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_foot.aspx")%>

</body>
</html>