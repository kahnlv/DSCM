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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_zcdetail.aspx.cs" Inherits="Backstage_templates_default_order_zcdetail" %>

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
      <th colspan="14">订单支持信息</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>下单人：</th>
      <td colspan="13"><%=order.user.User_Name%></td>
    </tr>
    <tr>    
      <th>支持金额：</th>
      <td colspan="13"><%=order.object_zc_pes.Object_Zc_Pes_Price%></td>
    </tr>
    <tr>
      <th>联系电话：</th>
      <td colspan="13"><%=order.user_delicery_address.User_Delivery_Address_User_Phone%></td>
    </tr>
    <tr>    
      <th>联系地址</th>
      <td colspan="13"><%=dtools.City(order.user_delicery_address.User_Delivery_Address_City)%><%=order.user_delicery_address.User_Delivery_Address_User_Address %></td>
    </tr>
    <tr>
      <th>回报内容：</th>
      <td colspan="13"><%=content%></td>
    </tr>
  </tbody>
</table>
</body>
</html>
