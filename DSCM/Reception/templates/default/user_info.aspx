<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 9:49:24 
* File name：user_info 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_info.aspx.cs" Inherits="Reception_templates_default_user_info" %>
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
    function checkMobile() {
        var obj = document.zcmpostForm;
        var regMobile = /^1[3,4,5,8]\d{9}$/;
        checInput(regMobile, obj.user_phone.value, "noticePhone");
    }
    function checkTel() {
        var obj = document.zcmpostForm;
        var regTel = /^0\d{2,3}-?\d{7,8}$/;
        if (obj.user_tel.value != "") {
            checInput(regTel, obj.user_tel.value, "noticeTel");
        }    
    }
    function checkPostCode() {
        var obj = document.zcmpostForm;
        var regPostCode = /^\d{6}$/;
        if (obj.city_code.value != "") {
            checInput(regPostCode, obj.city_code.value, "noticePostCode");
        }
    }
    function checkEmail() {
        var obj = document.zcmpostForm;
        var regEmail = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+(\.[a-zA-Z]{2,3})+$/;
        checInput(regEmail, obj.user_email.value, "noticeEmail");
    }  
</script>
<div class="pmanage_main fR">
    <div class="pmanage_head">
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
    </div>
    <div class="pmanage_menu">
      <ul class="HeaeNavList">
        <li><a href="/Reception/index.aspx?ds=user&cm=photo">修改头像</a></li>
        <li class="active"><a href="javascript:void(0)">个人信息</a></li>
        <li><a href="/Reception/index.aspx?ds=user&cm=spacedesign">空间设置</a></li>
      </ul>
    </div>
    <div class="main_con mT10">
      <div class="form-cont">
        <form id="zcmpostForm" name="zcmpostForm" action="/Reception/index.aspx?ds=user&cm=update" method="post" onsubmit=""  enctype="multipart/form-data">
          <p>
            <label><i>*</i>真实姓名：</label>
            <input type="text" class="txtBox" name="user_relname" value="<%=user.User_Relname %>"/>
          </p>
          <div>
            <label style="font-size: 14px; margin-top: -5px;"><i>*</i>性别：</label>
            <ul>
              <li>
                <input name="user_sex" type="radio" value="1" <%if(user.User_Sex.Equals("1")) {%> checked="" <%}%> >
                男</li>
              <li>
                <input name="user_sex" type="radio" value="0" <%if(user.User_Sex.Equals("0")) {%> checked="" <%}%>>
                女</li>
            </ul>
          </div>
          <div>
            <label style="font-size: 14px; margin-top: -5px;"><i>*</i>生日：</label>
            <ul>
              <li>
                <select name="user_birthday">
                <%
                    string bir = user.User_Birthday.Split(' ')[0];
                    string[] birday = bir.Split('/');
                    if (birday.Length != 3) birday = new string[] { "1950","01","01"};
                     %>

            <% for (int i = 1950; i < 2150; i++)
               { %>
                  <option <% if(birday[0]==(""+i)) {%> selected <%}%> value="<%=i %>"><%=i %>年</option>
            <% } %>
                </select>
              </li>
              <li>
                <select name="user_birthday">
                  <% for (int i = 1; i < 13; i++)
               { %>
                  <option <% if(birday[1]==(""+i)) {%> selected <%}%> value="<%=i %>"><%=i %>月</option>
            <% } %>
                </select>
              </li>
              <li>
                <select name="user_birthday">
                  <% for (int i = 1; i < 31; i++)
               { %>
                  <option <% if(birday[2]==(""+i)) {%> selected <%}%> value="<%=i %>"><%=i %>日</option>
            <% } %>
                </select>
              </li>
            </ul>
          </div>
          <p>
            <label><i>*</i>手机号码：</label>
            <input name="user_phone" type="text" class="txtBox" id="user_phone" value="<%=user.User_Phone %>" onblur="checkMobile()" maxlength="11"/>
            <span style="color:red;" class="error" id="noticePhone"></span> 
          </p>
          <p>
            <label>联系电话：</label>
            <input name="user_tel" type="text" class="txtBox" id="user_tel" value="<%=user.User_Tel %>" onblur="checkTel()" maxlength="13"/>
            <span style="color:red;" class="error" id="noticeTel"></span> 
          </p>
          <div>
            <label style="font-size: 14px; margin-top: -5px;"><i>*</i>通信地址：</label>
           <%-- <ul>
              <li>
                <select name="user_city">
                  <option>福建</option>
                </select>
                 </li>
              <li>
               <select name="user_city">
                  <option>厦门</option>
                </select>
                </li>
             </ul> --%>
               <span id="province" class="city_select">
                <select name="user_city" onchange="change(this)">
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
                  $.get("/Reception/index.aspx?ds=user&cm=citys", { id: obj.value }, function (data) {
                      document.getElementById("city").innerHTML = data;
                  });
              }
        </script>
          <p>
            <label>详细地址：</label>
            <input name="user_address" type="text" class="txtBox" id="user_address" value="<%=user.User_Address %>"/>
          </p>
          <p>
            <label>邮政编码：</label>
            <input name="city_code" type="text" class="txtBox" id="city_code" value="<%=user.City_Code %>" onblur="checkPostCode()" maxlength="6"/>
            <span style="color:red;" class="error" id="noticePostCode"></span> 
          </p>
          <p>
            <label><i>*</i>Email地址：</label>
            <input name="user_email" type="text" class="txtBox" id="user_email" value="<%=user.User_Email %>" onblur="checkEmail()"/>
            <span style="color:red;" class="error" id="noticeEmail"></span> 
          </p>
          <p>
            <label>&nbsp;</label>
            <input name="" type="submit" class="btn1"  value="提交信息"/>
          </p>
        </form>
      </div>
    </div>
  </div>
</div>
</div>
<div class="pB40"></div>




<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>