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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_zclist.aspx.cs" Inherits="Backstage_templates_default_zc_zclist" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w50 bn">
                    支持金额
                </td>
                <td class="w150 bn">
                    说明图片
                </td>
                <td class="w340 bn">
                    回报内容
                </td>
                <td class="w100 bn">
                    预计奖励日期(项目成功结束后预计)
                </td>
                <td class="w80 bn">
                    是否限制名额
                </td>
                <td class="w80 bn">
                    回报方式
                </td>
                <td class="w80 bn">
                    回报状态
                </td>
                <td class="w80 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_obj_zc != null)
                {
                    foreach (DSCM.ds_tbl_object_zc.tbl_object_zc tobj_zc in tbl_obj_zc)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    ￥<%=(decimal.Parse(tobj_zc.Object_Zc_Price)).ToString("f0")%>
                </td>
                <td>
                    <img style="width: 50px; height: 50px;" src="<%=tobj_zc.Object_Zc_Img1 %>" alt=""/>
                    <img style="width: 50px; height: 50px;" src="<%=tobj_zc.Object_Zc_Img2 %>" alt=""/>
                    <img style="width: 50px; height: 50px;" src="<%=tobj_zc.Object_Zc_Img3 %>" alt=""/>
                </td>
                <td>
                    <%=tobj_zc.Object_Zc_Doc%>
                </td>
                <td>
                    <%=tobj_zc.Object_Zc_Time%>天
                </td>
                <td>
                    <%if (tobj_zc.Object_Zc_Xianzhi.Equals("0")) { Response.Write("否"); } else if (tobj_zc.Object_Zc_Xianzhi.Equals("1")) { Response.Write("是"); }%>
                </td>
                <td>
                    <%=tobj_zc.Object_Zc_Fangshi%>
                </td> 
                <td>
                     <%if (tobj_zc.Object_Zc_Delstate.Equals("0")) { Response.Write("正常"); } else if (tobj_zc.Object_Zc_Delstate.Equals("1")) { Response.Write("标记删除"); }%>
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=zc&cm=zcupdate&id=<%=tobj_zc.Object_Zc_Id %>&raiseprice=<%=tobj.Object_Raise_Price %>">修改</a>                 
                    <% if (tobj_zc.Object_Zc_Delstate.Equals("0"))
                       {%>
                    <a href="/backstage/index.aspx?ds=zc&cm=zcdelete&id=<%=tobj_zc.Object_Zc_Id %>">删除</a>
                    <%} %>
                </td>
            </tr>
            <% }
                }
            %>
        </table>
    </div>
    <div class="paging clearfix mt10">
        <div class="record fl">
            共<span class="f_blue"><%=allcount %></span>条记录，当前显示第 <span class="f_blue">
                <%=count %></span> 页。
        </div>
        <div class="itemPage fr">
            <%=pagestr %>
        </div>
    </div>
</div>
<!-- 添加表格背景颜色 -->
<script type="text/javascript">
    $(document).ready(function () {
        var item = $(".concent-box tr").length;
        for (var i = 1; i <= item; i++) {
            var m = i % 2;
            if (m == 0) {
                $(".concent-box tr").eq(i).addClass("bg_lblue");
            }
        }
    })
</script>