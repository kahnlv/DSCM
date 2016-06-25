<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 11:53:37 
* File name：center_index 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_index.aspx.cs" Inherits="Reception_templates_default_center_index" %>
<%=model.ReadModel("/Reception/templates/default/public/center_heard.aspx")%>



<!-- 相册 -->
<div class="spaceCon">
  <div class="W1200">
    <h3 class="photoListText"><a href="/Reception/index.aspx?ds=center&cm=photo" class="fR">更多</a>相册列表</h3>
    <div class="photoListBox clearfix" >
<% 
    if (photo.Length > 0)
    { 
%>
      <div class="photoMed photoL fL" > <img src="<%=photo[0].Photo_Img %>" alt="" style="width:785px;height:416px"/>
        <div class="photoText">
          <h3 class="photoTit"><em><%=photo[0].num%></em><%=photo[0].Photo_Name %></h3>
          <p class="photoSub"><%=photo[0].Photo_Doc %></p>
          <p class="photoLink"><a href="/Reception/index.aspx?ds=center&cm=photolist&id=<%=photo[0].Photo_Id %>">更多</a></p>
        </div>
<% } %>
      <div class="photoR photosmall fR">
<% 
    if (photo.Length > 1)
    { 
%>
        <div class="photoMed PB36" > <img src="<%=photo[1].Photo_Img %>" alt="" style="width:385px;height:190px"/>
          <div class="photoText">
            <h3 class="photoTit"><em><%=photo[1].num%></em><%=photo[1].Photo_Name%></h3>
            <p class="photoSub"><%=photo[1].Photo_Doc%></p>
            <p class="photoLink"><a href="/Reception/index.aspx?ds=center&cm=photolist&id=<%=photo[1].Photo_Id %>">更多</a></p>
          </div>
          <span class="markLay"></span> </div>
<% 
    }
    if (photo.Length > 2)
    { 
%>
        <div class="photoMed"> <img src="<%=photo[2].Photo_Img %>" alt="" style="width:385px;height:190px" />
          <div class="photoText">
            <h3 class="photoTit"><em><%=photo[2].num%></em><%=photo[2].Photo_Name %></h3>
            <p class="photoSub"><%=photo[2].Photo_Doc%></p>
            <p class="photoLink"><a href="/Reception/index.aspx?ds=center&cm=photolist&id=<%=photo[2].Photo_Id %>">更多</a></p>
          </div>
          <span class="markLay"></span> </div>
<% } %>
      </div>
    </div>
    <div class="photoListBox clearfix">
      <div class=" photoR photosmall fL"  >
<% 
    if (photo.Length > 3)
    { 
%>
        <div class="photoMed PB36"  > <img src="<%=photo[3].Photo_Img %>" alt="" style="width:385px;height:190px" />
          <div class="photoText">
            <h3 class="photoTit"><em><%=photo[3].num%></em><%=photo[3].Photo_Name %></h3>
            <p class="photoSub"><%=photo[3].Photo_Doc%></p>
            <p class="photoLink"><a href="/Reception/index.aspx?ds=center&cm=photolist&id=<%=photo[3].Photo_Id %>">更多</a></p>
          </div>
          <span class="markLay"></span> </div>
<% 
    }
    if (photo.Length > 4)
    { 
%>
        <div class="photoMed"> <img src="<%=photo[4].Photo_Img %>" alt="" style="width:385px;height:190px" />
          <div class="photoText">
            <h3 class="photoTit"><em><%=photo[4].num%></em><%=photo[4].Photo_Name %></h3>
            <p class="photoSub"><%=photo[4].Photo_Doc%></p>
            <p class="photoLink"><a href="/Reception/index.aspx?ds=center&cm=photolist&id=<%=photo[4].Photo_Id %>">更多</a></p>
          </div>
          <span class="markLay"></span> </div>
<% } %>
      </div>
<% 
    if (photo.Length > 5)
    { 
%>
      <div class="photoMed photoL fR"> <img src="<%=photo[5].Photo_Img %>" alt="" style="width:785px;height:416px"/>
        <div class="photoText">
          <h3 class="photoTit"><em><%=photo[5].num%></em><%=photo[5].Photo_Name %></h3>
          <p class="photoSub"><%=photo[5].Photo_Doc%></p>
          <p class="photoLink"><a href="/Reception/index.aspx?ds=center&cm=photolist&id=<%=photo[5].Photo_Id %>">更多</a></p>
        </div>
        <span class="markLay"></span> </div>
<% } %>
    </div>
  </div>


  <!-- 日志 -->
  <div class="spaceLog clearfix">
    <div class="W1200">
      <div class="logL">
        <h3 class="logLtit">最新日志</h3>
        <div class="logLimg"> <a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/2014122813001.jpg" alt="" class="logLimg fL" /></a>
          <p><%=log.User_Log_Title %></p>
        </div>
        <div class="logTextInfo">
          <%=log.User_Log_Doc %>
        </div>
        <p class="logLink"><a href="/Reception/index.aspx?ds=center&cm=logview&id=<%=log.User_Log_Id %>">更多</a></p>
      </div>
      <div class="logR">
        <h3 class="logLtit">发起的项目</h3>
        <ul class="logRlist">
        <% 
            foreach (DSCM.ds_tbl_object.tbl_object o in tbl_obj)
            {
            %>
          <li><img src="<%=o.Object_Img %>" class="logRimg fL"  alt="" /><span><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=o.Object_Id %>"><%=o.Object_Title %></a></span></li>
        <% } %>
        </ul>
      </div>
    </div>
  </div>


  <!-- 视频 -->
  <div class="spaceLog clearfix">
    <div class="W1200">
      <div class="logL">
        <h3 class="logLtit">视频位置</h3>
        <ul class="spaceVideoList">
          <li><a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/videoimg001.jpg" alt="" /><em class="videoPlay"></em></a></li>
          <li><a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/videoimg002.jpg" alt="" /><em class="videoPlay"></em></a></li>
        </ul>
        <p class="logLink"><a href="#">更多</a></p>
      </div>
      <!-- 留言 -->
      <div class="MessageR">
        <h3 class="logLtit">留言</h3>
<form id="mesinsertpostForm" name="mesinsertpostForm" action="/Reception/index.aspx?ds=center&cm=dsmesinsert" method="post" onsubmit="">
        <div class="mesformBox">
          <textarea name="content" id="" class="mesArea"></textarea>
          <p class="commBtn"><span class="bntIcon01"></span><a href="javascript:mesinsert()" class="comReplyBtn">发表留言</a></p>
      </div>
</form>
<script type="text/javascript">
    function mesinsert() {
        var obj = document.mesinsertpostForm;
        obj.submit();
    }
</script>
        <p class="mesgSubTit">最近来访</p>
        <ul class="mesgList">
        <% 
            foreach (DSCM.ds_tbl_user_message.tbl_user_message mes in message)
            {   
        %>
          <li><a href="#"><img src="<%= mes.user.User_Img %>" alt="" width="55px" height="55px" /><em><%= mes.user.User_Name %></em></a></li>
        <% } %>
        </ul>
      </div>



    </div>
  </div>
</div>





<%=model.ReadModel("/Reception/templates/default/public/center_foot.aspx")%>
