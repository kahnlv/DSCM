<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_message.aspx.cs" Inherits="Backstage_templates_default_quanzi_message" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>


<div class="conent">
    <div class="add_delete clearfix">
        <div class="button clearfix fl">
            <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>images/add.png" alt=""/>
            <input type="button" value="添加" onclick="javascrtpr: location = '/backstage/index.aspx?ds=quanzi&cm=mesinsert'" />
        </div>       
    </div>
    <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=quanzi&cm=message" method="post">
        <span>通知内容：</span>
        <input name="message_content" value="<%=message_content %>"/>
         <input type="submit" value="搜索" />
        </form>
    </div>
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w300 bn">
                    通知内容
                </td>
                <td class="w80 bn">
                    通知类型
                </td>
                <td class="w80 bn">
                    通知类别
                </td>
                <td class="w100 bn">
                    发布时间
                </td>
                <td class="w50 bn">
                    发布人
                </td>
                <td class="w50 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_messages != null)
                {
                    foreach (DSCM.ds_tbl_message.tbl_message tmes in tbl_messages)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <%=tmes.Message_Content%>
                </td>
                <td>
                   <% if (tmes.tmescla.Message_Class_Type.Equals("0")) { Response.Write("站内通知"); } else if (tmes.tmescla.Message_Class_Type.Equals("1")) { Response.Write("邮件通知"); } %>
                </td>
                <td>
                    <%=tmes.tmescla.Message_Class_Name%>
                </td>
                <td>
                    <%=tmes.Message_Time%>
                </td>
                <td>
                    <%=tmes.admin.Admin_Name  %>
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=quanzi&cm=mesupdate&id=<%=tmes.Message_Id %>">修改</a>
                    <a href="/backstage/index.aspx?ds=quanzi&cm=dsmesdelete&id=<%=tmes.Message_Id %>">删除</a>
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

