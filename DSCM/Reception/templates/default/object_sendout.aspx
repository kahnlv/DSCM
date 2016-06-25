<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 13:44:06 
* File name：object_sendout 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="object_sendout.aspx.cs" Inherits="Reception_templates_default_object_sendout" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">
<script language="javascript" type="text/javascript">
    $(function () {
        var num = $(window).height() / 2 - 236;
        $('.reply').css('top', num);
        $("#bg").width($(document).width());
        $('#bg').height($(document).height());
        $('#bg').css('left', 0);
        $('#bg').css('top', 0);
    });
    function showdiv(order_id) {
        document.getElementById("bg").style.display = "block";
        document.getElementById("show1").style.display = "block";
        var obj = document.wuliupostForm;
        obj.order_id.value = order_id;
    }
    function hidediv() {
        document.getElementById("bg").style.display = 'none';
        document.getElementById("show1").style.display = 'none';
    }
    function wuliusend() {
        var obj = document.wuliupostForm;
        obj.submit();
    }
</script>

 <div class="pmanage_main fR">
      <div class="pmanage_head">
        <h1><%=user_space.User_Space_Name %></h1>
        <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li><a href="/Reception/index.aspx?ds=user&cm=object">发起项目</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=xhobject">喜欢项目</a></li>
          <li ><a href="/Reception/index.aspx?ds=user&cm=zcobject">支持项目</a></li>
          <li><a href="/Reception/index.aspx?ds=order&cm=trade">交易记录</a></li>
          <li class="active"><a href="javascript:void(0)">发货管理</a></li>
        </ul>
      </div>
      <div class="sendOut mT30">
        <div class="tit1">
          <ul>
           <%-- <li <% if(start == "2"){%> class="cur" <%} %>><a href="/Reception/index.aspx?ds=object&cm=sendout&start=2">已完成订单</a></li>
            <li <% if(start == "1"){%> class="cur" <%} %>><a href="/Reception/index.aspx?ds=object&cm=sendout&start=1">未完成订单</a></li>--%>
            <li <% if(start == "1"){%> class="cur" <%} %>><a href="/Reception/index.aspx?ds=object&cm=sendout&start=1">已完成订单</a></li>
            <li <% if(start == "0"){%> class="cur" <%} %>><a href="/Reception/index.aspx?ds=object&cm=sendout&start=0">未完成订单</a></li>
          </ul>
        </div>
        <div class="con1">
          <table cellpadding="0" cellspacing="0" class="w">
            <tr class="title">
              <td width="139" >支持人</td>
              <td width="288">支持项目</td>
              <td width="120">支付时间</td>
              <td width="120">操作</td>
              <td width="120">订单状态</td>
            </tr>

<% foreach (DSCM.ds_tbl_order.tbl_order order in user_log)
   { 
       
%>
            <tr class="del_1">
              <td width="139"><a href="#"><img src="<%=order.user.User_Img %>" style="width:50px;height:50px"></a><span class="fL" style="width:80px;"><a href="#"><%=order.user.User_Name %></a></span></td>
              <td class="info"><span><%=order.Object_Title%></span></td>
              <td class="time"><span></span><span><%=order.Order_Time%></span></td>  
              <td class="operate"><span><a  href="/Reception/index.aspx?ds=order&cm=details&order_id=<%=order.Order_Id %>">查看详细信息</a></span></td>
              <td class="state">
              <% if (order.Order_Start.Equals("0")) { Response.Write("<span class=\"stateimg\">等待付款</span>"); } %>
              <% if (order.Order_Start.Equals("1")) { string order_id = order.Order_Id; Response.Write("<span class=\"stateimg\">等待发货</span><span><a href=\"javascript:void(0)\" class=\"qx\" onclick=\"showdiv('"+order_id+"')\">填写物流信息</a></span>"); } %>
              <% if (order.Order_Start.Equals("2")) { Response.Write("<span class=\"stateimg\">订单已发货</span><span class=\"waring\">等待确认</span>"); } %>
              <% if (order.Order_Start.Equals("3")) { Response.Write("<span class=\"stateimg\">交易完成</span>"); } %>
              
              </td>
            </tr>
<% } %>

          </table>
        </div>
      </div>
      <div class="itemPage">  <%=pagestr%></div>
      <div class="reply" id="show1">
       <form id="wuliupostForm" name="wuliupostForm" action="/Reception/index.aspx?ds=object&cm=orderwuliu" method="post" onsubmit=""  enctype="multipart/form-data">
          <h1>填写物流信息<span id="shut" onclick="hidediv()">×</span> </h1>
          <div class="mesformBox">
            <h3>物流公司：
              <input value="" name="order_company" class="mesInput">
            </h3>
            <h3>运单号码：
              <input value="" name="order_waybillno" class="mesInput">
            </h3>
             <h3>发货信息：
              <input value="" name="order_delivery_info" class="mesInput">
            </h3>
             <h3>收货信息：
              <input value="" name="order_receive_info" class="mesInput">
            </h3>
            <p class="commBtn"><a href="javascript:wuliusend()" class="comReplyBtn">提交</a></p>
            <input value="" type="hidden" name="order_id" class="mesInput"/>
          </div>
          </form>
        </div>      
      <div id="bg" onclick="hidediv()"></div>  
  </div>     
 </div> 
</div>
<div class="pB40"></div>



<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
