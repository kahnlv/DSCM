<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_follow.aspx.cs" Inherits="Reception_templates_default_quanzi_follow" %>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>
<div class="secondNav">
    <ul class="viewNav clearfix">
        <li><a href="" class="on">达人</a></li>
    </ul>
</div>
<!---->
<div class="wrapper">
    <div class="nav2">
        <ul class="clearfix">
            <li><a href="/Reception/index.aspx?ds=quanzi&cm=daren" title="">领域达人</a></li>
            <li class="current"><a href="javascript:;" title="">我关注的人（2）</a></li>
        </ul>
    </div>
    <div class="focusBox clearfix">
        <div class="m-tabbar">
            <a class="ztag curtab" hidefocus="true" href="#">最近互动</a>
            <span class="sep">|</span>
            <a class="ztag" hidefocus="true" href="#">最新关注</a>
        </div>
        <div class="focusList clearfix">
            <ul class="f-cb ztag">
                <%if (null != friend)
                    {
                        if (friend.Count() > 0)
                        {
                            foreach (var m in friend)
                            {%>
                <li class="friend" data-user="<%=m.User_Id %>">
                    <div class="focusHead">
                        <a href="javascript:;" target="_blank">
                            <img class="xtag" src="<%=m.User_Img %>">
                        </a>
                    </div>
                    <div class="cnt">
                        <h4>
                            <em>
                                <a href="javascript:;" class="xtag" target="_blank"><%=m.User_Name %></a>
                            </em>
                        </h4>
                        <p class="xtag">02/28 17:38更新</p>
                    </div>
                    <a href="javascript:;" class="no_focus" title="取消关注">-</a>
                </li>
                <%}
                    }
                    else
                    {%>
                <li>暂无关注好友
                </li>
                <%}
                    }
                    else
                    {%>
                <li>暂无关注好友
                </li>
                <%} %>
            </ul>
        </div>
        <div class="searchCol">
            <div class="ssch clearfix">
                <input type="text" class="searchInp" placeholder="输入用户名称，查找关注的人">
                <button type="submit"></button>
            </div>
            <div class="recomFollowArea">
                <h3>推荐关注</h3>
                <div class="recomFollowList">
                    <%if (null != Recommend)
                        {
                            if (Recommend.Count() > 0)
                            {
                                foreach (var m in Recommend)
                                {%>
                    <div class="recomItem">
                        <a title="<%=m.User_Name %>" href="javascript:;" target="_blank">
                            <img src="<%=m.User_Img %>">
                        </a>
                        <a href="javascript:;" class="followbtn" data-user="<%=m.User_Id %>" title="添加关注">+</a>
                    </div>
                    <% }
                        }
                        else
                        {%>
                    暂无推荐

                               <% 
                                       }
                                   }
                                   else
                                   {%>
                    暂无推荐
                    <%} %>
                </div>
            </div>
        </div>
    </div>
</div>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_foot.aspx")%>