<%@ Page Language="C#" AutoEventWireup="true" CodeFile="side.aspx.cs" Inherits="Reception_templates_default_public_side" %>

<div class="side">
    <ul>
        <li class="relative first">
            <a href="javascript:;" title="" class="nickName">
                <span class="txt"><%=Save("user_name").ToString()%></span>
                <span class="txt"><%=Save("user_email").ToString() %></span>
            </a>
            <span class="downTriangle"></span>
        </li>
        <li class="sideLi">
            <a><span class="sicon1"></span>文章<%=(Save("totalcount")+"").Length > 0 ? string.Format("({0})",Save("totalcount")):"" %></a>
        </li>
        <li class="sideLi">
            <a><span class="sicon2"></span>通知</a>
        </li>
        <li class="sideLi">
            <a><span class="sicon3"></span>私信</a>
        </li>
        <li class="sideLi">
            <a><span class="sicon4"></span>个人设置</a>
        </li>
    </ul>
    <ul class="marT20">
        <li class="sideLi">
            <a><span class="sicon5"></span>关注</a>
        </li>
        <li class="sideLi">
            <a><span class="sicon6"></span>发现达人</a>
        </li>
    </ul>
</div>
