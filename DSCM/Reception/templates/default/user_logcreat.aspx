<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 11:34:43 
* File name：user_logcreat 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_logcreat.aspx.cs" Inherits="Reception_templates_default_user_logcreat" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">


<div class="pmanage_main fR">
      <div class="pmanage_head">
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li class="active"><a href="/Reception/index.aspx?ds=user&cm=log">日志管理</a></li>
          <li><a href="/Reception/index.aspx?ds=photo">相册管理</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=friends">关注好友列表</a></li>
        </ul>
      </div>
      <form id="zcmpostForm" name="zcmpostForm" action="/Reception/index.aspx?ds=user&cm=loginsert" method="post" onsubmit=""  enctype="multipart/form-data">
      <div class="setup">
      	<p>标题：<input type="text" class="inputtext" name="user_log_title" value="<%=user_log.User_Log_Title%>"></p>
		<p>分类：<select class="select1" name="user_log_class">
        			<option <% if(user_log.User_Log_Class.Equals("个人日志")){%> selected <%} %>>个人日志</option>
                    <option <% if(user_log.User_Log_Class.Equals("视频日志")){%> selected <%} %>>视频日志</option>
                    <option <% if(user_log.User_Log_Class.Equals("我的收藏")){%> selected <%} %>>我的收藏</option>
                    <option <% if(user_log.User_Log_Class.Equals("情感天地")){%> selected <%} %>>情感天地</option>
                    <option <% if(user_log.User_Log_Class.Equals("情感收藏")){%> selected <%} %>>情感收藏</option>
                    <option <% if(user_log.User_Log_Class.Equals("人生道理")){%> selected <%} %>>人生道理</option>
                    <option <% if(user_log.User_Log_Class.Equals("人生感悟")){%> selected <%} %>>人生感悟</option>
                </select> 
        </p>
        <div class="clearfix w">
        	<span class="fL">内容：</span>
            <div class="setuproot fL"><textarea style="width:400px;height:300px" name="user_log_doc"><%=user_log.User_Log_Doc %></textarea></div>
        </div>
        <p><input type="submit" value="发表" class="inputsubmit">
        <input type="hidden" value="<%=user_log_id %>" class="inputsubmit" name="user_log_id"></p>
      </div>
      </form>
    </div>
  </div>
</div>
<div class="pB40"></div>


<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>