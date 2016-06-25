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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_mes.aspx.cs" Inherits="Backstage_templates_default_user_mes" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<div class="conent">
     <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=user&cm=mes" method="post">
        <span>留言对象：</span>
        <input name="tousername" value="<%=tousername %>"/>
         <span>留言人：</span>
        <input name="username" value="<%=username %>"/>
         <span>留言内容：</span>
        <input name="plcontent" value="<%=plcontent %>"/><input type="submit" value="搜索" />
        </form> 
      </div>
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                 <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w100 bn">
                    留言对象
                </td>
                <td class="w80 bn">
                    留言内容
                </td>
                <td class="w80 bn">
                    留言人头像
                </td>
                <td class="w80 bn">
                    留言人
                </td>
                <td class="w100 bn">
                    留言时间
                </td>
                <td class="w80 bn tc">
                    操作
                </td>
            </tr>
           <% 
               if (user_mes != null)
                {
                    foreach (DSCM.ds_tbl_user_message.tbl_user_message tuser_mes in user_mes)
                    {
               %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                     <%=tuser_mes.touser.User_Name%>
                </td>
                <td>
                     <%=tuser_mes.User_Message_Center%>
                </td>
                <td>
                   <img style="width: 50px; height: 50px;" src="<%=tuser_mes.user.User_Img%>" alt=""/> 
                </td>
                <td>
                     <%=tuser_mes.user.User_Name%>
                </td>
                <td>
                    <%=tuser_mes.User_Message_Time%>
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=user&cm=meshuifu&id=<%=tuser_mes.User_Message_Id %>">回复列表</a>
                    <a href="/backstage/index.aspx?ds=user&cm=mesupdate&id=<%=tuser_mes.User_Message_Id %>">修改留言</a>
                    <a href="/backstage/index.aspx?ds=user&cm=dsmesdelete&id=<%=tuser_mes.User_Message_Id %>">删除留言及回复</a>
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
