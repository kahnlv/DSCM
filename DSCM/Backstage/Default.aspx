<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Backstage_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<meta name="keywords" content="" />
<meta name="description" content=""/>
<link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/base.css" rel="stylesheet" type="text/css"/>
<link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/frame.css" rel="stylesheet" type="text/css"/>
<title><%=PageTitle %></title>
</head>
<body>
<div class="header">
  <div class="header_top">
    <iframe src="templates/default/public/heard.aspx" id="head" name="head" frameborder="0" scrolling="no"></iframe>
  </div>
</div>
<div class="main">
  <div class="maincontent">
    <!-- 左边 start -->
<div class="left">
  <div class="leftmenu">
    <iframe src="templates/default/public/left.aspx?type=0" id="left" name="left" frameborder="0" scrolling="no"></iframe>
  </div>
</div>
<!-- 左边 end --> 
<!-- 右边 start -->
<div class="right">
  <div class="rightcontent">
    <iframe src="/backstage/index.aspx" id="right" name="main" frameborder="0" ></iframe>
  </div>
</div>
<!-- 右边 end -->
  </div>
</div>


</body>
</html>

