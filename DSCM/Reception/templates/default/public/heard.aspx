<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/17 10:22:54 
* File name：heard 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="heard.aspx.cs" Inherits="Reception_templates_default_public_heard" %>
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
</head>
<body>
<!-- header -->
<div class="header fixMenu">
	<div class="W1200">
		<h1 class="logo fL"></h1>
		<ul class="HeaeNavList fL">
			<li><a href="/Reception/index.aspx?ds=zc" class="home" alt="首页"></a></li>
			<li><a href="/Reception/index.aspx?ds=zc&cm=list">热门项目</a></li>
			<li><a href="/Reception/index.aspx?ds=zc&cm=list">专题项目</a></li>
			<li><a href="/Reception/index.aspx?ds=new">热点新闻</a></li>
			<li><a href="/Reception/index.aspx?ds=quanzi" class="circle" target="_blank">圈子</a></li>
            <li><a href="/Reception/index.aspx?ds=zc&cm=faqi" class="circle" target="_blank">发起项目</a></li>
		</ul>
		<div class="fR">


			<!-- 搜索 -->
			<span class="TopSearch fL">
				<input type="text" name="Topsear" class="TopSear" />
				<input type="submit" value="" class="TopSubBtn" />
			</span>



<% if (Save("user_phone").ToString().Equals(""))
   { %>
			<!-- 默认 -->
			<span class="adminTacitly ">
				<a href="javascript:void(0)" class="showLogin">登录</a>
				<a href="javascript:void(0)" class="cur showRegister">注册</a>
			</span>
<% }
   else
   { %>
            <span class="adminTacitly ">
				<a href="/Reception/index.aspx?ds=center">会员中心</a>
			</span>
			<!-- 展开 -->
			<div class="AdminDevelop">	 <!-- DevelopHover 移动时添加类 -->			
				<span class="photo"><a href="javascript:void(0)" target="_blank"><img src="<%=Save("user_img").ToString() %>" alt="" /></a></span>
				<em class="photoBg"></em>
				<div class="showDevelop hide">
					<a href="/Reception/index.aspx?ds=user&cm=zcobject" class="TopIcon1">支持的项目</a>
					<a href="/Reception/index.aspx?ds=user&cm=object" class="TopIcon2">发起的项目</a>
					<a href="/Reception/index.aspx?ds=user&cm=friends" class="TopIcon3">发起者后台</a>
					<a href="/Reception/index.aspx?ds=user&cm=xhobject" class="TopIcon4">喜欢的项目</a>
					<a href="/Reception/index.aspx?ds=user&cm=letter" class="TopIcon5">消息中心</a>
					<a href="/Reception/index.aspx?ds=user&cm=info" class="TopIcon6">个人设置</a>
					<a href="/Reception/index.aspx?ds=user&cm=out" class="TopIcon7">退出</a>
				</div>
			</div>
<% } %>
		</div>
	</div>
</div>
<!-- itemBanner -->