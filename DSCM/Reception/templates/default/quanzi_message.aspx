<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_message.aspx.cs" Inherits="Reception_templates_default_quanzi_message" %>
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
				<div class="letter">
					<div class="letter_title"><%=Save("user_relName").ToString() %>的通知</div>
					<ul class="letter_con">
                        
<% foreach (DSCM.ds_tbl_message.tbl_message mes in messages)
   { %>
						<a href="#">
						<li class="clearfix">
							<div class="letter_head fl"><img src="/Reception/resource/new/images/headpic.png" alt="" /></div>
							<div class="letter_text fl">
								<h1>来自众漫的通知<span class="letter_close disn"></span></h1>
								<p><%=mes.Message_Content %></p>
								<h1 style="line-height:26px;"><%=mes.Message_Time %></h1>
							</div>
						</li>
						</a>
 <%} %>
					</ul>
				</div>
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
					<li><span class="bg1"></span><a href="/Reception/index.aspx?ds=quanzi&cm=arcticle">文章</a></li>
					<li class="visited1"><span class="bg2"></span><a href="javascript:void(0)">通知</a></li>
				<%--	<li><span class="bg3"></span><a href="/Reception/index.aspx?ds=quanzi&cm=letter">私信</a></li>--%>
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