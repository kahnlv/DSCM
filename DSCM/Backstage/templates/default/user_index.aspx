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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_index.aspx.cs" Inherits="Backstage_templates_default_user_index" %>

<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
    <div class="add_delete clearfix">
        <div class="button clearfix fl">
            <img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>images/add.png" alt=""/>
            <input type="button" value="添加" onclick="javascrtpr:location='/backstage/index.aspx?ds=user&cm=insert'" />
        </div>       
    </div>
    <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=user&cm=index" method="post">
        <span>性别：</span> <span id="user_sex" class="city_select">
            <select name="user_sex">
                <option value="">请选择</option>
                <option <%if(user_sex.Equals("0")){ %>selected<%} %>  value="0">女</option>
                <option <%if(user_sex.Equals("1")){ %>selected<%} %>  value="1">男</option>
            </select>
        </span><span>通信地址：</span> <span id="province" class="city_select">
            <select name="object_address" onchange="change(this)">
                <option value="">请选择</option>
                <% 
                    foreach (DSCM.ds_tbl_province.tbl_province pro in province)
                    {
                %>
                     <option value="<%=pro.DI %>"><%=pro.Provincename%></option>
                <%
                    }
                %>
            </select>
        </span>
        <span id="city" class="city_select"></span>
        <span>用户名：</span>
        <input name="user_name" value="<%=user_name %>"/>
        <span>真实姓名：</span>
        <input name="user_relname" value="<%=user_relname %>" /><input type="submit" value="搜索" />
        </form>
        <script type="text/javascript">
            function change(obj) {
                $.get("/backstage/index.aspx?ds=city", { id: obj.value }, function (data) {
                    document.getElementById("city").innerHTML = data;
                });
            }
        </script>
    </div>
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w50 bn">
                    用户头像
                </td>
                <td class="w80 bn">
                    用户名
                </td>
                <td class="w80 bn">
                    真实姓名
                </td>
                <td class="w50 bn">
                    性别
                </td>
                <td class="w100 bn">
                    生日
                </td>
                <td class="w80 bn">
                    联系电话
                </td>
                <td class="w80 bn">
                    通信地址
                </td>
                <td class="w80 bn">
                    详细地址
                </td>
                <td class="w80 bn">
                    邮政编码
                </td>
                <td class="w80 bn">
                    Email地址
                </td>
                <td class="w80 bn">
                    用户状态
                </td>
                <td class="w100 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_user != null)
                {
                    foreach (DSCM.ds_tbl_user.tbl_user tuser in tbl_user)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <img style="width: 50px; height: 50px;" src="<%=tuser.User_Img %>" alt=""/>
                </td>
                <td>
                    <%=tuser.User_Name%>
                </td>
                <td>
                    <%=tuser.User_Relname%>
                </td>
                <td>
                  <% if (tuser.User_Sex.Equals("0")) { Response.Write("女"); } else if (tuser.User_Sex.Equals("1")) { Response.Write("男"); } %>
                </td>
                <td>
                     <%=tuser.User_Birthday%>
                </td>
                <td>
                    <%=tuser.User_Tel%>
                </td>
                <td>
                    <%=dtools.City(tuser.User_City)%>
                </td>
                <td>
                    <%=tuser.User_Address %>
                </td>
                <td>
                    <%=tuser.City_Code%>
                </td>
                <td>
                    <%=tuser.User_Email%>
                </td>
                <td>
                   <% if (tuser.User_Delstate.Equals("0")) { Response.Write("正常"); }else if (tuser.User_Delstate.Equals("1")) { Response.Write("标记删除"); } %>                   
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=user&cm=pwdupdate&id=<%=tuser.User_Id %>">修改密码</a>
                    <a href="/backstage/index.aspx?ds=user&cm=update&id=<%=tuser.User_Id %>">修改</a>
                    <% if (tuser.User_Delstate.Equals("0")){%>                       
                    <a href="/backstage/index.aspx?ds=user&cm=delete&id=<%=tuser.User_Id %>">删除</a>
                    <% }%>
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
