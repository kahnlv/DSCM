<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 11:54:12 
* File name：center_heard 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_heard.aspx.cs" Inherits="Reception_templates_default_public_center_heard" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<title>众漫网</title>
<meta name="description" content="">
<meta name="author" content="Bill.Xu">
<!-- 让IE浏览器用最高级内核渲染页面 还有用 Chrome 框架的页面用webkit 内核
	================================================== -->
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<!-- 让360双核浏览器用webkit内核渲染页面
	================================================== -->
<meta name="renderer" content="webkit">
<!-- CSS
	================================================== -->
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/reset.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/style.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/space.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/script.js"></script>
</head>
<body >
<div style="height:634px;">
  <div class="spaceHear"></div>
  <div class="spaceMenu clearfix">
    <div class="W1200 proRel">
      <div style="display:inline-block; width:100%;"> <span class="HeadPortrait fL head_pers">
      <img class="headProimg"  src="<%=Save("user_img").ToString() %>" alt=""/><%=Save("user_name").ToString() %></span>
        <ul class="HeaeNavList fR">
          <li <% if(op.Equals("")){%> class="active" <%} %>><a href="/Reception/index.aspx?ds=zc" class="home" alt="首页"></a></li>
          <li <% if(op.Equals("log")){%> class="active" <%} %>><a href="/Reception/index.aspx?ds=center&cm=log">日志</a></li>
          <li <% if(op.Equals("photo")){%> class="active" <%} %>><a href="/Reception/index.aspx?ds=center&cm=photo">相册</a></li>
          <li><a href="">视频</a></li>
          <li><a href="/Reception/index.aspx?ds=center&cm=leaveWord">留言</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=info">个人信息</a></li>
        </ul>
      </div>
    </div>
  </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $(".spaceMenu").capacityFixed();
    });
</script>
