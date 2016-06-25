<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 13:10:58 
* File name：user_friends 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_friends.aspx.cs" Inherits="Reception_templates_default_user_friends" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">

<div class="pmanage_main fR">
      <div class="pmanage_head">
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li><a href="/Reception/index.aspx?ds=user&cm=log">日志管理</a></li>
          <li><a href="/Reception/index.aspx?ds=photo">相册管理</a></li>
          <li class="active"><a href="javascript:void(0)">关注好友列表</a></li>
        </ul>
      </div>
      <div class="friend">
        <ul class="commList">
<%foreach (DSCM.ds_tbl_friend.tbl_friend friend in friends)
     {
        DateTime dt = new DateTime();
        DateTime.TryParse(friend.Friend_Time, out dt);
        %>
        <li>
          <div class="commInfo"> <a href="#" class="fL"><img src="<%=friend.user.User_Img %>" alt="" style="width:50px;height:50px"></a>
            <div class="fL comTit">
              <p><a href="#"><%=friend.user.proname%><%=friend.user.cityname%></a><%=(DateTime.Now - dt).Days%>天前</p>
              <p><%=friend.user.User_Name%>&nbsp;&nbsp;|&nbsp;&nbsp;好友<span><%=friend.user._Guanzhu%></span>人&nbsp;&nbsp;|&nbsp;&nbsp;收听<span><%=friend.user.Guanzhu%></span>人</p>
             <%-- <p>我关注的<a href="">某某某</a>、<a href="">午夜幽灵</a>等47人也关注了他，他们共同收听了<a href="">刘雨欣</a>，<a href="">武则天</a>等人</p>--%>
            </div>
            <p class="p_hn">
             <%if (friend.If_Friend == "0"){ %><a href="/Reception/index.aspx?ds=user&cm=friendinsert&userid=<%=friend.Friend_User_Id %>" class="st">立即收听</a><%  }%>
             <%if (friend.If_Friend == "1"){ %><a href="/Reception/index.aspx?ds=user&cm=friendinsert&friendid=<%=friend.Friend_Id%>" class="qx">取消关注</a><%  }%>
             <%if (friend.If_Friend == "2"){ %> <a class="hg">已互相关注</a><a href="/Reception/index.aspx?ds=user&cm=friendinsert&friendid=<%=friend.Friend_Id%>" class="qx">取消关注</a><%  }%>
            </p>
          </div>
        </li>
<%} %>
        </ul>
        <p class="itemPage clearfix"> 
        <%=pagestr %>
        </p>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>


<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
