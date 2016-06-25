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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_update.aspx.cs" Inherits="Backstage_templates_default_user_update" %>

<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" ID="c_topwin1" />
<link rel="stylesheet" href="/data/resource/rili/jquery-ui.css">
<link rel="stylesheet" href="/data/resource/rili/style.css">
<script src="/data/resource/rili/jquery-1.10.2.js" type="text/javascript"></script>
<script src="/data/resource/rili/jquery-ui.js" type="text/javascript"></script>
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
        checInput(regMobile, obj.user_phone.value, "noticePhone");
    }
    function checkTel() {
        var obj = document.mpostForm;
        var regTel = /^0\d{2,3}-?\d{7,8}$/;
        if (obj.user_tel.value != "") {
            checInput(regTel, obj.user_tel.value, "noticeTel");
        }
    }
    function checkPostCode() {
        var obj = document.mpostForm;
        var regPostCode = /^\d{6}$/;
        if (obj.city_code.value != "") {
            checInput(regPostCode, obj.city_code.value, "noticePostCode");
        }
    }
    function checkEmail() {
        var obj = document.mpostForm;
        var regEmail = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+(\.[a-zA-Z]{2,3})+$/;
        checInput(regEmail, obj.user_email.value, "noticeEmail");
    }
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.user_relname.value == "") {
            document.getElementById("error").innerHTML = "用户名不能为空";
            return false;
        }
        if (obj.user_phone.value == "") {
            document.getElementById("error").innerHTML = "手机号不能为空";
            return false;
        }
        if (obj.user_email.value == "") {
            document.getElementById("error").innerHTML = "Email地址不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
    <div class="base_root2">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=user&cm=dsupdate" method="post" onsubmit="return sub()">
            <h3><span>用户基本信息</span></h3>
            <ul class="forminfo">
                <li class=" mt10"><span>真实姓名：</span>
                    <input type="text" name="user_relname" value="<%=tuser.User_Relname %>" /></li>
                <li class=" mt10">
                    <span>通信地址：</span>
                    <div id="province" class="city_select">
                        <select name="object_address" onchange="change(this)">
                            <option value="">请选择</option>
                            <% 
                                foreach (DSCM.ds_tbl_province.tbl_province pro in province)
                                {                %>
                            <option value="<%=pro.DI %>" <%if (pro.DI.Equals(provinceid))
                                                           { %>
                                selected="selected" <%} %>><%=pro.Provincename%></option>
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
                    <input type="text" name="user_address" value="<%=tuser.User_Address %>" class="w300" />
                </li>
                <li class=" mt10"><span>生日：</span>
                    <input type="text" name="user_birthday" id="user_birthday" value="<%=tuser.User_Birthday %>" />
                </li>
                <script type="text/javascript">
                    $(function () {
                        $("#user_birthday").datepicker();
                    });
                </script>
                <li class=" mt10"><span>性别：</span>
                    <label>
                        <input type="radio" name="user_sex" value="1" id="Radio1" <%=tuser.User_Sex.Equals("1")?" checked ":"" %> />男</label>
                    <label>
                        <input type="radio" name="user_sex" value="0" id="Radio2" <%=tuser.User_Sex.Equals("0")?" checked ":"" %> />女</label>
                </li>
                <li class=" mt10"><span>手机号码：</span>
                    <input type="text" name="user_phone" value="<%=tuser.User_Phone %>" onblur="checkMobile()" maxlength="11" />
                    <label class="error" id="noticePhone"></label>
                </li>
                <li class=" mt10"><span>联系电话：</span>
                    <input type="text" name="user_tel" value="<%=tuser.User_Tel%>" onblur="checkTel()" maxlength="13" />
                    <label class="error" id="noticeTel"></label>
                </li>
                <li class=" mt10"><span>邮政编码：</span>
                    <input type="text" name="city_code" value="<%=tuser.City_Code %>" onblur="checkPostCode()" maxlength="6" />
                    <label class="error" id="noticePostCode"></label>
                </li>
                <li class=" mt10"><span>Email地址：</span>
                    <input type="text" name="user_email" value="<%=tuser.User_Email %>" onblur="checkEmail()" class="w300" />
                    <label class="error" id="noticeEmail"></label>
                </li>
                <li class=" mt10"><span>用户头像：</span>
                    <div>
                        <img src="<%=tuser.User_Img %>" id="user_img" alt="" width="50px" height="50px" />
                        <input type="hidden" name="user_img" id="img1" value="<%=tuser.User_Img %>" />
                        <iframe src="/img/adminupload.aspx?src=user_img&value=img1" style="border: none; height: 40px" frameborder="0"></iframe>
                    </div>
                    <p style="color: red; margin-left: 8%;">支持jpg\jpeg\png格式的照片</p>
                </li>
                <li class=" mt10">
                    <span>设为推荐：</span>
                    <%if (tuser.User_recommend == "0" || string.IsNullOrEmpty(tuser.User_recommend))
                      {%>
                    <input name="user_recommend" type="checkbox" />
                    <% }
                      else
                      {%>
                    <input name="user_recommend" checked="checked" type="checkbox" />
                    <%} %>
                  
                </li>
                <li><span style="color: red;" id="error"></span>
                    <input type="hidden" name="user_id" value="<%=user_id %>" />
                    <input type="submit" value="确认保存" />
                </li>
            </ul>
        </form>
    </div>
</div>
</body>
</html>
