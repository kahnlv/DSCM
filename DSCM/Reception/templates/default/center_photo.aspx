<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:20:55 
* File name：center_photo 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_photo.aspx.cs" Inherits="Reception_templates_default_center_photo" %>
<%=model.ReadModel("/Reception/templates/default/public/center_heard.aspx")%>


<div class="logWarp clearfix">
  <div class="logBoxL logViewBox">
    <div class="album">
      <ul>

<% 
    foreach (DSCM.ds_tbl_photo.tbl_photo p in photo)
    {  
       
%>
        <li>
          <div class="album_img"><img src="<%= p.Photo_Img %>"> <span> <em class="fL"><%=p.photo_class.Photo_Class_Name %></em> <em class="fR"></em> </span> </div>
          <div class="album_bg">半透明背景</div>
          <div class="album_more"> <em class="tit"><%=p.Photo_Name %></em> <em class="des"><%=p.Photo_Doc %></em> <a href="/Reception/index.aspx?ds=center&cm=photolist&id=<%=p.Photo_Id %>">更多</a> </div>
          <div class="album_num"><%=p.num %></div>
        </li>
<% } %>
      </ul>
    </div>
    <p class="itemPage clearfix">
    <%=pagestr %>
    </p>
  </div>
  <div class="logBoxR">
    <h3 class="logLtit">相册分类</h3>
    <ul class="logboxRlist">
    <% foreach (DSCM.ds_tbl_photo_class.tbl_photo_class pc in pclass)
       { %>
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=photo&type=<%=pc.Photo_Class_Id %>"><i></i><%=pc.Photo_Class_Name %></a></li>
    <% } %>
    </ul>
  </div>
</div>




<%=model.ReadModel("/Reception/templates/default/public/center_foot.aspx")%>
