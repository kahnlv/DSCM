<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 16:51:42 
* File name：zhichi 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhichi_index.aspx.cs" Inherits="Reception_templates_default_zhichi" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">

<form id="zccominsertmpostForm" name="zccominsertmpostForm" action="/Reception/index.aspx?ds=zhichi&cm=dsindex" method="post" onsubmit="">
<div class="newItemNav">
	<div class="W1200">
    <% 
        string str = obj.User_Name;
        
        %>
		<h1 class="suppTit"><%=obj.Object_Title %></h1>
		<p class="suppSubtit"><%=obj.User_Name%></p>
	</div>
</div>
<div class="W1200">
	<div class="orderCon clearfix">
		<h3 class="Ftit24">支持一下吧！</h3>
		<p class="FsubTit18">请输入您要支持的金额</p>
		<p class="itemSupfrom"><input type="text" name="object_zc_pes_price" id="object_zc_pes_price" class="itemSuptext" value="1" /><em>请根据您的兴趣来输入支持金额最少支持&1</em></p>
	</div>
	<div class="orderCon mT30">
		<p class="FsubTit18 pTB20">选择令您中意的回报</p>
		<ul class="supportForm clearfix">

			<li>
				<span class="settcheck"><input type="checkbox" name="checkbox1" id="tally_1" class="Nodis" value="" checked="checked"/><label for="tally_1"><strong>不需要回报</strong></label></span>
				<em>不需要回报，任性的支持这份梦想</em>
				<div class="disabled"></div>
			</li>

<%
foreach (DSCM.ds_tbl_object_zc.tbl_object_zc zc in obj_zc)
{            
%>
			<li class="cur">
				<span class="settcheck">
              <input type="checkbox" name="checkbox1" id="tally_2" class="Nodis" value="<%=zc.Object_Zc_Id %>"/>
                 <label for="tally_1">￥<%=zc.Object_Zc_Price %></label><i>已支持<%=zc.zccount%>次</i>
                </span>
				<em><%=HttpUtility.HtmlDecode(zc.Object_Zc_Doc) %></em>
				<div class="disabled"></div>
            </li>
<% 
                
}
%>
		</ul>
        <input name="obj_id" type="hidden" value="<%=obj.Object_Id %>"/>
		<p class="setBtn pL40">                                    
           <% if (Save("user_phone").ToString().Equals(""))
          { %>
               <input type="button" style="text-align: center;" class="PageBtn showLogin" value="去下单" />
           <% }
          else
          { %>
              <input type="submit" class="PageBtn" value="去下单" />
         <% } %>    	      
        </p>
	</div>
</div>
<div class="pB40"></div>
</form>

<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
