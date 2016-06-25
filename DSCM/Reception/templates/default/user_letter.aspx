<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 15:51:38 
* File name：user_letter 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_letter.aspx.cs" Inherits="Reception_templates_default_user_letter" %>
<%=model.ReadModel("/Reception/templates/default/public/user_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/personalManage.css" rel="stylesheet" type="text/css">
<script language="javascript" type="text/javascript">
    $(function () {
        var num = $(window).height() / 2 - 236;
        var s = $(window).width() / 2 - 300;
        $('.reply').css('top', num);
        $('.reply').css('left', s);
        $("#bg").width($(document).width());
        $('#bg').height($(document).height());
        $('#bg').css('left', 0);
        $('#bg').css('top', 0);
    });
    function showdiv(id, name) {
        document.getElementById("bg").style.display = "block";
        document.getElementById("show").style.display = "block";
        var obj = document.lettermpostForm;
        obj.user_letter_name.value = name;
        obj.letter_user_id.value = id;
    }
    function hidediv() {
        document.getElementById("bg").style.display = 'none';
        document.getElementById("show").style.display = 'none';
    }
    function sendletter() {
        var obj = document.lettermpostForm;
        obj.submit();
    }
</script>

<div class="pmanage_main fR">
      <div class="pmanage_head">
        <h1><%=user_space.User_Space_Name %></h1>
        <h4><%=user_space.User_Space_Signature%></h4>
      </div>
      <div class="pmanage_menu">
        <ul class="HeaeNavList">
          <li class="active"><a href="javascript:void(0)">系统站内信</a></li>
        </ul>
      </div>
     
      <div class="friend">
        <div class="tit">
          <ul>
            <li  class="cur"  ><a href="/Reception/index.aspx?ds=user&cm=letter&start=1">收件箱</a></li>
            <li  class="cur"  ><a href="/Reception/index.aspx?ds=user&cm=letter&start=2">发件箱</a></li>
          </ul>
        </div>
        <ul class="commList">
<% 
    foreach (DSCM.ds_tbl_letter.tbl_letter letter in user_log)
    {
        
%>
            <li>
                <div class="commInfo"> <a href="/Reception/index.aspx?ds=center" class="fL">
                 <img src="<% if (start.Equals("2")) { Response.Write(letter.user.User_Img); }else{Response.Write(letter.letter_user.User_Img);} %>" alt="" width="50px" height="50px"/></a>            
                    <div class="fL comTit">
                    <p><a href="#"><% if (start.Equals("2")) { Response.Write(letter.user.User_Name); }else{Response.Write(letter.letter_user.User_Name);} %></a> | <%=letter.Letter_Time %> </p>
                    <p>
                        <div>
                            <% 
                                foreach (DSCM.ds_tbl_letter_conten.tbl_letter_conten conten in letter.letter_contenList)
                                {
                                %>
                            <div class="fL comTit">
                                <p><a href="#"><%=conten.user.User_Name %></a> | <%=conten.Letter_Conten_Time %> </p>
                                <p><%=conten.Letter_Conten_Doc %></p>
                            </div>
                                <%
                                }
                            %>
                        </div>
                    </p>
                    </div>
                    <p class="p_dh"> <span class="qx">共<%=letter.letter_contenList.Length %>条对话</span> <a href="javascript:void(0)" class="qx ml5" onClick="showdiv('<%=letter.letter_user.User_Id %>','<%=letter.letter_user.User_Name %>')">回复</a> <a href="javascript:void(0)" class="qx ml5">删除</a> </p>
                </div>
            </li>
<% 
    }        
%>
        </ul>
        <p class="itemPage clearfix"> <%=pagestr%></p>
        <div class="reply" id="show">
         <form id="lettermpostForm" name="lettermpostForm" action="/Reception/index.aspx?ds=user&cm=lettersend" method="post" onsubmit=""  enctype="multipart/form-data">
          <h1><img src="<%=Save("user_img").ToString() %>"><a href=""><%=Save("user_name").ToString() %></a>，给他写封信~ <span id="shut" onclick="hidediv()">×</span> </h1>
          <div class="mesformBox">
            <h3>发送给：
              <input value="" name="user_letter_name" class="mesInput">
            </h3>
            <textarea name="letter_conten_doc" id="" class="mesArea"  >内容在这里输入，亲~</textarea>
            <p class="commBtn"><span class="bntIcon01"></span><span class="fR">您可以输入<em>800</em>字符</span></p>
            <p class="commBtn"><a href="javascript:sendletter()" class="comReplyBtn">发表回复</a></p>
            <input value="" type=hidden name="letter_user_id" class="mesInput">
          </div>
         </form>
        </div>
      </div>
      <div id="bg" onClick="hidediv()"></div>
    </div>
  </div>
</div>
<div class="pB40"></div>







<%=model.ReadModel("/Reception/templates/default/public/user_foot.aspx")%>
