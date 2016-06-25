<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 14:31:01 
* File name：zc_com 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_com.aspx.cs" Inherits="Reception_templates_default_zc_com" %>

<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">

<style>
    .com_form {
        width: 100%;
        position: relative;
    }

    .input {
        width: 99%;
        height: 60px;
        border: 1px solid #ccc;
    }

    .com_form p {
        height: 28px;
        line-height: 28px;
        position: relative;
    }

    .qqFace {
        margin-top: 4px;
        background: #fff;
        padding: 2px;
        border: 1px #dfe6f6 solid;
    }

        .qqFace table td {
            padding: 0px;
        }

            .qqFace table td img {
                cursor: pointer;
                border: 1px #fff solid;
            }

                .qqFace table td img:hover {
                    border: 1px #0066cc solid;
                }

    #show {
        width: 680px;
        margin: 20px auto;
    }
</style>
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
<!-- itemBanner -->
<div class="itemBanner Mt58" style="background: url(<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBn_01.jpg) no-repeat center 0;"></div>
<div class="bannerLine"></div>
<div class="mainWarp W1024 pB40 clearfix">
    <div class="itemDetailsL">
        <h1 class="DetailTit"><%=tbl_obj.Object_Title%></h1>
        <p class="initiator"><span>发起人：<a href="#"><%=tbl_obj.User_Name %></a></span><span><%=tbl_obj.proname %><%=tbl_obj.cityname %></span></p>
        <div class="detaiLay">
            <ul class="detailNav fL">
                <li><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=object_id %>">项目主页</a></li>
                <li class="active"><a href="javascript:void(0)">评论（<%=allcount%>）</a></li>
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
        <div class="commentWarp">

            <form id="zccominsertmpostForm" name="zccominsertmpostForm" action="/Reception/index.aspx?ds=zc&cm=dscominsert" method="post" onsubmit="">
                <div class="commenTarea">
                    <div class="com_form">
                        <textarea rows="" cols="" class="input" id="content" name="content"></textarea>
                        <%-- <span class="upload"></span>--%>
                        <p class="commBtn">
                            <span class="bntIcon01" id="comment"></span>

                            <% if (Save("user_phone").ToString().Equals(""))
                               { %>
                            <a href="javascript:void(0)" class="comReplyBtn showLogin">发表评论</a>
                            <% }
                               else
                               { %>
                            <a href="javascript:cominsert()" class="comReplyBtn">发表评论</a>
                            <% } %>
                        </p>
                    </div>
                </div>
                <input name="object_id" type="hidden" value="<%=object_id %>" />
            </form>
            <script>
                function cominsert() {
                    var str = $("#content").val();
                    $("#content").val(replace_em(str));

                    //查看结果
                    function replace_em(str) {
                        str = str.replace(/\</g, '&lt;');
                        str = str.replace(/\>/g, '&gt;');
                        str = str.replace(/\n/g, '<br/>');
                        str = str.replace(/\[em_([0-9]*)\]/g, '<img src="/Reception/resource/images/face/$1.gif" border="0" />');
                        return str;
                    }
                    var obj = document.zccominsertmpostForm;
                    obj.submit();
                }
            </script>
            <%--	<div class="entire"><a href="#" class="active">全部</a><a href="#">只看发起人</a></div>--%>
            <ul class="commList">

                <% int mmi = 1; foreach (DSCM.ds_tbl_object_pl.tbl_object_pl pl in obj_pl)
                   {
                       DateTime dtpl = new DateTime();
                       DateTime.TryParse(pl.Object_Pl_Time, out dtpl);
                %>
                <li>
                    <div class="commInfo">
                        <a href="/Reception/index.aspx?ds=center" class="fL">
                            <img src="<%=pl.tbl_us.User_Img%>" alt="" width="50px" height="50px" /></a>
                        <div class="fL comTit">
                            <p><em class="fR"><%=mmi++ %>F</em><a href="/Reception/index.aspx?ds=center"><%=pl.tbl_us.User_Name%></a><span class="grayText"><%=(DateTime.Now-dtpl).Days %>天前</span></p>
                            <p>
                                <%=pl.Object_Pl_Content.Replace("&lt;","<").Replace("&gt;",">").Replace("&quot;","\"")%>
                            </p>
                        </div>
                        <% foreach (DSCM.ds_tbl_object_pl.tbl_object_pl par_pl in pl.object_pl)
                           {
                               DateTime dtpl2 = new DateTime();
                               DateTime.TryParse(par_pl.Object_Pl_Time, out dtpl2);
                        %>
                        <div class="commhuifu">
                            <a href="/Reception/index.aspx?ds=center" class="fL">
                                <img src="<%=par_pl.tbl_us.User_Img%>" alt="" width="50px" height="50px" /></a>
                            <div class="fL comTit1">
                                <p><a href="/Reception/index.aspx?ds=center"><%=par_pl.tbl_us.User_Name%></a><span class="grayText"><%=(DateTime.Now-dtpl2).Days %>天前</span></p>
                                <p name="show">
                                    <%=par_pl.Object_Pl_Content.Replace("&lt;","<").Replace("&gt;",">").Replace("&quot;","\"")%>
                                </p>
                            </div>
                        </div>
                        <%  } %>
                        <p class="p_hn">
                            <%--<a href="#" class="comNum">1</a>--%>

                            <% if (Save("user_phone").ToString().Equals(""))
                               { %>
                            <a href="javascript:void(0)" class="showLogin">回复</a>
                            <% }
                               else
                               { %>
                            <a href="javascript:void(0)" class="showComment">回复</a>
                            <% } %>
                        </p>
                    </div>
                    <div class="criticism hide">
                        <form id="com<%=pl.Object_Pl_Id %>" name="com<%=pl.Object_Pl_Id %>" action="/Reception/index.aspx?ds=zc&cm=dscominsert" method="post" onsubmit="">
                            <div class="commenTarea">
                                <div class="com_form">
                                    <textarea name="content" id="contentReplay"></textarea>
                                    <p><a href="javascript:subcom('<%=pl.Object_Pl_Id %>')" style="float: right">回复</a></p>
                                    <input type="hidden" name="object_pl_id" value="<%=pl.Object_Pl_Id %>" />
                                    <input name="object_id" type="hidden" value="<%=object_id %>" />
                                </div>
                            </div>
                        </form>
                    </div>
                </li>
                <% } %>
            </ul>
        </div>
    </div>
    <script>
        function subcom(id) {
            //var str = $("#contentReplay").val();
            //$("#contentReplay").val(replace_em(str));

            ////查看结果
            //function replace_em(str) {
            //    str = str.replace(/\</g, '&lt;');
            //    str = str.replace(/\>/g, '&gt;');
            //    str = str.replace(/\n/g, '<br/>');
            //    str = str.replace(/\[em_([0-9]*)\]/g, '<img src="/Reception/resource/images/face/$1.gif" border="0" />');
            //    return str;
            //}

            var obj = document.getElementById("com" + id);
            obj.submit();
        }
    </script>
    <div class="itemDetailsR">
        <div class="itembor statistics">
            <% 
                decimal dc1 = 0;
                decimal dc2 = 0;
                decimal.TryParse(tbl_obj.Object_Raise_Price, out dc1);
                decimal.TryParse(tbl_obj.Object_Raise_Ready_Manry, out dc2);
                if (dc1 == 0) dc1 = 999999999;
            %>
            <p class="f-01"><em>￥</em><%=tbl_obj.Object_Raise_Ready_Manry %></p>
            <p class="f-02">目前累计资金</p>
            <p class="f-02">此项目必须在 <%=tbl_obj.Object_Stop_Time%>前得到￥<%=tbl_obj.Object_Raise_Price%>的支持才可成功</p>
            <p class="itemBarBox"><span class="itemBar"><em style="width: <% Response.Write((Math.Round((dc2 / dc1) * 100,2)).ToString()); %>%"></em></span><span class="itemBartips"><% Response.Write((Math.Round((dc2 / dc1) * 100, 2)).ToString());%>%</span></p>
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
        <div class="advertisement">
            <a href="#">
                <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/2014A15641fagw14.jpg" alt="" /></a>
        </div>
    </div>
</div>

<script type="text/javascript">

</script>

<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
<script src="/Reception/resource/js/jquery-1.9.1.min.js"></script>
<script src="/Reception/resource/js/jquery.qqFace.js"></script>
<script>
    $(function () {
        $('#comment').qqFace({
            id: 'facebox', //表情盒子的ID
            assign: 'content', //给那个控件赋值
            path: '/Reception/resource/images/face/'	//表情存放的路径
        });
        //$('#replay').qqFace({
        //    id: 'facebox', //表情盒子的ID
        //    assign: 'contentReplay', //给那个控件赋值
        //    path: '/Reception/resource/images/face/'	//表情存放的路径
        //});

    });

</script>
