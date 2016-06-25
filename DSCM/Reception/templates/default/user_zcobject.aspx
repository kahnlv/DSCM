<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 15:24:07 
* File name：user_zcobject 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_zcobject.aspx.cs" Inherits="Reception_templates_default_user_zcobject" %>
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
          <li class="active"><a href="javascript:void(0)">支持项目</a></li>
          <li><a href="/Reception/index.aspx?ds=order&cm=trade">交易记录</a></li>
          <li><a href="/Reception/index.aspx?ds=object&cm=sendout">发货管理</a></li>
        </ul>
      </div>
      <div class="project mT30">
        <div class="tit">
          <ul>
            <li<% if (start.Equals("")) { %> class="cur" <%}  %>><a href="/Reception/index.aspx?ds=user&cm=zcobject">所有</a></li>
            <li<% if (start.Equals("1")) { %> class="cur" <%}  %>><a href="/Reception/index.aspx?ds=user&cm=zcobject&start=1">已支付</a></li>
            <li<% if (start.Equals("0")) { %> class="cur" <%}  %>><a href="/Reception/index.aspx?ds=user&cm=zcobject&start=0">未支付</a></li>
          </ul>
        </div>
        <div class="con">
          <table cellpadding="0" cellspacing="0">
            <tr class="title">
              <td width="120" >项目名称</td>
              <td width="300">&nbsp;</td>
              <td width="120">支付日期</td>
              <td width="120">支付金额</td>
              <td width="120">状态</td>
              <td width="120">操作</td>
            </tr>
<% 
    foreach (DSCM.ds_tbl_order.tbl_order order in user_log)
    {
    
%>
            <tr class="del_1">
              <td width="100"><img src="<%=order.tbl_obj.Object_Img  %>" style="width:100px;height:100px" alt=""/></td>
              <td class="info"><%=order.Object_Title %></td>
              <td class="time"><%=order.object_zc_pes.Object_Zc_Pes_Time %></td>
              <td class="price"><span><%=order.Order_Price %>元</span><span>(含运费10元)</span></td>
              <td class="state">
              <% 
                  if (order.Order_Start.Equals("0")) {%> <span>未支付</span><a href="/Reception/index.aspx?ds=order&cm=index2&order_id=<%=order.Order_Id %>">前往支付</a><% } else { %> <span>支付完成</span><%}
                %>
             </td>
              <td class="operate"><a href="/Reception/index.aspx?ds=order&cm=details&order_id=<%=order.Order_Id %>">回报内容</a><a href="/Reception/index.aspx?ds=order&cm=details&order_id=<%=order.Order_Id %>">收货地址</a></td>
            </tr>
<% 
    }
%>
          </table>
        </div>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>




<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
