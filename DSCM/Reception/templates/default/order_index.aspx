<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 10:20:39 
* File name：order_index 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_index.aspx.cs" Inherits="Reception_templates_default_order_index" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/jquery-1.9.1.min.js"></script>
<script type="text/javascript">
    function checInput(regstr, objvalue, errornote) {
        if (!regstr.test(objvalue)) {
            document.getElementById(errornote).innerHTML = "您输入的格式不正确！";
        }
        else {
            document.getElementById(errornote).innerHTML = "";
        }
    }
    function checkPostCode() {
        var obj = document.order_zcmpostForm;
        var regPostCode = /^\d{6}$/;
        checInput(regPostCode, obj.user_delivery_address_city_code.value, "noticePostCode");
    }
    function checkEmail() {
        var obj = document.order_zcmpostForm;
        var regEmail = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+(\.[a-zA-Z]{2,3})+$/;
        if (obj.user_delivery_address_user_email.value != "") {
            checInput(regEmail, obj.user_delivery_address_user_email.value, "noticeEmail");
        }
    }
    function checkMobile() {
        var obj = document.order_zcmpostForm;
        var regMobile = /^1[3,4,5,8]\d{9}$/;
        checInput(regMobile, obj.user_delivery_address_user_phone.value, "noticePhone");
    }
</script>
<div class="newItemNav">
	<div class="W1200">
		<ul class="orderlist">
			<li class="active"><div class="navitTit Newitem_01">订单提交</div><p class="itemNavBottom">1<em></em></p></li>
			<li><div class="navitTit Newitem_02">确认支付</div><p class="itemNavBottom">2<em></em></p></li>
			<li><div class="navitTit Newitem_03">支付成功</div><p class="itemNavBottom">3<em></em></p></li>
		</ul>
	</div>
</div>
<div class="W1200">
	<div class="orderCon mB20">
		<div class="orderItem clearfix">
			<img src="<%=tbl_obj.Object_Img%>" alt="" style="width:318px;height:248px"/>			
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
 

<form id="order_zcmpostForm" name="order_zcmpostForm" action="/Reception/index.aspx?ds=order&cm=dsinsert" method="post" onsubmit=""  enctype="multipart/form-data">
		<div class="orderinfo clearfix">
			<div class="clearfix">
				<span class="settcheck"><input type="checkbox" name="checkbox1" id="tally_1" checked="checked" class="Nodis" /><label for="tally_1">不计回报，慷慨支持！</label></span>
			</div>
			<p class="orderTopline"></p>
			<h2 class="orderinfoTit">填写收件人信息:</h2>			
		</div>
		<dl class="ItemInfo clearfix">
			<dt><em class="red">*</em>收件人姓名:</dt>
			<dd><span class="orderinpBox"><input type="text" name="user_delivery_address_user_relname" id="user_delivery_address_user_relname" /></span></dd>
		</dl>
		<dl class="ItemInfo clearfix">
			<dt><em class="red">*</em>省份/直辖市:</dt>
			<dd>
				<div class="smgSelectWrap listTabSel fL">
						<div class="smgSelectText" title="请选择" id="smgSelectText">请选择</div>
						<input type="hidden" value="1" name="user_delivery_address_city">
						<div class="smgSelectListWrap">
							<div class="smgSelectList">
                            <% foreach (DSCM.ds_tbl_province.tbl_province p in province)
                               { %>
								<p val="<%=p.DI %>" class="smgIthems"><%=p.Provincename %></p>
                            <% } %>
							</div>
						</div>
				</div>
				<div class="smgSelectWrap listTabSel fL">
						<div class="smgSelectText" title="请选择">请选择</div>
						<input type="hidden" value="1" name="user_delivery_address_city"/>
						<div class="smgSelectListWrap">
							<div class="smgSelectList" id="smgSelectList">
								
							</div>
						</div>
				</div>
			</dd>
		</dl>
		<dl class="ItemInfo clearfix">
			<dt><em class="red">*</em>详细地址:</dt>
			<dd><span class="orderinpBox"><input type="text" name="user_delivery_address_user_address" id="user_delivery_address_user_address" /></span></dd>
		</dl>
		<dl class="ItemInfo clearfix">
			<dt><em class="red">*</em>邮政编码:</dt>
			<dd><span class="orderinpBox"><input type="text" name="user_delivery_address_city_code" id="user_delivery_address_city_code" onblur="checkPostCode()" maxlength="6"/></span>
                <span style="color:red;" class="error" id="noticePostCode"></span> 
            </dd>

		</dl>
		<dl class="ItemInfo clearfix">
			<dt>收件人邮箱:</dt>
			<dd><span class="orderinpBox"><input type="text" name="user_delivery_address_user_email" id="user_delivery_address_user_email" onblur="checkEmail()"/></span>
                <span style="color:red;" class="error" id="noticeEmail"></span> 
            </dd>
		</dl>
		<dl class="ItemInfo clearfix">
			<dt><em class="red">*</em>收件人手机:</dt>
			<dd><span class="orderinpBox"><input type="text" name="user_delivery_address_user_phone" id="user_delivery_address_user_phone" onblur="checkMobile()" maxlength="11"/></span>
                <span style="color:red;" class="error" id="noticePhone"></span> 
            </dd>
		</dl>
		<dl class="ItemInfo clearfix">
			<dt>备注:</dt>
			<dd><span class="itemtextareaBox"><textarea name="order_doc" id="order_doc" rows="10"></textarea></span></dd>
		</dl>
		<p class="orderTips"> <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/icon_25.png" class="fL" alt="" /> 
        风险提示:中抽中的产品多为尚在开发，因此众筹成功到你收到回报之间可能需要一段等待时间；如果项目发起方无法按约定的时间发出回报，众漫网将督促发起方向支持者进行说明并积极解决问题，请大家耐心等待</p>
		<p class="orderAmount">实际支付总金额: <span>￥<%= raisemoney %></span><em>(免运费)</em></p>
		<p class="itemPageBtn" style="width:68.5%"><a href="javascript:order_submit()" class="PageBtn">确认 & 下一步</a></p>
        <input type="hidden" name="object_zc_id" id="object_zc_id" value="<%=object_zc_id %>"/>
        <input type="hidden" name="object_id" id="object_id" value="<%=object_id %>" />
</form>
	</div>
</div>
<div class="pB40"></div>
<script type="text/javascript">

    function order_submit() {
        var obj = document.order_zcmpostForm;
        obj.submit();
    }

</script>

<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
