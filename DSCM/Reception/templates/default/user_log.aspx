<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 11:19:24 
* File name：user_log 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_log.aspx.cs" Inherits="Reception_templates_default_user_log" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">

<div class="pmanage_main fR">
      <div class="pmanage_head">
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li class="active"><a href="javascript:void(0)">日志管理</a></li>
          <li><a href="/Reception/index.aspx?ds=photo">相册管理</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=friends">关注好友列表</a></li>
        </ul>
      </div>
      <div class="friend">
        <div class="album-btn"> <a href="/Reception/index.aspx?ds=user&cm=logcreat" class="btn1 fL">创建日志</a></div>
        <ul class="commList">
<% foreach (DSCM.ds_tbl_user_log.tbl_user_log log in user_log)
   {%>
          <li>
            <div class="commInfo">
              <div class="fL comTit">
                <p><a href="#"><%=log.User_Log_Title %></a> </p>
                <p>分类：<%=log.User_Log_Class %> | <%=log.User_Log_Time %></p>
                <p>
                    <%=log.User_Log_Doc %>
                </p>
              </div>
              <p class="p_dh"> <a href="/Reception/index.aspx?ds=user&cm=logcreat&id=<%=log.User_Log_Id %>" class="qx ml5">编辑</a> <a href="/Reception/index.aspx?ds=user&cm=logdel&id=<%=log.User_Log_Id %>" class="qx ml5">删除</a> </p>
            </div>
          </li>
<% } %>
        </ul>
        <p class="itemPage clearfix"> <%=pagestr%></p>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>

<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
