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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_index.aspx.cs" Inherits="Backstage_templates_default_new_index" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
    <div class="add_delete clearfix">
        <div class="button clearfix fl">
            <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>images/add.png" alt=""/>
            <input type="button" value="添加" onclick="javascrtpr:location='/backstage/index.aspx?ds=new&cm=insert'" />
        </div>       
    </div>
    <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=new&cm=index" method="post">
        <span>新闻标题：</span>
        <input name="new_title" value="<%=new_title %>"/>
        <span>新闻描述：</span>
        <input name="new_inc" value="<%=new_inc %>" />
        <span>关键字：</span>
        <input name="new_key" value="<%=new_key %>" /><input type="submit" value="搜索" />
        </form>
    </div>
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w100 bn">
                    新闻标题
                </td>
                <td class="w100 bn">
                    关键字
                </td>
                <td class="w100 bn">
                    新闻标签
                </td>
                <td class="w100 bn">
                    发布时间
                </td>
                <td class="w100 bn">
                    是否推荐
                </td>
                <td class="w100 bn">
                    新闻描述
                </td>
                <td class="w100 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_news != null)
                {
                    foreach (DSCM.ds_tbl_new.tbl_new tnew in tbl_news)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <%=tnew.New_Title%>
                </td>
                <td>
                    <%=tnew.New_Key%>
                </td>
                <td>
                    <%=tnew.New_Label%>
                </td>
                <td>
                    <%=tnew.New_Time%>
                </td>
                <td>
                <% if (tnew.New_Tuijian.Equals("1")) { Response.Write("是"); }
                   else if (tnew.New_Tuijian.Equals("0")) { Response.Write("否"); } %>
                </td>
                <td>
                    <%=tnew.New_Inc%>
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=new&cm=detail&id=<%=tnew.New_Id %>">查看</a>
                    <a href="/backstage/index.aspx?ds=new&cm=update&id=<%=tnew.New_Id %>">修改</a>
                    <a href="/backstage/index.aspx?ds=new&cm=delete&id=<%=tnew.New_Id %>">删除</a>
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
</body>
</html>
