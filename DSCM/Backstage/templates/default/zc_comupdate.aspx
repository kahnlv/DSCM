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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_comupdate.aspx.cs" Inherits="Backstage_templates_default_zc_comupdate" %>

<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.object_pl_content.value == "") {
            document.getElementById("error").innerHTML = "评论内容不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=zc&cm=dscomupdate" method="post" onsubmit="return sub()">
    <h3><span>项目评论信息</span></h3>
     <ul class="forminfo">
          <li class=" mt10"><span>评论内容：</span>      
              <textarea style="width:300px;height:100px;" name="object_pl_content"><%=tobj_pl.Object_Pl_Content%></textarea>
          </li>
    <li><span style="color:red;" id="error"></span> 
        <input type="hidden" name="obj_pl_id" value="<%=obj_pl_id %>"/>   
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>
