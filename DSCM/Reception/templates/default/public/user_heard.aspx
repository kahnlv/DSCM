<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 15:17:57 
* File name：user_heard 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_heard.aspx.cs" Inherits="Reception_templates_default_public_user_heard" %>
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
<script type="text/javascript" src="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/jquery-1.9.1.min.js"></script>
</head>
<body>
<div class="pmanage">
  <div class="W1200">
    <div class="pmanagelist fL">
      <div class="pmanage_left"><img class="fL" src="<%=user_img %>" width="188" height="250">
        <ul class="fR">       
          <li><a href="/Reception/index.aspx?ds=zc">返回首页</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=photo">修改头像</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=info">个人信息</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=spacedesign">空间设置</a></li>
        </ul>
      </div>
      <div class="pmanagelist_list">
        <dl>
          <dt><a href="/Reception/index.aspx?ds=user&cm=address">收货地址管理</a></dt>
        </dl>
        <dl>
          <dt><a href="/Reception/index.aspx?ds=user&cm=object">项目管理<i></i></a></dt>
          <dd>
            <ul>
              <li><a href="/Reception/index.aspx?ds=user&cm=object">发起项目</a></li>
              <li><a href="/Reception/index.aspx?ds=user&cm=xhobject">喜欢项目</a></li>
              <li><a href="/Reception/index.aspx?ds=user&cm=zcobject">支持项目</a></li>
              <li><a href="/Reception/index.aspx?ds=order&cm=trade">交易记录</a></li>
             <li><a href="/Reception/index.aspx?ds=object&cm=sendout">发货管理</a></li>
            </ul>
          </dd>
        </dl>
        <dl>
          <dt><a href="/Reception/index.aspx?ds=user&cm=log">空间管理<i></i></a></dt>
          <dd>
            <ul>
              <li><a href="/Reception/index.aspx?ds=user&cm=log">日志管理</a></li>
              <li><a href="/Reception/index.aspx?ds=photo">相册管理</a></li>
              <li><a href="/Reception/index.aspx?ds=user&cm=friends">关注好友列表</a></li>
            </ul>
          </dd>
        </dl>
        <dl>
          <dt><a href="/Reception/index.aspx?ds=user&cm=letter">消息管理<i></i></a></dt>
          <dd>
            <ul>
              <li><a href="/Reception/index.aspx?ds=user&cm=letter">站内信</a></li>
            </ul>
          </dd>
        </dl>
      </div>
    </div>
