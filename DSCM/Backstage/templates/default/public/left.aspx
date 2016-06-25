<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/1 14:44:01 
* File name：left 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="Backstage_templates_default_public_left" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="" />
<meta name="description" content=""/>
<link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/base.css" rel="stylesheet" type="text/css"/>
<link href="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/css/index.css" rel="stylesheet" type="text/css"/>
<script type="text/javascript" src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/js/jquery-1.8.3.min.js"></script>
</head>
<body>
<div class="main w"> 
  <!-- 左边 start -->
    <div class="menu" id="menu">
      <div class="sidebar">
        <h3><img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/tx.png"><span><%=TypeToStr(type) %></span></h3>
        <div class="my">
<%
   // DSCM_NAV.Navigation.Length
    if (DSCM_NAV != null && DSCM_NAV.Navigation != null)
    {
        foreach (DSCM.BLL.Navigation nav in DSCM_NAV.Navigation)
        {
            if (nav.Title.Equals(TypeToStr(type)))
            {
                foreach (DSCM.BLL.Menu menu in nav.Menu)
                {
%>
        <dl>
            <dt class="dt"><a href="javascript:void(0)"><img src="<%=HTMLConfig.HTML_ADMIN_PATH_RESOURCE %>new/images/icon4.png"><%=menu.Title%></a></dt>
            <dd class="dd" style="display:none ;"> 
<% 
    if (menu._Menu != null)
    {
        foreach (DSCM.BLL.Menu mu in menu._Menu)
        {            
%>
                <a href="<%=mu.Url %>" target="main" ><i></i><%=mu.Title%><em></em></a> 
<% 
    }
    }
%>              
            </dd>
        </dl>
<% 
    }
            }
        }
    }else
    {
    %>
    <script>
        parent.location = "/Backstage/templates/default/login.aspx";
    </script>
    <%
    }
%>
          
        </div>
      </div>
      <script type="text/javascript">
          $(function () {
              $(".my").find(".dt").click(function () {
                  if ($(this).parent("dl").find(".dd").css("display") == "none") {
                      $(".my").find(".dd").slideUp();
                      $(this).parent("dl").find(".dd").slideDown();
                  } else {
                      $(this).parent("dl").find(".dd").slideUp();
                  }
              });
          });
   
</script> 
    </div>
  </div>
  <!-- 左边 end --> 
</div>
</body>
</html>

