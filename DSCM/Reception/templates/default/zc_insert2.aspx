<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/21 10:13:57 
* File name：zc_insert2 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_insert2.aspx.cs" Inherits="Reception_templates_default_zc_insert2" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.all.min.js"> </script>

<form id="zcmpostForm" name="zcmpostForm" action="/Reception/index.aspx?ds=zc&cm=dsinsert2" method="post" onsubmit=""  enctype="multipart/form-data">
<div class="newItemNav">
	<div class="W1200">
		<ul class="NewNavlist">
			<li><div class="navitTit Newitem_01">项目信息</div><p class="itemNavBottom">1<em></em></p></li>
			<li class="active"><div class="navitTit Newitem_02">项目详情</div><p class="itemNavBottom">2<em></em></p></li>
			<li><div class="navitTit Newitem_03">回报设置</div><p class="itemNavBottom">3<em></em></p></li>
			<li><div class="navitTit Newitem_04">提交审核</div><p class="itemNavBottom">4</p></li>
		</ul>
	</div>
</div>
<div class="W1200">
	<div class="newItemCon clearfix">
		<h1 class="itemTopTit"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/projectTit.png" alt="" /></h1>
		<div class="ItemFormL">
			<dl class="ItemInfo clearfix nopB">
				<dt><em class="red">*</em>项目图片:</dt>
				<dd>
					<div class="box">
						<input type="text" name="copyFile"  class="textbox" />
						<a href="javascript:void(0);"  class="link">浏览</a>
						<input type="file" class="uploadFile" name="object_img" onchange="getFile(this,'copyFile')" />
					</div>
				</dd>
			</dl>
			<p class="proTopBorder"></p>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>项目视频:</dt>
				<dd>
					<div class="box">
						<input type="text" name="video"  class="textbox" />
						<a href="javascript:void(0);"  class="link">浏览</a>
						<input type="file" class="uploadVideo" name="object_video" onchange="getFile(this,'video')" />
					</div>
				</dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt><em class="red">*</em>项目介绍:</dt>
				<dd><span class="itemtextareaBox">
                <script id="editor" type="text/plain" style="width:1024px;height:500px;"></script>
                </span></dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt>已经开发时间:</dt>
				<dd><span class="itemInpBox"><input type="text" name="object_raise_start_time" id="" style="IME-MODE: disabled; " onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14" /></span><em>天</em></dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt>游戏开发周期:</dt>
				<dd><span class="itemInpBox"><input type="text" name="object_game_zhouqi" id="" style="IME-MODE: disabled; " onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14" /></span><em>天</em></dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt>已经有开发商:</dt>
				<dd>
					<div class="selproperty alarmradio">
						<span><input type="radio" class="radNo" id="proper01" name="object_kaifashang"  value="1"/><label for='proper01'>是</label></span>
						<span><input type="radio" class="radNo" id="proper02" checked="checked" name="object_kaifashang" value="0"/><label for='proper02'>否</label></span>
					</div>
				</dd>
			</dl>
			<dl class="ItemInfo clearfix">
				<dt>希望引入VC:</dt>
				<dd>
					<div class="selproperty alarmradio">
						<span><input type="radio" class="radNo" id="vc1" name="object_VC"  value="1"/><label for='vc1'>是</label></span>
						<span><input type="radio" class="radNo" id="vc2" checked="checked" name="object_VC" value="0"/><label for='vc2'>否</label></span>
					</div>
				</dd>
			</dl>
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

       obj.editorValue.value= html_encode(obj.editorValue.value);

        obj.submit();
    }
</script>
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
