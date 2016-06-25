<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：center_leaveWord 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_leaveWord.aspx.cs" Inherits="Reception_templates_default_center_leaveWord" %>
<%=model.ReadModel("/Reception/templates/default/public/center_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">

<div class="logWarp clearfix">
  <div class="logBoxL logViewBox">
    <h3 class="logLtit">所有留言</h3>
    <ul class="commList clearfix">
    
<% int mmi = 1; foreach (DSCM.ds_tbl_user_message.tbl_user_message m in message)
   {
       DateTime dtmes = new DateTime();
       DateTime.TryParse(m.User_Message_Time, out dtmes);
       
       %>
        <li>
          <div class="commInfo"> <a href="/Reception/index.aspx?ds=center" class="fL"><img src="<%=m.user.User_Img %>" alt="" width="50px" height="50px"/></a>
            <div class="fL comTit">
              <p><em class="fR"><%=mmi++ %>F</em><a href="#"><%= m.user.User_Name %></a><span class="grayText"><%=(DateTime.Now - dtmes).Days%>天前</span></p>
              <p><%=m.User_Message_Center %></p>
            </div>

<% foreach (DSCM.ds_tbl_user_message.tbl_user_message par_mes in m.user_mes)
   {
         DateTime dtmes2 = new DateTime();
         DateTime.TryParse(par_mes.User_Message_Time, out dtmes2);
 %> 
         <div class="commhuifu"> <a href="/Reception/index.aspx?ds=center" class="fL"><img src="<%=par_mes.user.User_Img %>" alt="" width="50px" height="50px"/></a>
          <div class="fL comTit1">
            <p><a href="#"><%=par_mes.user.User_Name%></a><span class="grayText"><%=(DateTime.Now - dtmes2).Days%>天前</span></p>
            <p><%=par_mes.User_Message_Center %></p>
          </div>
        </div>
<% } %>
          <p class="p_hn"><%--<a href="#" class="comNum">1</a>--%><a href="javascript:void(0)" class="showComment">回复</a></p>
          <div class="criticism hide">
<form id="mescom<%=m.User_Message_Id %>" name="mescom<%=m.User_Message_Id %>" action="/Reception/index.aspx?ds=center&cm=dsmesinsert" method="post" onsubmit="">
            <textarea name="content"></textarea>
            <p ><a href="javascript:submescom('<%=m.User_Message_Id %>')" style="float:right;">回复</a></p>
             <input type="hidden" name="user_message_id" value="<%=m.User_Message_Id %>" />
</form>
          </div>
        </li>
<% } %>  

      </ul>
    <p class="itemPage clearfix"><%=pagestr %></p>
  </div> 
 <script type="text/javascript">
      function submescom(id) {
          var obj = document.getElementById("mescom" + id);
          obj.submit();
      }
</script>    
  <div class="logBoxR">
    <h3 class="logLtit">我要留言</h3>
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
  </div>
</div>
    
<%=model.ReadModel("/Reception/templates/default/public/center_foot.aspx")%>
