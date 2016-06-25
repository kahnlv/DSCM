<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/17 10:23:54 
* File name：foot 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="foot.aspx.cs" Inherits="Reception_templates_default_public_foot" %>
<!-- footer -->
<div class="footer">
	<div class="footLine">
		<span class="bg-org"></span>
		<span class="bg-green"></span>
		<span class="bg-org"></span>
		<span class="bg-green"></span>
	</div>
	<div class="W1200">
		<ul class="footList clearfix">
			<li>
				<h3 class="footTit">关于我们</h3>
				<p class="footAboutCon">众筹平台志在帮助动漫爱好者们实现自己的梦想，呵护每一个动漫爱好者的理想。众筹平台志在帮助动漫爱好者们实现自己的梦想，呵护每一个动漫爱好者的理想。</p>
			</li>
			<li>
				<h3 class="footTit">热门支持</h3>
				<div class="footHotList">
					<a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/hot_01.png" width="60" height="60" alt="" /></a>
					<a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/hot_02.png" width="60" height="60" alt="" /></a>
					<a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/hot_03.png" width="60" height="60" alt="" /></a>
					<a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/hot_04.png" width="60" height="60" alt="" /></a>
					<a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/hot_05.png" width="60" height="60" alt="" /></a>
					<a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/hot_06.png" width="60" height="60" alt="" /></a>
				</div>
			</li>
			<li>
				<h3 class="footTit">近期线下活动</h3>
				<div class="recentList">
					<p><a href="#">150名实况足球爱好者陆家嘴正大交流会</a><em>2015年1月1日 </em></p>
					<p class="recenLine"></p>
					<p><a href="#">150名实况足球爱好者陆家嘴正大交流会</a><em>2015年1月1日 </em></p>
				</div>
			</li>
			<li>
				<h3 class="footTit">联系我们</h3>
				<div class="footContact">
					<p class="IocnUs01">上海市杨浦区水丰路100号图书馆二楼4楼众漫工作室</p>
					<p class="IocnUs02">021-6566 6566 <br />021-6566 8588</p>
					<p class="IocnUs03">上海市杨浦区水丰路100号图书馆二楼4楼众漫工作室</p>
				</div>
			</li>
		</ul>
	</div>
</div>
<!-- 登录&&注册弹出窗口 -->
<div class="popBox"></div>
<!-- 登录 -->
<div class="pop-container popLogin">
<form id="usermpostForm" name="usermpostForm" action="/Reception/index.aspx?ds=user&cm=login" method="post" onsubmit="">
	<p class="shut-down"><a href="javascript:void(0)" class="Popclose"></a></p>
	<h3 class="popTit">登录</h3>
	<p class="popImg"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/popTopbg.jpg" alt="" /></p>
	<dl class="popList">
		<dd>
            <span class="orderinpBox">
                <input type="text" id="" name="user_phone" value="用户名" class="Inpfocus">
            </span>
        </dd>
		<dd>
            <span class="orderinpBox"><input type="text" value="密码" class="clickTextfocus">
                <input type="password" value="" id="pwd" name="user_pwd" class="clickfocus">
            </span>
        </dd>
		<dd>
            <a href="<%=HTMLConfig.HTML_PATH_PAGE %>findout_choose.aspx" class="fR f-org">忘记密码？</a>
            <span class="settcheck">
            <input type="checkbox" class="Nodis" checked="checked" id="tally_1" name="checkbox1"><label for="tally_1" class="checked">记住密码</label>
            </span>
        </dd>
	</dl>
	<p class="PopBtnBox"><a href="javascript:submituserlogin()" class="Popbtn">登录</a></p>
	<p class="popIcon"><a href="#" class="weixin"></a><a href="#" class="weibo"></a></p>
	<p class="popReg"><a href="javascript:void(0)">免费注册</a></p>
</form>
</div>
<!-- 注册 -->
<div class="pop-container popRegister">

<form id="mpostForm" name="mpostForm" action="/Reception/index.aspx?ds=user&cm=regedit" method="post" onsubmit="">
	<p class="shut-down"><a href="javascript:void(0)" class="Popclose"></a></p>
	<h3 class="popTit">注册</h3>
	<dl class="popList">
		<dd>
            <span class="orderinpBox">
                <input type="text" id="" name="user_phone" value="请输入手机号" class="Inpfocus">
            </span>
        </dd>
		<dd>
            <span class="orderinpBox">
                <input type="text" value="请输入6-16位密码" class="clickTextfocus">
                <input type="password" value="" name="user_pwd" id="user_pwd" class="clickfocus">
            </span>
        </dd>
		<dd>
            <span class="orderinpBox">
            <input type="text" value="请再次输入6-16位密码" class="clickTextfocus">
            <input type="password" value="" id="user_pwd1" name="user_pwd1" class="clickfocus">
            </span>
        </dd>
		<dd>
            <span class="orderinpBox" style="width:110px">
                <input type="text" value="请输入图片中的数字" class="clickTextfocus">
                <input type="password" value="" name="user_code" id="password" class="clickfocus">
            </span>
            <img id="vdimgck" align="absmiddle" onClick="this.src='/Reception/index.aspx?ds=img&t=123'+Math.random()" style="cursor: pointer;" alt="看不清？点击更换" src="/Reception/index.aspx?ds=img" />
        </dd>
		<dd>
            <span class="orderinpBox" style="width:110px">
                <input type="text" value="请输入验证码" class="clickTextfocus">
                <input type="password" value="" name="phone_code" id="phone_code" class="clickfocus">
            </span>
            <a href="javascript:void(0)"class="fR authCode">获取验证码</a>
        </dd>
		<dd>
        <span class="settcheck">
        <input type="checkbox" class="Nodis" checked="checked" id="tally_1" name="checkbox1"><label for="tally_1" class="checked">阅读并同意众漫网的《服务协议》</label></span></dd>
	</dl>
	<p class="PopBtnBox"><a href="javascript:submituser()" class="Popbtn">注册</a></p>
	<p class="popbottomlog">已有账号，请<a href="javascript:void(0)"><em>登录</em></a></p>
</form>

<script>
    function submituser() {
        var obj = document.mpostForm;
        obj.submit();
    }
    function submituserlogin() {
        var obj = document.usermpostForm;
        obj.submit();
    }
</script>
</div>
<script src="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/require.js" data-main="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/main" ></script>
</body>
</html>