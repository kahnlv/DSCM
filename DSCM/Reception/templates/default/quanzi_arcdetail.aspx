<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_arcdetail.aspx.cs" Inherits="Reception_templates_default_quanzi_arcdetail" %>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>

<div id="container" class="clearfix">
			<div class="main fl">
				<div class="main_nav">
					<ul>
						<li class="face"></li>
						<li class="bg1"><a href="/Reception/index.aspx?ds=quanzi&cm=arcinsert">文字</a></li>
						<li class="bg2"><a href="/Reception/index.aspx?ds=quanzi&cm=photo">图片</a></li>
						<li class="bg3"><a href="#">音乐</a></li>
						<li class="bg4"><a href="#">视频</a></li>
					</ul>
				</div>
				<ul class="part">
                    <li class="clearfix" style="margin-bottom:0;">
					<div class="part_face fl"><img src="<%=article.user.User_Img.Replace("/big/","/saml/") %>" alt="" width="80" height="80" /></div>
					<div class="part_con fr">
						<div class="part_bg"></div>
						<div class="part_title"><%=article.Article_Title %><span>-众漫推荐</span></div>
						<div class="part_p">
							<img src="<%=article.Article_Pic %>" alt="" class="mr25 mb40 fl" width="160" height="200"/>
                             <%=System.Web.HttpUtility.UrlDecode(article.Article_Contents) %>
						</div>
                        <div style="margin-top: 25px;"></div>
						<div class="part_bottom fl">
							<div class="type fl clearfix"><span></span>
                                <%foreach (string bq in article.bqs)
                                  {%>
                                      <a href="#" class="grey"><%=bq %></a>
                                  <%} %>
							</div>
							<ul class="discuss fr clearfix">
								<li><a href="#">热度(<%=hot %>)</a></li>
								<li><a href="/Reception/index.aspx?ds=quanzi&cm=discuss&id=<%=article.Article_Id %>">评论(<%=article.plnum %>)</a></li>
								<li><a href="/Reception/index.aspx?ds=quanzi&cm=share&id=<%=article.Article_Id %>">分享</a></li>
								<li><a href="#">推荐</a></li>
								<li style="padding:0;"><a href="#" style=" display:block;width:30px; height:30px;"></a></li>
							</ul>
						</div>
					</div>
				</li>

				</ul>
                    </div>
			<!-- 个人信息 -->
			<div class="person fr">
				<div class="per_infor clearfix">
					<div class="left fl">
						<h1><%=Save("user_name").ToString()%></h1>
                        <h3 style="cursor:pointer" title="<%=Save("user_email").ToString() %>">
                            <%=Save("user_email").ToString().Length>24?Save("user_email").ToString().Substring(0,24):Save("user_email").ToString() %>
                        </h3>
					</div>
					<a href="#" class="right fr"><span></span></a>
				</div>
				<ul class="person_nav">
					<li class="visited1"><span class="bg1"></span><a href="/Reception/index.aspx?ds=quanzi&cm=arcticle">文章</a></li>
					<li><span class="bg2"></span><a href="/Reception/index.aspx?ds=quanzi&cm=message">通知</a></li>
					<%--<li><span class="bg3"></span><a href="/Reception/index.aspx?ds=quanzi&cm=letter">私信</a></li>--%>
					<li><span class="bg4"></span><a href="/Reception/index.aspx?ds=quanzi&cm=person">个人设置</a></li>
				</ul>
			</div>
			<div class="person fr mt15">
				<ul class="person_nav">
					<li><span class="bg5"></span><a href="#">关注</a></li>
				<%--	<li class="visited"><span class="bg6"></span><a href="/Reception/index.aspx?ds=quanzi&cm=daren">发现达人</a></li>--%>
				</ul>
			</div>
			<!-- 个人信息 -->
		</div>

</div>
</body>
</html>