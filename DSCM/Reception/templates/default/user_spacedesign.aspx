<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：daohang 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_spacedesign.aspx.cs" Inherits="Reception_templates_default_user_spacedesign" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">

<div class="pmanage_main fR">
    <div class="pmanage_head">
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
    </div>
    <div class="pmanage_menu">
      <ul class="HeaeNavList">
        <li><a href="/Reception/index.aspx?ds=user&cm=photo">修改头像</a></li>
        <li><a href="/Reception/index.aspx?ds=user&cm=info">个人信息</a></li>
        <li class="active"><a href="javascript:void(0)">空间设置</a></li>
      </ul>
    </div>
    <form id="spaceForm" name="spaceForm" action="/Reception/index.aspx?ds=user&cm=spaceinsert" method="post" onsubmit=""  enctype="multipart/form-data">
      <div class="setup">
        <p>空间名称：
          <input type="text" class="inputtext" name="user_space_name" value=""/>
        </p>          
        <div class="clearfix w">
        	<span class="fL">个性签名：</span>
            <div class="setuproot fL"><textarea style="width:400px;height:200px" name="user_space_signature"></textarea></div>
        </div>
        <p><input type="submit" class="inputsubmit" value="提交信息"/></p>   
      </div>
    </form>
  </div>
</div>
</div>
<div class="pB40"></div>
<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>