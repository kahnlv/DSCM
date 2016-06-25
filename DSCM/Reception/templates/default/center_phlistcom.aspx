<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_phlistcom.aspx.cs" Inherits="Reception_templates_default_center_phlistcom" %>
 <div class="commentWarp"  id="commList">
     <form id="imgcominsertpostForm" name="imgcominsertpostForm" action="/Reception/index.aspx?ds=center&cm=dsimgmesinsert&megid=" method="post" onsubmit="">
                <div class="spaceArea">
                    <textarea rows="" cols="" name="content"></textarea>
                    <span class="upload"></span>
                    <p class="commBtn"><span class="bntIcon01"></span><a href="javascript:imgmesinsert()" class="comReplyBtn" style="float: right;">发表评论</a></p>
                </div>
                <input type="hidden" name="photo_img_id" value=""/>
            </form>
     <ul class="commList">
                <% int mmi = 1; foreach (DSCM.ds_tbl_user_message.tbl_user_message m in message)
                   {
                       DateTime dtmes = new DateTime();
                       DateTime.TryParse(m.User_Message_Time, out dtmes);
       
                %>
                <li>
                    <div class="commInfo">
                        <a href="/Reception/index.aspx?ds=center" class="fL">
                            <img src="<%=m.user.User_Img %>" alt="" width="50px" height="50px" /></a>
                        <div class="fL comTit2">
                            <p><em class="fR"><%=mmi++ %>F</em><a href="#"><%= m.user.User_Name %></a><span class="grayText"><%=(DateTime.Now - dtmes).Days%>天前</span></p>
                            <p><%=m.User_Message_Center %></p>
                        </div>

                        <% foreach (DSCM.ds_tbl_user_message.tbl_user_message par_mes in m.user_mes)
                           {
                               DateTime dtmes2 = new DateTime();
                               DateTime.TryParse(par_mes.User_Message_Time, out dtmes2);
                        %>
                        <div class="commhuifu">
                            <a href="/Reception/index.aspx?ds=center" class="fL">
                                <img src="<%=par_mes.user.User_Img %>" alt="" width="50px" height="50px" /></a>
                            <div class="fL comTit1">
                                <p><a href="#"><%=par_mes.user.User_Name%></a><span class="grayText"><%=(DateTime.Now - dtmes2).Days%>天前</span></p>
                                <p><%=par_mes.User_Message_Center %></p>
                            </div>
                        </div>
                        <% } %>
                        <p class="p_hn"><%--<a href="#" class="comNum">1</a>--%><a href="javascript:void(0)" class="showComment">回复</a></p>
                        <div class="criticism hide">
                            <form id="imgcom<%=m.User_Message_Id %>" name="imgcom<%=m.User_Message_Id %>" action="/Reception/index.aspx?ds=center&cm=dsimgmesinsert&megid=<%=m.User_Message_Id %>" method="post" onsubmit="">
                                <textarea name="content"></textarea>
                                <p><a href="javascript:subimgcom('<%=m.User_Message_Id %>')" style="float: right;">回复</a></p>
                                <input type="hidden" name="photo_img_id" value=""/>
                            </form>
                        </div>
                </li>
                <% } %>
            </ul>
     <p class="itemPage clearfix">
                <%=pagestr %>
            </p>
  </div>

