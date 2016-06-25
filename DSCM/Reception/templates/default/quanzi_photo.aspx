<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_photo.aspx.cs" Inherits="Reception_templates_default_quanzi_photo" %>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>

<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.all.min.js"></script>
<script type="text/javascript" src="/data/resource/js/jquery.form.js"></script>
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
            <li class="clearfix">

                <form id="mpostForm" class="clearfix" method="post" name="mpostForm" action="">
                    <div class="part_face fr" style="background: #fff; padding: 10px; width: 550px;">
                        <div style="margin-bottom: 5px; margin-left: 33px;">
                            图片
                                    <img src="/Reception/resource/new/images/headpic1.png" id="arc_pic" alt="" width="100" height="100" />
                            <input type="hidden" id="img1" value="/Reception/resource/new/images/headpic.png" />
                            <input type="file" name="imgpath" onchange="imgload(this)" />
                        </div>
                    </div>
                </form>
                <script>
                    function imgload(obj) {
                        $('#mpostForm').ajaxSubmit({
                            url: "/Reception/index.aspx?ds=LoadImg&cm=loadimg",
                            success: function (html, status) {
                                var result = html.replace("<pre>", "");
                                if (result == "") {
                                    alert('上传失败');
                                }
                                else {
                                    document.getElementById("arc_pic").src = result;
                                    document.getElementById("img1").value = result;
                                }
                            }
                        });
                    }
                </script>

                <form id="qzmpostForm" name="qzmpostForm" action="/Reception/index.aspx?ds=quanzi&cm=dsphotoinsert" method="post" onsubmit="">
                    <div class="part_con fr">
                        <div class="part_bg"></div>
                        <span>图片标题</span><h1 class="arc_title">
                            <input type="text" id="arc_title" name="arc_title" style="width: 350px; height: 30px;" /></h1>
                        <span>图片标签</span>
                        <div class="notice-sort" style="width: 500px; border: none">
                            <%foreach (DSCM.ds_tbl_biaoqian.tbl_biaoqian bq in tbqs)
                              {%>
                            <input type="checkbox" name="arc_biaoqian" value="<%=bq.Biaoqian_Name %>"><%=bq.Biaoqian_Name %>
                            <%} %>
                        </div>
                        <span>图片内容</span>
                        <script id="editor" type="text/plain" style="width: 500px; height: 500px;"></script>
                        <input type="hidden" name="arc_pic" />
                        <input type="hidden" name="arc_content" />
                        <input type="button" onclick="qz_submit()" value="提交" class="comment_btn ml10" />
                    </div>
                </form>
            </li>
        </ul>
    </div>
    <!-- 个人信息 -->
    <div class="person fr">
        <div class="per_infor clearfix">
            <div class="left fl">
                <h1><%=Save("user_name").ToString()%></h1>
                <h3 style="cursor: pointer" title="<%=Save("user_email").ToString() %>">
                    <%=Save("user_email").ToString().Length>24?Save("user_email").ToString().Substring(0,24):Save("user_email").ToString() %>
                </h3>
            </div>
            <a href="#" class="right fr"><span></span></a>
        </div>
        <ul class="person_nav">
            <li class="visited1"><span class="bg1"></span><a href="/Reception/index.aspx?ds=quanzi&cm=arcticle">文章</a></li>
            <li><span class="bg2"></span><a href="/Reception/index.aspx?ds=quanzi&cm=message">通知</a></li>
            <%--<li><span class="bg3"></span><a href="/Reception/index.aspx?ds=quanzi&cm=letter">私信</a></li>--%>
            <li class="visited"><span class="bg4"></span><a href="/Reception/index.aspx?ds=quanzi&cm=person">个人设置</a></li>
        </ul>
    </div>
    <div class="person fr mt15">
        <ul class="person_nav">
            <li><span class="bg5"></span><a href="#">关注</a></li>
            <%--			<li class="visited"><span class="bg6"></span><a href="/Reception/index.aspx?ds=quanzi&cm=daren">发现达人</a></li>--%>
        </ul>
    </div>
    <!-- 个人信息 -->
</div>
<script type="text/javascript">
    var ue = UE.getEditor('editor', { initialFrameWidth: 500 });
    function qz_submit() {
        var qz_obj = document.qzmpostForm;
        if (qz_obj != null) {
            qz_obj.arc_pic.value = document.getElementById("img1").value;
            qz_obj.arc_content.value = encodeURI(UE.getEditor('editor').getContent())
            qz_obj.submit();
        }
    }
</script>
</div>
</body>
</html>
