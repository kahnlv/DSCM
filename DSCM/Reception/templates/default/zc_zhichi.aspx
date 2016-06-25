<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 15:32:19 
* File name：zc_zhichi 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_zhichi.aspx.cs" Inherits="Reception_templates_default_zc_zhichi" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/jquery-1.9.1.min.js"></script>
<script>
    $(function () {
        var num = $(window).height() / 2 - 236;
        var s = $(window).width() / 2 - 300;
        $('.reply').css('top', num);
        $('.reply').css('left', s);
        $("#bg").width($(document).width());
        $('#bg').height($(document).height());
        $('#bg').css('left', 0);
        $('#bg').css('top', 0);
    });
    function showdiv(id,name) {
        document.getElementById("bg").style.display = "block";
        document.getElementById("show").style.display = "block";
        var obj = document.lettermpostForm;
        obj.user_letter_name.value = name;
        obj.letter_user_id.value = id;
    }
    function hidediv() {
        document.getElementById("bg").style.display = 'none';
        document.getElementById("show").style.display = 'none';
    }
    function sendletter() {
        var obj = document.lettermpostForm;
        obj.submit();
    }
</script>
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
<div class="itemBanner Mt58" style="background:url(<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemBn_01.jpg) no-repeat center 0;"></div>
<div class="bannerLine"></div>
<div class="mainWarp W1024 pB40 clearfix">
  <div class="itemDetailsL">
    
    <h1 class="DetailTit"><%=tbl_obj.Object_Title%></h1>
		<p class="initiator"><span>发起人：<a href="#"><%=tbl_obj.User_Name %></a></span><span><%=tbl_obj.proname %><%=tbl_obj.cityname %></span></p>
		<div class="detaiLay">
			<ul class="detailNav fL">
				<li><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=object_id %>">项目主页</a></li>
				<li><a href="/Reception/index.aspx?ds=zc&cm=com&id=<%=object_id %>">评论（<%=obj_pl%>）</a></li>
				<li class="active"><a href="javascript:void(0)">支持者（<%=allcount%>）</a></li>
			</ul>
			<div class="shareWeibo fR">
				<a href="#" class="ico_01" title="sina"></a>
				<a href="#" class="ico_02" title="QQ"></a>
				<a href="#" class="ico_03" title="微信"></a>
				<a href="#" class="ico_04" title="share"></a>
				<a href="#" class="shareCounter">123</a>
			</div>
		</div>


    <div class="dealSupporter">
      <ul class="supperList">
<% foreach (DSCM.ds_tbl_object_zc_pes.tbl_object_zc_pes pes in zc_pes)
   {
%>
        <li>
          <div class="information"> <a href="#" class="superPhoto"><img src="<%=pes.User_Img%>" alt="" width="50px" height="50px" /></a>
            <h3 class="supTit"><%=pes.User_Name%></h3>
            <p>支持此项目</p>
            <span class="money">￥<%=pes.Object_Zc_Pes_Price%></span> </div>
         <% if (Save("user_phone").ToString().Equals(""))
         { %>
             <a href="javascript:void(0)" style="text-align: center;" class="private_Letter showLogin">发私信</a>
          <% }
         else
         { %>
            <a href="javascript:void(0)" onClick="showdiv('<%=pes.User_Id %>','<%=pes.User_Name %>')" class="private_Letter">发私信</a> 
          <% } %>  
        </li>
<% } %>
      </ul>
    </div>

    <div class="itemPage"> 
    <%=pagestr %>
    </div>

<!-- 私信弹出框 -->

    <div class="reply" id="show">
    <form id="lettermpostForm" name="lettermpostForm" action="/Reception/index.aspx?ds=user&cm=lettersend" method="post" onsubmit=""  enctype="multipart/form-data">
      <h1><img src="<%=Save("user_img").ToString() %>"><a href=""><%=Save("user_name").ToString() %></a>，给他写封信~ <span id="shut" onclick="hidediv()">×</span> </h1>
      <div class="mesformBox">
        <h3>发送给：
          <input value="" name="user_letter_name" class="mesInput">
        </h3>
        <textarea name="letter_conten_doc" id="" class="mesArea"  >内容在这里输入，亲~</textarea>
        <p class="commBtn"><span class="bntIcon01"></span><span class="fR">您可以输入<em>800</em>字符</span></p>
        <p class="commBtn"><a href="javascript:sendletter()" class="comReplyBtn">发表回复</a></p>
        <input value="" type=hidden name="letter_user_id" class="mesInput">
      </div>
    </form>
    </div>
    <div id="bg" onClick="hidediv()"></div>



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
				<dd><em><%=allcount%></em>支持</dd>
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
    <div class="advertisement"><a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/2014A15641fagw14.jpg" alt="" /></a></div>
  </div>
</div>


<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
