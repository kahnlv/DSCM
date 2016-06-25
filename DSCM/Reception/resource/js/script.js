(function($){
    $.fn.capacityFixed = function(options) {
        var opts = $.extend({},$.fn.capacityFixed.deflunt,options);
        var FixedFun = function(element) {
            var top = opts.top;
            element.css({
                "top":top
            });
            $(window).scroll(function() {
                var scrolls = $(this).scrollTop();
                if (scrolls > top) {
                    if (window.XMLHttpRequest) {
                        element.css({
                            position: "fixed",
                            top: 0,													
                        });
						$(".HeadPortrait").removeClass("head_pers");
						$(".HeadPortrait").addClass("head_pers_2");
						$(".HeadPortrait img").removeClass("headProimg");
						$(".HeadPortrait img").addClass("headProimg_2");
                    } else {
                        element.css({
                            top: scrolls
                        });
						$(".HeadPortrait").removeClass("head_pers_2");
						$(".HeadPortrait").addClass("head_pers");
						$(".HeadPortrait img").removeClass("headProimg_2");
						$(".HeadPortrait img").addClass("headProimg");
                    }
                }else {
                    element.css({
                        position: "absolute",
                        top: top
                    });
					$(".HeadPortrait").removeClass("head_pers_2");
					$(".HeadPortrait").addClass("head_pers");
					$(".HeadPortrait img").removeClass("headProimg_2");
					$(".HeadPortrait img").addClass("headProimg");
                }
            });
            element.find(".close-ico").click(function(event){
                element.remove();
                event.preventDefault();
            })
        };
        return $(this).each(function() {
            FixedFun($(this));
        });
    };
    $.fn.capacityFixed.deflunt={
		right : 0,//相对于页面宽度的右边定位
        top:572
	};
})(jQuery);