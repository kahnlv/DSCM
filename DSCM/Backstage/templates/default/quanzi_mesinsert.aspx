<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_mesinsert.aspx.cs" Inherits="Backstage_templates_default_quanzi_mesinsert" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.message_content.value == "") {
            document.getElementById("error").innerHTML = "通知内容不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=quanzi&cm=dsmesinsert" method="post" onsubmit="return sub()">
    <h3><span>通知基本信息</span></h3>
     <ul class="forminfo">
      <li class=" mt10"><span>通知内容：</span>
          <textarea style="width:600px;height:100px;" name="message_content"></textarea>
      </li>
      <li class=" mt10"><span>通知类别：</span>
         <div id="mescla_id" class="city_select">
            <select name="mescla_id">  
                 <option value="">请选择</option>
                <% 
                    foreach (DSCM.ds_tbl_message_class.tbl_message_class tmescla in tbl_mesclas)
                    {
                %>
                     <option value="<%=tmescla.Message_Class_Id %>"><%=tmescla.Message_Class_Name%></option>
                <%
                    }
                %>
            </select>
        </div>
      </li>
    <li><span style="color:red;" id="error"></span> 
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>
