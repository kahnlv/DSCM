<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 11:39:51 
* File name：order_index3 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_index3.aspx.cs" Inherits="Reception_templates_default_order_index3" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">


<div class="newItemNav">
	<div class="W1200">
		<ul class="orderlist">
			<li><div class="navitTit Newitem_01">订单提交</div><p class="itemNavBottom">1<em></em></p></li>
			<li><div class="navitTit Newitem_02">确认支付</div><p class="itemNavBottom">2<em></em></p></li>
			<li class="active"><div class="navitTit Newitem_03">支付成功</div><p class="itemNavBottom">3<em></em></p></li>
		</ul>
	</div>
</div>
<div class="W1200">
	<div class="orderCon paySucceed">
		<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/scuueedBg.png" alt="" />
		<h3 class="succTit">恭喜您，支付成功</h3>
		<p class="succJump"><em id="timer">3</em>秒后自动跳转</p><!-- 请参考setModule.js第146行 -->
	</div>
</div>
<div class="pB40"></div>

<script type="text/javascript">
    // 3秒后自动跳转
    function countDown(secs, surl) {
        //alert(surl);     
        var jumpTo = document.getElementById('timer');
        jumpTo.innerHTML = secs;
        if (--secs > 0) {
            setTimeout("countDown(" + secs + ",'" + surl + "')", 1000);
        }
        else {
            location.href = surl;
        }
    }
    //3秒后自动跳转
    countDown(3, '/Reception/index.aspx?ds=zc');
</script>
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
