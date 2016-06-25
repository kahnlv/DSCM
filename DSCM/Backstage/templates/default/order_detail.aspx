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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_detail.aspx.cs" Inherits="Backstage_templates_default_order_detail" %>

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
      <th colspan="14">订单物流信息</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>物流公司：</th>
      <td colspan="13"><%=order.Order_Company%></td>
    </tr>
    <tr>    
      <th>运单号码：</th>
      <td colspan="13"><%=order.Order_Waybillno%></td>
    </tr>
    <tr>
      <th>发货信息：</th>
      <td colspan="13"><%=order.Order_Delivery_Info%></td>
    </tr>
    <tr>    
      <th>收货信息</th>
      <td colspan="13"><%=order.Order_Receive_Info %></td>
    </tr>
  </tbody>
</table>
</body>
</html>
