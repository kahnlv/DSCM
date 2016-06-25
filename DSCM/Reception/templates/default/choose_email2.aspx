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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choose_email2.aspx.cs" Inherits="Reception_templates_default_choose_email2" %>
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
        <p>
        <i></i><span>密码重设邮件已发送到：264399@qq.com</span>
        </p>
        <p style="margin-bottom:240px;"><span class="fontshe" style="padding-left:34px;">请点击邮件中的密码重设链接，即可进行密码重设。</span></p>	           
    </div>
	
</div>
<script type="text/javascript">
    this.location.href = "/Reception/templates/default/choose_email3.aspx";
</script>
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
