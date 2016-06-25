document.write("<div style='position:absolute;left:0px;top:0px;filter: alpha(opacity=50);width:100%;height:100%;z-index:1999;display:none;' id='MessBoxBg2x'></div>");
document.write("<div style='position:absolute; left:0px; top:100px; width:250px; z-index:2000; background-color:#ffffff; border:solid 1px #dcdcdc;display:none;' id='MessBox2x'>");
document.write("	<div style=' padding:0px; cursor:move;height:26px' onmousedown='drag(this.parentNode, event);'>");
document.write("	<TABLE width=100% cellpadding=5 cellspacing=0 style='background:url(/data/resource/images/index5_31.jpg) repeat-x;' border=0 height=26px>");
document.write("	<TR >");
document.write("		<TD align=left>&nbsp;&nbsp;<font style='font-family:microsoft yahei;color:#000000;font-size:12px' id='MessTitleID2x'></font></TD>");
document.write("		<TD align=right style='padding-top:5px'><a href='javascript:CloseMess2();'><img src=/data/resource/images/shengqing2_03.jpg border=0 style='cursor:pointer' align=absmiddle></a>&nbsp;</TD>");
document.write("	</TR>");
document.write("	</TABLE>");
document.write("	</div>");
document.write("	<div style='padding:0px;background-color:#fff;'><div style='height:1px;'></div>");
document.write("		<iframe width=0 height=0 border=0 scrolling=no frameborder=0 src='' name='MessIframe2x' id='MessIframe2x'></iframe>");
document.write("	</div>");
document.write("</div>");

document.write("<div style='position:absolute;left:0px;top:0px;filter: alpha(opacity=50);width:100%;height:100%;z-index:2999;display:none;' id='MessBoxBg3x'></div>");

document.write("<div style='position:absolute; left:100px; top:100px; width:250px; z-index:3000; background-color:#ffffff; border:solid 1px #dcdcdc;display:none;' id='MessBox3x'>");
document.write("	<div style='padding:0px;cursor:move;height:26px' onmousedown='drag(this.parentNode, event);'>");
document.write("	<TABLE width=100% cellpadding=5 cellspacing=0 style='background:url(/data/resource/images/index5_31.jpg) repeat-x;' border=0 height=26px>");
document.write("	<TR >");
document.write("		<TD align=left>&nbsp;&nbsp;<font style='font-family:microsoft yahei;color:#000000;font-size:12px' id='MessTitleID3x'></font></TD>");
document.write("		<TD align=right style='padding-top:5px'><a href='javascript:CloseMess3();'><img src=/data/resource/images/shengqing2_03.jpg border=0 style='cursor:pointer' align=absmiddle></a>&nbsp;</TD>");
document.write("	</TR>");
document.write("	</TABLE>");
document.write("	</div>");
document.write("	<div style='padding:0px;background-color:#dcdcdc;'><div style='height:1px;'></div>");
document.write("		<iframe width=0 height=0 border=0 frameborder=0 src='' name='MessIframe3x' id='MessIframe3x'></iframe>");
document.write("	</div>");
document.write("</div>");


function OpenMess3x(Width,Height,IframeSrc,Title)
{
	var MessBox = document.getElementById("MessBox3x");  
	var MessBoxBg = document.getElementById("MessBoxBg3x");
	var FrameObj= document.getElementById("MessIframe3x");
	var TitleObj=document.getElementById("MessTitleID3x");

	TitleObj.innerHTML=Title;
	MessBox.style.display="block";
	MessBox.style.width=Width+"px";
	MessBox.style.height=Height+"px";
	sc1("MessBox3x");
	FrameObj.style.width=parseInt(Width)+"px";
	FrameObj.style.height=parseInt(Height-27)+"px";
	MessBoxBg.style.display="block";
  	
	var winHeight=document.body.clientHeight;
  	MessBoxBg.style.height=winHeight ;

	document.getElementById("MessIframe3x").src=IframeSrc;
}
function CloseMess3()
{
	var MessBox = document.getElementById("MessBox3x");  
	var MessBoxBg = document.getElementById("MessBoxBg3x");
	MessBox.style.display="none";
	MessBoxBg.style.display="none";
}

function OpenMess2x(Width,Height,IframeSrc,Title)
{
	var MessBox = document.getElementById("MessBox2x");  
	var MessBoxBg = document.getElementById("MessBoxBg2x");
	var FrameObj= document.getElementById("MessIframe2x");
	var TitleObj=document.getElementById("MessTitleID2x");

	TitleObj.innerHTML=Title;
	MessBox.style.display="block";
	MessBox.style.width=Width+"px";
	MessBox.style.height=Height+"px";
	sc1("MessBox2x");
	FrameObj.style.width=parseInt(Width)+"px";
	FrameObj.style.height=parseInt(Height-27)+"px";
	MessBoxBg.style.display="block";
  	var winHeight=document.body.clientHeight ;
  	MessBoxBg.style.height=winHeight ;
	document.getElementById("MessIframe2x").src=IframeSrc;
}
function CloseMess2()
{
	var MessBox = document.getElementById("MessBox2x");  
	var MessBoxBg = document.getElementById("MessBoxBg2x");
	MessBox.style.display="none";
	MessBoxBg.style.display="none";
}
function sc1(name){
 document.getElementById(name).style.top="50px";
 document.getElementById(name).style.left="230px";//(document.documentElement.scrollLeft+(document.documentElement.clientWidth-document.getElementById(name).offsetWidth)/2)+
}

function drag(elementToDrag, event)
{

	var startX = event.clientX, startY = event.clientY;
	var origX = elementToDrag.offsetLeft, origY = elementToDrag.offsetTop;
	var deltaX = startX - origX, deltaY = startY - origY;
	if(document.addEventListener) //判断浏览器
	{
		document.addEventListener("mousemove", moveHandler, true);
		document.addEventListener("mouseup", upHandler, true);
	}
	else if(document.attachEvent)
	{
		elementToDrag.setCapture();
		elementToDrag.attachEvent("onmousemove", moveHandler);
		elementToDrag.attachEvent("onmouseup", upHandler);
		elementToDrag.attachEvent("onlosecapture", upHandler);
	}

	if(event.stopPropagation)
	{
		event.stopPropagation();
	}
	else
	{
		event.cancelBubble = true;
	}

	if(event.preventDefault)
	{
		event.preventDefault();
	}
	else
	{
		event.returnValue = false;
	}
	///定义鼠标移动方法
	function moveHandler(e)
	{
		if(!e)
		{
			e = window.event;
		}
		if(e.clientX - deltaX<=0)
		{
			elementToDrag.style.left = "0px";
		}
		else
		{
			elementToDrag.style.left = (e.clientX - deltaX) + "px";
		}
		if(e.clientY - deltaY<=0)
		{
			elementToDrag.style.top = "0px";
		}
		else
		{
			elementToDrag.style.top = (e.clientY - deltaY) + "px";
		}
		if(e.stopPropagation) 
		{
			e.stopPropagation();
		}
		else
		{
			e.cancelBubble = true;
		}	
	}
	//定义鼠标抬起方法
	function upHandler(e)
	{

		if(!e)
		{
			e = window.event;
		}
		if(document.removeEventListener)
		{
			document.removeEventListener("mouseup", upHandler, true);
			document.removeEventListener("mousemove", moveHandler, true);

		}
		else if(document.detachEvent)
		{
			elementToDrag.detachEvent("onlosecapture", upHandler);
			elementToDrag.detachEvent("onmouseup", upHandler);
			elementToDrag.detachEvent("onmousemove", moveHandler);
			elementToDrag.releaseCapture();
		}
		if(e.stopPropagation)
		{
			e.stopPropagation();
		}
		else
		{
			e.cancelBubble = true;
		}
	}
}