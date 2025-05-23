<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="logion1.ascx.cs" Inherits="Pinble_Challenge.Contorls.logion1" %>
<script type="text/javascript" src="../js/jquery-1.4.4.js"></script>
<script type="text/javascript" src="../js/jquery.blockUI.js"></script>
<script type="text/javascript" src="../js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript" src="../js/Header.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/SearchAjax.js?date=new date().gettime()"></script>
<div class="zanneiy_red">
    <div id="logion">
        <ul class="yleft">
            <li class="yxia">用户名：</li>
            <li>
                <input id="txtUsername" name="" type="text" class="h-input inputbox border-shadow"
                    style="background: #FFF; float: left; width: 80px; height:20px" /></li>
            <li class="yxia">密码：</li>
            <li>
                <input id="txtPassword" name="" type="password" class="h-input inputbox border-shadow"
                    style="background: #FFF; float: left; width: 80px;height:20px" />
            </li>
            <li class="yxia">验证码：</li>
            <li>
                <input type="text" id="txtCode" maxlength="4" class="h-input inputbox border-shadow"
                    style="background: #FFF; float: left; width: 50px;height:20px" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" />
            </li>
            <li>
                <img src="/publicPage/VerifyCode.aspx" align="top" alt="看不清？点击更换，不区分大小写！" id="imgVerify"
                    onclick="this.src=this.src+'?'" style="width: 65px; height: 20px; cursor: hand;" />
                <img alt="正确" src="../images/note_ok.gif" id="imgOKH" style="display: none;" />
                <img alt="错误" src="../images/note_error.gif" id="imgErrorH" style="display: none;" />
                <input id="btnLogin" class="submit pointer loginbutton" style="margin-left: 10px; height:20px"
                    type="button" value="登录" />
                    <input type="button" id="imgReset" class="HeadReset" />
                            &nbsp;&nbsp;<input type="checkbox" id="cbState" title="保存登录状态" />保存登录状态
                <%--<a href="#">
                    <img src="images/top_05.png" width="61" height="21" /></a>--%></li>
            <li class="yxia"><a href="http://www.pinble.com/Register.aspx">免费注册</a></li>
            <li class="yxia"><a href="http://www.pinble.com/RecoverPasswd1.aspx">忘记密码？</a></li>
        </ul>
    </div>
    <div id="linfo" style="display: none">
     <ul class="yleft">
           <li> <span id="name"></span>&nbsp;&nbsp;&nbsp;<a href="http://www.pinble.com/UserCenter/User_Center.aspx" target="_blank">用户中心</a>&nbsp;&nbsp;&nbsp;</li>
           <li> <a href="../publish.aspx">发布预测</a></li> 
            
            <li>&nbsp;&nbsp;<a href="javascript:void(0)" id="aLoginOut">安全退出</a></li>
            </ul>
        </div>
    <ul class="yright">
<%--        <li class="yrtu">
            <img src="../images/top_a.png" width="13" height="12" /></li>
        <li><a  href='#' onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://match.pinble.com');">设为首页</a></li>--%>
        <li class="yrtu">
            <img src="../images/top_b.png" width="13" height="12" /></li>
        <li><a target="_top" href="javascript:window.external.addFavorite('http://match.pinble.com','拼搏在线擂台主页');">加入收藏</a>
</li>
        <li class="yrtu">
            <img src="../images/top_c.png" width="13" height="12" /></li>
        <li><a href="http://www.pinble.com/Contact.htm" target="_blank">联系我们</a></li>
    </ul>
</div>
