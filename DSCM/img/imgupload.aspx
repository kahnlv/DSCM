<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imgupload.aspx.cs" Inherits="img_imgupload" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta   http-equiv= "content-type "   content= "application/vnd.wap.xhtml+xml;charset=UTF-8 "/> 
<title></title>
</head>
<body>
<% if (succe)
   {
%>
<script>
    parent.document.getElementById("<%=imageSrc %>").src = "<%=imgSrc %>";
    parent.document.getElementById("<%=imageValue %>").value = "<%=imgSrc %>";
</script>
<%
   }
%>
<!-- form start -->
<form id="mpostForm" name="mpostForm" action="/img/imgupload.aspx" method="post" enctype="multipart/form-data">

    <input type="button" class="btn" value="浏览文件">
    <input type="file" name="fileUp" class="file" id="fileUp">
    <input type="submit" name="File1" id="File1" class="btn" value="上传">
    <input name="src" id="src"  type="hidden" value="<%=imageSrc %>">
    <input name="value" id="value"  type="hidden" value="<%=imageValue %>">
</form>

<style type="text/css">
    .file-box{ position:relative;width:340px} 
    .txt{ height:22px; border:1px solid #cdcdcd; width:180px;} 
    .btn{ background-color:#FFF; border:1px solid #CDCDCD;height:24px; width:70px;} 
    .file{ position:absolute; top:9px; left:9px; height:24px; filter:alpha(opacity:0);opacity: 0;width:70px } 
</style>

</body>
</html>
