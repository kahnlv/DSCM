<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:27:31 
* File name：center_logview 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_logview.aspx.cs" Inherits="Reception_templates_default_center_logview" %>
<%=model.ReadModel("/Reception/templates/default/public/center_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<div class="logWarp clearfix">
  <div class="logBoxL logViewBox">
    <h3 class="logLtit"><%=user_log.User_Log_Class %></h3>
    <div class="logCon logConborder">
    <%--  <p><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/2014122818001.jpg" alt="" /></p>--%>
      <p><%=user_log.User_Log_Doc %></p>
    </div>
  
    <form id="logcominsertpostForm" name="logcominsertpostForm" action="/Reception/index.aspx?ds=center&cm=dslogmesinsert" method="post" onsubmit="">
			<div class="mesformBox">
				<textarea rows="" cols="" name="content" class="mesArea"></textarea>
				<p class="commBtn"><span class="bntIcon01"></span><a href="javascript:logmesinsert()" class="comReplyBtn">发表评论</a></p>
			</div>
            <input type="hidden" name="user_log_id" value="<%=user_log.User_Log_Id %>"/>
</form>
<script type="text/javascript">
    function logmesinsert() {
        var obj = document.logcominsertpostForm;
        obj.submit();
    }
</script>
    <ul class="commList clearfix">
<% int mmi = 1; foreach (DSCM.ds_tbl_user_message.tbl_user_message m in message)
   {
       DateTime dtmes = new DateTime();
       DateTime.TryParse(m.User_Message_Time, out dtmes);
%>
      <li>
        <div class="commInfo"> <a href="/Reception/index.aspx?ds=center" class="fL"><img src="<%=m.user.User_Img %>" alt=""width="50px" height="50px"/></a>
          <div class="fL comTit">
            <p><em class="fR"><%=mmi++ %>F</em><a href="#"><%=m.user.User_Name %></a><span class="grayText"><%=(DateTime.Now - dtmes).Days%>天前</span></p>
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
<form id="logcom<%=m.User_Message_Id %>" name="logcom<%=m.User_Message_Id %>" action="/Reception/index.aspx?ds=center&cm=dslogmesinsert" method="post" onsubmit="">
						<textarea name="content"></textarea>
						<p ><a href="javascript:sublogcom('<%=m.User_Message_Id %>')" style="float:right;">评论</a></p>
                        <input type="hidden" name="user_message_id" value="<%=m.User_Message_Id %>" />
                        <input type="hidden" name="user_log_id" value="<%=user_log.User_Log_Id %>"/>
</form>
					</div>
      </li>
        
<% } %>
    </ul>
    <p class="itemPage clearfix"> 
    <%=pagestr %>
     </p>
  </div>
<script type="text/javascript">
    function sublogcom(id) {
        var obj = document.getElementById("logcom" + id);
        obj.submit();
    }
</script>
  <div class="logBoxR">
    <h3 class="logLtit">日志分类</h3>
    <ul class="logboxRlist">
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=log&type=0"><i></i>个人日志</a></li>
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=log&type=1"><i></i>视频日志</a></li>
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=log&type=2"><i></i>我的收藏</a></li>
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=log&type=3"><i></i>情感天地</a></li>
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=log&type=4"><i></i>情感收藏</a></li>
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=log&type=5"><i></i>人生道理</a></li>
      <li><span></span><a href="/Reception/index.aspx?ds=center&cm=log&type=6"><i></i>人生感悟</a></li>
    </ul>
  </div>
</div>



<%=model.ReadModel("/Reception/templates/default/public/center_foot.aspx")%>
