<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:23:23 
* File name：center_photolist2 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="center_photolist2.aspx.cs" Inherits="Reception_templates_default_center_photolist2" %>

<%=model.ReadModel("/Reception/templates/default/public/center_heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<script>
    var json = eval('(' + '<%=JsonStr %>' + ')');
</script>
<div class="mainWarp W1200 pB40 mT30 clearfix">
    <div class="W1200">
        <input type="hidden" name="photoid" id="photoid" value="<%=photo_img.Photo_Id %>" />
        <input type="hidden" name="imgid" id="imgid" value="<%=photo_img.Photo_Img_Id %>" />
        <div class="imgbox">
            <div class="titlebox">
                <div class="title"><span id="title"><%=photo_img.Photo_Img_Title%></span></div>
                <div class="num"><span id="number"></span>/<span id="photonum"><%=photo_img.photo.num %></span></div>
            </div>
            <div class="banner">
                <div class="img">
                    <a href="javascript:void(0)"><img id="imgsrc" src="<%=photo_img.Photo_Img_Path%>" alt="" style="width:1200px;height:678px"/></a>                
                </div>
                <i class="left" id="prev"></i>
                <i class="right" id="next"></i>
                <div class="introdus" id="imgdoc"><%=photo_img.Photo_Img_Doc%></div>
                <div class="little-img">
                    <ul>
                        <li><img id="little1" alt="" src="<%=photo_img.Photo_Img_Path%>"/></li>
                        <li class="current"><img id="littleimgsrc" alt="" src="<%=photo_img.Photo_Img_Path%>" /></li>
                        <li><img id="little2" alt="" src="<%=photo_img.Photo_Img_Path%>"/></li>
                    </ul>
                </div>
                <div class="share">
                    <a href="javascript:void(0)" class="btn_zan"><i class="dianzan"></i><span id="zannum"><%=photo_img.zannum%></span></a>
                    <a href="javascript:void(0)"><i class="weibo"></i><span id="plnum"><%=photo_img.plnum%></span></a>
                </div>
            </div>
        </div>
        <div class="commentWarp"  id="commList">
        
        </div>
    </div>
</div>
<script type="text/javascript">

    var imgid = document.getElementById("imgid").value;
    var allcount = json.total; //总条数
    var nImgIndex = 0; //当前图片索引
    for (var item in json.rows) {
        if (imgid == json.rows[item].photo_img_id) {
            nImgIndex = json.rows.indexOf(json.rows[item]);
            document.getElementById("number").innerHTML = nImgIndex + 1;
        }
    }
    SetValue(nImgIndex);
    var prev = document.getElementById("prev");
    var next = document.getElementById("next");
    //下一张图片
    next.onclick = function () {
        if (nImgIndex == allcount - 1) {
            nImgIndex = 0;
        }
        else {
            nImgIndex++;
        }
        SetValue(nImgIndex);
        Setfunction();
    }
    //上一张图片
    prev.onclick = function () {
        if (nImgIndex == 0) {
            nImgIndex = allcount - 1;
        }
        else {
            nImgIndex--;
        }
        SetValue(nImgIndex);
        Setfunction();
    }
    //为页面上的一些内容项赋值
    function SetValue(nImgIndex) {
        if (allcount > 0) {

            if (allcount == 1) {
                document.getElementById("little1").src = json.rows[0].photo_img_path.replace('big', 'saml');
                document.getElementById("little2").src = json.rows[0].photo_img_path.replace('big', 'saml');
            }
            else {
                if (nImgIndex == 0) {
                    document.getElementById("little1").src = json.rows[allcount - 1].photo_img_path.replace('big', 'saml');
                    document.getElementById("little2").src = json.rows[nImgIndex + 1].photo_img_path.replace('big', 'saml');
                }
                else if (nImgIndex == allcount - 1) {
                    document.getElementById("little1").src = json.rows[nImgIndex - 1].photo_img_path.replace('big', 'saml');
                    document.getElementById("little2").src = json.rows[0].photo_img_path.replace('big', 'saml');
                }
                else {
                    document.getElementById("little1").src = json.rows[nImgIndex - 1].photo_img_path.replace('big', 'saml');
                    document.getElementById("little2").src = json.rows[nImgIndex + 1].photo_img_path.replace('big', 'saml');
                }
            }
            document.getElementById("imgid").value = json.rows[nImgIndex].photo_img_id;
            document.getElementById("photonum").innerHTML = json.total;
            document.getElementById("number").innerHTML = nImgIndex + 1;
            document.getElementById("imgsrc").src = json.rows[nImgIndex].photo_img_path;
            document.getElementById("littleimgsrc").src = json.rows[nImgIndex].photo_img_path.replace('big', 'saml');
            document.getElementById("title").innerHTML = json.rows[nImgIndex].photo_img_title;
            document.getElementById("imgdoc").innerHTML = json.rows[nImgIndex].photo_img_doc;
            document.getElementById("plnum").innerHTML = json.rows[nImgIndex].plnum;
            document.getElementById("zannum").innerHTML = json.rows[nImgIndex].zannum;

            imgid = document.getElementById("imgid").value;
            fLoadImgCom(json.rows[nImgIndex].photo_img_id);
        }       
    }

    //加载图片的评论信息
    function fLoadImgCom(imgId) {
        $.ajax({
            type: "post",
            url: "/Reception/index.aspx?ds=center&cm=phlistcom&id=" + imgId,
            async: false,
            cache: false,
            success: function (result) {
                document.getElementById("commList").innerHTML = result;               
            },
            error: function (mes) {
                alert(mes + "失败");
            }
        });
    }

    //发表评论
    function imgmesinsert() {
        var obj = document.imgcominsertpostForm;
        obj.photo_img_id.value = imgid;
        obj.submit();
    }
    //回复评论
    function subimgcom(id) {
        var obj2 = document.getElementById("imgcom" + id);
        obj2.photo_img_id.value = imgid;
        obj2.submit();
    }
    //图片点赞
    $(".btn_zan").click(function () {
        var imgid = $("#imgid").val();
        var that = $(this).find("span#zannum");
        $.ajax({
            type: "POST",
            url: "/Reception/index.aspx?ds=center&cm=zanimg",
            data: { id: imgid },
            dataType: 'text',   //返回的数据类型
            async: false,
            cache: false,
            success: function (result) {
                that.html(result);
            },
            error: function () {
                alert("点赞失败");
            }
        });
    });
</script>

<%=model.ReadModel("/Reception/templates/default/public/center_foot.aspx")%>
