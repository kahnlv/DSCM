<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_upphoto.aspx.cs" Inherits="Reception_templates_default_quanzi_upphoto" %>
<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>

<div id="container" class="clearfix">
		<div class="main fl">
			
		</div>
		<!-- 个人信息 -->
		<div class="person fr">
			<div class="per_infor clearfix">
				<div class="left fl">
						<h1><%=Save("user_name").ToString()%></h1>
                        <h3 style="cursor:pointer" title="<%=Save("user_email").ToString() %>">
                            <%=Save("user_email").ToString().Length>24?Save("user_email").ToString().Substring(0,24):Save("user_email").ToString() %>
                        </h3>
				</div>
				<a href="#" class="right fr"><span></span></a>
			</div>
			<ul class="person_nav">
				<li class="bg1"><a href="/Reception/index.aspx?ds=quanzi&cm=arcticle">文章</a></li>
				<li class="bg2"><a href="/Reception/index.aspx?ds=quanzi&cm=message">通知</a></li>
				<li class="bg3"><a href="/Reception/index.aspx?ds=quanzi&cm=letter">私信</a></li>
				<li class="bg4"><a href="/Reception/index.aspx?ds=quanzi&cm=person">个人设置</a></li>
			</ul>
		</div>
		<!-- 个人信息 -->
	</div>
	<!--上传头像弹出框-->
	<div class="openwin">
		<div class="openwin-top">上传头像 <div id="close"></div></div>
		<div class="container">
			<div class="imageBox">
				<div class="thumbBox"></div>
				<div class="spinner" style="display: none"><input type="file" id="file">
				<div class="spidiv">选择图片</div>
				</div>
			</div>
			<div class="action">
				<div class="action-rtop">拖拽或缩放虚线框，生成自己满意的头像</div>
				<input type="text" id="btnCrop" class="unify" value=""><br/>
				110*110像素<br/>
				<input type="text" id="btnZoomIn" class="unify" value=""><br/>
				64*64像素<br/>
				<input type="text" id="btnZoomOut" class="unify" value=""><br/>
				30*30像素<br/>
			</div>
			<div class="cropped"></div>
		</div>
	</div>
	<!--上传头像弹出框-->
	<!--遮罩层-->
	<div id="mask"></div>
	<!--遮罩层-->
</div>
</body>
<script type="text/javascript">
    $(window).load(function () {
        var options =
		{
		    thumbBox: '.thumbBox',
		    spinner: '.spinner',
		    imgSrc: 'images/avatar.png'
		};
        var cropper = $('.imageBox').cropbox(options);
        $('#file').on('change', function () {
            var reader = new FileReader();
            reader.onload = function (e) {
                options.imgSrc = e.target.result;
                cropper = $('.imageBox').cropbox(options);
            };
            reader.readAsDataURL(this.files[0]);
            this.files = [];
        });
        $('#btnCrop').on('click', function () {
            var img = cropper.getDataURL();
            $('.cropped').append('<img src="' + img + '">');
        });
        $('#btnZoomIn').on('click', function () {
            cropper.zoomIn();
        });
        $('#btnZoomOut').on('click', function () {
            cropper.zoomOut();
        });
        //弹出层关闭按钮
        $('#close').click(function () {
            $('.openwin').hide();
            $('#mask').hide();
        })
    });
</script>

</html>
