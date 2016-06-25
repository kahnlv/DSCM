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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choose_phone2.aspx.cs" Inherits="Reception_templates_default_choose_phone2" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/index.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/find.css" rel="stylesheet" type="text/css">
<div class="W1200 Mt98 ">
	<div class="find-password">
    	<h3>找回密码</h3>
        	<ul>
            	<li >
                	<span class="findnav1" >
                    	1.输入手机号
                    </span>
                </li>
                <li>
                	<span class="findnav" >
                    	2.重设密码
                        <em></em>
                    </span>
                </li>
                <li>
                	<span>
                    	3.完成
                    </span>
                </li>
            </ul>
        
        	<div class="findroot"><span class="fL wid">手机号：</span><input type="text" class="inputtext1" value="" /> </div>
        
       		<div class="findroot"><span class="fL wid ">验证码：</span><input type="text"  class="inputtext2" value=""/><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/yanzhengma.png" class="yanzheng" /><span class="current2">*验证码错误</span></div>
            <div class="findroot"><input type="submit" value="获取动态吗" class="inputsubmit1" /><span class="fL">已发送</span></div>
            <div class="findroot"><span class="fL wid">动态码：</span><input type="text" class="inputtext1" value="" /><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/dui.png" class="dongtaiimg"/><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/cuo.png" class="dongtaiimg"/></div>
            <div class="findroot"><span class="fL wid">设置新密码：</span><input type="text" class="inputtext1" value="" /> <span class="fL" style="margin-right:20px;">密码长度必须在6~14个字符之间</span><span class="current2">*密码格式不正确</span></div>
            <div class="findroot"><span class="fL wid">确认密码：</span><input type="text" class="inputtext1" value="" /><span class="current2">*输入密码与新密码不一致</span></div> 
       		<div class="findroot"><a href="<%=HTMLConfig.HTML_PATH_PAGE %>choose_phone3.aspx"><input type="submit" value="确认提交" class="inputsubmit" /></a></div>
           
    </div>
	
</div>

<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
