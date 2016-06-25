<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：order_details 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_details.aspx.cs" Inherits="Reception_templates_default_order_details" %>
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
         <li><a href="/Reception/index.aspx?ds=order&cm=trade">交易记录</a></li>
         <li class="active"><a href="/Reception/index.aspx?ds=object&cm=sendout">发货管理</a></li>
       </ul>
      </div>
      <div class="sendOut mT30">
        <div class="con2 w">
          <p><span class="con2-left">支持人：</span><%=order.user.User_Name%></p>
          <p><span class="con2-left ">支持金额：</span><%=order.object_zc_pes.Object_Zc_Pes_Price %></p>
          <p><span class="con2-left">联系电话：</span><%=order.user_delicery_address.User_Delivery_Address_User_Phone %></p>
          <p><span class="con2-left">联系地址：</span><%=order.user_delicery_address.proname %><%=order.user_delicery_address.cityname %><%=order.user_delicery_address.User_Delivery_Address_User_Address %></p>
          <p><span class="con2-left">回报内容：</span><span class="con2-root"><%=content%></span>
          </p>
        </div>
      </div>
    </div>
  </div> 
</div>
 <div class="pB40"></div>
<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
