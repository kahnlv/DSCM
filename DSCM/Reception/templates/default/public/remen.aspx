<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 9:41:26 
* File name：remen 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="remen.aspx.cs" Inherits="Reception_templates_default_public_remen" %>

<% 
    if(type.Equals("gxq"))
    {
    %>
<ul class="interList">
<% 
foreach (DSCM.ds_tbl_object.tbl_object obj in tbl_obj)
{
    DateTime dt1 = new DateTime();
    DateTime.TryParse(obj.Object_Start_Time, out dt1);
    DateTime dt2 = new DateTime();
    DateTime.TryParse(obj.Object_Stop_Time, out dt2);
    TimeSpan dt = dt2 - dt1;
    
   // obj.Object_Img
    decimal dc1 = 0;
    decimal dc2 = 0;
    decimal.TryParse(obj.Object_Raise_Price, out dc1);
    decimal.TryParse(obj.Object_Raise_Ready_Manry, out dc2);
    if (dc1 == 0) dc1 = 9999999;
%>
	<li>
		<a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=obj.Object_Id %>"><img src="<%=obj.Object_Img %>" alt="" style="width:220px;height:148px"/></a>
		<p><%=obj.User_Name %></p>
		<p><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=obj.Object_Id %>"><%=obj.Object_Title %></a></p>
		<div class="interItem"><span class="fL">支持：<%=obj.Object_Zc %>次</span><span class="fR ItemtextR">众筹中</span></div>
              
             <% if (Save("user_phone").ToString().Equals(""))
                { %>                
		            <a href="javascript:void(0)" class="linkInter showLogin"><em><%=obj.xhcount %></em></a>
             <% }
                else
                {%>
			       <a href="/Reception/index.aspx?ds=zc&cm=dsxhinsert&id=<%=obj.Object_Id%>" class="linkInter"><em><%=obj.xhcount %></em></a>                
                <%} %>

		<div class="supporter clearfix">
			<span class="m_01"><em><% Response.Write((Math.Round((dc2 / dc1) * 100, 2)).ToString()); %>%</em>已达到</span>
			<span class="m_02"><em>￥<%=obj.Object_Raise_Ready_Manry %></em>已筹集</span>
			<span class="m_03"><em><%=dt.Days%>天</em>剩余时间</span>
		</div>
	</li>
<% 
}
    }
    else if (type.Equals("rm"))
    {
%>

<% 
foreach (DSCM.ds_tbl_object.tbl_object obj in tbl_obj)
{
        // obj.Object_Img
    
%>
<li>
	<div class="detaHot">
		<a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=obj.Object_Id %>"><img src="<%=obj.Object_Img %>" style="width:150px;height:105px"></a>
		<h5><a href="/Reception/index.aspx?ds=zc&cm=item&id=<%=obj.Object_Id %>"><%=obj.Object_Title %></a></h5>
		<p>已筹资：<em>¥<%=obj.Object_Raise_Ready_Manry %></em></p>
		<p>结束时间：<em><%=obj.Object_Stop_Time.Split(' ')[0] %></em></p>
		</div>
</li>
<% 
}     
    }
%>

</ul>

