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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_logcom.aspx.cs" Inherits="Backstage_templates_default_user_logcom" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>

<div class="conent">
     <div class="serv_search clearfix">
        <form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=user&cm=logcom" method="post">
         <span>日志类别：</span> <span id="user_log_class" class="city_select">
            <select name="user_log_class">
                <option value="">请选择</option>
                <option <%if(user_log_class.Equals("个人日志")){ %>selected<%} %>  value="个人日志">个人日志</option>
                <option <%if(user_log_class.Equals("视频日志")){ %>selected<%} %>  value="视频日志">视频日志</option>
                <option <%if(user_log_class.Equals("我的收藏")){ %>selected<%} %>  value="我的收藏">我的收藏</option>
                <option <%if(user_log_class.Equals("情感天地")){ %>selected<%} %>  value="情感天地">情感天地</option>
                <option <%if(user_log_class.Equals("情感收藏")){ %>selected<%} %>  value="情感收藏">情感收藏</option>
                <option <%if(user_log_class.Equals("人生道理")){ %>selected<%} %>  value="人生道理">人生道理</option>
                <option <%if(user_log_class.Equals("人生感悟")){ %>selected<%} %>  value="人生感悟">人生感悟</option>
            </select>
        </span>
        <span>日志标题：</span>
        <input name="logtitle" value="<%=logtitle %>"/>
         <span>评论人：</span>
        <input name="username" value="<%=username %>"/>
         <span>评论内容：</span>
        <input name="plcontent" value="<%=plcontent %>"/><input type="submit" value="搜索" />
        </form> 
      </div>
    <div class="concent-box">
        <table>
            <tr class="bg_blue">
                 <td class="w50 bn">
                    <input type="checkbox" />
                </td>
                <td class="w80 bn">
                    日志标题
                </td>
                <td class="w100 bn">
                    日志类别
                </td>
                <td class="w80 bn">
                    评论内容
                </td>
                <td class="w80 bn">
                    评论人头像
                </td>
                <td class="w80 bn">
                    评论人
                </td>
                <td class="w100 bn">
                    评论时间
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
                    <%=tuser_mes.user_log.User_Log_Title%>
                </td>
                <td>
                     <%=tuser_mes.user_log.User_Log_Class%>
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
                    <a href="/backstage/index.aspx?ds=user&cm=loghuifu&id=<%=tuser_mes.User_Message_Id %>">回复列表</a>
                    <a href="/backstage/index.aspx?ds=user&cm=logcomupdate&id=<%=tuser_mes.User_Message_Id %>">修改评论</a>
                    <a href="/backstage/index.aspx?ds=user&cm=dscomdelete&id=<%=tuser_mes.User_Message_Id %>">删除评论及回复</a>
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
