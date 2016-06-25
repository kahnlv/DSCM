<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/25 10:13:38 
* File name：photo_index 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="photo_index.aspx.cs" Inherits="Reception_templates_default_photo_index" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">
<script type="text/javascript">
    $(function () {
        $("#album_creat").click(function () {
            $(".album-layout").show();
        });
        $("em").click(function () {
            $(".album-layout").hide();
        });
        $("#submit").click(function () {
            $(".album-layout").hide();
        })
    });
</script>


 <div class="pmanage_main fR">
      <div class="pmanage_head">
        <h1><%=user_space.User_Space_Name %></h1>
        <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li><a href="/Reception/index.aspx?ds=user&cm=log">日志管理</a></li>
          <li class="active"><a href="javascript:void(0)">相册管理</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=friends">关注好友列表</a></li>
        </ul>
      </div>
      <div class="main_con">
        <div class="btn1 album-btn" id="album_creat">创建相册</div>
       
        <div class="album-layout">
        <form id="photozcmpostForm" name="photozcmpostForm" action="/Reception/index.aspx?ds=photo&cm=insert" method="post" onsubmit=""  enctype="multipart/form-data">
          <h2>创建相册<em>×</em></h2>
          <li class="cont">
            <label>相册名称：</label>
            <input name="photo_name" type="text" class="txtBox">
          </li>
          <li class="cont">
            <label>相册描述：</label>
            <textarea name="photo_doc"rows="5" cols="50"></textarea>
          </li>
          <li class="cont">
            <label>相册分类：</label>
            <input name="photo_class_id" type="text" class="txtBox">
          </li>
          <li class="cont">
            <label>相册封面：</label>
            <div class="upload"> 
              <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/album1.gif"> 
              <a class="link" href="javascript:void(0);">浏览</a>
              <input name="photo_img" type="file" class="uploadFile"/>
              <span class="warning">(上传.jpg或.gif图片)</span>
            </div>
          </li>
          <li class="cont">
            <label>&nbsp;</label>
            <input name="" type="submit" class="btn1" id="submit" value="确认保存" style="border:none;">
          </li>
        </form>
        </div>
        



        
        
        <div class="album-list">
          <ul>
<% foreach (DSCM.ds_tbl_photo.tbl_photo photo in user_log)
   {
       
%>
            <li>
              <div class="album-photo"><img src="<%=photo.Photo_Img %>"></div>
              <div class="info">
                <h3><%=photo.Photo_Name %></h3>
                <p><%=photo.Photo_Doc %></p>
              </div>
              <div class="time"><%=photo.Photo_Time %>发布</div>
              <div class="num">（<%=photo.num %>）</div>
              <div class="operat"> <a class="upload" href="/Reception/index.aspx?ds=photo&cm=img&id=<%=photo.Photo_Id %>">进入相册</a> <a href="/Reception/index.aspx?ds=photo&cm=photodel&id=<%=photo.Photo_Id %>">[删除相册]</a></div>
            </li>
<% 
   } 
%>
          </ul>
        </div>





        <!-- 翻页 start -->
        <p class="itemPage clearfix">
        <%=pagestr %>
        </p>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>


<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>