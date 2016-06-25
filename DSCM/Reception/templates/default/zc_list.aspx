<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 9:52:02 
* File name：zc_list 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_list.aspx.cs" Inherits="Reception_templates_default_zc_list" %>
<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">

<!-- itemBanner Mt58-->
<div class="W1200 Mt58 clearfix">
  <ul class="itemList">
    <li class="all active"><a href="/Reception/index.aspx?ds=zc&cm=list"><span>全部</span></a></li>
    <li class="item01"><a href="/Reception/index.aspx?ds=zc&cm=list&type=动漫"><span>动漫</span></a></li>
    <li class="item02"><a href="/Reception/index.aspx?ds=zc&cm=list&type=游戏"><span>游戏</span></a></li>
    <li class="item03"><a href="/Reception/index.aspx?ds=zc&cm=list&type=Cosplay"><span>Cosplay</span></a></li>
    <li class="item04"><a href="/Reception/index.aspx?ds=zc&cm=list&type=漫画"><span>漫画</span></a></li>
    <li class="item05"><a href="/Reception/index.aspx?ds=zc&cm=list&type=模型制作"><span>模型制作</span></a></li>
    <li class="item06"><a href="/Reception/index.aspx?ds=zc&cm=list&type=影视"><span>影视</span></a></li>
  </ul>
  <div class="itemTopAll">
  <dl>
    <dt><a href="#">所有项目 （<%=objcount %>）</a><i></i></dt>
    <dd>
      <ul>
        <li><a href="/Reception/index.aspx?ds=zc&cm=list&xm=1&px=<%=PX %>&type=<%=type %>">众筹中</a></li>
        <li><a href="/Reception/index.aspx?ds=zc&cm=list&xm=2&px=<%=PX %>&type=<%=type %>">已成功</a></li>
        <li><a href="/Reception/index.aspx?ds=zc&cm=list&xm=3&px=<%=PX %>&type=<%=type %>">即将开始</a></li>
      </ul>
    </dd>
  </dl>
  <dl>
    <dt><a href="#" class="down">默认排序</a><i></i></dt>
    <dd>
      <ul>
        <li><a href="/Reception/index.aspx?ds=zc&cm=list&px=1&xm=<%=XM %>&type=<%=type %>">最新上线</a></li>
        <li><a href="/Reception/index.aspx?ds=zc&cm=list&px=2&xm=<%=XM %>&type=<%=type %>">最高目标金额</a></li>
        <li><a href="/Reception/index.aspx?ds=zc&cm=list&px=3&xm=<%=XM %>&type=<%=type %>">最多支持人数</a></li>
        <li><a href="/Reception/index.aspx?ds=zc&cm=list&px=4&xm=<%=XM %>&type=<%=type %>">最多支持金额</a></li>
      </ul>
    </dd>
  </dl>
  </div>
</div>
<div class="mainContact W1200 clearfix">
  <div class="itemW5">
    <ul class="MitemList clearfix">

<% 
foreach (DSCM.ds_tbl_object.tbl_object tobj in tbl_obj)
{
    DateTime dt1 = new DateTime();
    DateTime.TryParse(tobj.Object_Start_Time, out dt1);
    DateTime dt2 = new DateTime();
    DateTime.TryParse(tobj.Object_Stop_Time, out dt2);
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
      <li> 
      <span class="itemGenre genre05"><%=tobj.Object_Class %></span> 
      
      <a class="mitemImg" href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tobj.Object_Id %>"><img src="<%=tobj.Object_Img %>" alt="" /></a>
        <p class="mainTit"><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tobj.Object_Id %>"><%=tobj.Object_Title %></a></p>
        <div class="mainSubCon">
          <%if (tobj.Object_Doc.Length > 100) { Response.Write(HttpUtility.HtmlDecode(tobj.Object_Doc.Substring(0, 100))); } else { Response.Write(HttpUtility.HtmlDecode(tobj.Object_Doc)); } %>
        </div>
        <div class="sustain">
          <div class="fL w566">
            <dl class="raising">
              <dd><em><% 
                          decimal dc1 = 0;
                          decimal dc2 = 0;
                          decimal.TryParse(tobj.Object_Raise_Price, out dc1);
                          decimal.TryParse(tobj.Object_Raise_Ready_Manry,out dc2);
                          Response.Write((Math.Round((dc2 / dc1) * 100,0)).ToString());
    %>%</em>已达到</dd>
              <dd><em>￥<%=(decimal.Parse(tobj.Object_Raise_Ready_Manry)).ToString("f0")%></em>已筹集</dd>
              <dd class="Nobor"><em><%=dt.Days %>天</em>剩余时间</dd>
            </dl>
            <p class="progressBar"><span class="progress" style="width:<%=Math.Round((dc2/dc1) * 100,0) %>%"></span></p>
          </div>       
             <% if (Save("user_phone").ToString().Equals(""))
            { %>
                <a href="javascript:void(0)" class="sustainTit fR showLogin">支持</a>
             <% }
            else
            { %>
                <a href="/Reception/index.aspx?ds=zhichi&id=<%=tobj.Object_Id%>" class="sustainTit fR">支持</a>
           <% } %>     			

          </div>
        <span class="endTips"><em><%=dt.Days %></em>天结束</span> 
      </li>
<% 
} 
%>
    </ul>
  </div>
  <div class="itemPage mB20"> 
 <%=pagestr%>
  </div>
</div>



<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>