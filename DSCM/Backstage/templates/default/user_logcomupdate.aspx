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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_logcomupdate.aspx.cs" Inherits="Backstage_templates_default_user_logcomupdate" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.user_message_center.value == "") {
            document.getElementById("error").innerHTML = "评论内容不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=user&cm=dslogcomupdate" method="post" onsubmit="return sub()">
    <h3><span>日志评论信息</span></h3>
     <ul class="forminfo">
          <li class=" mt10"><span>评论内容：</span>      
              <textarea style="width:300px;height:100px;" name="user_message_center"><%=tuser_mes.User_Message_Center%></textarea>
          </li>
    <li><span style="color:red;" id="error"></span> 
        <input type="hidden" name="user_message_id" value="<%=user_message_id %>"/>   
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>