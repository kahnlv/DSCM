<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/7/27 10:05:46 
* File name：daohang 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Backstage_templates_default_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="Generator" content=""/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=PageTitle %></title>
<link  href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/base.css" rel="stylesheet" />
<link  href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/login.css" rel="stylesheet" />
</head>
<body>
<div class="loginbg">
  <div class="login-top clearfix">
    <div class="top-left fl"> <i></i>欢迎登录后台管理界面平台 </div>   
  </div>
<form name="form1" method="post" action="/Backstage/index.aspx?ds=admin&cm=login">
  <div class="logo"> <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/logo.png" /> </div>
  <div class="login clearfix">
    <div class="login-left fl"> <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/login1.png" /> </div>
    <div class="login-right fl">
      <p><span>用户登录</span>UserLogin</p>
      <div class="logininfo clearfix"> <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/user_login.png" />
        <input type="text" value="" name="username" placeholder="用户名" />
      </div>
      <div class="logininfo clearfix"> <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/pw.png" />
        <input type="password" value="" name="password"  placeholder="密码"/>
      </div>
      <div class="login-bottom clearfix">
        <input type="submit"  value="登录"/>
        <input type="checkbox" />
        <span>记住账号</span> <a href="#">忘记密码？</a> </div>
    </div>
  </div>
</form>
</div>
<div class="footer w"> 版权所有 2015 <a href="#">zhongchou.sddxcb.com</a>  </div>
</body>
</html>
