function bannerSide(){
	var sideHtml='',index = 0,adTimer,			
		len  = $(".slider > li").length;
	for(var i = 0; i < len; i++){
		sideHtml += "<li><a  href='javascript:void(0)'>" + (i+1) + "</a></div>";
	};
	$('.controlNav').html(sideHtml);
	$(".controlNav li:last").addClass("Nolast");
	$(".slider li:last").addClass("banrLast");
	$(".controlNav").css('margin-top',-($('.controlNav').height()/2)+'px');	
	$(".controlNav li").mouseover(function(){
		index  =   $(".controlNav li").index(this);
		showImg(index);
	}).eq(0).mouseover();	
	//滑入 停止动画，滑出开始动画.
	$('.banner_nivoSlider').hover(function(){
		clearInterval(adTimer);
		},function(){
		adTimer = setInterval(function(){
			index++;
			if(index==len){index=0;}
			showImg(index);	
		} , 5000);
	}).trigger("mouseleave");	
}
function showImg(index){
	var adHeight = $(".banner_nivoSlider").height();
	$(".slider").stop(true,false).animate({top : -adHeight*index},500);
	$(".controlNav li").removeClass("cur").eq(index).addClass("cur");
}
function navHove(){
	$(".AdminDevelop").hover(function(){
		$(this).addClass("DevelopHover");
		$(this).find(".showDevelop").removeClass("hide");
	},function(){
		$(this).removeClass("DevelopHover");
		$(this).find(".showDevelop").addClass("hide");
	});
}
function radNo(){
	//****************单选框选择效果******************//
	$(".alarmradio .radNo").each(function (i) {
        if ($(this).attr("checked") == "checked") {
            $('.alarmradio label').eq(i).addClass('whitered');
        }
    });
    var alarmleth = $('.alarmradio').length;
    for (var i = 0; i < alarmleth; i++) {
        var _inputName = $('.alarmradio').eq(i).find("input").attr('name');
        $(".alarmradio").eq(i).each(function () {
            $(this).find("label").attr('name', _inputName);
        });
        Alarm_levels(_inputName);
    }
    function Alarm_levels(_name) {
        $('.alarmradio label[name="' + _name + '"]').on("click", function () {
            $(".alarmradio").find("label[name='" + _name + "']").removeClass('whitered');
            $(this).addClass('whitered');
        });
    }
	//****************复选框选择效果******************//
    $(".settcheck .Nodis").each(function (i) {
        var that = $(this);
        if ($(this).attr("checked") == "checked") {
            $('.settcheck label').eq(i).addClass('checked');
        }
        $('.settcheck label').eq(i).on("click", function () {
            var _this = $(this);
            _this.toggleClass('checked');
            //***给input添加checked属性***//
            if (_this.hasClass("checked")) {
                that.attr("checked", "checked");
            }
            else {
                that.removeAttr("checked");
            }
        });
    });
    $(".single").click(function (e) {
        var _this = $(this);
        var _others;
        _others = $(".single").filter(function () {
            var ks = $(this);
            if (ks[0] !== _this[0]) {
                return ks;
            }
        });
        _others.removeClass('checked');
        _others.prev("input").removeAttr('checked');
    });
	//***记录默认值***//
	var select_Init = $('.alarmradio .radNo:checked');
	var selectcheckbox = $('.settcheck .Nodis:checked');
	//***重置***//
	$('.resBtn').click(function () {
		$('.alarmradio .radNo').attr("checked", false);
		$('.alarmradio label').removeClass('whitered');
		select_Init.each(function () {
			$(this).attr("checked", true);
			$(this).next().addClass('whitered');
		});
		$('.settcheck .Nodis').attr("checked", false);
		$('.settcheck label').removeClass('checked');
		selectcheckbox.each(function () {
			$(this).attr("checked", true);
			$(this).next().addClass('checked');
		});
	});
}
function Select(){
	//参考js/select.js
	$(".listTabSel").smgSelect({
	  defText:"",//默认
	  fixcalcNum:84
	});
}
function ShowComment(){
	$(".showComment").each(function(i){
		$(".showComment").eq(i).click(function(){
			$(".criticism").eq(i).toggleClass("hide");
		});
	});

}

function getFile(obj,inputName){
	var file_name = $(obj).val();
	$("input[name='"+inputName+"']").val(file_name);
}
function inputFocus(){
	//文本域显示隐藏
	$(".Inpfocus").focus(function(){
		if($(this).val() ==this.defaultValue){  
			$(this).val("");
			// $(this).css('color','#555');
		} 
	}).blur(function(){
		if ($(this).val() == '') {
			$(this).val(this.defaultValue);
			// $(this).css('color','#999');
		}
	});
	$(".clickTextfocus").focus(function(){
		$(this).hide().siblings('input,textarea').css('display','block').focus();
	});
	$(".clickfocus").blur(function(){
		if($(this).val()==''){
			$(this).hide().siblings('input,textarea').css('display','block');	
		}
	});
}
function HomeLogin(){
	$(".showLogin").click(function(){
		$(".popBox").addClass("show");
		$(".popLogin").animate({top:"40px",opacity:1,"z-index":"999"},500);
	});
	$(".showRegister").click(function(){
		$(".popBox").addClass("show");
		$(".popRegister").animate({top:"40px",opacity:1,"z-index":"999"},500);
	});	
	$(".Popclose").click(function(){
		$(".popLogin,.popRegister").animate({top:"-100%",opacity:0,"z-index":"101"},500);
		$(".popBox").removeClass("show");
	});
	$(".popReg a").click(function(){
		$(".popLogin").css({top:"-100%",opacity:0,"z-index":"101"});
		$(".popRegister").css({top:"40px",opacity:1,"z-index":"999"});
	});
	$(".popbottomlog a").click(function(){
		$(".popRegister").css({top:"-100%",opacity:0,"z-index":"101"});
		$(".popLogin").css({top:"40px",opacity:1,"z-index":"999"});
	});
}
function logMenu(){
	$(".logboxRlist li:odd").addClass("evel");
}
function Setfunction() {
	bannerSide();
	$('.hotNewList li:first').addClass("Nobor");
	$('.successList li:first').addClass("NoMarginL");
	$('.portpeList li:first').addClass("Nobor");
	// alert($('body').innerWidth());
	$('.popBox').css('width',$('body').innerWidth()+'px');
	navHove();//头像下拉
	$("#GameMarquee").kxbdMarquee({direction:"left"});
	radNo();
	Select();
	ShowComment();
	//文件上传
	getFile();
	inputFocus();
	HomeLogin();
	logMenu();
}
