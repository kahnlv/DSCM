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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="findout_choose.aspx.cs" Inherits="Reception_templates_default_findout_choose" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/index.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/find.css" rel="stylesheet" type="text/css">

<div class="W1200 Mt98 ">
  <div class="find-password">
    <h3>可以选择通过邮箱和手机号找回密码</h3>
    <div class="findroot"> <span class="wid">请选择找回方式：</span> </div>
    <form id="form1" name="form1" method="post" action="">
      <div class="findroot choose">
        <label>
          <input type="radio" name="RadioGroup1" value="手机方式" id="RadioGroup1_0" onclick="choose1()"/>
          手机发送短信</label>
        <br />
        <label>
          <input type="radio" name="RadioGroup1" value="邮箱方式" id="RadioGroup1_1" onclick="choose2()"/>
          邮箱验证</label>
      </div>
    </form>
  </div>
</div>

<script type="text/javascript">
    function choose1() {
        location.href = "/Reception/templates/default/choose_phone1.aspx";
    }
    function choose2() {
        location.href = "/Reception/templates/default/choose_email1.aspx";
    }
</script>
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
