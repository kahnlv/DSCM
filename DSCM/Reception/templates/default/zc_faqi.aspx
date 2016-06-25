<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 16:50:00 
* File name：zc_faqi 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_faqi.aspx.cs" Inherits="Reception_templates_default_zc_faqi" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">


<div class="launchWarp">
	<h3 class="launTit">我们一起共建梦想</h3>
	<p class="launConText">众漫网是一家可以帮助您实现梦想的网站，在这里可以发布您的梦想、创意和创业计划，并通过网络平台面对公众集资，</p>
	<p class="launConText">让有创造力的人可能获得他们所需要的资金，以便使他们的梦想有可能实现。</p>
	<p class="launForm"><input type="checkbox" checked name="" id="" />阅读并同意众漫网的《服务协议》《众筹公告》</p>
	
    <% if (Save("user_phone").ToString().Equals(""))
   { %>
    <a href="javascript:void(0)" class="bottomlaunText showLogin">发起我的梦想</a>
    <% }
   else
   { %>
   <a href="/Reception/index.aspx?ds=zc&cm=insert" class="bottomlaunText">发起我的梦想</a>
   <% } %>
</div>




<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
