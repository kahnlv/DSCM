<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：daohang 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_xhobject.aspx.cs" Inherits="Reception_templates_default_user_xhobject" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">

<div class="pmanage_main fR">
      <div class="pmanage_head">
      <h1><%=user_space.User_Space_Name %></h1>
      <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li><a href="/Reception/index.aspx?ds=user&cm=object">发起项目</a></li>
          <li  class="active"><a href="javascript:void(0)">喜欢项目</a></li>
          <li><a href="/Reception/index.aspx?ds=user&cm=zcobject">支持项目</a></li>
          <li><a href="/Reception/index.aspx?ds=order&cm=trade">交易记录</a></li>
          <li><a href="/Reception/index.aspx?ds=object&cm=sendout">发货管理</a></li>
        </ul>
      </div>
      <div class="MainconL mT30">
        <ul class="MitemList clearfix">
<% 
    foreach (DSCM.ds_tbl_object.tbl_object tb in tbl_obj)
    {
        DateTime dt1 = new DateTime();
        DateTime.TryParse(tb.Object_Start_Time, out dt1);
        DateTime dt2 = new DateTime();
        DateTime.TryParse(tb.Object_Stop_Time, out dt2);
        //TimeSpan dt = dt2 - dt1;
        TimeSpan dt ;

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
					<a class="mitemImg" href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tb.Object_Id %>" target=_blank><img style="width:249px;height:229px" src="<%=tb.Object_Img.Replace("big","saml") %>" alt="" /></a>
					<p class="mainTit"><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tb.Object_Id %>"  target=_blank><%=tb.Object_Title %></a></p>
					<div class="mainSubCon">
						<%if (tb.Object_Doc.Length > 120) { Response.Write(tb.Object_Doc.Substring(0, 120)); } else { Response.Write(tb.Object_Doc); } %>
					</div>
					<div class="sustain">
						<div class="fL w566">
							<dl class="raising">
								<dd><em><% 
                          decimal dc1 = 0;
                          decimal dc2 = 0;
                          decimal.TryParse(tb.Object_Raise_Price, out dc1);
                          decimal.TryParse(tb.Object_Raise_Ready_Manry,out dc2);
                          Response.Write((Math.Round((dc2 / dc1) * 100, 2)).ToString());
    %>%</em>已达到</dd>
								<dd><em>￥<%=tb.Object_Raise_Ready_Manry %></em>已筹集</dd>
								<dd class="Nobor"><em><%=dt.Days%>天</em>剩余时间</dd>
							</dl>
							<p class="progressBar"><span class="progress" style="width:<%  Response.Write((Math.Round((dc2 / dc1) * 100,2)).ToString()); %>%"></span></p>
						</div>
						<a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=tb.Object_Id %>" class="sustainTit fR">查看</a>
					</div>
					<span class="endTips"><em><%=dt.Days%></em>天结束</span>
				</li>
<% 
    }        
%>
         
        </ul>
        <p class="itemPage clearfix">
         <%=pagestr%>
          </p>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>




<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
