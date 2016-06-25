<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：daohang 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_detail.aspx.cs" Inherits="Backstage_templates_default_new_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>css/detail.css" rel="stylesheet" type="text/css"/>
</head>
<body>
 
<table border="0" cellpadding="0" cellspacing="0" class="object-joinin">
  <thead>
    <tr>
      <th colspan="14">新闻基本信息</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>新闻标题：</th>
      <td colspan="13"><%=tnew.New_Title%></td>
    </tr>
    <tr>    
      <th>关键字：</th>
      <td colspan="13"><%=tnew.New_Key %></td>
    </tr>
    <tr>
      <th>新闻标签：</th>
      <td colspan="13"><%=tnew.New_Label%></td>
    </tr>
    <tr>    
      <th>发布时间</th>
      <td colspan="13"><%=tnew.New_Time%></td>
    </tr>
    <tr>
      <th>是否推荐：</th>
      <td colspan="13"> 
      <% if (tnew.New_Tuijian.Equals("1")) { Response.Write("是"); }
         else if (tnew.New_Tuijian.Equals("0")) { Response.Write("否"); } %>
      </td>
    </tr>
    <tr>
      <th>新闻描述：</th>
      <td colspan="13"><%=tnew.New_Inc%></td>
    </tr>
    <tr>
      <th>新闻内容：</th>
      <td colspan="13"><%=tnew.New_Doc%></td>
    </tr>
  </tbody>
</table>
</body>
</html>
