<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quanzi_follow.aspx.cs" Inherits="Reception_templates_default_quanzi_follow" %>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_heard.aspx")%>
<div class="secondNav">
    <ul class="viewNav clearfix">
        <li><a href="" class="on">达人</a></li>
    </ul>
</div>
<!---->
<div class="wrapper">
    <div class="nav2">
        <ul class="clearfix">
            <li><a href="/Reception/index.aspx?ds=quanzi&cm=daren" title="">领域达人</a></li>
            <li class="current"><a href="javascript:;" title="">我关注的人（2）</a></li>
        </ul>
    </div>
    <div class="focusBox clearfix">
        <div class="m-tabbar">
            <a class="ztag curtab" hidefocus="true" href="#">最近互动</a>
            <span class="sep">|</span>
            <a class="ztag" hidefocus="true" href="#">最新关注</a>
        </div>
        <div class="focusList clearfix">
            <ul class="f-cb ztag">
                <li>
                    <div class="focusHead">
                        <a href="http://sengen.lofter.com" target="_blank">
                            <img class="xtag" src="http://imgsize.ph.126.net/?imgurl=http://imglf0.ph.126.net/gWQlqaWc7S7NqKMICqKCdg==/6598208860763173737.jpg_64x64x0.jpg">
                        </a>
                    </div>
                    <div class="cnt">
                        <h4>
                            <em>
                                <a href="http://sengen.lofter.com" class="xtag" target="_blank">SenGen·LoFoTo</a>
                            </em>
                        </h4>
                        <p class="xtag">02/28 17:38更新</p>
                    </div>
                    <a href="#" class="no_focus" title="取消关注">-</a>
                    <div class="popup">
                        <div class="popTriangle-top-left"></div>
                        <div class="poptop clearfix">
                            <div class="fl clearfix">
                                <a href="" class="sHeadIcon fl">
                                    <img src="" alt=""></a>
                                <p class="nickname">昵称</p>
                                <p class="wenzhang"><span class="marR20">文章718</span><span>关注12</span></p>
                            </div>
                            <div class="myFocus"><a class="fr focus">已关注</a></div>
                        </div>
                        <div class="imgShow clearfix">
                            <a class="imgCont" href="">
                                <img src="images/test.jpg" alt=""></a>
                            <a class="imgCont" href="">
                                <img src="images/test.jpg" alt=""></a>
                            <a class="imgCont" href="">
                                <img src="images/test.jpg" alt=""></a>
                        </div>
                        <div class="recommend">
                            更多相似达人:<a href="" title="">北欧达人</a>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="focusHead">
                        <a href="http://sengen.lofter.com" target="_blank">
                            <img class="xtag" src="http://imgsize.ph.126.net/?imgurl=http://imglf0.ph.126.net/gWQlqaWc7S7NqKMICqKCdg==/6598208860763173737.jpg_64x64x0.jpg">
                        </a>
                    </div>
                    <div class="cnt">
                        <h4>
                            <em>
                                <a href="http://sengen.lofter.com" class="xtag" target="_blank">SenGen·LoFoTo</a>
                            </em>
                        </h4>
                        <p class="xtag">02/28 17:38更新</p>
                    </div>
                    <a href="#" class="no_focus" title="取消关注">-</a>
                </li>
                <li>
                    <div class="focusHead">
                        <a href="http://sengen.lofter.com" target="_blank">
                            <img class="xtag" src="http://imgsize.ph.126.net/?imgurl=http://imglf0.ph.126.net/gWQlqaWc7S7NqKMICqKCdg==/6598208860763173737.jpg_64x64x0.jpg">
                        </a>
                    </div>
                    <div class="cnt">
                        <h4>
                            <em>
                                <a href="http://sengen.lofter.com" class="xtag" target="_blank">SenGen·LoFoTo</a>
                            </em>
                        </h4>
                        <p class="xtag">02/28 17:38更新</p>
                    </div>
                    <a href="#" class="no_focus" title="取消关注">-</a>
                </li>
                <li>
                    <div class="focusHead">
                        <a href="http://sengen.lofter.com" target="_blank">
                            <img class="xtag" src="http://imgsize.ph.126.net/?imgurl=http://imglf0.ph.126.net/gWQlqaWc7S7NqKMICqKCdg==/6598208860763173737.jpg_64x64x0.jpg">
                        </a>
                    </div>
                    <div class="cnt">
                        <h4>
                            <em>
                                <a href="http://sengen.lofter.com" class="xtag" target="_blank">SenGen·LoFoTo</a>
                            </em>
                        </h4>
                        <p class="xtag">02/28 17:38更新</p>
                    </div>
                    <a href="#" class="no_focus" title="取消关注">-</a>
                </li>
            </ul>
        </div>
        <div class="searchCol">
            <div class="ssch clearfix">
                <input type="text" class="searchInp" placeholder="输入用户名称，查找关注的人">
                <button type="submit"></button>
            </div>
            <div class="recomFollowArea">
                <h3>推荐关注</h3>
                <div class="recomFollowList">
                    <%foreach (var m in Recommend)
                        {%>
                    <div class="recomItem">
                        <a title="<%=m.User_Name %>" href="javascript:;" target="_blank">
                            <img src="<%=m.User_Img %>">
                        </a>
                        <a href="javascript:;" class="followbtn" data-user="<%=m.User_Id %>" title="添加关注">+</a>
                    </div>
                    <% }%>
                </div>
            </div>
        </div>
    </div>
</div>

<%=model.ReadModel("/Reception/templates/default/public/quanzi_foot.aspx")%>