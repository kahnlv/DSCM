<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/17 10:17:01 
* File name：zc_index 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_index.aspx.cs" EnableEventValidation="false" Inherits="Reception_templates_default_zc_index" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/index.css" rel="stylesheet" type="text/css">
<div class="banner_nivoSlider">
	<ul class="slider">
		<li><span class="bannerBg01"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/banner_01.jpg" alt="" /></span>
        <a href="#" class="bannerLink"><em>瞄瞄</em></a><em class="bannerDownBg"></em></li>
		<li><span class="bannerBg02"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/banner_01.jpg" alt="" /></span>
        <a href="#" class="bannerLink"><em>瞄瞄</em></a><em class="bannerDownBg"></em></li>
		<li><span class="bannerBg02"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/banner_01.jpg" alt="" /></span>
        <a href="#" class="bannerLink"><em>瞄瞄</em></a><em class="bannerDownBg"></em></li>
		<li><span class="bannerBg02"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/banner_01.jpg" alt="" /></span>
        <a href="#" class="bannerLink"><em>瞄瞄</em></a><em class="bannerDownBg"></em></li>
	</ul>
	<ul class="controlNav">
	</ul>
</div>
<div class="bannerLine"></div>
<!-- main -->
<div class="mainWarp W1200">
	<div class="ItemSubWarp">
		<dl class="ItemList clearfix">
			<dt>
				<a href="/Reception/index.aspx?ds=zc&cm=list&type=动漫" class="radiusLTop">
					<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBg01.jpg" alt="" height="460" />
					<em class="itemTit">动漫</em>
					<span class="itemText ItemIcon01-h"><em class="ItemHoverTit">动漫</em><em class="ItemsubTit">本站集结众多动画与漫画的众筹项目</em></span>
					<span class="markLay"></span><i class="itemBorder_01"></i>
				</a>
			</dt>
			<dd>
				<a href="/Reception/index.aspx?ds=zc&cm=list&type=游戏" class="radiusRTop">
					<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBg02.jpg" alt="" height="230" />
					<em class="itemTit">游戏</em>
					<span class="itemText ItemIcon02-h"><em class="ItemHoverTit">游戏</em><em class="ItemsubTit">本站集结众多动画与漫画的众筹项目</em></span>
					<span class="markLay"></span><i class="itemBorder_02"></i>
				</a>
				<a href="/Reception/index.aspx?ds=zc&cm=list&type=Cosplay">
					<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBg03.jpg" alt="" height="230" />
					<em class="itemTit">Cosplay</em>
					<span class="itemText ItemIcon01-h"><em class="ItemHoverTit">Cosplay</em><em class="ItemsubTit">本站集结众多动画与漫画的众筹项目</em></span>
					<span class="markLay"></span><i class="itemBorder_03"></i>
				</a>
			</dd>
			<dt>
				<a href="/Reception/index.aspx?ds=zc&cm=list&type=漫画">
					<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBg04.jpg" alt="" height="230" />
					<em class="itemTit">漫画</em>
					<span class="itemText ItemIcon02-h"><em class="ItemHoverTit">漫画</em><em class="ItemsubTit">本站集结众多动画与漫画的众筹项目</em></span>
					<span class="markLay"></span><i class="itemBorder_04"></i>
				</a>
				<a href="/Reception/index.aspx?ds=zc&cm=list&type=模型制作" class="radiusLBottom">
					<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBg05.jpg" alt="" height="230" />
					<em class="itemTit">模型制作</em>
					<span class="itemText ItemIcon01-h"><em class="ItemHoverTit">模型制作</em><em class="ItemsubTit">本站集结众多动画与漫画的众筹项目</em></span>
					<span class="markLay"></span><i class="itemBorder_05"></i>
				</a>
			</dt>
			<dd>
				<a href="/Reception/index.aspx?ds=zc&cm=list&type=影视" class="radiusRBottom">
					<img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBg06.jpg" alt="" height="460" />
					<em class="itemTit">影视</em>
					<span class="itemText ItemIcon02-h"><em class="ItemHoverTit">影视</em><em class="ItemsubTit">本站集结众多动画与漫画的众筹项目</em></span>
					<span class="markLay"></span><i class="itemBorder_06"></i>
				</a>
			</dd>
		</dl>
	</div>
	<div class="mainContact W1200 clearfix">
		<div class="MainconL">
			<ul class="MitemList clearfix">
<% 
    foreach (DSCM.ds_tbl_object.tbl_object tb in t_obj)
    {
        DateTime dt1 = new DateTime();
        DateTime.TryParse(tb.Object_Start_Time, out dt1);
        DateTime dt2 = new DateTime();
        DateTime.TryParse(tb.Object_Stop_Time, out dt2);
        TimeSpan dt = dt2 - dt1;
%>
				<li>
					<a class="mitemImg" href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tb.Object_Id %>"><img style="width:249px;height:229px" src="<%=tb.Object_Img.Replace("big","saml") %>" alt="" /></a>
					<p class="mainTit"><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tb.Object_Id %>">
                   
                    <%if (tb.Object_Title.Length > 30) { Response.Write(HttpUtility.HtmlDecode(tb.Object_Title.Substring(0, 30))); } else { Response.Write(HttpUtility.HtmlDecode(tb.Object_Title)); } %>
                    </a></p>
					<div class="mainSubCon">
						<%if (tb.Object_Doc.Length > 200) { Response.Write(HttpUtility.HtmlDecode(tb.Object_Doc.Substring(0, 200))); } else { Response.Write(HttpUtility.HtmlDecode(tb.Object_Doc)); } %>
					</div>
					<div class="sustain">
						<div class="fL w566">
							<dl class="raising">
								<dd><em><% 
                          decimal dc1 = 0;
                          decimal dc2 = 0;
                          decimal.TryParse(tb.Object_Raise_Price, out dc1);
                          decimal.TryParse(tb.Object_Raise_Ready_Manry,out dc2);
                          Response.Write(((dc2/dc1) * 100).ToString());
    %>%</em>已达到</dd>
								<dd><em>￥<%=tb.Object_Raise_Ready_Manry %></em>已筹集</dd>
								<dd class="Nobor"><em><%=dt.Days%>天</em>剩余时间</dd>
							</dl>
							<p class="progressBar"><span class="progress" style="width:<%=((dc2/dc1) * 100) %>%"></span></p>
						</div>                             
                        <% if (Save("user_phone").ToString().Equals(""))
                       { %>
                           <a href="javascript:void(0)" class="sustainTit fR sustainTit2 showLogin">支持</a>
                        <% }
                       else
                       { %>
                          <a href="/Reception/index.aspx?ds=zhichi&id=<%=tb.Object_Id%>" class="sustainTit fR sustainTit2">支持</a>
                      <% } %>    						
					</div>
					<span class="endTips"><em><%=dt.Days%></em>天结束</span>
				</li>
<% 
    }        
%>
			</ul>
		</div>
		<div class="MainconR">
			<div class="mainRbor mB10">
				<h3 class="mainRtit"><span class="IconR_01">公告</span></h3>
				<div class="msgCon">本站于2014年12月01日起支持新浪微博和腾讯微博\QQ快捷登陆接口注册提交信息为（用户名、手机号-验证码/邮箱-验证链接、密码）本站于2014年12月01日起支持新浪微博和腾讯微博\QQ快捷登陆接口注册</div>
			</div>
			<div class="mainRbor mB5">
				<h3 class="mainRtit"><span class="IconR_02">热点新闻</span></h3>
				<ul class="hotNewList clearfix">
					<li><a href="#">迪斯尼米老鼠Cosplay童装</a>100元1套<em class="hotTime">2015年1月1日</em></li>
					<li><a href="#">迪斯尼米老鼠Cosplay童装</a>100元1套<em class="hotTime">2015年1月1日</em></li>
					<li><a href="#">迪斯尼米老鼠Cosplay童装</a>100元1套<em class="hotTime">2015年1月1日</em></li>
					<li><a href="#">迪斯尼米老鼠Cosplay童装</a>100元1套<em class="hotTime">2015年1月1日</em></li>
				</ul>
				<p class="hotNewPage"><a href="#" class="hotPre"></a><a href="" class="hotNext"></a></p>
			</div>
			<div class="mainRbor noBottom">
				<h3 class="mainRtit"><span class="IconR_03">圈热点</span></h3>
				<ul class="roundList clearfix">
					<li>
						<a href="#" class="ImgL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201411301925img_01.jpg" alt="" /></a>
						<p class="memberCon">小鸟就这么愤怒了，太霸道了！</p>
						<p class="partake"><span>参与<em>56105</em></span></p>
					</li>
					<li>
						<a href="#" class="ImgL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201411301925img_02.jpg" alt="" /></a>
						<p class="memberCon">小鸟就这么愤怒了，太霸道了！</p>
						<p class="partake"><span>参与<em>56105</em></span></p>
					</li>
					<li>
						<a href="#" class="ImgL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201411301925img_03.jpg" alt="" /></a>
						<p class="memberCon">小鸟就这么愤怒了，太霸道了！</p>
						<p class="partake"><span>参与<em>56105</em></span></p>
					</li>
				</ul>
				<p class="MemberNewPage"><a href="#" class="hotPre"></a><a href="" class="hotNext"></a></p>
			</div>
			<div class="mainRbor mainNotop">
				<h3 class="mainRtit"><span class="IconR_03">会员中心</span></h3>
				<ul class="roundList clearfix">
					<li>
						<a href="#" class="ImgL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201411301925img_04.jpg" alt="" /></a>
						<p class="memberCon">小鸟就这么愤怒了，太霸道了！</p>
						<p class="partake"><span>参与<em>56105</em></span></p>
					</li>
					<li>
						<a href="#" class="ImgL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201411301925img_05.jpg" alt="" /></a>
						<p class="memberCon">小鸟就这么愤怒了，太霸道了！</p>
						<p class="partake"><span>参与<em>56105</em></span></p>
					</li>
					<li>
						<a href="#" class="ImgL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201411301925img_03.jpg" alt="" /></a>
						<p class="memberCon">小鸟就这么愤怒了，太霸道了！</p>
						<p class="partake"><span>参与<em>56105</em></span></p>
					</li>
				</ul>
				<p class="MemberNewPage"><a href="#" class="hotPre"></a><a href="" class="hotNext"></a></p>
			</div>
		</div>
	</div>
</div>
<!-- 项目数字 -->
<div class="odometerWarp">
	<ul class="odometerNum clearfix">
		<li><span class="OdNum"><%=objcount %></span><em class="OdSubTit odIcon01">项目总数</em></li>
		<li><span class="OdNum"><%=pescount %></span><em class="OdSubTit odIcon02">累计支持人</em></li>
		<li><span class="OdNum"><%=zc_pes.Object_Zc_Pes_Price.Equals("") ? "0" : zc_pes.Object_Zc_Pes_Price %></span><em class="OdSubTit odIcon03">累计筹资金额</em></li>
	</ul>
</div>
<!-- 成功案例 -->
<div class="successCaseWarp W1200">
	<h2 class="successTit">成功案例</h2>
	<ul class="successList clearfix">
    <% foreach (DSCM.ds_tbl_object.tbl_object tobject in tobj)
       {
    %>

		<li>
            <a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tobject.Object_Id %>">
            <img src="<%=tobject.Object_Img %>" alt="" />
            <span class="sucSubText"><%=tobject.Object_Title %></span>
            <em class="stateText"><%=tobject.Object_Title %></em>
            </a>
        </li>
    <% } %>
        <%--<li><a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/20141130006.jpg" alt="" /><span class="sucSubText">来和若水</span><em class="stateText">一起建设一个免费画画的艺术空间</em></a></li>
		<li><a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/20141130007.jpg" alt="" /><span class="sucSubText">来和若水</span><em class="stateText">一起建设一个免费画画的艺术空间</em></a></li>
		<li><a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/20141130008.jpg" alt="" /><span class="sucSubText">来和若水</span><em class="stateText">一起建设一个免费画画的艺术空间</em></a></li>--%>
	</ul>
</div>
<div class="bottomGameBg">
	<div id="GameMarquee">
		<ul class="marqueList">
			<li><a href="#1"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/bottomImg01.png" alt="" /></a></li>
			<li><a href="#2"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/bottomImg02.png" alt="" /></a></li>
			<li><a href="#3"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/bottomImg03.png" alt="" /></a></li>
			<li><a href="#4"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/bottomImg04.png" alt="" /></a></li>
			<li><a href="#5"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/bottomImg05.png" alt="" /></a></li>
			<li><a href="#6"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/bottomImg03.png" alt="" /></a></li>
		</ul>
	</div>	
	<a href="/Reception/index.aspx?ds=zc&cm=faqi" class="bottomGameText">让梦想照进现实</a>
</div>

<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>