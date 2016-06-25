<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_mesclass.aspx.cs" Inherits="Backstage_templates_default_quanzi_mesclass" %>

<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
    <div class="add_delete clearfix">
        <div class="button clearfix fl">
            <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>images/add.png" alt=""/>
            <input type="button" value="添加" onclick="javascrtpr: location = '/backstage/index.aspx?ds=quanzi&cm=mesclainsert'" />
        </div>       
    </div>
    <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=quanzi&cm=mesclass" method="post">
        <span>通知类型：</span> <span id="mescla_type" class="city_select">
            <select name="mescla_type" onchange="change(this)">
                <option value="">请选择</option>
                <option <%if(mescla_type.Equals("0")){ %>selected<%} %>  value="0">站内通知</option>
                <option <%if(mescla_type.Equals("1")){ %>selected<%} %>  value="1">邮件通知</option>
            </select>
        </span><span>通知类别：</span> <span id="mescla_parentid" class="city_select">
            <select name="mescla_parentid" >
                <option value="">请选择</option>
                <% 
                    foreach (DSCM.ds_tbl_message_class.tbl_message_class tmesparcla in tbl_mespraclas)
                    {
                %>
                     <option value="<%=tmesparcla.Message_Class_Id %>" <%if(tmesparcla.Message_Class_Id.Equals(mescla_parentid)){ %>selected<%} %> ><%=tmesparcla.Message_Class_Name%></option>
                <%
                    }
                %>
            </select>
        </span>
      <script type="text/javascript">
          function change(obj) {
              $.get("/backstage/index.aspx?ds=quanzi&cm=mesparcla", { type: obj.value }, function (data) {
                  document.getElementById("mescla_parentid").innerHTML = data;
              });
          }
      </script>   
            <input type="submit" value="搜索" />
        </form>
    </div>
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w80 bn">
                    通知类别名
                </td>
                <td class="w80 bn">
                    通知类型
                </td>
                <td class="w80 bn">
                    通知父类名
                </td>
                <td class="w80 bn">
                    添加时间
                </td>
                <td class="w80 bn">
                    添加人
                </td>
                <td class="w80 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_mesclas != null)
                {
                    foreach (DSCM.ds_tbl_message_class.tbl_message_class tmescla in tbl_mesclas)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <%=tmescla.Message_Class_Name%>
                </td>
                <td>
                  <% if (tmescla.Message_Class_Type.Equals("0")) { Response.Write("站内通知"); } else if (tmescla.Message_Class_Type.Equals("1")) { Response.Write("邮件通知"); } %>
                </td>
                <td>
                     <%=tmescla.mesparclaname%>
                </td>
                <td>
                     <%=tmescla.Message_Class_Time%>
                </td>
                <td>
                    <%=tmescla.admin.Admin_Name%>
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=quanzi&cm=mesclaupdate&id=<%=tmescla.Message_Class_Id %>">修改</a>
                    <a href="/backstage/index.aspx?ds=quanzi&cm=dsmescladelete&id=<%=tmescla.Message_Class_Id %>">删除</a>
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