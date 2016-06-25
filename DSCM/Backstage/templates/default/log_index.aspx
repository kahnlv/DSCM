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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log_index.aspx.cs" Inherits="Backstage_templates_default_log_index" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
    <div class="concent-box">
    	<table>
        	<tr class="bg_blue">
                <td class="clearfix w80 number bn">
                	操作人
                </td>
                <td class="w340 bn">
                	操作内容
                </td>
                <td class="w80 bn">
                	操作时间
                </td>
            </tr>
<% foreach (DSCM.ds_tbl_log.tbl_log ti in logs)
   { %>
            <tr>
                <td><%=ti.User_Name %></td>
                <td><%=ti.Center %></td>
                <td><%=ti.Time %></td>
            </tr>
<% } %>
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
