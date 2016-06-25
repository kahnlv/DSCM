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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_index.aspx.cs" Inherits="Backstage_templates_default_zc_index" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
    <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=zc&cm=index" method="post">
        <span>项目类别：</span> <span id="object_class" class="city_select">
            <select name="obj_class">
                <option value="">请选择</option>
                <option <%if(obj_class.Equals("动漫")){ %>selected<%} %>  value="动漫">动漫</option>
                <option <%if(obj_class.Equals("游戏")){ %>selected<%} %>  value="游戏">游戏</option>
                <option <%if(obj_class.Equals("Cosplay")){ %>selected<%} %>  value="Cosplay">Cosplay</option>
                <option <%if(obj_class.Equals("漫画")){ %>selected<%} %>  value="漫画">漫画</option>
                <option <%if(obj_class.Equals("模型制作")){ %>selected<%} %>  value="模型制作">模型制作</option>
                <option <%if(obj_class.Equals("影视")){ %>selected<%} %>  value="影视">影视</option>
            </select>
        </span><span>区域：</span> <span id="province" class="city_select">
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
        <span>项目名称：</span>
        <input name="obj_title" value="<%=obj_title %>"/>
        <span>发起人：</span>
        <input name="obj_username" value="<%=obj_username %>"/><input type="submit" value="搜索" />
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
                <td class="w80 bn">
                    项目图片
                </td>
                <td class="w100 bn">
                    项目名称
                </td>
                <td class="w80 bn">
                    已筹集
                </td>
                <td class="w80 bn">
                    融资目标
                </td>
                <td class="w80 bn">
                    发起人
                </td>
                <td class="w100 bn">
                    开始时间
                </td>
                <td class="w100 bn">
                    结束时间
                </td>
                <td class="w80 bn">
                    项目状态
                </td>
                <td class="w80 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_obj != null)
                {
                    foreach (DSCM.ds_tbl_object.tbl_object tobj in tbl_obj)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <img style="width: 50px; height: 50px;" src="<%=tobj.Object_Img %>" alt=""/>
                </td>
                <td>
                    <%=tobj.Object_Title%>
                </td>
                <td>
                    ￥<%=(decimal.Parse(tobj.Object_Raise_Ready_Manry)).ToString("f0")%>
                </td>
                <td>
                    ￥<%=(decimal.Parse(tobj.Object_Raise_Price)).ToString("f0")%>
                </td>
                <td>
                     <%=tobj.User_Name%>
                </td>
                <td>
                    <%=tobj.Object_Start_Time%>
                </td>
                <td>
                    <%=tobj.Object_Stop_Time%>
                </td>
                <td>
                   <% if (tobj.Object_State.Equals("0")) { Response.Write("等待审核"); } 
                       else if (tobj.Object_State.Equals("1")) { Response.Write("审核成功"); } 
                       else if (tobj.Object_State.Equals("2")) { Response.Write("审核失败"); }
                       else if (tobj.Object_State.Equals("3")) { Response.Write("标记删除"); } %>                   
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=zc&cm=zclist&id=<%=tobj.Object_Id %>">回报列表</a> 
                    <a href="/backstage/index.aspx?ds=zc&cm=detail&id=<%=tobj.Object_Id %>">查看</a>  
                    <a href="/backstage/index.aspx?ds=zc&cm=update&id=<%=tobj.Object_Id %>">修改</a>
                    <% if (!tobj.Object_State.Equals("3")) {%>
                    <a href="/backstage/index.aspx?ds=zc&cm=delete&id=<%=tobj.Object_Id %>">删除</a>
                    <% }%>
                    <% if (tobj.Object_State.Equals("0")) {%>
                    <a href="/backstage/index.aspx?ds=zc&cm=shenhe&id=<%=tobj.Object_Id %>">审核</a>
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
