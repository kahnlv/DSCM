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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_shenhe.aspx.cs" Inherits="Backstage_templates_default_zc_shenhe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
<link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>css/detail.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<table border="0" cellpadding="0" cellspacing="0" class="object-joinin">
  <thead>
    <tr>
      <th colspan="14">项目基本信息</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>项目名称：</th>
      <td colspan="7"><%=tobj.Object_Title%></td>
      <th>游戏名称：</th>
      <td colspan="5"><%=tobj.Object_Game_Name %></td>
    </tr>
    <tr>
      <th>项目发起人：</th>
      <td><%=tobj.User_Name %></td>
      <th>项目地点：</th>
      <td><%=dtools.City(tobj.Object_Address)%></td>
      <th>项目类别：</th>
      <td><%=tobj.Object_Class %></td>
      <th>项目标签：</th>
      <td><%=tobj.Object_Label %></td>
      <th>项目预计平台：</th>
      <td colspan="5"><%=tobj.Object_Pingtai %></td>
    </tr>
    <tr>
      <th>融资目标：</th>
      <td><%=tobj.Object_Raise_Price%>元</td>
      <th>融资开始时间</th>
      <td><%=tobj.Object_Start_Time%></td>
      <th>募资期限</th>
      <td><%=tobj.Object_Qixian%>天</td>
      <th>游戏开发周期：</th>
      <td><%=tobj.Object_Game_Zhouqi %>天</td>
      <th>已经开发时间：</th>
      <td colspan="5"><%=tobj.Object_Raise_Start_Time%>天</td>
    </tr>
    <tr>
      <th>项目简介：</th>
      <td colspan="5"><%=tobj.Object_Doc %></td>
      <th>项目介绍：</th>
      <td colspan="7"><%=tobj.Object_Content %></td>
    </tr>
    <tr>    
      <th>已有开发商：</th>
      <td><% if (tobj.Object_Kaifashang.Equals("0")) { Response.Write("否"); } else if (tobj.Object_Kaifashang.Equals("1")) { Response.Write("是"); }%></td>
      <th>希望引入VC：</th>
      <td><% if (tobj.Object_VC.Equals("0")) { Response.Write("否"); } else if (tobj.Object_VC.Equals("1")) { Response.Write("是"); }%></td>
      <th>项目图片</th>
      <td colspan="3"><img style="width: 150px; height: 150px;" src="<%=tobj.Object_Img %>" alt=""/></td>
      <th>项目视频</th>
      <td colspan="5"><img style="width: 150px; height: 150px;" src="<%=tobj.Object_Video %>" alt=""/></td>
    </tr>
    <tr>
      <th>身份证号：</th>
      <td><%=tobj.User_Code%></td>
      <th>性别：</th>
      <td><% if (tobj.User_Sex.Equals("0")) { Response.Write("女"); } else if (tobj.User_Sex.Equals("1")) { Response.Write("男"); }%></td>
      <th>手机号：</th>
      <td><%=tobj.User_Phone%></td>
      <th>邮箱：</th>
      <td><%=tobj.User_Email%></td>
      <th>身份证照片</th>
      <td colspan="5"><img style="width: 150px; height: 150px;" src="<%=tobj.User_Code_Img %>" alt=""/></td>
     </tr>
  </tbody>
</table>
<div class="object-operat"><span>审核操作：</span>
  <form id="form1" name="form1" method="post" action="/backstage/index.aspx?ds=zc&cm=dsshenhe">
    <label>
      <input type="radio" name="object_state" value="1" checked="checked" id="RadioGroup1_0" />
      成功</label>
    <label>
      <input type="radio" name="object_state" value="2" id="RadioGroup1_1" />
      失败</label>
      <input type="hidden" name="object_id" value="<%=object_id %>" />
      <div class="object-btn">      
         <input type="submit" value="提交" />
      </div>
  </form>
</div>
</body>
</html>
