<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:22:13 
* File name：center_photolist 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_photolist.aspx.cs" Inherits="Reception_templates_default_center_photolist" %>
<%=model.ReadModel("/Reception/templates/default/public/center_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">


<div class="logWarp clearfix">
  <div class="albumList">
    <h1>相册列表</h1>
    <ul>
<% 
    foreach (DSCM.ds_tbl_photo_img.tbl_photo_img img in photo_img)
   {
%> 
      <li> <a href="/Reception/index.aspx?ds=center&cm=photolist2&id=<%=img.Photo_Img_Id %>"><img src="<%=img.Photo_Img_Path %>"></a>
        <div class="tit">
          <div class="fL"><a href="#"><%=img.Photo_Img_Title %></a></div>
          <div class="fR"> <a href="javascript:void(0)" class="btn_zan"><i class="zan"></i><label><%=img.zannum %></label></a> 
          <a href="javascript:void(0)"><i class="feed"></i><%=img.plnum%></a>
           <input type="hidden" name="photo_img_id" value="<%=img.Photo_Img_Id %>" />
          </div>         
        </div>
        <div class="albumList_bg">背景半透明</div>
        <div class="des"><a href="#"><%=img.Photo_Img_Doc %></a></div>       
      </li>      
<%
   } 
%>
    </ul>
    <p class="itemPage clearfix"> 
    <%=pagestr %>
    </p>
 <script type="text/javascript">
     $(".btn_zan").click(function () {
         var imgid = $(this).parent().find("input").val();
         var that = $(this).find("label");
         $.ajax({
             type: "POST",
             url: "/Reception/index.aspx?ds=center&cm=zanimg",
             data: { id: imgid },
             dataType: 'text',   //返回的数据类型
             async: false,
             cache: false,
             success: function (result) {   
                 that.html(result);
             },
             error: function () {
                 alert("点赞失败");
             }
         });
     });
 </script>
  </div>
</div>


<%=model.ReadModel("/Reception/templates/default/public/center_foot.aspx")%>
