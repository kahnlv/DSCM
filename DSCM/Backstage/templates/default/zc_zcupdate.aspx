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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_zcupdate.aspx.cs" Inherits="Backstage_templates_default_zc_zcupdate" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<script>
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.object_zc_price.value == "") {
            document.getElementById("error").innerHTML = "支持金额不能为空";
            return false;
        }
        if (obj.object_zc_time.value == "") {
            document.getElementById("error").innerHTML = "预计奖励日期不能为空";
            return false;
        }
        if (obj.object_zc_price.value > obj.raiseprice.value) {
            document.getElementById("error").innerHTML = "支持金额应小于等于融资目标金额";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=zc&cm=dszcupdate" method="post" onsubmit="return sub()">
    <h3><span>项目回报基本信息</span></h3>
     <ul class="forminfo">
      <li class=" mt10"><span>支持金额：</span>
      <input type="text" name="object_zc_price" value="<%=tobj_zc.Object_Zc_Price %>" onkeyup="this.value=this.value.replace(/\D/g,'')"  
            onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14"/>元
      </li>
      <li class=" mt10"><span>说明图片：</span>
        <div>                             
        <img src="<%=tobj_zc.Object_Zc_Img1 %>" id="showImg1" alt="" width="50px" height="50px"/>
        <input type="hidden" name="object_zc_img1" id="img1" value="<%=tobj_zc.Object_Zc_Img1 %>" />
        <iframe src="/img/adminupload.aspx?src=showImg1&value=img1" style="border:none;height:40px" frameborder="0"></iframe>
        </div>
        <div style="margin-left:8%;">
        <img src="<%=tobj_zc.Object_Zc_Img2 %>" id="showImg2" alt="" width="50px" height="50px"/>
        <input type="hidden" name="object_zc_img2" id="img2" value="<%=tobj_zc.Object_Zc_Img2 %>" />
        <iframe src="/img/adminupload.aspx?src=showImg2&value=img2" style="border:none;height:40px" frameborder="0"></iframe>
        </div>   
        <div style="margin-left:8%;">
        <img src="<%=tobj_zc.Object_Zc_Img3 %>" id="showImg3" alt="" width="50px" height="50px"/>
        <input type="hidden" name="object_zc_img3" id="img3" value="<%=tobj_zc.Object_Zc_Img3 %>" />
        <iframe src="/img/adminupload.aspx?src=showImg3&value=img3" style="border:none;height:40px" frameborder="0"></iframe>
        </div>   
		<p style="color:red;margin-left:8%;">图片最大宽x高为400*300px,最大为5M，请选择合适图片</p>          
      </li>
      <li class=" mt10"><span>预计奖励日期：</span>
      <input type="text" name="object_zc_time" value="<%=tobj_zc.Object_Zc_Time %>" onkeyup="this.value=this.value.replace(/\D/g,'')"  
            onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14"/>天
      </li>
      <li class=" mt10"><span>限制名额：</span>
      <label><input type="radio" name="object_zc_xianzhi" value="1" id="RadioGroup1_0" <%=tobj_zc.Object_Zc_Xianzhi.Equals("1")?" checked ":"" %>/>是</label>
      <label><input type="radio" name="object_zc_xianzhi" value="0" id="RadioGroup1_1" <%=tobj_zc.Object_Zc_Xianzhi.Equals("0")?" checked ":"" %>/>否</label>
      </li>
      <li class=" mt10"><span>回报方式：</span>
       <label><input type="radio" name="object_zc_fangshi" id="Radio1" value="发码" <%=tobj_zc.Object_Zc_Fangshi.Equals("发码")?" checked ":"" %> />发码</label>
       <label><input type="radio" name="object_zc_fangshi" id="Radio2" value="邮寄" <%=tobj_zc.Object_Zc_Fangshi.Equals("邮寄")?" checked ":"" %> />邮寄</label>
       <label><input type="radio" name="object_zc_fangshi" id="Radio3" value="邮寄+发码" <%=tobj_zc.Object_Zc_Fangshi.Equals("邮寄+发码")?" checked ":"" %> />邮寄+发码</label>
      </li>
    <%--  <li><span>回报内容：</span>      
          <textarea style="width:300px;height:100px;" name="object_zc_doc"><%=tobj_zc.Object_Zc_Doc %></textarea>
      </li>--%>

    <li><span style="color:red;" id="error"></span> 
        <input type="hidden" name="obj_zc_id" value="<%=obj_zc_id %>"/>
        <input type="hidden" name="raiseprice" value="<%=raiseprice %>"/>     
        <input type="hidden" name="obj_id" value="<%=tobj_zc.Object_Id %>"/>   
        <input type="submit" value="确认保存" />
    </li>
    </ul>
</form>
  </div>
</div>
</body>
</html>
