//配置页面加载模块参数
require.config({
	paths: {
		//国内CDN镜像，GoogleCDN镜像，都失败的话再调用本地文件
		'jquery'			:['http://code.jquery.com/jquery-1.9.1.min','jquery-1.9.1.min'],
		'slide'			    :'jquery.slides.min',
		'kxbdMarquee'		:'jquery.kxbdMarquee',
		"selectcon"		    :"select",
		'setModule': 'setModule'
	},
	shim: {
		jquery			: {exports: '$'},
		'slide'	: {deps: ['jquery']},
		'kxbdMarquee'	: {deps: ['jquery']},
		'selectcon'  : {deps: ['jquery']},
		'setModule'  	: {deps: ['jquery','slide','kxbdMarquee','selectcon']}
	}
});
require(['jquery','setModule'], function($) {
	$(function() {
		Setfunction();
	});
});
