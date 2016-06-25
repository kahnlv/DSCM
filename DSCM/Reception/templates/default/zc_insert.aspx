<!--
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/21 9:43:50 
* File name：zc_insert 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
-->

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zc_insert.aspx.cs" ValidateRequest="false" EnableEventValidation="false" Inherits="Reception_templates_default_zc_insert" %>

<%=model.ReadModel("/Reception/templates/default/public/heard.aspx")%>
<link href="<%=HTMLConfig.HTML_PATH_RESOURCE %>css/itemPage.css" rel="stylesheet" type="text/css">
<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.config.js"></script>
<script type="text/javascript" src="/data/resource/ueditor/third-party/zeroclipboard/ZeroClipboard.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/data/resource/ueditor/ueditor.all.min.js"> </script>


<form id="zcmpostForm" name="zcmpostForm" action="/Reception/index.aspx?ds=zc&cm=dsinsert" method="post" onsubmit="">
    <div class="newItemNav">
        <div class="W1200">
            <ul class="NewNavlist">
                <li class="active">
                    <div class="navitTit Newitem_01">项目信息</div>
                    <p class="itemNavBottom">1<em></em></p>
                </li>
                <li>
                    <div class="navitTit Newitem_02">项目详情</div>
                    <p class="itemNavBottom">2<em></em></p>
                </li>
                <li>
                    <div class="navitTit Newitem_03">回报设置</div>
                    <p class="itemNavBottom">3<em></em></p>
                </li>
                <li>
                    <div class="navitTit Newitem_04">提交审核</div>
                    <p class="itemNavBottom">4</p>
                </li>
            </ul>
        </div>
    </div>
    <div class="W1200">
        <div class="newItemCon clearfix">
            <h1 class="itemTopTit">
                <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/itemTopTit.png" alt="" /></h1>
            <div class="ItemFormL">
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>项目名称:</dt>
                    <dd><span class="itemInpBox">
                        <input type="text" name="object_title" id="" /></span><p class="errorMsg">不能少于10个字</p>
                    </dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>游戏名称:</dt>
                    <dd><span class="itemInpBox">
                        <input type="text" name="object_game_name" id="" /></span></dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>项目类别:</dt>
                    <dd>
                        <div class="selradio alarmradio">
                            <!-- 这里的ID可以随变取，但要和后面"for"对应 { checked="checked"}表示选中-->
                            <span>
                                <input type="radio" class="radNo" id="sortIcon01" name="object_class" value="动漫" />
                                <label class="sort_1" for='sortIcon01'>
                                    <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/sortIcon_01.png">动漫</label>
                            </span>
                            <span>
                                <input type="radio" class="radNo" id="sortIcon02" name="object_class" value="游戏" />
                                <label class="sort_2" for='sortIcon02'>
                                    <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/sortIcon_02.png">游戏</label>
                            </span>
                            <span>
                                <input type="radio" class="radNo" id="sortIcon03" name="object_class" value="Cosplay" />
                                <label class="sort_1" for='sortIcon03'>
                                    <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/sortIcon_03.png">Cosplay</label>
                            </span>
                            <span>
                                <input type="radio" class="radNo" id="sortIcon04" name="object_class" value="漫画" />
                                <label class="sort_2" for='sortIcon04'>
                                    <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/sortIcon_04.png">漫画</label>
                            </span>
                            <span>
                                <input type="radio" class="radNo" id="sortIcon05" name="object_class" value="模型制作" />
                                <label class="sort_1" for='sortIcon05'>
                                    <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/sortIcon_05.png">模型制作</label>
                            </span>
                            <span>
                                <input type="radio" class="radNo" id="sortIcon06" name="object_class" value="影视" />
                                <label class="sort_2" for='sortIcon06'>
                                    <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/sortIcon_06.png">影视</label>
                            </span>
                        </div>
                    </dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>项目标签:</dt>
                    <dd>
                        <div class="tallyBox">
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_1" class="Nodis" value="桌面" /><label for="tally_1">桌面</label></span>
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_2" class="Nodis" value="探险" /><label for="tally_2">探险</label></span>
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_3" class="Nodis" value="娱乐场" /><label for="tally_3">娱乐场</label></span>
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_4" class="Nodis" value="骰子" /><label for="tally_4">骰子</label></span>
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_5" class="Nodis" value="教育" /><label for="tally_5">教育</label></span>
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_6" class="Nodis" value="扑克牌" /><label for="tally_6">扑克牌</label></span>
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_7" class="Nodis" value="街机" /><label for="tally_7">街机</label></span>
                            <span class="settcheck">
                                <input type="checkbox" name="object_label" id="tally_8" class="Nodis" value="儿童" /><label for="tally_8">儿童</label></span>
                        </div>
                    </dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>项目地点:</dt>
                    <dd>
                        <div class="smgSelectWrap listTabSel fL">
                            <div class="smgSelectText" title="请选择" id="smgSelectText">请选择</div>
                            <input type="hidden" value="1" name="object_address">
                            <div class="smgSelectListWrap">
                                <div class="smgSelectList">
                                    <% foreach (DSCM.ds_tbl_province.tbl_province p in province)
                                        { %>
                                    <p val="<%=p.DI %>" class="smgIthems"><%=p.Provincename %></p>
                                    <% } %>
                                </div>
                            </div>
                        </div>
                        <div class="smgSelectWrap listTabSel fL">
                            <div class="smgSelectText" title="请选择">请选择</div>
                            <input type="hidden" value="1" name="object_address">
                            <div class="smgSelectListWrap">
                                <div class="smgSelectList" id="smgSelectList">
                                </div>
                            </div>
                        </div>
                    </dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>项目简介:</dt>
                    <dd>
                        <script id="editor" type="text/plain" style="width: 1024px; height: 500px;"></script>
                    </dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>项目预计平台:</dt>
                    <dd>
                        <span class="settcheck">
                            <input type="checkbox" name="object_pingtai" id="iOS" checked="checked" class="Nodis" value="iOS" /><label for="iOS">iOS</label></span>
                        <span class="settcheck">
                            <input type="checkbox" name="object_pingtai" id="Android" checked="checked" class="Nodis" value="Android" /><label for="Android">Android</label></span>
                        <span class="settcheck">
                            <input type="checkbox" name="object_pingtai" id="Phone" checked="checked" class="Nodis" value="Windows Phone" /><label for="Phone">Windows Phone</label></span>
                    </dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>募资期限:</dt>
                    <dd><span class="itemInpBox">
                        <input type="text" name="object_qixian" id="" style="ime-mode: disabled;" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14" /></span><em>天</em></dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt>开始时间:</dt>
                    <link rel="stylesheet" href="/data/resource/rili/jquery-ui.css">
                    <script src="/data/resource/rili/jquery-1.10.2.js"></script>
                    <script src="/data/resource/rili/jquery-ui.js"></script>
                    <link rel="stylesheet" href="/data/resource/rili/style.css">
                    <dd><span class="itemInpBox">
                        <input type="text" name="object_start_time" id="object_start_time" value="<%=DateTime.Now.ToShortDateString() %>" /></span>
                        <script>
                            $(function () {
                                $("#object_start_time").datepicker();
                            });
                        </script>
                    </dd>
                </dl>
                <dl class="ItemInfo clearfix">
                    <dt><em class="red">*</em>融资目标:</dt>
                    <dd><span class="itemInpBox">
                        <input type="text" name="object_raise_price" id="" style="ime-mode: disabled;" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" maxlength="9" size="14" /></span><em>元</em></dd>
                </dl>
                <p class="itemPageBtn">
                    <% if (Save("user_phone").ToString().Equals(""))
                        { %>
                    <a href="javascript:void(0)" class="PageBtn showLogin">保存 & 下一步</a>
                    <% }
                        else
                        { %>
                    <a href="javascript:zc_submit()" class="PageBtn">保存 & 下一步</a>
                    <% } %>
                </p>
            </div>

            <div class="ItemFormR">
                <div class="itemBorder clearfix">
                    <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/20141204.jpg" alt="" class="ItemImg" />
                    <p class="itemName">项目名称</p>
                    <p class="itemPhoto">
                        <img src="<%=HTMLConfig.HTML_PATH_RESOURCE %>images/temp/201400154245.jpg" alt="" /></p>
                    <div class="itemSupporter clearfix" style="display:none">
                        <span class="m_01"><em>92%</em>已达到</span>
                        <span class="m_02"><em>￥15900</em>已筹集</span>
                        <span class="m_03"><em>15天</em>剩余时间</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="pB40"></div>
    <input type="hidden" name="pro_doc" />
</form>
<script type="text/javascript">

    function html_decode(str) {
        var s = "";
        if (str.length == 0) return "";
        s = str.replace(/&gt;/g, "&");
        s = s.replace(/&lt;/g, "<");
        s = s.replace(/&gt;/g, ">");
        s = s.replace(/&nbsp;/g, " ");
        s = s.replace(/&#39;/g, "\'");
        s = s.replace(/&quot;/g, "\"");
        s = s.replace(/<br>/g, "\n");
        return s;
    }
    function html_encode(str) {
        var s = "";
        if (str.length == 0) return "";
        s = str.replace(/&/g, "&gt;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        s = s.replace(/ /g, "&nbsp;");
        s = s.replace(/\'/g, "&#39;");
        s = s.replace(/\"/g, "&quot;");
        s = s.replace(/\n/g, "<br>");
        return s;
    }
    var ue = UE.getEditor('editor');
    function zc_submit() {
        var zc_obj = document.zcmpostForm;
        if (zc_obj != null) {
            zc_obj.editorValue.value = html_encode(zc_obj.editorValue.value);
            //zc_obj.editorValue.value = "";
            zc_obj.submit();
        }
    }
</script>
<%=model.ReadModel("/Reception/templates/default/public/foot.aspx")%>
