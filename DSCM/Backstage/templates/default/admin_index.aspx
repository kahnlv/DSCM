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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_index.aspx.cs" Inherits="Backstage_templates_default_admin_index" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
	<div class="add_delete clearfix">
    	<div class="button clearfix fl">
        	<img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/add.png" />
            <input type="button" value="添加" onclick="javascript:location='/backstage/index.aspx?ds=admin&cm=insert'"/>
        </div>
    </div>

     <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/Backstage/templates/default/admin_index.aspx" method="post">       
        <span>用户名称：</span>
        <input name="adminname" />
        <input type="submit" value="搜索" />
        </form>
    </div>

    <div class="concent-box">
    	<table>
        	<tr class="bg_blue">
                <td class="w340 bn">
                	用户名
                </td>
                <td class="w80 bn">
                	密码
                </td>
                <td class="w120 bn tc">
                	操作
                </td>
            </tr>
<% 
    foreach(DSCM.ds_tbl_admin.tbl_admin adm in admin)
    {    
%>
            <tr>
                <td><%=adm.Admin_Name %></td>
                <td>******</td>
                <td class="bn tc">
                  <a href="/backstage/index.aspx?ds=admin&cm=update&id=<%=adm.Admin_Id %>">修改密码</a>
                <% if (!adm.Admin_Name.Equals("admin"))
                   { %>
                    <a href="/backstage/index.aspx?ds=admin&cm=delete&id=<%=adm.Admin_Id %>">删除</a>
                <% } %>
            </td> </tr>
<% 
    }    
%>
        </table>
    </div>
     <div class="paging clearfix mt10">
    	<div class="record fl">
        	共<span class="f_blue"><%=allcount %></span>条记录，当前显示第 <span class="f_blue"><%=count %></span> 页。
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

