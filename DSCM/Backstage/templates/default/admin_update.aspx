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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_update.aspx.cs" Inherits="Backstage_templates_default_admin_update" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.oldpwd.value == "") {
            document.getElementById("error").innerHTML = "原始密码不能为空";
            return false;
        }
        if (obj.newpwd.value == "") {
            document.getElementById("error").innerHTML = "新密码不能为空";
            return false;
        }
        if (obj.newpwd.value != obj.qnewpwd.value) {
            document.getElementById("error").innerHTML = "两次密码不一致";
            return false;
        }
    }
</script>
<form id="mpostForm" name="mpostForm" action="/Backstage/index.aspx?ds=admin&cm=dsupdate" method="post" onsubmit="return sub()">
<div class="conenttow">
  <div class="base_root">
    <h3><span>基本信息</span></h3>
    <p class=" mt10"><span>管理员名称：</span>
        <label><%=admin.Admin_Name %></label></p>
    <%--  <input type="text" name="admin_name" value="<%=admin. %>"/></p>--%>
    <p><span>旧密码：</span>
      <input type="text" name="oldpwd"/></p>
    <p><span>新密码：</span>
      <input type="text" name="newpwd"/></p>
    <p><span>确认密码：</span>
      <input type="text" name="qnewpwd"/></p>
    
    <p><span></span>
      <span style="color:red;" id="error"></span> 
     <%-- <input type="hidden"name="act" value="insert"/>--%>
     <input type="hidden" name="adminid" value="<%=adminid %>"/>
      <input type="submit" value="确认保存" />
    </p>
  </div>
</div>
</form>
</body>
</html>
