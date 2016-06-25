<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_biaoqian.aspx.cs" Inherits="Backstage_templates_default_quanzi_biaoqian" %>

<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
    <div class="add_delete clearfix">
        <div class="button clearfix fl">
            <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>images/add.png" alt=""/>
            <input type="button" value="添加" onclick="javascrtpr: location = '/backstage/index.aspx?ds=quanzi&cm=bqinsert'" />
        </div>       
    </div>
    <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=quanzi&cm=biaoqian" method="post">
        <span>标签类型：</span> <span id="biaoqian_type" class="city_select">
            <select name="biaoqian_type">
                <option value="">请选择</option>
                <option <%if(bqtype.Equals("0")){ %>selected<%} %>  value="0">兴趣标签</option>
                <option <%if(bqtype.Equals("1")){ %>selected<%} %>  value="1">文章标签</option>
                <option <%if(bqtype.Equals("2")){ %>selected<%} %>  value="2">图片标签</option>
            </select>
        </span>
            <input type="submit" value="搜索" />
        </form>
    </div>
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w50 bn">
                    标签名称
                </td>
                <td class="w50 bn">
                    标签类型
                </td>
                <td class="w80 bn">
                    添加时间
                </td>
                <td class="w100 bn">
                    添加人
                </td>
                <td class="w100 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_bqs != null)
                {
                    foreach (DSCM.ds_tbl_biaoqian.tbl_biaoqian tbq in tbl_bqs)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <%=tbq.Biaoqian_Name%>
                </td>
                <td>
                  <% if (tbq.Biaoqian_Type.Equals("0")) { Response.Write("兴趣标签"); } else if (tbq.Biaoqian_Type.Equals("1")) { Response.Write("文章标签"); } else if (tbq.Biaoqian_Type.Equals("2")) { Response.Write("图片标签"); }%>
                </td>
                <td>
                     <%=tbq.Biaoqian_Time%>
                </td>
                <td>
                    <%=tbq.admin.Admin_Name%>
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=quanzi&cm=bqupdate&id=<%=tbq.Biaoqian_Id %>">修改</a>
                    <a href="/backstage/index.aspx?ds=quanzi&cm=dsbqdelete&id=<%=tbq.Biaoqian_Id %>">删除</a>
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
