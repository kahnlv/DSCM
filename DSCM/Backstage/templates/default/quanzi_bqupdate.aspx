<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_bqupdate.aspx.cs" Inherits="Backstage_templates_default_quanzi_bqupdate" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.biaoqian_name.value == "") {
            document.getElementById("error").innerHTML = "标签名称不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=quanzi&cm=dsbqupdate" method="post" onsubmit="return sub()">
    <h3><span>标签基本信息</span></h3>
     <ul class="forminfo">
      <li class=" mt10"><span>标签名称：</span>
          <input type="text" name="biaoqian_name" value="<%=tbq.Biaoqian_Name %>"/>
      </li> 
      <li class=" mt10">
        <span>标签类型：</span> <div id="biaoqian_type" class="city_select">
            <select name="biaoqian_type"> 
                <option value="0" <%if(tbq.Biaoqian_Type.Equals("0")){ %> selected="selected"<%} %>>兴趣标签</option>
                <option value="1" <%if(tbq.Biaoqian_Type.Equals("1")){ %> selected="selected"<%} %>>文章标签</option>
                <option value="2" <%if(tbq.Biaoqian_Type.Equals("2")){ %> selected="selected"<%} %>>图片标签</option>
            </select>
        </div>
      </li>
    <li><span style="color:red;" id="error"></span> 
        <input type="hidden" name="biaoqian_id" value="<%=biaoqian_id %>"/>   
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>
