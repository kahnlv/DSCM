<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 10:11:37 
* File name：new_index 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_index.aspx.cs" Inherits="Reception_templates_default_new_index" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/about.css" rel="stylesheet" type="text/css">
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/news.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="<%=HTMLConfig.HTML_PATH_RESOURCE %>js/jquery-1.9.1.min.js"></script>
<script>
    function setTab03Syn(i) {
        selectTab03Syn(i);
    }

    function selectTab03Syn(i) {
        switch (i) {
            case 1:
                document.getElementById("TabTab03Con1").style.display = "block";
                document.getElementById("TabTab03Con2").style.display = "none";
                document.getElementById("font1").style.borderBottom = "1px solid #ff431b";
                document.getElementById("font2").style.borderBottom = "1px solid #ccc";
                break;
            case 2:
                document.getElementById("TabTab03Con1").style.display = "none";
                document.getElementById("TabTab03Con2").style.display = "block";
                document.getElementById("font1").style.borderBottom = "1px solid #ccc";
                document.getElementById("font2").style.borderBottom = "1px solid #ff431b";
                break;
        }
    }
</script>


<div class="clearfix pB40 Mt58 W1200">
  <h1 class="about-font">热点新闻</h1>
  <div class="about-content clearfix">
    <div class="fL news-box">
      <div class="banner"> <a href="#"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/20149f6237025e3369.jpg" /></a>
        <div class="albumList_bg">背景半透明</div>
        <div class="des"><a href="#">忍者神龟发源于日本，你造吗？</a></div>
      </div>
      <div class="news-list">
        <h3>最新资讯</h3>
        <dl >
        <% 
            foreach (DSCM.ds_tbl_new.tbl_new tnew in tbl_news)
        {%>
          <dd class="about-content clearfix"> <a href="#" class="fL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/20141130001.jpg" /></a>
            <div class="fL news-list-r">
            <div class="newsfont"> <a href="#" class="fL"><%=tnew.New_Inc %></a> <span class="fL">Hot</span> </div>
            <span class="root"><%=tnew.New_Doc %></span> <span class="date"><%=tnew.New_Time %></span> </div>
          </dd>
        <%}%>       
        </dl>
        <div class="itemPage">
         <%=pagestr%>
        </div>
      </div>
    </div>
    <div class="fR">
      <div class="news-reader">
        <div class="reader">
          <ul>
            <li id="font1"  onMouseOver="setTab03Syn(1);" style="border-bottom:1px solid #ff431b;">周阅读</li>
            <li id="font2"  onMouseOver="setTab03Syn(2);" style="border-bottom:1px solid #ccc;">月阅读</li>
          </ul>
        </div>
        <div class="readerRoot" id="TabTab03Con1">
          <ul>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li style="border-bottom:none;"><a href="#">去参加活动</a></li>
          </ul>
        </div>
        <div class="readerRoot" style="display:none;" id="TabTab03Con2">
          <ul>
            <li><a href="#">去参加活动2</a></li>
            <li><a href="#">去参加活动2</a></li>
            <li><a href="#">去参加活2动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
            <li><a href="#">去参加活动</a></li>
          </ul>
        </div>
      </div>
      <div class="introdus">
        <h3>推荐文章</h3>
        <ul>
        
        <% foreach (DSCM.ds_tbl_new.tbl_new tnew1 in tbl_news1)
         {%>
           <li> <a href="#" class="fL"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201411301925img_01.jpg" /></a> <div class="introdus_jj"><a href="#"><%=tnew1.New_Doc %></a><span><%=tnew1.New_Time %></span></div> </li>
        <%} %>             
        </ul>
      </div>
    </div>
  </div>
</div>


<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
