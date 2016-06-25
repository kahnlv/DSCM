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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choose_email4.aspx.cs" Inherits="Reception_templates_default_choose_email4" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/index.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/find.css" rel="stylesheet" type="text/css">
<div class="W1200 Mt98 ">
	<div class="find-password">
    	<h3>找回密码</h3>
        	<ul>
            	<li >
                	<span class="findnav1">
                    	1.输入Email
                    </span>
                </li>
                <li>
                	<span class="findnav1">
                    	2.重设密码
                       
                    </span>
                </li>
                <li>
                	<span  class="findnav">
                    	3.完成
                    </span>
                </li>
            </ul>
         <div class="funtirimg"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/scuueedBg.png" /></div>
        <p class="tec">
        <span>恭喜你，密码设置成功。</span>
        </p>
        <p class="tec"><span class="fontshe">你可以使用新密码登录格瓦拉生活网。</span></p>	
        <div class="funtirimg1"><input type="submit" class="inputsubmit"  value="确认提交"/><a href="/Reception/index.aspx?ds=zc" class="current2">返回众漫网首页</a></div>           
    </div>
	
</div>
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>