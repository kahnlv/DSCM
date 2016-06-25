<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 16:16:09 
* File name：user_pohot 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_photo.aspx.cs" Inherits="Reception_templates_default_user_pohot" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">

 <div class="pmanage_main fR">
      <div class="pmanage_head">
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li class="active"><a href="javascript:void(0)">修改头像</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=info">个人信息</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=spacedesign">空间设置</a></li>
        </ul>
      </div>
      <div class="changephoto">
        <div class="photo_box">
          <div class="box1">
            <div class="ph1" ><img src="<%=user_img %>"></div>
            <span>大头像188*188</span> </div>
          <div class="box2">
            <div class="ph2"><img src="<%=user_img %>"></div>
            <span>小头像48*48</span> </div>
        </div>
        <form id="photo_zcmpostForm" name="photo_zcmpostForm" action="/Reception/index.aspx?ds=user&cm=upimg" method="post" onsubmit="" enctype="multipart/form-data">
        <div class="photo_upload  mT10"><input type="file" id="upload" name="user_photo" /> <a href="javascript:baocun()" class="btn1 fL">保存</a> <em>支持jpg\jpeg\png格式的照片</em></div>
        </form>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>


						

<script>
    function baocun() {
        var obj = document.photo_zcmpostForm;
        obj.submit();
    }
</script>
<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
