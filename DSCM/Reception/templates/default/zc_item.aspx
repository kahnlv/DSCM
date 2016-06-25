<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/17 12:12:05 
* File name：zc_item 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_item.aspx.cs" Inherits="Reception_templates_default_zc_item" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<%

    DateTime dt1 = new DateTime();
    DateTime.TryParse(tbl_obj.Object_Start_Time, out dt1);
    DateTime dt2 = new DateTime();
    DateTime.TryParse(tbl_obj.Object_Stop_Time, out dt2);
    //TimeSpan dt = dt2 - dt1;
    TimeSpan dt;

    if (dt2 > DateTime.Now)
    {
        dt = dt2 - DateTime.Now;
    }
    else
    {
        dt = TimeSpan.Zero;
    }
 %>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<div class="itemBanner Mt58" style="background:url(<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBn_01.jpg) no-repeat center 0;"></div>
<div class="bannerLine"></div>
<div class="mainWarp W1024 pB40 clearfix">
	<div class="itemDetailsL">
		<h1 class="DetailTit"><%=tbl_obj.Object_Title%></h1>
		<p class="initiator"><span>发起人：<a href="#"><%=tbl_obj.User_Name %></a></span><span><%=tbl_obj.proname %><%=tbl_obj.cityname %></span></p>
		<div class="detaiLay">
			<ul class="detailNav fL">
				<li class="active"><a href="javascript:void(0)">项目主页</a></li>
				<li><a href="/Reception/index.aspx?ds=zc&cm=com&id=<%=object_id %>">评论（<%=obj_pl%>）</a></li>
				<li><a href="/Reception/index.aspx?ds=zc&cm=zhichi&id=<%=object_id %>">支持者（<%=zhichi%>）</a></li>
			</ul>
			<div class="shareWeibo fR">
				<a href="#" class="ico_01" title="sina"></a>
				<a href="#" class="ico_02" title="QQ"></a>
				<a href="#" class="ico_03" title="微信"></a>
				<a href="#" class="ico_04" title="share"></a>
				<a href="#" class="shareCounter">123</a>
			</div>
		</div>
		<div class="detaiCon">
			<%=HttpUtility.HtmlDecode(tbl_obj.Object_Content) %>
		</div>
		<div class="detaiCorner">
			<span>分类：<a href="#"><%=tbl_obj.Object_Class%></a></span>
			<span>标签：<%=tbl_obj.Object_Label%></span>
		</div>
		<div class="detaiPortpe">
			<h2 class="portpeTit">热门推荐</h2>
			<ul class="portpeList">
				<%=model.ReadModel("/Reception/templates/default/public/remen.aspx?c=4&type=rm")%>
			</ul>
		</div>
	</div>
	<div class="itemDetailsR">
		<div class="itembor statistics">
        <% 
                          decimal dc1 = 0;
                          decimal dc2 = 0;
                          decimal.TryParse(tbl_obj.Object_Raise_Price, out dc1);
                          decimal.TryParse(tbl_obj.Object_Raise_Ready_Manry, out dc2);
                          if (dc1 == 0) dc1 = 9999999;
    %>
			<p class="f-01"><em>￥</em><%=tbl_obj.Object_Raise_Ready_Manry %></p>
			<p class="f-02">目前累计资金</p>
			<p class="f-02">此项目必须在 <%=tbl_obj.Object_Stop_Time%>前得到￥<%=tbl_obj.Object_Raise_Price%>的支持才可成功</p>
			<p class="itemBarBox"><span class="itemBar"><em style="width:<%  Response.Write((Math.Round((dc2 / dc1) * 100,2)).ToString());%>%"></em></span><span class="itemBartips"><% 
                    Response.Write((Math.Round((dc2 / dc1) * 100, 2)).ToString());
    %>%</span></p>
			<dl class="itemRaising">
				<dd><em><%=dt.Days%>天</em>剩余时间</dd>
				<dd><em><%=zhichi%></em>支持</dd>
				<dd><em><%=tbl_obj.xhcount%></em>喜欢</dd>
			</dl>
		</div>
		<p class="supLink">        
             <% if (Save("user_phone").ToString().Equals(""))
            { %>
                <a href="javascript:void(0)" style="text-align: center;" class="supportHash fL showLogin"><em>支持</em></a>
                <a href="javascript:void(0)" style="text-align: center;" class="like_top fL showLogin"><em>喜欢</em></a>
             <% }
            else
            { %>
              <input type="hidden" id="obj_id" value="<%=tbl_obj.Object_Id%>"/>
              <a href="/Reception/index.aspx?ds=zhichi&id=<%=tbl_obj.Object_Id%>" class="supportHash fL"><em>支持</em></a>
			  <a href="/Reception/index.aspx?ds=zc&cm=dsxhinsert&id=<%=tbl_obj.Object_Id%>" class="like_top fL"><em>喜欢</em></a>
           <% } %>     			
		</p>
        <% 
            foreach (DSCM.ds_tbl_object_zc.tbl_object_zc ozc in obj_zc)
            {
        %>
		<div class="itembor itemMiddle">
			<h3 class="itemMtit"><em>￥<%=ozc.Object_Zc_Price %></em>已有<%=ozc.zccount%>位支持者</h3>
			<div class="itemMidCon">
            	<%if (ozc.Object_Zc_Doc.Length > 60) { Response.Write(HttpUtility.HtmlDecode(ozc.Object_Zc_Doc.Substring(0, 60))); } else { Response.Write(HttpUtility.HtmlDecode(ozc.Object_Zc_Doc)); } %>
				<%--<%=HttpUtility.HtmlDecode(ozc.Object_Zc_Doc) %>--%>
			</div>
		</div>	
          <% if (Save("user_phone").ToString().Equals(""))
         { %>
             <a href="javascript:void(0)" style="text-align: center;" class="sustainLink showLogin">支持<%=ozc.Object_Zc_Price %></a>
          <% }
         else
         { %>
             <a href="/Reception/index.aspx?ds=order&obj_zc_id=<%=ozc.Object_Zc_Id %>" class="sustainLink">支持<%=ozc.Object_Zc_Price %></a>
          <% } %>       
		 
        <% } %>

		<div class="intereWarp clearfix">
			<h3 class="intereTit">你可能感兴趣的项目</h3>
			
            <ul class="interList">
				<%=model.ReadModel("/Reception/templates/default/public/remen.aspx?c=3&type=gxq")%>
			</ul>


		</div>
		<div class="advertisement"><a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/2014A15641fagw14.jpg" alt="" /></a></div>
	</div>
</div>

<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>