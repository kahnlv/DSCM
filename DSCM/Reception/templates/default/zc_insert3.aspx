<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/21 11:24:33 
* File name：zc_insert3 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_insert3.aspx.cs" Inherits="Reception_templates_default_zc_insert3" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.all.min.js"> </script>
<form id="zcmpostForm" name="zcmpostForm" action="/Reception/index.aspx?ds=zc&cm=dsinsert3" method="post" onsubmit=""  enctype="multipart/form-data">
<div class="newItemNav">
	<div class="W1200">
		<ul class="NewNavlist">
			<li><div class="navitTit Newitem_01">项目信息</div><p class="itemNavBottom">1<em></em></p></li>
			<li><div class="navitTit Newitem_02">项目详情</div><p class="itemNavBottom">2<em></em></p></li>
			<li class="active"><div class="navitTit Newitem_03">回报设置</div><p class="itemNavBottom">3<em></em></p></li>
			<li><div class="navitTit Newitem_04">提交审核</div><p class="itemNavBottom">4</p></li>
		</ul>
	</div>
</div>
<div class="W1200">
	<div class="newItemCon clearfix">
		<h1 class="itemTopTit"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/reportSeTit.png" alt="" /></h1>
		<div class="ItemFormL">
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>支持金额:</dt>
				<dd><span class="itemInpBox"><input type="text" name="object_zc_price" id="" style="IME-MODE: disabled; " onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14" /></span><em>元</em><p class="errorMsg">支持金额应该小于等于本期融资总金额</p></dd>
				
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>说明图片:</dt>
				<dd>
					<div class="box setfileBox">
						<input type="text" name="video"  class="photoText" />
						<a href="javascript:void(0);"  class="link">浏览</a>
						<input type="file" class="SetloadFile" name="object_zc_img1" onchange="getFile(this,'video')" />
					</div>
					<div class="box setfileBox">
						<input type="text" name="copyFile"  class="photoText" />
						<a href="javascript:void(0);"  class="link">浏览</a>
						<input type="file" class="SetloadFile" name="object_zc_img2" onchange="getFile(this,'copyFile')" />
					</div>
					<div class="box setfileBox">
						<input type="text" name="copyFile1"  class="photoText" />
						<a href="javascript:void(0);"  class="link">浏览</a>
						<input type="file" class="SetloadFile" name="object_zc_img3" onchange="getFile(this,'copyFile1')" />
					</div>
					<p class="errorMsg">图片最大宽x高为400*300px,最大为5M，请选择合适图片</p>
				</dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>回复内容:</dt>
				<dd><span class="itemtextareaBox">
                <script id="editor" type="text/plain" style="width:1024px;height:500px;"></script>
                </span></dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>预计奖励日期:</dt>
				<dd><p class="SetTips">项目成功结束后预计</p><span class="itemInpBox"><input type="text" name="object_zc_time" id="" style="IME-MODE: disabled; " onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14" /></span><p class="errorMsg">填写证书</p></dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>是否限制名额:</dt>
				<dd>
					<div class="selproperty alarmradio">
						<span><input type="radio" class="radNo" id="num1" name="object_zc_xianzhi" value="1" /><label for='num1'>是</label></span>
						<span><input type="radio" class="radNo" id="num2" checked="checked" name="object_zc_xianzhi"  value="0" /><label for='num2'>否</label></span>
					</div>
				</dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>回报方式:</dt>
				<dd>
					<div class="selproperty alarmradio">
						<span><input type="radio" class="radNo" id="way1" name="object_zc_fangshi" value="发码" /><label for='way1'>发码</label></span>
						<span><input type="radio" class="radNo" id="way2" checked="checked" name="object_zc_fangshi" value="邮寄" /><label for='way2'>邮寄</label></span>
						<span><input type="radio" class="radNo" id="way3" name="object_zc_fangshi" value="邮寄+发码" /><label for='way3'>邮寄+发码</label></span>
					</div>
				</dd>
			</dl>
			<p class="setBtn"><input type="reset" class="PageBtn" value="取消" /><input type="submit" class="PageBtn" value="保存" /></p>
			<p class="itemPageBtn">                                     
                 <% if (Save("user_phone").ToString().Equals(""))
                { %>
                    <a href="javascript:void(0)" class="PageBtn showLogin">保存 & 下一步</a>
                 <% }
                else
                { %>
                     <a href="javascript:zc_submit()" class="PageBtn">保存 & 下一步</a>
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
<script type="text/javascript">
    var ue = UE.getEditor('editor');

    function html_encode(str) {
        var s = "";
        if (str.length == 0) return "";
        s = str.replace(/&/g, "&gt;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        s = s.replace(/ /g, "&nbsp;");
        s = s.replace(/\'/g, "&#39;");
        s = s.replace(/\"/g, "&quot;");
        s = s.replace(/\n/g, "<br>");
        return s;
    }   
    function zc_submit() {
        var obj = document.zcmpostForm;
        obj.action = "/Reception/index.aspx?ds=zc&cm=dsinsert4";
        obj.editorValue.value=html_encode(obj.editorValue.value);
        obj.submit();
    }
</script>
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
