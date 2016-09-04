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
            $('.titleInputDiv').show();
            //$('.musicInputDiv').hide().eq(-1).show();
            break;
        case 2:
            $('.editInputDiv').eq(0).show();
            $('.picUpload').show();
            $('.muti_picUpload').hide();
            $('.picUploadWrap').hide();
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

//=========显示名片=========
$('.leftMain .messageImg,.leftMain .nick').on('mouseover', function (e) {
    var userid = $(this).parents('.messageList').attr('data-user'), param = { 'act': 'getInfo', 'uid': userid }, that = $(this);
    if (!$('.popup').html()) {
        ajax_fun(param, function (result) {
            console.log(result)
            if (result.success) {
                that.append(popup(result));
            }
        });
    }
});
$('.f-cb li').on('mouseover', function (e) {
    var userid = $(this).attr('data-user'), param = { 'act': 'getInfo', 'uid': userid }, that = $(this);
    if (!$('.popup').html()) {
        ajax_fun(param, function (result) {
            console.log(result)
            if (result.success) {
                that.append(popup(result));
            }
        });
    }
});

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

    html += '<div class="imgShow clearfix">';
    if (article && article.length > 0) {
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
    } else {
        html += '<p class="noData">暂无内容</p>';
    }

    html += '</div>';

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
$(document).on('mouseleave', '.popup', function (e) {
    $(this).remove();
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
        },
        error: function () {
            alert('您上传的图片超过1M，请裁剪后再重新上传')
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
        $('.picUpload').show();
        $('.muti_picUpload').hide();
        $('.picUploadWrap').hide();
        $('.editInputDiv').eq(-1).hide();
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
                    $('.publishBar').after(setContentHtml(arc_pic, arc_content, arc_title, result.user.User_Name, result.user.User_Img, arc_biaoqian ? arc_biaoqian.split(',') : '', result.msg, true, photos, 0, 0, result.msg));
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

var setContentHtml = function (/**封面图*/pic, /**内容*/content, /**标题*/title, /**昵称*/nickname, /**头像*/headImg, /**标签*/tags, /**用户id*/guid, /**是否能编辑*/isEdit, /**图片集*/photos,/**热度*/hot, /**评论数*/review, /**文章ID*/aid) {
    var html = '<div class="messageList clearfix" data-id="' + guid + '">\
            <div class="messageImgDiv relative">\
                <a class="messageImg fl" href="javascript::">\
                    <img src="' + headImg + '" alt="">\
                </a>\
            </div>\
            <div class="messageCont fr">\
                <a class="nick" href="javascript::">' + nickname + '</a>\
                <div class="mainCont"><div class="clearfix">',
                tag = '', ol = '';
    if (pic) {
        html += '<div class="imgc"><a class="imgCont fl smallImg" href="javascript:;">\
                        <img src="' + pic + '" alt="">';

        ol = '<ol class="bigImg none"><li><img src="' + pic + '" alt="">\
                                    <a href="' + pic + '" target="_blank" class="">查看大图</a></li>';
        if (photos.length > 0) {
            var photo = photos.split(','), len = photo.length;
            html += '<span class="total">' + (len + 1) + ' </span>';

            for (var i = 0 ; i < len; i++) {
                var item = photo[i];
                ol += '<li><img src="' + item + '" alt="">\
                                    <a href="' + item + '" target="_blank" class="">查看大图</a></li>';
            }
        }
        ol += '</ol>';

        html += '</a>' + ol + '</div>';
    }
    html += '<div class="txt">\
                        <p><a href="javascript::">' + title + '</a></p>\
                        <p>'+ content + '</p>\
                    </div></div>\
                    <div class="opt">\
                    <div class="optLeft">';
    if (tags && tags.length > 0) {
        for (var i = 0, len = tags.length; i < len; i++) {
            tag = tags[i];
            html += '<span><a href="">' + (i == 0 ? '<i class="bqIcon"></i>' : '') + tag + '</a></span>';
        }
    }
    if (isEdit) {
        html += '   </div>\
                    <div class="optRight" data-id="'+ aid + '">\
                        ' + (hot > 0 ? '<span><a href="javascript:;" class="hot">热度(' + hot + ')</a></span>' : '') + '\
                        <span><a href="javascript:;" class="edit none">编辑</a>\
                        <span><a href="javascript:;" class="deleted">删除</a></span>\
                        <span><a href="javascript:;" class="review">评论' + (review > 0 ? '(' + review + ')' : '') + '</a></span>\
                    </div>\
                </div>\
            </div>\
        </div>\
    </div>';
    } else {
        html += '   </div>\
                    <div class="optRight" data-id="' + aid + '">\
                        <span><a href="javascript::">热度(' + (hot > 0 ? '(' + hot + ')' : '') + ')</a></span>\
                        <span><a href="javascript::">评论' + (review > 0 ? '(' + review + ')' : '') + '</a></span>\
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
                    $optRight.html('<span><a href="javascript:;" class="hot">热度(<i>1</i>)</a></span>' + $optRight.html());
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


var ajax_fun = function (param, callback, url, error) {
    if (!url) {
        url = '/ajax/circle.ashx'
    }
    $.ajax({
        url: url,
        data: param, dataType: 'json',
        success: function (result) {
            (callback && typeof (callback) === 'function') && callback(result);
        },
        error: function (errormsg) {
            (error && typeof (error) === 'function') && error(errormsg);
        }
    });
}

$(document).on('click.hotTag', '.blogRight a', function () {
    var tagName = $(this).attr('data-name'),
        pageIndex = 0, pageSize = 10;
    if ($(this).parent('li').hasClass('hot-tag')) {
        return false;
    }
    else {
        $(this).parent('li').addClass('hot-tag').siblings().removeClass('hot-tag');
        setDarenHtml(pageIndex, pageSize, tagName);
    }
});

setDarenHtml = function (/**第几页*/pageIndex, /**总页数*/pageSize, /**标签值*/tagName) {
    var param = { ds: 'quanzi', cm: 'GetList', pi: pageIndex, ps: pageSize, name: tagName },
    loading = $('.loading');
    ajax_fun(param, function (data) {
        var len = data.length, item, html = '', tips = '滚动加载更多';
        if (data && len > 0) {
            for (var i = 0; i < len; i++) {
                item = data[i];
                html += '<li class="blogitm">\
                    <div class="m-info clearfix">\
                        <a href="javascript:;" class="m-head">\
                            <img src="'+ item.User_Img + '" alt="">\
                        </a>\
                        <a class="focusBtn" href="javascript:;" data-user="'+ item.User_Id + '">\
                            '+ (item.Guanzhu == 0 ? "<b>+</b><span>关注</span>" : "<span>取消关注</span>") + '\
                        </a>\
                        <h3>\
                            <a class="ttl" href="javascript:;" target="_blank">'+ item.User_Name + '</a>\
                        </h3>\
                        <div class="tags">';
                if (item.tbl_user_biaoqian && item.tbl_user_biaoqian.length > 0) {
                    for (var j = 0, l = item.tbl_user_biaoqian.length; j < l; j++) {
                        html += item.tbl_user_biaoqian[j].biaoqian_Name;
                    }
                }
                html += '</div>\
                    </div>\
                    <div class="postlist">\
                        <ul>';
                if (item.tbl_article && item.tbl_article.length > 0) {
                    for (var j = 0, l = item.tbl_article.length; j < l; j++) {
                        var aItem = item.tbl_article[j];
                        html += '<li class="m-post m-post-img"><a class="fullnk" href="javascript:;" target="_blank">';
                        if (aItem.Article_Pic.length == 0) {
                            html += '<span class="pic">' + aItem.Article_Title + unescape(aItem.Article_Contents) + '</span><span class="layer"></span>';
                        }
                        else {
                            html += '<span class="pic" style="background: url(' + aItem.Article_Pic + ') center center no-repeat;"></span><span class="layer"></span>'
                        }
                        html += '</a></li>'
                    }
                }
                html += '</ul>\
                    </div>\
                </li>';
            }
        }

        if (len < 10 && len > 0) {
            tips = '<div>到底了~</div>';
        } else if (len == 0) {
            tips = '暂无数据';
        }

        if (pageIndex == 0) {
            $('.blogUL').html(html);
        } else {
            $('.blogUL').append(html);
        }

        pageIndex = parseInt(pageIndex + 1);

        if (loading && loading.length == 0) {
            $('.blogUL').after('<div class="loading daren" data-tag="' + tagName + '" data-page="' + pageIndex + '">' + tips + '</div>');
        }
        else {
            loading.attr({ 'data-page': pageIndex, 'data-tag': tagName }).html(tips);
        }

    }, '/Reception/index.aspx',
        function (error) {
            console.log(error);
            _this.html('<div>服务器有点忙或您的网络断开了，请重新尝试</div>');
        });
}

$(document).on('click', '.smallImg', function () {
    $(this).hide();
    $(this).siblings('.bigImg').show();
});
$(document).on('click', '.bigImg', function () {
    $(this).hide();
    $(this).siblings('.smallImg').show();
});

/*******热点start**********/
$(document).on('click', '.hot', function (e) {
    var id = $(this).parents('.optRight').attr('data-id'),
            messageList = $(this).parents('.messageList'),
            hotPanle = messageList.find('.hotPanle'),
             html = ' <div class="review_pop relative hotPanle">\
					<i class="triange_top" style="right: 183px;"></i>\
					<ul class="review_list marT20"></ul><div class="slideUp">\
						<a href="javascript::">收起</a>\
					</div>\
				</div>';
    if (hotPanle && hotPanle.length == 0) {
        messageList.find('.review_pop').remove();
        messageList.append(html);
        var hotPanle = messageList.find('.review_list');
        setHotHtmml(id, 0, 10, -1, hotPanle);
    }
    else {
        if (hotPanle.is(':hidden')) {
            hotPanle.show();
        } else {
            hotPanle.hide();
        }
    }
});

setHotHtmml = function (id, pi, ps, t, hotPanle) {
    ajax_fun({ ds: 'quanzi', cm: 'review', id: id, pi: pi, ps: ps, t: t }, function (data) {
        var lihtml = '', hotLoad = hotPanle.next('.hotLoad'), tips = '点击加载更多。。。';
        if (data && data.length > 0) {
            for (var i = 0, len = data.length; i < len; i++) {
                var item = data[i],
                    user = item.user;

                lihtml += '<li class="clearfix"><a class="img_left"><img src="' + user.User_Img + '" alt=""></a>';
                lihtml += '<div class="cmtcnt">\
								<div class="cmt_left">\
									<a href="" class="user">' + user.User_Name + '</a>\
									<span class="cmttxt">' + (item.Type == 0 ? '评论了这篇文章' : '喜欢这篇文章') + '</span>\
								</div>\
							</div></li>';
            }
            pi += 1;
            hotPanle.append(lihtml);

            if (len < ps) {
                tips = '';
            }

            if (hotLoad.length == 0) {
                hotPanle.after('<div class="loading hotLoad" data-page="' + pi + '">' + tips + '</div>');
            } else {
                hotLoad.attr('data-page', pi).html('');
            }
        } else {
            hotLoad.html('').removeClass('hotLoad');
        }
    }, '/Reception/index.aspx');
}

$(document).on('click', '.hotLoad', function () {
    var pi = parseInt($(this).attr('data-page')),
        id = $(this).parents('.messageList').find('.optRight').attr('data-id'),
        hotPanle = $(this).siblings('.review_list');

    setHotHtmml(id, pi, 10, -1, hotPanle);
});
/********end*********/

/*****评论start*****/
$(document).on('click', '.review', function () {
    var id = $(this).parents('.optRight').attr('data-id'),
                messageList = $(this).parents('.messageList'),
                reviewPanle = $(this).parents('.messageList').find('.reviewPanle');
    var html = '<div class="review_pop relative reviewPanle">\
					<i class="triange_top"  style="right: 35px;"></i>\
					<div class="add clearfix">\
						<div contenteditable="true" class="inputxt" maxlength="200"></div>\
						<a href="javascript:;" data-id="'+ id + '" class="fb_btn">发布</a>\
					</div>\
					<ul class="review_list marT20">\
					</ul>\
					<div class="slideUp">\
						<a href="javascript::">收起</a>\
					</div>\
				</div>';

    if (reviewPanle && reviewPanle.length == 0) {
        messageList.find('.review_pop').remove();
        messageList.append(html);
        var reviewList = messageList.find('.review_list');
        setReviewHtml(id, 0, 10, 0, reviewList);
    }
    else {
        if (reviewPanle.is(':hidden')) {
            reviewPanle.show();
        } else {
            reviewPanle.hide();
        }
    }
});

var setReviewHtml = function (id, pi, ps, t, reviewList) {
    ajax_fun({ ds: 'quanzi', cm: 'review', id: id, pi: pi, ps: ps, t: t }, function (data) {
        var lihtml = '', reviewLoad = reviewList.next('.reviewLoad'), tips = '点击加载更多。。。';
        if (data && data.length > 0) {
            for (var i = 0, len = data.length; i < len; i++) {
                var item = data[i], user = item.user;
                lihtml += '<li class="clearfix">\
							<a class="img_left">\
								<img src="'+ user.User_Img + '" alt="">\
							</a>\
							<div class="cmtcnt">\
								<div class="cmt_left">\
									<a href="" class="user">'+ user.User_Name + '</a>\
									<span class="cmttxt">'+ decodeURI(item.Article_Pl_Content) + '</span>\
								</div>\
								<div class="cmtopt">\
									<a class="cmt_link jh_tag"  style="display:none;" href="">加黑</a>\
									<a class="cmt_link none" href="">删除</a>\
									<a class="cmt_link none" href="">回复</a>\
								</div>\
							</div>\
						</li>';
            }
            pi += 1;
            reviewList.append(lihtml);

            if (len < ps) {
                tips = '';
            }

            if (reviewLoad.length == 0) {
                reviewList.after('<div class="loading reviewLoad" data-page="' + pi + '">' + tips + '</div>');
            } else {
                reviewLoad.attr('data-page', pi).html(tips);
            }
        } else {
            reviewLoad.html('').removeClass('reviewLoad');
        }
    }, '/Reception/index.aspx');
}

$(document).on('click', '.reviewLoad', function () {
    var pi = parseInt($(this).attr('data-page')),
        id = $(this).parents('.messageList').find('.optRight').attr('data-id'),
        reviewList = $(this).siblings('.review_list');

    setReviewHtml(id, pi, 10, 0, reviewList);
});
/*****end*****/

$(document).on('click', '.slideUp', function () {
    $(this).parent().remove();
});

$(document).on('click', '.fb_btn', function () {
    var that = $(this), id = that.attr('data-id'),
        value = that.prev('.inputxt').html();

    ajax_fun({ act: 'review', con: encodeURI(value), aid: id }, function (result) {
        if (result.success) {
            user = result.user;
            that.parents('.reviewPanle').find('.review_list').prepend('<li class="clearfix">\
							<a class="img_left">\
								<img src="'+ user.User_Img + '" alt="">\
							</a>\
							<div class="cmtcnt">\
								<div class="cmt_left">\
									<a href="" class="user">'+ user.User_Name + '</a>\
									<span class="cmttxt">' + value + '</span>\
								</div>\
								<div class="cmtopt">\
									<a class="cmt_link jh_tag" style="display:none;" href="">加黑</a>\
									<a class="cmt_link none" href="">删除</a>\
									<a class="cmt_link none" href="">回复</a>\
								</div>\
							</div>\
						</li>');
            var count = that.parents('.messageList').find('.optRight').find('.review').children('i').text();
            if (count && count.length > 0) {
                that.parents('.messageList').find('.optRight').find('.review').children('i').text(parseInt(count) + 1);
            } else {
                that.parents('.messageList').find('.optRight').find('.review').html('评论(<i>1</i>)');
            }
            that.prev('.inputxt').html('');
        } else {
            alert(result.msg);
        }
    });
});

$(window).scroll(function () {
    var _this = $('.loading'), pageindex = _this.attr('data-page'), tips = _this.find('div').text();
    if (_this.length > 0 && tips != '到底了~') {
        if ($(document).scrollTop() >= $(document).height() - $(window).height()) {
            if (_this.find('span').length == 0) {
                _this.html('<span class="color1"></span><span class="color2"></span><span class="color3"></span><span class="color4"></span><span class="color5"></span>');
            }

            if (_this.hasClass('index')) {
                getIndexHtml(pageindex, _this);
            }
            else if (_this.hasClass('daren')) {
                var tagName = _this.attr('data-tag');
                setDarenHtml(pageindex, 10, tagName);
            }
            else if (_this.hasClass('follow')) {
                var keyword = _this.attr('data-key');
                setFollowHtml(pageindex, _this, keyword);
            }
        }
    }
});


getIndexHtml = function (pageindex, _this) {
    ajax_fun({ ds: 'quanzi', cm: 'page', pageindex: pageindex },
        function (data) {
            var item,
                user,
                html = '';
            if (data && data.length > 0) {
                for (var i = 0, len = data.length; i < len; i++) {
                    item = data[i];
                    user = item.user;
                    html += setContentHtml(item.Article_Pic, unescape(item.Article_Contents), item.Article_Title, user.User_Name, user.User_Img, item.bqs, user.User_Id, user.User_Id == item.User_Id, item.Article_Pics, item.Article_Hot, item.plnum, item.Article_Id);
                }
                _this.attr('data-page', parseInt(pageindex) + 1).html('<div>加载更多。。。</div>').before(html);
            } else {
                _this.html('<div>到底了~</div>');
            }
        },
        '/Reception/index.aspx',
        function (error) {
            console.log(error);
            _this.html('<div>服务器有点忙或您的网络断开了，请重新尝试</div>');
        });
}

setFollowHtml = function (pageindex, _this, keyword, orderby) {
    ajax_fun({ ds: 'quanzi', cm: 'FollowList', pi: pageindex, key: keyword, o: orderby, ps: 20 }, function (data) {
        var item, len, html = '', tips = '滚动加载更多。。。';

        if (data && data.length > 0) {
            for (var i = 0, len = data.length; i < len; i++) {
                item = data[i];
                html += '<li class="friend" data-user="' + item.User_Id + '">\
                    <div class="focusHead">\
                        <a href="javascript:;" target="_blank">\
                            <img class="xtag" src="' + item.User_Img + '">\
                        </a>\
                    </div>\
                    <div class="cnt">\
                        <h4>\
                            <em>\
                                <a href="javascript:;" class="xtag" target="_blank">' + item.User_Name + '</a>\
                            </em>\
                        </h4>\
                        <p class="xtag">' + (item.Update_Time && item.Update_Time.length > 0 ? item.Update_Time : '未更新') + '</p>\
                    </div>\
                    <a href="javascript:;" class="no_focus" title="取消关注">-</a>\
                </li>';
            }

            if (len < 20 && len > 0) {
                tips = '<div></div>';
            } else if (len == 0) {
                tips = '暂无关注好友';
            }

            if (pageindex == 0) {
                $('.f-cb').html(html);
            } else {
                $('.f-cb').append(html);
            }

            pageindex = parseInt(pageindex + 1);

            if (_this && _this.length == 0) {
                $('.f-cb').after('<div class="loading follow" data-key="' + keyword + '" data-page="' + pageindex + '">' + tips + '</div>');
            }
            else {
                _this.attr({ 'data-page': pageindex, 'data-key': keyword }).html(tips);
            }
        } else {
            $('.f-cb').html(html);
            if (_this && _this.length == 0) {
                $('.f-cb').after('<div class="loading follow" data-key="' + keyword + '" data-page="' + pageindex + '"></div>');
            }
            else {
                _this.attr({ 'data-page': pageindex, 'data-key': keyword }).html('');
            }
        }
    }, '/Reception/index.aspx',
    function (error) {
        console.log(error);
        _this.html('<div>服务器有点忙或您的网络断开了，请重新尝试</div>');
    });
}

$('button[type=submit]').on('click', function () {
    var keyword = $('.searchInp').val();
    setFollowHtml(0, $('.follow'), keyword);
    return false;
});

$('.m-tabbar .ztag').on('click', function () {
    $(this).addClass('curtab').siblings().removeClass('curtab');

    if ($(this).index() == 0) {
        setFollowHtml(0, $('.follow'), "");
    } else {
        setFollowHtml(0, $('.follow'), "", 1);
    }
});