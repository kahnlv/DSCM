<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_share.aspx.cs" Inherits="Reception_templates_default_quanzi_share" %>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>

	<div class="type_nav">
		<ul class="clearfix">
<%--			<li style="border-left:0;"><a href="#">浏览</a></li>
			<li class="hover"><a href="/Reception/index.aspx?ds=quanzi&cm=biaoqian">标签</a></li>
			<li><a href="#">品牌</a></li>
			<li><a href="#">话题</a></li>
			<li><a href="#">专题</a></li>--%>
			<li><a href="/Reception/index.aspx?ds=quanzi&cm=daren">达人</a></li>
		<%--	<li style="border-right:0;width:125px;"><a href="#">模板</a></li>--%>
		</ul>
	</div>
	<div id="container" class="clearfix">
		<div class="main fl">
			<ul class="part">
				<li class="clearfix" style="margin-bottom:0;">
					<div class="part_face fl"><img src="<%=article.user.User_Img.Replace("/big/","/saml/") %>" alt="" width="80" height="80" /></div>
					<div class="part_con fr">
						<div class="part_bg"></div>
						<div class="part_title"><%=article.Article_Title %><span>-众漫推荐</span></div>
						<div class="part_p">
							<img src="<%=article.Article_Pic %>" alt="" class="mr25 mb40 fl"  width="160" height="200" />
                             <%=System.Web.HttpUtility.UrlDecode(article.Article_Contents) %>
						</div>
							<a class="part_more fl" href="/Reception/index.aspx?ds=quanzi&cm=arcdetail&id=<%=article.Article_Id%>">展开</a>
						<div class="part_bottom fl">
							<div class="type fl clearfix"><span></span>
                                  <%foreach (string bq in article.bqs)
                                  {%>
                                      <a href="#" class="grey"><%=bq %></a>
                                  <%} %>
							</div>
							<ul class="discuss fr clearfix">
								<li><a href="#">热度(0)</a></li>  <%-- <%=article.Article_Hot %>--%>
								<li><a href="/Reception/index.aspx?ds=quanzi&cm=discuss&id=<%=article.Article_Id %>">评论(<%=article.plnum %>)</a></li>
								<li><a href="javascript:void(0)">分享</a></li>
								<li><a href="#">推荐</a></li>
								<li style="padding:0;"><a href="#" style=" display:block;width:30px; height:30px;"></a></li>
							</ul>
						</div>
					</div>
				</li>
				<div class="comment fr">
					<div class="comment_bg right1"></div>
					<%--<ul class="share clearfix ml30">
						<li><a href="#" class="bg1">微信</a></li>
						<li><a href="#" class="bg2">新浪微博</a></li>
						<li><a href="#" class="bg3">QQ空间</a></li>
						<li><a href="#" class="bg4">百度贴吧</a></li>
						<li><a href="#" class="bg5">QQ空间</a></li>
						<li><a href="#" class="bg6">我的主页</a></li>
					</ul>--%>
                    <div class="bdsharebuttonbox"><a href="#" class="bds_more" data-cmd="more"></a><a href="#" class="bds_qzone" data-cmd="qzone"></a><a href="#" class="bds_tsina" data-cmd="tsina"></a><a href="#" class="bds_tqq" data-cmd="tqq"></a><a href="#" class="bds_renren" data-cmd="renren"></a><a href="#" class="bds_weixin" data-cmd="weixin"></a></div>
<script>window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdPic": "", "bdStyle": "0", "bdSize": "32" }, "share": {}, "image": { "viewList": ["qzone", "tsina", "tqq", "renren", "weixin"], "viewText": "分享到：", "viewSize": "16" }, "selectShare": { "bdContainerClass": null, "bdSelectMiniList": ["qzone", "tsina", "tqq", "renren", "weixin"] } }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>
				</div>
			</ul>
		</div>
	</div>
	</div>
</body>
</html>