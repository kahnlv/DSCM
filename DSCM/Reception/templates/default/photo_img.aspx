<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/25 10:59:32 
* File name：photo_insert 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="photo_img.aspx.cs" Inherits="Reception_templates_default_photo_img" %>
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
          <li class="active"><a href="/Reception/index.aspx?ds=photo">相册管理</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=friends">关注好友列表</a></li>
        </ul>
      </div>
      <div class="main_con">
        <div class="btn1 album-btn" id="album_creat">上传照片</div>
        <div class="album-layout">
          <h2>上传相片<em>×</em></h2>
          <form id="photozcmpostForm" name="photozcmpostForm" action="/Reception/index.aspx?ds=photo&cm=imginsert" method="post" onsubmit=""  enctype="multipart/form-data">
          <li class="cont">
            <label>标题：</label>
            <input name="photo_img_title" type="text" class="txtBox">
          </li>
          <li class="cont">
            <label>描述：</label>
            <textarea name="photo_img_doc"></textarea>
          </li>
          <li class="cont">
            <label>上传照片：</label>
            <div class="upload"><a class="link" href="javascript:void(0);">浏览</a>
              <input name="photo_img_path" type="file" class="uploadFile">
              <span class="warning">(上传.jpg或.gif图片)</span>
            </div>
          </li>
          <li class="cont">
            <label>&nbsp;</label>
            <input name="" type="submit" class="btn1" id="submit" value="确认保存" style="border:none;">
            <input name="photo_id" type="hidden"  value="<%=photo_id %>">
          </li>
          </form>

        </div>
        <div class="photolist">
          <ul>
<% 
    foreach (DSCM.ds_tbl_photo_img.tbl_photo_img img in user_log)
    {
        
%>
            <li> <img src="<%=img.Photo_Img_Path %>" style="width:300px;height:260px">
              <div class="tit"><%=img.Photo_Img_Title %></div>
              <div class="ms">
              <%=img.Photo_Img_Doc %>
              </div>
              <div class="photo-opera"> <span class="photo-op-tip"><i class="icon-m"></i></span>
                <dl class="photo-op-list">
                  <dd> <a class="js-album-makeCover" href="/Reception/index.aspx?ds=photo&cm=photoUpdate&id=<%=img.Photo_Img_Id %>"><i class="icon-cover-m"></i>设为封面</a> </dd>
                  <dd> <a class="js-album-delete" href="/Reception/index.aspx?ds=photo&cm=imgdel&id=<%=img.Photo_Img_Id %>"><i class="icon-rubbish-m"></i>删除</a> </dd>
                </dl>
              </div>
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
