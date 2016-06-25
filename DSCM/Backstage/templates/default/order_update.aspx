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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_update.aspx.cs" Inherits="Backstage_templates_default_order_update" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<script type="text/javascript">
    function checInput(regstr, objvalue, errornote) {
        if (!regstr.test(objvalue)) {
            document.getElementById(errornote).innerHTML = "您输入的格式不正确！";
        }
        else {
            document.getElementById(errornote).innerHTML = "";
        }
    }
    function checkMobile() {
        var obj = document.mpostForm;
        var regMobile = /^1[3,4,5,8]\d{9}$/;
        checInput(regMobile, obj.user_delivery_address_user_phone.value, "noticePhone");
    }
    function checkTel() {
        var obj = document.mpostForm;
        var regTel = /^0\d{2,3}-?\d{7,8}$/;
        if (obj.user_delivery_address_user_tel.value != "") {
            checInput(regTel, obj.user_delivery_address_user_tel.value, "noticeTel");
        }
    }
    function checkPostCode() {
        var obj = document.mpostForm;
        var regPostCode = /^\d{6}$/;
        if (obj.user_delivery_address_city_code.value != "") {
            checInput(regPostCode, obj.user_delivery_address_city_code.value, "noticePostCode");
        }
    }
    function checkEmail() {
        var obj = document.mpostForm;
        var regEmail = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+(\.[a-zA-Z]{2,3})+$/;
        if (obj.user_delivery_address_user_email.value != "") {
            checInput(regEmail, obj.user_delivery_address_user_email.value, "noticeEmail");
        }
    }
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.user_delivery_address_user_relname.value == "") {
            document.getElementById("error").innerHTML = "用户名不能为空";
            return false;
        }
        if (obj.user_delivery_address_user_phone.value == "") {
            document.getElementById("error").innerHTML = "手机号不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=user&cm=dsupdate" method="post" onsubmit="return sub()">
    <h3><span>订单收货信息</span></h3>
     <ul class="forminfo">
      <li class=" mt10"><span>真实姓名：</span>
      <input type="text" name="user_delivery_address_user_relname" value="<%=tuser.User_Delivery_Address_User_Relname %>"/></li>
      <li class=" mt10">
        <span>收货地址：</span> <div id="province" class="city_select">
            <select name="object_address" onchange="change(this)">
                <option value="">请选择</option>
                <% 
                    foreach (DSCM.ds_tbl_province.tbl_province pro in province)
                    {                %>
                     <option value="<%=pro.DI %>" <%if(pro.DI.Equals(provinceid)){ %> selected="selected"<%} %>><%=pro.Provincename%></option>                
                 <% }%>
            </select>
        </div>
        <div id="city" class="city_select"></div> 
      </li>
      <script type="text/javascript">
          function change(obj) {
              $.get("/backstage/index.aspx?ds=city", { id: obj.value }, function (data) {
                  document.getElementById("city").innerHTML = data;
              });
          }
      </script>   
      <li class=" mt10"><span>详细地址：</span>
       <input type="text" name="user_delivery_address_user_address" value="<%=tuser.User_Delivery_Address_User_Address %>" class="w300"/>
      </li>  
      <li class=" mt10"><span>手机号码：</span>
       <input type="text" name="user_delivery_address_user_phone" value="<%=tuser.User_Delivery_Address_User_Phone %>" onblur="checkMobile()" maxlength="11"/>
       <label class="error" id="noticePhone"></label> 
      </li>
      <li class=" mt10"><span>联系电话：</span>
       <input type="text" name="user_delivery_address_user_tel" value="<%=tuser.User_Delivery_Address_User_Tel%>" onblur="checkTel()" maxlength="13"/>
        <label class="error" id="noticeTel"></label> 
      </li>
      <li class=" mt10"><span>邮政编码：</span>
       <input type="text" name="user_delivery_address_city_code" value="<%=tuser.User_Delivery_Address_City_Code %>" onblur="checkPostCode()" maxlength="6"/>
       <label class="error" id="noticePostCode"></label> 
      </li>
      <li class=" mt10"><span>Email地址：</span>
       <input type="text" name="user_delivery_address_user_email" value="<%=tuser.User_Delivery_Address_User_Email %>" onblur="checkEmail()" class="w300"/>
         <label class="error" id="noticeEmail"></label> 
      </li>
    <li><span style="color:red;" id="error"></span> 
        <input type="hidden" name="user_delivery_address_id" value="<%=tuser.User_Delivery_Address_Id %>"/>   
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>
