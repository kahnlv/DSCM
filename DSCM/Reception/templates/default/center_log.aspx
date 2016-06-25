<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:15:53 
* File name：center_log 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_log.aspx.cs" Inherits="Reception_templates_default_center_log" %>
<%=model.ReadModel("/Reception/templates/default/public/center_heard.aspx")%>





<div class="logWarp clearfix">
  <div class="logBoxL">
    <div style="display:inline-block;">
<% foreach (DSCM.ds_tbl_user_log.tbl_user_log log in user_log)
   { %>

      <h3 class="logLtit"><%=log.User_Log_Class %></h3>
      <div class="logCon">
    <%--<p><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/2014122818001.jpg" alt="" /></p>--%>
        <h3><%=log.User_Log_Title %></h3>
        <p><%=log.User_Log_Doc %></p>
        <p class="logLink clearfix"><a href="/Reception/index.aspx?ds=center&cm=logview&id=<%=log.User_Log_Id %>">更多</a></p>
      </div>
<% } %>

    </div>
    <p class="itemPage clearfix"> 
    <%=pagestr %>
    </p>
  </div>
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