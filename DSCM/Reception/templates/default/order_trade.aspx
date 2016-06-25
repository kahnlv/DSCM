<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 15:04:16 
* File name：order_trade 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_trade.aspx.cs" Inherits="Reception_templates_default_order_trade" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">


<div class="pmanage_main fR">
      <div class="pmanage_head">
        <h1><%=user_space.User_Space_Name %></h1>
        <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li><a href="/Reception/index.aspx?ds=user&cm=object">发起项目</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=xhobject">喜欢项目</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=zcobject">支持项目</a></li>
          <li class="active"><a href="javascript:void(0)">交易记录</a></li>
          <li><a href="/Reception/index.aspx?ds=object&cm=sendout">发货管理</a></li>
        </ul>
      </div>
      <div class="project mT30">
      <div class="con">
          <table cellpadding="0" cellspacing="0" width="100%">
            <tr class="title">
              <td >项目名称</td>
              <td >支付日期</td>
              <td >支付金额</td>
              <td >状态</td>
              <td >操作</td>
            </tr>

<% 
    foreach (DSCM.ds_tbl_order.tbl_order order in user_log)
    {
%>
            <tr class="del_2">
              <td class="name"><%=order.Object_Title %></td>
              <td class="time"><span><%=order.Order_Time %></span></td>
              <td class="price"><span><%=order.Order_Price %>元</span></td>
              <td class="state"><% if (order.Order_Start.Equals("0")) { %>未付款<%} else { %>已付款<%} %></td>
              <td class="operate"><% if (order.Order_Start.Equals("0")) { %><a href="/Reception/index.aspx?ds=order&cm=index2&order_id=<%=order.Order_Id %>">现在就去支付</a><%} else { %>-<%} %></td>
            </tr>
<% 
    }        
%>
         </table>
        </div>
</div>
      <p class="itemPage clearfix">  <%=pagestr%></p>
    </div>
 </div>
</div>
<div class="pB40"></div>



<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
