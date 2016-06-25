<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_setup.aspx.cs" Inherits="Reception_templates_default_quanzi_setup" %>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>

<div id="setup-conten">
    <div class="setcon-top">
        <div class="setct-l">账号设置</div>
        <a class="setct-r" href="">主页设置</a>
    </div>
    <div class="setcon-postbox">
        <div class="setpos-l">邮箱账号</div>
        <div class="setpos-r">
            <div class="setposr-top">可以用该邮箱直接登录 众漫圈子</div>
            <div class="setposr-con">jinrongk45@163.com</div>
            <div class="setposr-bot"><a href="">修改账号密码 ></a></div>
        </div>
    </div>
    <div class="setcon-postbox">
        <div class="setpos-l">社交账号</div>
        <div class="setpos-r">
            <div class="setposr-top">绑定社交账号，绑定后可以用以下直接登录 众漫圈子</div>
            <div class="setposr-con fl set-sociall"><a href="http://weibo.com/">新浪微博（绑定）</a></div>
            <div class="setposr-con fr set-socialr"><a href="http://www.qq.com/">腾讯QQ（绑定）</a></div>
        </div>
    </div>
    <div class="setcon-notice">
        <div class="setpos-l">站内通知</div>
        <div class="setpos-r">
            <div class="setposr-top">勾选后将会收到对应的站内通知</div>
            <form action="" method="post">
                <%int i = 0; foreach (DSCM.ds_tbl_message_class.tbl_message_class mc in mescla1)
                  {
                      if (i < mescla1.Length - 1)
                      {%>
                      <div class="notice-sort">
                        <span class="notice-sp"><%=mc.Message_Class_Name%></span>  
                          <%foreach (DSCM.ds_tbl_message_class.tbl_message_class mcc in mc.mescla)
                            {%>
                                <input type="checkbox" name="me" value="<%=mcc.Message_Class_Id%>"><%=mcc.Message_Class_Name%>
                            <%} %>
                      </div>
                  <%
                      }
                      else
                      {%>
                       <div class="notice-sortbt">
                            <span class="notice-sp"><%=mc.Message_Class_Name%></span> 
                          <%foreach (DSCM.ds_tbl_message_class.tbl_message_class mcc in mc.mescla)
                            {%>
                                <input type="checkbox" name="me" value="<%=mcc.Message_Class_Id%>"><%=mcc.Message_Class_Name%>
                            <%} %>
                      </div>
                      <%}
                        i++;
                  } %>
            </form>
        </div>
    </div>
    <div class="setcon-mailcall">
        <div class="setpos-l">邮件通知</div>
        <div class="setpos-r">
            <div class="setposr-top">勾选后将会收到对应的站内通知</div>
            <div class="mail-call">
                <form action="" method="post">
                     <%foreach (DSCM.ds_tbl_message_class.tbl_message_class mescla in mescla2)
                     {%>
                         <input type="checkbox" name="message_class" value="<%=mescla.Message_Class_Id %>"><%=mescla.Message_Class_Name %>
                     <%} %>
                </form>
            </div>
        </div>
    </div>
    <div class="setcon-postbox">
        <div class="setpos-l">首页动态</div>
        <div class="setpos-r">
            <div class="setposr-top">根据“我的兴趣” ，每天精选最好的内容在“首页”动态中显示</div>
            <form action="" method="post">
                <%foreach (DSCM.ds_tbl_biaoqian.tbl_biaoqian bq in tbqs)
                {%>
                    <input type="checkbox" name="xq_biaoqian" value="<%=bq.Biaoqian_Name %>"><%=bq.Biaoqian_Name %>
                <%} %>
            </form>
            <div class="setposr-bot"><a href="">修改兴趣 ></a></div>
        </div>
    </div>
    <div class="setcon-postbox">
        <div class="setpos-l">首页动态</div>
        <div class="setpos-r">
            <div class="setposr-top">该功能是圈子为用户提供的一种特殊服务，您可以选择一张作品，作为自己的个人登陆页</div>
            <div class="setposr-bot"><a href="">查看制作方法 ></a></div>
        </div>
    </div>
    <div class="setup-edit">
        <button class="set-blacklist">黑名单</button>
        <button class="set-delete">删除账号或主页</button>
        <button class="set-keep">保存</button>
    </div>
</div>
</div>
</body>
</html>