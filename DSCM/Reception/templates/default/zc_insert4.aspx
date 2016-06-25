<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 11:48:39 
* File name：zc_insert4 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_insert4.aspx.cs" Inherits="Reception_templates_default_zc_insert4" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<script type="text/javascript">
    function checInput(regstr, objvalue, errornote) {
        if (!regstr.test(objvalue)) {
            document.getElementById(errornote).innerHTML = "您输入的格式不正确！";
        }
        else {
            document.getElementById(errornote).innerHTML = "";
        }
    }
    function checkUserCode() {
        var obj = document.zcmpostForm;
        var regCode = /^\d{15}$|^\d{18}$|^\d{17}(\d|X|x)$/;
        checInput(regCode, obj.user_code.value, "noticeUserCode");
    }
    function checkMobile() {
        var obj = document.zcmpostForm;
        var regMobile = /^1[3,4,5,8]\d{9}$/;
        checInput(regMobile, obj.user_phone.value, "noticePhone");
    }
    function checkEmail() {
        var obj = document.zcmpostForm;
        var regEmail = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+(\.[a-zA-Z]{2,3})+$/;
        checInput(regEmail, obj.user_email.value, "noticeEmail");
    }  
</script>
<form id="zcmpostForm" name="zcmpostForm" action="/Reception/index.aspx?ds=zc&cm=dsinsert5" method="post" onsubmit="return sub()">
<div class="W1200">
	<div class="newItemCon clearfix">
		<h1 class="itemTopTit"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/submitAuditTit.png" alt="" /></h1>
		<div class="ItemFormL">
			<h2 class="auditTit">认证信息</h2>
			<p class="auditSub">提示：预售项目的发起基于诚信和部分信息的透明，需要您的真实信息已完成审核阶段，我们承诺您的个人信息不会泄露，感谢理解与支持</p>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>真实姓名:</dt>
				<dd><span class="itemInpBox"><input type="text" name="user_name" id="" /></span></dd>				
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>身份证号码:</dt>
				<dd><span class="itemInpBox"><input type="text" name="user_code" id="" onblur="checkUserCode()"  maxlength="18"/></span>
                    <span style="color:red;" class="error" id="noticeUserCode"></span> 
                </dd>				
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>性别:</dt>
				<dd>
					<div class="selproperty alarmradio">
						<span><input type="radio" class="radNo" id="sex1" name="user_sex"  value="1"/><label for='sex1'>男</label></span>
						<span><input type="radio" class="radNo" id="sex2" checked="checked" name="user_sex" value="0"/><label for='sex2'>女</label></span>
					</div>
				</dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>上传身份证照片:</dt>
				<dd>
					<div class="box setfileBox">
						<input type="text" name="video"  class="photoText" />
						<a href="javascript:void(0);"  class="link">浏览</a>
						<input type="file" class="SetloadFile" name="user_code_img" onchange="getFile(this,'video')" />
					</div>
					<p class="errorMsg">请上传身份证包含肩部以上的头部信息</p>
				</dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>手机号码:</dt>
				<dd><span class="itemInpBox"><input type="text" name="user_phone" id="" onblur="checkMobile()" maxlength="11"/></span>
                  <span style="color:red;" class="error" id="noticePhone"></span> 
                </dd>				
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>邮箱:</dt>
				<dd><span class="itemInpBox"><input type="text" name="user_email" id="" onblur="checkEmail()"/></span>
                 <span style="color:red;" class="error" id="noticeEmail"></span> </dd>				
			</dl>
             <span style="color:red;" id="error"></span> 
			<p class="itemPageBtn">                              
            <% if (Save("user_phone").ToString().Equals(""))
           { %>
                <input type="button" style="text-align: center;" class="PageBtn showLogin" value="提交审核" />
            <% }
           else
           { %>
              <input type="submit" class="PageBtn" value="提交审核" />
          <% } %>    	                 
            </p>
		</div>
		<div class="ItemFormR">
			<div class="itemBorder clearfix">
				<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/20141204.jpg" alt="" class="ItemImg" />
				<p class="itemName">项目名称</p>
				<p class="itemPhoto"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201400154245.jpg" alt="" /></p>
				<div class="itemSupporter clearfix">
					<span class="m_01"><em>92%</em>已达到</span>
					<span class="m_02"><em>￥15900</em>已筹集</span>
					<span class="m_03"><em>15天</em>剩余时间</span>
				</div>
			</div>
		</div>
	</div>
</div>
<div class="pB40"></div>
</form>

<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>