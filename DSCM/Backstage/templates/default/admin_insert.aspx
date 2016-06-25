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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_insert.aspx.cs" Inherits="Backstage_templates_default_admin_insert" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.admin_pwd.value == "") {
            document.getElementById("error").innerHTML = "密码不能为空";
            return false;
        }
        if (obj.admin_pwd.value != obj.admin_pwd1.value) {
            document.getElementById("error").innerHTML = "两次密码不一致";
            return false;
        }
        if (obj.admin_name.value == "") {
            document.getElementById("error").innerHTML = "管理员名称不能为空";
        }
    }
</script>
<form id="mpostForm" name="mpostForm" action="/Backstage/index.aspx?ds=admin&cm=dsinsert" method="post" onsubmit="return sub()">
<div class="conenttow">
  <div class="base_root">
    <h3><span>基本信息</span></h3>
    <p class=" mt10"><span>管理员名称：</span>
      <input type="text" name="admin_name"/></p>
    <p><span>管理员密码：</span>
      <input type="text" name="admin_pwd"/></p>
    <p><span>确认密码：</span>
      <input type="text" name="admin_pwd1"/></p>    
    <p><span></span>
      <span style="color:red;" id="error"></span> 
      <input type="submit" value="确认保存" />
    </p>
  </div>
</div>
</form>
</body>
</html>
