<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 15:42:23 
* File name：user_zc 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_zc.aspx.cs" Inherits="Reception_templates_default_user_zc" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">


 <div class="pmanage_main fR">
      <div class="pmanage_head">
        <h1>栀子花开</h1>
        <h4>有沟不一定火，有钱不一定任性有钱不一定任性有钱不一定任性有钱不一定任性有钱不一定任性有钱不一定任性有钱不一定任性有钱不一定任性</h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li><a href="startproject.html">发起项目</a></li>
          <li class="active"><a href="project.html">支持项目</a></li>
          <li><a href="trade-record.html">交易记录</a></li>
          <li><a href="SendOut-finish.html">发货管理</a></li>
        </ul>
      </div>
      <div class="project mT30">
        <div class="tit">
          <ul>
            <li class="cur"><a href="">所有</a></li>
            <li><a href="">已支付</a></li>
            <li><a href="">未支付</a></li>
          </ul>
        </div>
        <div class="con">
          <table cellpadding="0" cellspacing="0">
            <tr class="title">
              <td width="120" >项目名称</td>
              <td width="300">&nbsp;</td>
              <td width="120">支付日期</td>
              <td width="120">支付金额</td>
              <td width="120">状态</td>
              <td width="120">操作</td>
            </tr>

<% 
    foreach (DSCM.ds_tbl_object_zc_pes.tbl_object_zc_pes pes in zc_pes)
    {
        
%>
            <tr class="del_1">
              <td width="100"><img src="<%=pes.tbl_obj.Object_Img %>" style="width:100px;height:100px"></td>
              <td class="info"><%=pes.tbl_obj.Object_Title %></td>
              <td class="time"><span>2015-01-01</span><span>11:10:00</span></td>
              <td class="price"><span>100元</span><span>(含运费10元)</span></td>
              <td class="state"><span>未支付</span><a href="">前往支付</a></td>
              <td class="operate"><a href="">回报内容</a><a href="">收货地址</a></td>
            </tr>
<% 
    }    
%>



            <tr class="del_1">
              <td width="100"><img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/album1.gif"></td>
              <td class="info">网站常用简洁的TAB选项卡，代码简洁易用。兼容主流浏览器，懒人图库推荐下载！</td>
              <td class="time"><span>2015-01-01</span><span>11:10:00</span></td>
              <td class="price"><span>100元</span><span>(含运费10元)</span></td>
              <td class="state">已支付</td>
              <td class="operate"><a href="">回报内容</a><a href="">收货地址</a></td>
            </tr>
          </table>
        </div>
      </div>
    </div>
  </div>
</div>
<div class="pB40"></div>




<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
