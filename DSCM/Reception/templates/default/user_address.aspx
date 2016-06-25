<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 10:37:18 
* File name：user_address 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_address.aspx.cs" Inherits="Reception_templates_default_user_address" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">
<script type="text/javascript">
   function checInput(regstr,objvalue,errornote) {
        if (!regstr.test(objvalue)) {
            document.getElementById(errornote).innerHTML = "您输入的格式不正确！";
        }
        else {
            document.getElementById(errornote).innerHTML = "";
        }
    }
    function checkPostCode() {
        var obj = document.zcmpostForm;
        var regPostCode = /^\d{6}$/;
        if (obj.user_delivery_address_city_code.value != "") {
            checInput(regPostCode, obj.user_delivery_address_city_code.value, "noticePostCode");
        }
    }
    function checkMobile() {
        var obj = document.zcmpostForm;
        var regMobile = /^1[3,4,5,8]\d{9}$/;
        checInput(regMobile, obj.user_delivery_address_user_phone.value, "noticePhone");
    }
    function checkTel() {
        var obj = document.zcmpostForm;
        var regTel = /^0\d{2,3}-?\d{7,8}$/;
        if (obj.user_delivery_address_user_tel.value != "") {
            checInput(regTel, obj.user_delivery_address_user_tel.value, "noticeTel");
        }       
    }
 </script>
<div class="pmanage_main fR">
      <div class="pmanage_head">       
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li class="active"><a href="javascript:void(0)">收货地址管理</a></li>
        </ul>
      </div>
      <div class="receive mT10">
        <div class="title">管理收货信息</div>
        <table cellpadding="0" cellspacing="0" width="100%">
          <tr class="tit">
            <td width="150">收货人</td>
            <td width="200">所在地区</td>
            <td width="250">详细地址</td>
            <td width="100">邮编</td>
            <td width="150">联系方式</td>
            <td width="150">操作</td>
<% foreach (DSCM.ds_tbl_user_delivery_address.tbl_user_delivery_address address in user_delivery_address)
   { %>
          <tr class="con">
            <td><%=address.User_Delivery_Address_User_Relname %></td>
            <td><%=address.proname%><%=address.cityname%></td>
            <td><%=address.User_Delivery_Address_User_Address %></td>
            <td><%=address.User_Delivery_Address_City_Code %></td>
            <td><%=address.User_Delivery_Address_User_Phone %></td>
            <td><a href="/Reception/index.aspx?ds=user&cm=address&id=<%=address.User_Delivery_Address_Id %>">编辑</a><a href="/Reception/index.aspx?ds=user&cm=addressdel&id=<%=address.User_Delivery_Address_Id %>">删除</a></td>
          </tr>
<% } %>
        </table>
        <div class="add btn1">添加地址</div>

        <div class="form-cont">
          <form id="zcmpostForm" name="zcmpostForm" action="/Reception/index.aspx?ds=user&cm=addressinsert" method="post" onsubmit=""  enctype="multipart/form-data">
            <p>
              <label><i>*</i>真实姓名：</label>
              <input name="user_delivery_address_user_relname" type="text" class="txtBox" value="<%=delivery_address.User_Delivery_Address_User_Relname %>">
            </p>
            <div>
              <label style="font-size: 14px; margin-top: -5px;"><i>*</i>通信地址：</label>
             <%-- <ul>
                <li>
                  <select name="user_delivery_address_city">
                    <option>福建</option>
                  </select>
                   </li>
                <li>
                  <select name="user_delivery_address_city">
                    <option>厦门</option>
                  </select>
                  </li>
              </ul>--%>
              <span id="province" class="city_select">
                <select name="user_delivery_address_city" onchange="change(this)">
                  <option>请选择</option>
                  <% 
                    foreach (DSCM.ds_tbl_province.tbl_province pro in province)
                    {
                    %>
                    <option <%if(pro.DI.Equals(provinceid)){ %> selected="selected"<%} %>  value="<%=pro.DI %>"><%=pro.Provincename %></option>
                    <%
                    }
                %>
                </select>
                </span>   
                 <span id="city" class="city_select"></span>     
            </div>
             <script type="text/javascript">
                function change(obj) {
                    $.get("/Reception/index.aspx?ds=center&cm=citys", { id: obj.value }, function (data) {
                        document.getElementById("city").innerHTML = data;
                    });
                }
             </script>
            <p>
              <label>详细地址：</label>
              <input name="user_delivery_address_user_address" type="text" class="txtBox" id="user_delivery_address_user_address" value="<%=delivery_address.User_Delivery_Address_User_Address %>"/>
            </p>
            <p>
              <label>邮政编码：</label>
              <input name="user_delivery_address_city_code" type="text" class="txtBox" id="user_delivery_address_city_code" value="<%=delivery_address.User_Delivery_Address_City_Code %>" onblur="checkPostCode()" maxlength="6"/>
              <span style="color:red;" class="error" id="noticePostCode"></span> 
            </p>
            <p>
              <label><i>*</i>手机号码：</label>
              <input name="user_delivery_address_user_phone" type="text" class="txtBox" id="user_delivery_address_user_phone" value="<%=delivery_address.User_Delivery_Address_User_Phone %>" onblur="checkMobile()" maxlength="11"/>
              <span style="color:red;" class="error" id="noticePhone"></span> 
            </p>
            <p>
              <label>联系电话：</label>
              <input name="user_delivery_address_user_tel" type="text" class="txtBox" id="user_delivery_address_user_tel" value="<%=delivery_address.User_Delivery_Address_User_Tel %>" onblur="checkTel()" maxlength="13"/> 
               <span style="color:red;" class="error" id="noticeTel"></span> 
            </p>
            <p>
              <label>&nbsp;</label>
               <span style="color:red;" id="error"></span> 
              <input name="" type="submit" class="btn2"  value="提交信息">
              <input name="user_delivery_address_id" type="hidden" class="btn2"  value="<%=user_delivery_address_id %>">
            </p>
          </form>
        </div>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>
<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>