<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_mesclainsert.aspx.cs" Inherits="Backstage_templates_default_quanzi_mesclainsert" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.mescla_name.value == "") {
            document.getElementById("error").innerHTML = "通知类别名不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=quanzi&cm=dsmesclainsert" method="post" onsubmit="return sub()">
    <h3><span>通知基本信息</span></h3>
     <ul class="forminfo">
      <li class=" mt10"><span>通知类别名：</span>
          <input type="text" name="mescla_name" value=""/>
      </li> 
      <li class=" mt10">
        <span>通知类型：</span> <div id="mescla_type" class="city_select">
            <select name="mescla_type" onchange="change(this)"> 
                <option value="0">站内通知</option>
                <option value="1">邮件通知</option>
            </select>
        </div>
      </li>
      <li class=" mt10">
        <span>通知类别父类：</span> <div id="mescla_parentid" class="city_select">
            <select name="mescla_parentid">  
                 <option value="0">无</option>
                <% 
                    foreach (DSCM.ds_tbl_message_class.tbl_message_class tmesparcla in tbl_mespraclas)
                    {
                %>
                     <option value="<%=tmesparcla.Message_Class_Id %>"><%=tmesparcla.Message_Class_Name%></option>
                <%
                    }
                %>
            </select>
        </div>
      </li>
      <script type="text/javascript">
          function change(obj) {
              $.get("/backstage/index.aspx?ds=quanzi&cm=mesparcla", { type: obj.value }, function (data) {
                  document.getElementById("mescla_parentid").innerHTML = data;
              });
          }
      </script>   
    <li><span style="color:red;" id="error"></span> 
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>
