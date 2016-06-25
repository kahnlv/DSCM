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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_index.aspx.cs" Inherits="Backstage_templates_default_order_index" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>
<link rel="stylesheet" href="/data/resource/rili/jquery-ui.css">
<link rel="stylesheet" href="/data/resource/rili/style.css">
<script src="/data/resource/rili/jquery-1.10.2.js" type="text/javascript"></script>
<script src="/data/resource/rili/jquery-ui.js" type="text/javascript"></script>
<div class="conent">
    <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=order&cm=index" method="post">
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
        </span>
        <span>项目名称：</span>
        <input name="obj_title" value="<%=obj_title %>"/>
        <span>下单人：</span>
        <input name="username" value="<%=username %>"/>
        <span>下单时间：</span>
        <input name="ordertime" id="ordertime" value="<%=ordertime %>"/>
        <span>至：</span>
        <input name="endordertime"  id="endordertime" value="<%=endordertime %>"/>
        <input type="submit" value="搜索" />
      <script type="text/javascript">
          $(function () {
              $("#ordertime").datepicker(); 
              $("#endordertime").datepicker();
          });
	  </script>
        </form>
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
                    下单人
                </td>
                <td class="w80 bn">
                    订单金额
                </td>
                <td class="w100 bn">
                    支付时间
                </td>
                <td class="w100 bn">
                    订单备注
                </td>
                <td class="w80 bn">
                    订单状态
                </td>
                <td class="w80 bn tc">
                    操作
                </td>
            </tr>
            <% 
                if (tbl_order != null)
                {
                    foreach (DSCM.ds_tbl_order.tbl_order torder in tbl_order)
                    {
            %>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td>
                    <img style="width: 50px; height: 50px;" src="<%=torder.tbl_obj.Object_Img %>" alt=""/>
                </td>
                <td>
                    <%=torder.Object_Title%>
                </td>
                <td>
                     <%=torder.user.User_Name%>
                </td>
                <td>
                    ￥<%=torder.Order_Price%>
                </td>
                <td>
                    <%=torder.Order_Time%>
                </td>
                <td>
                    <%=torder.Order_Doc%>
                </td>
                <td>
                   <% if (torder.Order_Start.Equals("0")) { Response.Write("等待付款"); }
                      else if (torder.Order_Start.Equals("1")) { Response.Write("等待发货"); }
                      else if (torder.Order_Start.Equals("2")) { Response.Write("等待确认"); }
                      else if (torder.Order_Start.Equals("3")) { Response.Write("交易完成"); } 
                      else if (torder.Order_Start.Equals("4")) { Response.Write("标记删除"); } %>                    
                </td>
                <td class="bn tc">
                    <a href="/backstage/index.aspx?ds=order&cm=zcdetail&id=<%=torder.Order_Id %>">查看支持详情</a> 
                    <% if (!torder.Order_Start.Equals("0") && !torder.Order_Start.Equals("1"))
                       {%>
                    <a href="/backstage/index.aspx?ds=order&cm=detail&id=<%=torder.Order_Id %>">查看物流信息</a>  
                    <% }%>
                    <a href="/backstage/index.aspx?ds=order&cm=update&id=<%=torder.Order_Id %>">修改收货地址</a>
                    <% if (!torder.Order_Start.Equals("4"))
                       {%>
                    <a href="/backstage/index.aspx?ds=order&cm=delete&id=<%=torder.Order_Id %>">删除</a>
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
