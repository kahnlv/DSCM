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
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_update.aspx.cs" Inherits="Backstage_templates_default_zc_update" %>
<%@ Register TagPrefix="topwin" TagName="c_topwin" Src="~/Backstage/templates/default/public/heard.ascx" %>
<topwin:c_topwin runat="server" id="c_topwin1"/>  
<link rel="stylesheet" href="/data/resource/rili/jquery-ui.css">
<link rel="stylesheet" href="/data/resource/rili/style.css">
<script src="/data/resource/rili/jquery-1.10.2.js" type="text/javascript"></script>
<script src="/data/resource/rili/jquery-ui.js" type="text/javascript"></script>
<script type="text/javascript">
    function checInput(regstr, objvalue, errornote) {
        if (!regstr.test(objvalue)) {
            document.getElementById(errornote).innerHTML = "您输入的格式不正确！";
        }
        else {
            document.getElementById(errornote).innerHTML = "";
        }
    }
    function checkUserCode() {
        var obj = documen
        t.mpostForm;
        var regCode = /^\d{15}$|^\d{18}$|^\d{17}(\d|X|x)$/;
        checInput(regCode, obj.user_code.value, "noticeUserCode");
    }
    function checkMobile() {
        var obj = document.mpostForm;
        var regMobile = /^1[3,4,5,8]\d{9}$/;
        checInput(regMobile, obj.user_phone.value, "noticePhone");
    }
    function checkEmail() {
        var obj = document.mpostForm;
        var regEmail = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+(\.[a-zA-Z]{2,3})+$/;
        checInput(regEmail, obj.user_email.value, "noticeEmail");
    }  
    function sub() {
        document.getElementById("error").innerHTML = "";
        var obj = document.mpostForm;
        if (obj.object_title.value == "") {
            document.getElementById("error").innerHTML = "项目名称不能为空";
            return false;
        }
        if (obj.object_address.value == "") {
            document.getElementById("error").innerHTML = "项目地点不能为空";
            return false;
        }
        if (obj.object_class.value == "") {
            document.getElementById("error").innerHTML = "项目类别不能为空";
            return false;
        }
    }
</script>
<div class="conenttow">
  <div class="base_root2">
<form id="mpostForm" name="mpostForm" action="/backstage/index.aspx?ds=zc&cm=dsupdate" method="post" onsubmit="return sub()">
    <h3><span>项目回报基本信息</span></h3>
     <ul class="forminfo">
      <li class=" mt10">
        <span>项目名称：</span><input type="text" name="object_title" value="<%=tobj.Object_Title%>" class="w340"/>
      </li>
      <li class="mt10">      
        <span>游戏名称：</span><input type="text" name="object_game_name" value="<%=tobj.Object_Game_Name %>"  class="w340"/> 
      </li>
      <li class="mt10">      
        <span>项目发起人：</span><input type="text" name="user_name" value="<%=tobj.User_Name %>" class="w150"/>
      </li>
      <li class=" mt10">
        <span>项目地点：</span> <div id="province" class="city_select">
            <select name="object_address" onchange="change(this)">
                <option value="">请选择</option>
                <% 
                    foreach (DSCM.ds_tbl_province.tbl_province pro in province)
                    {                %>
                     <option value="<%=pro.DI %>" <%if(pro.DI.Equals(provinceid)){ %> selected="selected"<%} %>><%=pro.Provincename%></option>                
                 <% }%>
            </select>
        </div>
        <div id="city" class="city_select"></div>      
      </li>
      <script type="text/javascript">
          function change(obj) {
              $.get("/backstage/index.aspx?ds=city", { id: obj.value }, function (data) {
                  document.getElementById("city").innerHTML = data;
              });
          }
      </script>
      <li class=" mt10">
         <span>项目类别：</span> <span id="object_class" class="city_select">
            <select name="object_class">
                <option value="">请选择</option>
                <option <%if(tobj.Object_Class.Equals("动漫")){ %>selected<%} %>  value="动漫">动漫</option>
                <option <%if(tobj.Object_Class.Equals("游戏")){ %>selected<%} %>  value="游戏">游戏</option>
                <option <%if(tobj.Object_Class.Equals("Cosplay")){ %>selected<%} %>  value="Cosplay">Cosplay</option>
                <option <%if(tobj.Object_Class.Equals("漫画")){ %>selected<%} %>  value="漫画">漫画</option>
                <option <%if(tobj.Object_Class.Equals("模型制作")){ %>selected<%} %>  value="模型制作">模型制作</option>
                <option <%if(tobj.Object_Class.Equals("影视")){ %>selected<%} %>  value="影视">影视</option>
            </select>
      </li>
      <li class=" mt10">
      <span>项目标签：</span>
          <div class="tips_checkbox">
            <input name="object_label" type="checkbox" value="桌面" <%if(tobj.Object_Label.Contains("桌面")){%> checked <%} %>/><em>桌面</em>
            <input name="object_label" type="checkbox" value="探险" <%if(tobj.Object_Label.Contains("探险")){%> checked <%} %>/><em>探险</em>
            <input name="object_label" type="checkbox" value="娱乐场" <%if(tobj.Object_Label.Contains("娱乐场")){%> checked <%} %>/><em>娱乐场</em>
            <input name="object_label" type="checkbox" value="骰子" <%if(tobj.Object_Label.Contains("骰子")){%> checked <%} %>/><em>骰子</em>
            <input name="object_label" type="checkbox" value="教育" <%if(tobj.Object_Label.Contains("教育")){%> checked <%} %>/><em>教育</em>
            <input name="object_label" type="checkbox" value="扑克牌" <%if(tobj.Object_Label.Contains("扑克牌")){%> checked <%} %>/><em>扑克牌</em>
            <input name="object_label" type="checkbox" value="街机" <%if(tobj.Object_Label.Contains("街机")){%> checked <%} %>/><em>街机</em>
            <input name="object_label" type="checkbox" value="儿童" <%if(tobj.Object_Label.Contains("儿童")){%> checked <%} %>/><em>儿童</em>
         </div> 
      </li>
      <li class=" mt10">      
      <span>项目预计平台：</span>
          <div class="tips_checkbox">
            <input name="object_pingtai" type="checkbox" value="iOS"  <%if(tobj.Object_Pingtai.Contains("iOS")){%> checked <%} %>/><em>iOS</em>
            <input name="object_pingtai" type="checkbox" value="Android"  <%if(tobj.Object_Pingtai.Contains("Android")){%> checked <%} %>/><em>Android</em>
            <input name="object_pingtai" type="checkbox" value="Phone"  <%if(tobj.Object_Pingtai.Contains("Phone")){%> checked <%} %>/><em>Phone</em>
          </div>
      </li>
      <li class="mt10">      
        <span>融资目标：</span>
        <input type="text" name="object_raise_price" value="<%=tobj.Object_Raise_Price%>" class="w150" 
        onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14"/>元
      </li>
      <li class="mt10">      
        <span>开始时间：</span><input type="text" name="object_start_time" id="object_start_time" value="<%=tobj.Object_Start_Time%>" class="w150"/>   
      </li>
      <script type="text/javascript">
          $(function () {
              $("#object_start_time").datepicker();
          });
	  </script>
      <li class="mt10">      
       <span>募资期限：</span><input type="text" name="object_qixian" value="<%=tobj.Object_Qixian%>" class="w150" 
        onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14"/>天
      </li> 
      <li class="mt10">      
       <span>游戏开发周期：</span><input type="text" name="object_game_zhouqi" value="<%=tobj.Object_Game_Zhouqi%>" class="w150" 
        onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14"/>天
      </li>
      <li class="mt10">      
       <span>已经开发时间：</span><input type="text" name="object_raise_start_time" value="<%=tobj.Object_Raise_Start_Time%>" class="w150" 
        onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14"/>天
      </li>
      <li class="mt10">      
         <span>已有开发商：</span>
         <div>
        <label><input type="radio" name="object_kaifashang" value="1" id="Radio1" <%=tobj.Object_Kaifashang.Equals("1")?" checked ":"" %>/>是</label>
        <label><input type="radio" name="object_kaifashang" value="0" id="Radio2" <%=tobj.Object_Kaifashang.Equals("0")?" checked ":"" %>/>否</label>
        </div>
      </li>
      <li class=" mt10">
        <span>希望引入VC：</span>  
        <div>
        <label><input type="radio" name="object_VC" value="1" id="Radio3" <%=tobj.Object_VC.Equals("1")?" checked ":"" %>/>是</label>
        <label><input type="radio" name="object_VC" value="0" id="Radio4" <%=tobj.Object_VC.Equals("0")?" checked ":"" %>/>否</label>
        </div>
      </li>
      <li class=" mt10">        
        <span>身份证号：</span>
        <input type="text" name="user_code" value="<%=tobj.User_Code%>" class="w150" onblur="checkUserCode()"  maxlength="18"/>
        <label class="error" id="noticeUserCode"></label>      
      </li>
      <li class=" mt10">        
        <span>手机号：</span>
        <input type="text" name="user_phone" value="<%=tobj.User_Phone %>" class="w150" onblur="checkMobile()" maxlength="11"/>  
        <label class="error" id="noticePhone"></label>  
      </li>
      <li class=" mt10">        
        <span>邮箱：</span>
        <input type="text" name="user_email" value="<%=tobj.User_Email %>" class="w150"  onblur="checkEmail()"/>     
         <label class="error" id="noticeEmail"></label>
      </li>
      <li class=" mt10">        
        <span>性别：</span>
          <div>
           <label><input type="radio" name="user_sex" value="1" id="Radio5" <%=tobj.User_Sex.Equals("1")?" checked ":"" %>/>男</label>
           <label><input type="radio" name="user_sex" value="0" id="Radio6" <%=tobj.User_Sex.Equals("0")?" checked ":"" %>/>女</label>
         </div>
      </li>
      <li class=" mt10">
       <span>项目图片：</span>           
        <div>
        <img src="<%=tobj.Object_Img %>" id="object_img" alt="" width="50px" height="50px"/>
        <input type="hidden" name="object_img" id="img1" value="<%=tobj.Object_Img %>" />
        <iframe src="/img/adminupload.aspx?src=object_img&value=img1" style="border:none;height:40px" frameborder="0"></iframe>     
        </div>    
        </li>
        <li>
       <span>项目视频：</span>    
        <div>
        <img src="<%=tobj.Object_Video %>" id="object_video" alt="" width="50px" height="50px"/>
        <input type="hidden" name="object_video" id="img2" value="<%=tobj.Object_Video %>" />
        <iframe src="/img/adminupload.aspx?src=object_video&value=img2" style="border:none;height:40px" frameborder="0"></iframe>
        </div>     
        </li>
        <li>   
       <span>身份证照片：</span>
        <div>
        <img src="<%=tobj.User_Code_Img %>" id="user_code_img" alt="" width="50px" height="50px"/>
        <input type="hidden" name="user_code_img" id="img3" value="<%=tobj.User_Code_Img %>" />
        <iframe src="/img/adminupload.aspx?src=user_code_img&value=img3" style="border:none;height:40px" frameborder="0"></iframe>
        </div>    
      </li>
      <li class="mt10">
         <input type="hidden" name="object_id" value="<%=object_id %>" />
         <input type="submit" value="提交" />
      </li>
     </ul>
  
   <%-- <tr>
      <th>项目简介：</th>
      <td colspan="5"><textarea style="width:300px;height:100px;" name="object_zc_doc"><%=tobj.Object_Doc %></textarea></td>
      <th>项目介绍：</th>
      <td colspan="7"><textarea style="width:300px;height:100px;" name="object_zc_doc"><%=tobj.Object_Content %></textarea></td>
    </tr>--%>
   </form>
  </div>  
</div>
</body>
</html>
