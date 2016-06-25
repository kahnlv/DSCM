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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="choose_email1.aspx.cs" Inherits="Reception_templates_choose_email1" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/index.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/find.css" rel="stylesheet" type="text/css">
<div class="W1200 Mt98 ">
	<div class="find-password">
    	<h3>找回密码</h3>
        	<ul>
            	<li >
                	<span class="findnav">
                    	1.输入Email
                        <em></em>
                    </span>
                </li>
                <li>
                	<span >
                    	2.重设密码
                        
                    </span>
                </li>
                <li>
                	<span>
                    	3.完成
                        
                    </span>
                </li>
            </ul>
        
        	<div class="findroot"><span class="fL wid">输入Email：</span><input type="text" class="inputtext1"  /> <span class="current2">*格式不正确</span><span class="current2">*邮箱不存在</span></div>
        
       		<div class="findroot"><span class="fL wid ">验证码：</span><input type="text"  class="inputtext2"/><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/yanzhengma.png" class="yanzheng" /><span class="current2">*验证码错误</span></div>
            
       		<div class="findroot"><a href="<%=HTMLConfig.HTML_PATH_PAGE %>choose_email2.aspx"><input type="submit" value="下一步" class="inputsubmit" /></a></div>
           
    </div>
	
</div>
<script type="text/javascript">

</script>    
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
