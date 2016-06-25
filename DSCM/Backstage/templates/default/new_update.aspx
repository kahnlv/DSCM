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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_update.aspx.cs" Inherits="Backstage_templates_default_new_update" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<link rel="stylesheet" href="/data/resource/rili/jquery-ui.css">
<link rel="stylesheet" href="/data/resource/rili/style.css">
<script src="/data/resource/rili/jquery-1.10.2.js" type="text/javascript"></script>
<script src="/data/resource/rili/jquery-ui.js" type="text/javascript"></script>
<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.new_title.value == "") {
            document.getElementById("error").innerHTML = "新闻标题不能为空";
            return false;
        }
        if (obj.new_doc.value == "") {
            document.getElementById("error").innerHTML = "新闻内容不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=new&cm=dsupdate" method="post" onsubmit="return sub()">
    <h3><span>新闻基本信息</span></h3>
     <ul class="forminfo">
      <li class=" mt10"><span>关键字：</span>
      <input type="text" name="new_key" value="<%=tnew.New_Key %>" class="w340"/>
      </li>
      <li class=" mt10"><span>新闻标题：</span>
      <input type="text" name="new_title" value="<%=tnew.New_Title %>" class="w340"/>
      </li>
      <li class=" mt10"><span>发布时间：</span>
      <input type="text" name="new_time" id="new_time" value="<%=tnew.New_Time %>" class="w340"/>
      </li>
      <script type="text/javascript">
          $(function () {
              $("#new_time").datepicker();
          });
	  </script>
      <li class=" mt10"><span>新闻标签：</span>
      <input type="text" name="new_label" value="<%=tnew.New_Label %>" class="w340"/>
      </li>
      <li class=" mt10"><span>新闻描述：</span>
          <textarea style="width:600px;height:100px;" name="new_inc"><%=tnew.New_Inc%></textarea>
      </li>
      <li class=" mt10"><span>新闻内容：</span>
          <textarea style="width:600px;height:300px;" name="new_doc"><%=tnew.New_Doc%></textarea>
      </li>
      <li class=" mt10"><span>是否推荐：</span>
      <label><input type="radio" name="new_tuijian" value="1" id="Radio1" <%=tnew.New_Tuijian.Equals("1")?" checked ":"" %>/>是</label>
      <label><input type="radio" name="new_tuijian" value="0" id="Radio2" <%=tnew.New_Tuijian.Equals("0")?" checked ":"" %>/>否</label>
      </li>
    <li><span style="color:red;" id="error"></span> 
        <input type="hidden" name="new_id" value="<%=new_id %>"/>   
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>
