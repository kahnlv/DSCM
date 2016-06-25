<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_biaoqian.aspx.cs" Inherits="Reception_templates_default_quanzi_biaoqian" %>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>

	<div class="type_nav">
		<ul class="clearfix">
<%--			<li style="border-left:0;"><a href="#">浏览</a></li>
			<li class="hover"><a href="/Reception/index.aspx?ds=quanzi&cm=biaoqian">标签</a></li>
			<li><a href="#">品牌</a></li>
			<li><a href="#">话题</a></li>
			<li><a href="#">专题</a></li>--%>
			<li><a href="/Reception/index.aspx?ds=quanzi&cm=daren">达人</a></li>
<%--			<li style="border-right:0;width:125px;"><a href="#">模板</a></li>--%>
		</ul>
	</div>
	<div id="container" class="clearfix">
		<div class="main fl">
			<ul class="part">
				<li class="clearfix">
					<div class="part_face fl"><img src="<%=art1.user.User_Img.Replace("/big/","/saml/") %>" alt="" height="80" width="80"/></div>
					<div class="part_con fr">
						<div class="part_bg"></div>
						<div class="part_title"><%=art1.Article_Title %><span>-众漫推荐</span></div>
						<p class="part_p">
							<img src="<%=art1.Article_Pic %>" alt="" class="mr25 mb40 fl" width="160" height="200"/>
                             <%=System.Web.HttpUtility.UrlDecode(art1.Article_Contents) %>
						</p>
					    <a class="part_more fl" href="/Reception/index.aspx?ds=quanzi&cm=arcdetail&id=<%=art1.Article_Id%>">展开</a>
						<div class="part_bottom">
							<div class="type fl clearfix"><span></span>
                                  <%foreach (string bq in art1.bqs)
                                  {%>
                                      <a href="#" class="bgblue"><%=bq %></a>
                                  <%} %>
							</div>
							<ul class="discuss fr clearfix">
								<li><a href="#">热度(<%=art1.Article_Hot %>)</a></li>
								<li><a href="/Reception/index.aspx?ds=quanzi&cm=discuss&id=<%=art1.Article_Id %>">评论(<%=art1.plnum %>)</a></li>
								<li><a href="/Reception/index.aspx?ds=quanzi&cm=share&id=<%=art1.Article_Id %>">分享</a></li>
								<li><a href="#">推荐</a></li>
								<li style="padding:0;"><a href="#" style=" display:block;width:30px; height:30px;"></a></li>
							</ul>
						</div>
					</div>
				</li>
				<li class="clearfix">
					<div class="part_face fl"><img src="<%=art2.user.User_Img.Replace("/big/","/saml/") %>" alt="" height="80" width="80"/></div>
					<div class="part_con fr">
						<div class="part_bg"></div>
						<div class="part_title"><%=art2.Article_Title %><span>-众漫推荐</span></div>
						<div class="part_p">
							<img src="<%=art2.Article_Pic %>" alt="" class="mr25 mb40 fl" width="160" height="200"/>
							<%=System.Web.HttpUtility.UrlDecode(art2.Article_Contents) %>
						</div>
					    <a class="part_more fl" href="/Reception/index.aspx?ds=quanzi&cm=arcdetail&id=<%=art2.Article_Id%>">展开</a>
						<div class="part_bottom fl">
							<div class="type fl clearfix"><span></span>
                                  <%foreach (string bq in art2.bqs)
                                  {%>
                                      <a href="#" class="grey"><%=bq %></a>
                                  <%} %>
							</div>
							<ul class="discuss fr clearfix">
								<li><a href="#">热度(<%=art2.Article_Hot %>)</a></li>
								<li><a href="/Reception/index.aspx?ds=quanzi&cm=discuss&id=<%=art2.Article_Id %>">评论(<%=art2.plnum %>)</a></li>
								<li><a href="/Reception/index.aspx?ds=quanzi&cm=share&id=<%=art2.Article_Id %>">分享</a></li>
								<li><a href="#">推荐</a></li>
								<li style="padding:0;"><a href="#" style=" display:block;width:30px; height:30px;"></a></li>
							</ul>
						</div>
					</div>
				</li>
			</ul>
		</div>
	</div>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_foot.aspx")%>