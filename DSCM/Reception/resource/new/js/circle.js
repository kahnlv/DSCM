$('.user').hover(
    function () {
        $('.userHover').show();
    },
    function () {
        $('.userHover').hide();
    }
);

//*******************
$('.editDiv .cancle').bind('click', function () {
    $('.editDiv,.mask').hide();
    $('.publishBar').css('visibility', 'visible');
});
$('.publishLink').bind('click', function () {
    $('.editDiv,.mask').show();
    $('.publishBar').css('visibility', 'hidden');
    $('.editInputDiv').hide();
    switch ($(this).parent('li').index()) {
        case 1:
            $('.editInputDiv').eq(2).show();
            //$('.musicInputDiv').hide().eq(-1).show();
            break;
        case 2:
            $('.editInputDiv').eq(0).show();
            $('.muti_picUpload').hide();
            break;
        case 3:
            $('.editInputDiv').eq(1).show();
            $('.musicInputDiv').hide().eq(0).show();
            break;
        case 4:
            $('.editInputDiv').eq(1).show();
            $('.musicInputDiv').hide().eq(1).show();
            break;
    }
});

$('.messageImg, .nick').on('mouseover', function (e) {
    var userid = $(this).parents('.messageList').attr('data-user'), param = { 'act': 'getInfo', 'uid': userid }, that = $(this);
    ajax_fun(param, function (result) {
        if (result.success) {
            if ($('.popup').html()) {
                $('.popup').remove();
            }
            that.append(popup(result));
        }
    });
});

//=========显示名片=========
var popup = function (data) {
    var html = '<div class="popup">\
                    <div class="popTriangle-top-left"></div>\
                    <div class="poptop clearfix">\
                        <div class="fl clearfix">',
        user = data.user, article = data.article, alike = data.alike, len = 0, item = '';

    if (user) {
        html += '<a href="" class="sHeadIcon fl"><img src="' + user.User_Img + '" alt=""></a>\
                            <p class="nickname">' + user.User_Name + '</p>';
        if (data.count > 0) {
            html += '<p class="wenzhang">文章 ' + data.count + '</p>';
        }
        html += '</div>';
        if (user.Guanzhu == 1) {
            html += '<a class="fr focus" href="javascript:;" data-user="' + user.User_Id + '">已关注</a>';
        } else if (user.Guanzhu == 0) {
            html += '<a class="fr focus"  href="javascript:;" data-user="' + user.User_Id + '">关注</a>'
        }

        html += '</div>';
    }

    if (article) {
        html += '<div class="imgShow clearfix">';
        len = article.length;
        if (len > 0) {
            for (var i = 0; i < len; i++) {
                item = article[i];
                if (item.Article_Pic.length > 0) {
                    html += '<a href="javascript:;" class="imgCont"><img src="' + item.Article_Pic + '" alt=""></a>';
                } else {
                    html += '<a href=""><span class="txtCont">\
								<p class="title">' + item.Article_Title + '</p>\
								<p class="txt">' + unescape(item.Article_Contents) + '</p>\
							</span></a>';
                }
            }
        } else {
            html += '<p class="noData">暂无内容</p>';
        }
        html += '</div>';
    }

    if (alike) {
        for (var i = 0, len = alike.length ; i < len ; i++) {
            item = alike[i];
            html += '<div class="recommend">\
					        更多相似达人：<a href="" title="">'+ item.User_Name + '</a>\
					</div>';
        }
    }
    html += '</div>'
    return html;
};

//=========移除名片=========
$(document).on('mouseover.leftMain', function (e) {
    var element = e.srcElement || e.target;
    if (!$(element).parents().hasClass('popup') && !$(element).parents().hasClass('messageImg') && !$(element).hasClass('nick')) {
        $('.popup').remove();
    }
});

//=========关注/取消关注=========
$(document).on('click.follow', 'a.focus, a.focusBtn, a.followbtn', function (e) {
    var userid = $(this).attr('data-user'), param = { 'act': 'follow', 'uid': userid }, that = $(this), oldText = that.text();
    ajax_fun(param, function (result) {
        if (result.success) {            
            if (that.hasClass('focusBtn')) {
                that.html($.trim(oldText) == '取消关注' ? '<b>+</b><span>关注</span>' : '<span>取消关注</span>');
            }
            else if (that.hasClass('followbtn')) {
                if (oldText == '+') {
                    that.text('-').attr('title', '取消关注');
                } else {
                    that.text('+').attr('title', '添加关注');
                }
            }
            else {
                that.text(oldText == '已关注' ? '关注' : '已关注');
            }
        } else {
            alert(result.msg);
        }
    });
});

$('.uploadPic').on('change', function () {
    var $imgFrm = $(this).parent();
    $imgFrm.ajaxSubmit({
        url: '/Reception/index.aspx?ds=LoadImg&cm=loadimg',
        dataType: 'json', type: 'post',
        success: function (result) {
            if (result.success) {
                if ($imgFrm.attr('id') == 'frmImg') {
                    $('.picUpload').hide();
                    $('.muti_picUpload').show();
                    $('.picUploadWrap').html('').show();
                    $('.editInputDiv').eq(-1).show().find('.titleInputDiv').hide();
                }
                $('.picUploadWrap').append(setImgHtml(result.msg));
                $('.imgList img').each(function () {
                    var img = new Image(), w = $(this).parent().width(), h = $(this).parent().height(), that = $(this);
                    $('<img/>').attr('src', $(this).attr('src')).load(function () {
                        var img_w = this.width, img_h = this.height;
                        if (img_w / img_h >= w / h) {
                            if (img_w > w) {
                                var height = img_h * w / img_w;
                                that.css({ "width": w, "height": height });
                            }
                        } else {
                            if (img_h > h) {
                                var width = img_w * h / img_h;
                                that.css({ "width": width, "height": h });
                            }
                        }
                    });

                });
            }
            else {
                if (result.msg.length > 0) {
                    alert(result.msg);
                }
            }
        }
    });
});

var setImgHtml = function (imgSrc) {
    return '<div class="imgList">\
                            <div class="imgWrap">\
                                <img src="'+ imgSrc + '" alt="">\
                            </div>\
                            <a href="" class="del">×</a>\
                        </div>';
}

$('.del').live('click', function () {
    $(this).parent().remove();
    if ($('.imgList').length == 0) {
        $('.picUpload').eq(0).show();
        $('.muti_picUpload').hide();
        $('.picUploadWrap').hide();
    }
    return false;
});

$('.publish').on('click', function () {
    var arc_title = '', arc_content = '', arc_pic = '', arc_biaoqian = '', arc_type = '', photos = '', index = 0, $frmEdit = $('#frmEdit'), array = [];

    $('.editInputDiv').each(function () {
        if ($(this).is(':visible')) {
            arc_type = $(this).index();
        }
    });

    arc_title = $('.titleInputDiv>:text').val();
    arc_content = ue.getContent();
    arc_biaoqian = $('.tagInputDiv>:text').val();

    $('.imgList img').each(function (index) {
        var src = $(this).attr('src');
        if (index == 0) {
            arc_pic = src;
        } else {
            array.push(src);
        }
    })

    if (array.length > 0) {
        photos = array.join();
    }

    if ($frmEdit) {
        $frmEdit.find('input[name=arc_title]').val(arc_title);
        $frmEdit.find('input[name=arc_content]').val(escape(arc_content));
        $frmEdit.find('input[name=arc_biaoqian]').val(arc_biaoqian);
        $frmEdit.find('input[name=arc_type]').val(arc_type);
        $frmEdit.find('input[name=arc_pic]').val(arc_pic);
        $frmEdit.find('input[name=photos]').val(photos);
        $frmEdit.ajaxSubmit({
            url: '/Reception/index.aspx?ds=quanzi&cm=dsarcinsert',
            dataType: 'json',
            success: function (result) {
                if (result.success) {
                    console.log('添加成功喽');
                    $('.publishBar').after(setContentHtml(arc_pic, arc_content, arc_title, '', arc_biaoqian ? arc_biaoqian.split(',') : '', result.msg, true));
                    $('.editDiv,.mask').hide();
                    $('.publishBar').css('visibility', 'visible');
                } else {
                    alert(result.msg);
                }
            }
        });
    }
});

$('.cancle').on('click', function () {
    ue.setContent('');
    $('.titleInputDiv>:text').val('');
    $('.tagInputDiv>:text').val('');
});

var setContentHtml = function (pic, content, title, nickname, tags, guid, isEdit) {
    var html = '<div class="messageList clearfix" data-id="' + guid + '">\
            <a class="messageImg fl" href="">\
                <img src="" alt="">\
            </a>\
            <div class="messageCont fr">\
                <a class="nick" href="">' + nickname + '</a>\
                <div class="mainCont">',
                tag = '';
    if (pic) {
        html += '<a class="imgCont fl" href="">\
                        <img src="'+ pic + '" alt="">\
                    </a>';
    }
    html += '<div class="txt">\
                        <p><a href="">'+ title + '</a></p>\
                        <p>'+ content + '</p>\
                    </div>\
                    <div class="opt">\
                    <div class="optLeft">';
    for (var i = 0, len = tags.length; i < len; i++) {
        tag = tags[i];
        html += '<span><a href="">' + (i == 0 ? '<i class="bqIcon"></i>' : '') + tag + '</a></span>';
    }
    if (isEdit) {
        html += '   </div>\
                    <div class="optRight">\
                        <span><a href="javascript:;" class="edit">编辑</a>\
                        <span><a href="javascript:;" class="deleted">删除</a></span>\
                        <span><a href="javascript:;" class="review">评论</a></span>\
                    </div>\
                </div>\
            </div>\
        </div>\
    </div>';
    } else {
        html += '   </div>\
                    <div class="optRight">\
                        <span><a href="">热度(0)</a></span>\
                        <span><a href="">评论(0)</a></span>\
                        <span><a href="javascript:;"><i class="zanIcon">赞</i></a></span>\
                    </div>\
                </div>\
            </div>\
        </div>\
    </div>';
    }
    return html;
}

$(document).on('click.like', '.zanIcon', function () {
    var $optRight = $(this).parents('.optRight'), hasOn = $(this).hasClass('on'), id = $optRight.attr('data-id'), param = { 'act': 'like', 'aid': id, 'o': (hasOn ? 1 : 0) }, that = $(this);
    ajax_fun(param, function (result) {
        if (result.success) {
            $hot = $optRight.find('span .hot');
            var hot = parseInt($hot.children('i').text());
            if (that.hasClass('on')) {
                that.removeClass('on');
                hot = isNaN(hot) ? 0 : hot -= 1;
                if (hot == 0) {
                    $hot.remove();
                }
            }
            else {
                that.addClass('on');
                if ($hot.length > 0 && !isNaN(hot)) {
                    $hot.children('i').text(hot++);
                } else {
                    $optRight.html('<span><a href="javascript" class="hot">热度(<i>1</i>)</a></span>' + $optRight.html());
                }
            }
        } else {
            alert(result.msg);
        }
    });
});

$(document).on('click.delete', '.deleted', function () {
    var that = $(this).parents('.messageList'), id = that.find('.optRight').attr('data-id'), param = { 'act': 'del', 'aid': id };
    ajax_fun(param, function (result) {
        if (result.success) {
            that.remove();
        }
        else {
            alert(result.msg);
        }
    });
});


var ajax_fun = function (param, callback) {
    $.ajax({
        url: '/ajax/circle.ashx',
        data: param, dataType: 'json',
        success: function (result) {
            (callback && typeof (callback) === 'function') && callback(result);
        },
        error: function () {
        }
    });
}

$(document).on('click.hotTag', '.blogRight a', function () {
    var tagName = $(this).attr('data-name');
});