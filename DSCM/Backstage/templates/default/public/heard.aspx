<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/1 12:02:31 
* File name：heard 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="heard.aspx.cs" Inherits="Backstage_templates_default_public_heard" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="Generator" content=""/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=PageTitle %></title>
<link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/base.css" rel="stylesheet" type="text/css"/>
<link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/index.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/js/jquery-1.8.3.min.js"></script>
</head>
<body>
<!-- 头部 start -->
<div id="header">
  <div class="logo"><img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/logo.png"></div>
  <div class="feature">
    <ul>

<% 
    if (DSCM_NAV != null && DSCM_NAV.Navigation != null)
    {
        foreach (DSCM.BLL.Navigation nav in DSCM_NAV.Navigation)
        {
%>
        <li> 
            <a href="left.aspx?type=<%=nav.Type %>" class="on" target="left"><img src="<%=nav.Img %>" >
            <p><%=nav.Title%></p>
            </a> 
        </li>
<%
    }
    }
    else
    {
    %>
    <script>
        parent.location = "/Backstage/templates/default/login.aspx";
    </script>
    <%
    }
%>
    </ul>
  </div>
  <div class=" head_info fr">
    <div class="help"><a style="border-right:0;" href="/backstage/index.aspx?ds=admin&cm=out" target="_top">退出</a></div>
    <div class="user"><img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/user.png"><a href=""><%=Save("admin_name") %></a></div>
  </div>
</div>
</body>
</html>