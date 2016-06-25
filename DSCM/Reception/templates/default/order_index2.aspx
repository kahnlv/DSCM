<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 11:34:51 
* File name：order_index2 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_index2.aspx.cs" Inherits="Reception_templates_default_order_index2" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">


<div class="newItemNav">
	<div class="W1200">
		<ul class="orderlist">
			<li><div class="navitTit Newitem_01">订单提交</div><p class="itemNavBottom">1<em></em></p></li>
			<li class="active"><div class="navitTit Newitem_02">确认支付</div><p class="itemNavBottom">2<em></em></p></li>
			<li><div class="navitTit Newitem_03">支付成功</div><p class="itemNavBottom">3<em></em></p></li>
		</ul>
	</div>
</div>
<div class="W1200">
	<div class="orderCon mB20">
		<div class="orderItem clearfix">
			<img src="<%=tbl_obj.Object_Img%>" alt="" />			
			<div class="orderRTop">
				<h1 class="orderTit"><%=tbl_obj.Object_Title%></h1>
				<p>回报内容：</p>
				<p><%=obj_zc.Object_Zc_Doc %></p>
				<p>回报档：￥<%=obj_zc.Object_Zc_Price%></p>
				<p>邮费：包邮</p>
				<p>回报方式：<%=obj_zc.Object_Zc_Fangshi%></p>
				<p>汇报时间：众筹结束后<%=obj_zc.Object_Zc_Time%>天</p>
			</div>
		</div>
	</div>
	<div class="orderCon">

   <form id="order_zcmpostForm" name="order_zcmpostForm" action="/Reception/index.aspx?ds=order&cm=dsinsert2" method="post" onsubmit=""  enctype="multipart/form-data">
		<div class="orderinfo clearfix">
			<h2 class="orderinfoTit">请选择支付方式:</h2>			
		</div>
		<div class="orderBank clearfix">
			<div class="alipay clearfix">
				<span class="Selbank">
					<em class="alarmradio"><input type="radio" class="radNo"  checked="checked" id="vc1" name="vc"  /><label for='vc1'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_01.jpg" alt="支付宝" /></label></em>					
				</span>
			</div>
			<div class="orderLine clearfix">
				<p class="orderBankTit">网银支付</p>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc2" name="vc" /><label for='vc2'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_02.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc3" name="vc" /><label for='vc3'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_03.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc4" name="vc" /><label for='vc4'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_04.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc5" name="vc" /><label for='vc5'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_05.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc6" name="vc" /><label for='vc6'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_06.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc7" name="vc" /><label for='vc7'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_07.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc8" name="vc" /><label for='vc8'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_08.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc9" name="vc" /><label for='vc9'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_09.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc10" name="vc" /><label for='vc10'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_10.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc11" name="vc" /><label for='vc11'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_11.jpg" alt="" /></label></em>
				</span>
				<span class="Selbank ">
					<em class="alarmradio"><input type="radio" class="radNo" id="vc12" name="vc" /><label for='vc12'><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/bank_12.jpg" alt="" /></label></em>
				</span>
			</div>
		</div>
		<p class="itemPageBtn" style="width:90%"><a href="javascript:order_submit()" class="PageBtn">确认付款</a></p>
        <input type="hidden" name="object_zc_id" id="object_zc_id" value="<%=object_zc_id %>"/>
        <input type="hidden" name="object_id" id="object_id" value="<%=object_id %>" />
        <input type="hidden" name="order_id" id="order_id" value="<%=order_id %>" />
      </form>
	</div>
</div>
<div class="pB40"></div>
<script type="text/javascript">
    function order_submit() {
        var obj = document.order_zcmpostForm;
        obj.submit();
    }
//    function order_submit() {
//        $.ajax({
//            type: "post",
//            async: false,
//            url: "/Reception/index.aspx?ds=order&cm=dsinsert2",
//            success: function (result) {
//                if (result == "1") {
//                    location.href = "/Reception/index.aspx?ds=order&cm=index3";
//                }
//                else {
//                    alert("支付失败！");
//                }
//            }
//        });
//    }

</script>


<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
