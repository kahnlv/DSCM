<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_index.aspx.cs" Inherits="Reception_templates_default_quanzi_index" %>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>
<div class="wrapper relative">
    <div class="leftMain">
        <ul class="publishBar clearfix">
            <li class="user relative"><span class="userIcon"></span>
                <div class="userHover">上传头像</div>
                <input type="file" class="head_upload"></li>
            <li><a href="javascript:;" class="publishLink"><i class="publishIcon1"></i>
                <p>文字</p>
            </a></li>
            <li><a href="javascript:;" class="publishLink"><i class="publishIcon2"></i>
                <p>图片</p>
            </a></li>
            <li><a href="javascript:;" class="publishLink"><i class="publishIcon3"></i>
                <p>音乐</p>
            </a></li>
            <li><a href="javascript:;" class="publishLink"><i class="publishIcon4"></i>
                <p>视频</p>
            </a></li>
        </ul>

        <%foreach (var m in articles)
            { %>
        <div class="messageList clearfix" data-user="<%=m.User_Id %>">
            <div class="messageImgDiv relative">
                <a class="messageImg fl" href="javascript:;">
                    <img src="<%=m.user.User_Img %>" alt="<%=m.user.User_Name %>">
                </a>

            </div>
            <div class="messageCont fr">
                <a class="nick" href=""><%=m.user.User_Name %></a>
                <div class="mainCont">
                    <div class="clearfix">
                    <%if ((m.Article_Pic + "").Length > 0)
                        { %>
                    <a class="imgCont fl" href="javascript:;">
                        <img src="<%=m.Article_Pic %>" alt="">
                    </a>
                    <%} %>
                    <div class="txt">
                        <p><a href="javascript:;"><%=m.Article_Title %></a></p>
                        <p>
                            <%=HttpUtility.UrlDecode(m.Article_Contents) %>
                        </p>
                    </div>
                        </div>
                    <div class="opt">
                        <div class="optLeft">
                            <%if (m.bqs.Length > 0)
                                { %>
                            <i class="bqIcon"></i>
                            <%foreach (var s in m.bqs)
                                { %>
                            <a href=""><span>s</span></a>
                            <%}
                                }%>
                        </div>
                        <div class="optRight" data-id="<%=m.Article_Id %>">
                            <%if (m.hot > 0)
                                { %>
                            <span><a href="javascript:;" class="hot">热度(<i><%=m.hot %></i>)</a></span>
                            <%} %>
                            <%if ((Save("user_id") + "").Length > 0 && m.User_Id.Equals(Save("user_id")))
                                {%>
                            <span><a href="javascript:;" class="edit">编辑</a></span>
                            <span><a href="javascript:;" class="deleted">删除</a></span>
                            <span><a href="javascript:;" class="review">评论<%=m.plnum > 0 ? string.Format("(<i>{0}</i>)",m.plnum):"" %></a></span>
                            <%}
                                else
                                { %>
                            <span><a href="">评论<%=m.plnum > 0 ? string.Format("(<i>{0}</i>)",m.plnum):"" %></a></span>
                            <%--<span><a href="">分享</a></span>
                            <span><a href="">推荐</a></span>--%>
                            <span><a href="javascript:;"><i class="zanIcon<%=m.isLike ? " on" : "" %>">赞</i></a></span>
                            <%} %>
                        </div>
                    </div>
        </div>
        </div>
        </div>
        <%} %>
    </div>

    <%=model.ReadModel("/Reception/templates/default/public/side.aspx?ds=info")%>


    <!-- ======================================================== -->
    <div class="mask"></div>
    <div class="editDiv" style="display: none;">
        <div class="clearfix">
            <a class="userImg fl" href="">
                <img src="/Reception/resource/new/images/headicon.png" alt="">
            </a>
            <div class="editCont fr">
                <p class="nick" href="">昵称</p>
                <!--图片输入模块-->
                <div class="editInputDiv marT20">
                    <div class="picUpload relative">
                        <form id="frmImg">
                            <input type="file" name="imgpath" class="uploadPic">
                        </form>
                        <span class="uploadIcon"></span>
                        <p class="tac color88">添加一张图片</p>
                    </div>
                    <div class="picUploadWrap clearfix" style="display: none;">
                    </div>
                    <div class="muti_picUpload relative" style="display: none;">
                        <form id="frmOtherImg">
                            <input type="file" name="imgpath" class="uploadPic">
                        </form>
                        <p class="tac color88"><span class="plus">+</span>&nbsp;&nbsp;继续添加</p>
                    </div>
                </div>
                <!--音乐/视频输入模块-->
                <div class="editInputDiv marT20" style="display: none;">
                    <div class="musicInputDiv relative">
                        <span class="graySearch"></span>
                        <input type="text" class="musicInput" placeholder="请用歌名、专辑、艺术家搜索">
                    </div>
                    <div class="musicInputDiv relative">
                        <input type="text" class="videoInput" placeholder="贴入视频地址">
                    </div>
                </div>
                <!--文字输入模块-->
                <div class="editInputDiv marT20" style="display: none;">
                    <div class="titleInputDiv">
                        <input type="text" class="editInput" name="arc_title" placeholder="标题（可不填）">
                    </div>
                    <div class="contentInputDiv">
                        <script id="editor" type="text/plain"></script>
                    </div>
                    <div class="tagInputDiv">
                        <input type="text" class="editInput" name="arc_biaoqian" placeholder="添加相关标签，用逗号或回车分隔">
                    </div>
                </div>
                <div class="btnGroup clearfix">
                    <a href="javascript:;" class="btn cancle fl">取&emsp;消</a>
                    <a href="javascript:;" class="btn publish fr">发&emsp;布</a>
                </div>
            </div>
        </div>
    </div>
</div>

<form id="frmEdit" method="post">
    <input type="hidden" name="arc_title" value="" />
    <input type="hidden" name="arc_content" value="" />
    <input type="hidden" name="arc_pic" value="" />
    <input type="hidden" name="arc_biaoqian" value="" />
    <input type="hidden" name="arc_type" value="" />
    <input type="hidden" name="photos" value="" />
</form>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_foot.aspx")%>
