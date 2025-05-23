<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LotteryHead.ascx.cs"
    Inherits="Pbzx.Web.Contorls.LotteryShop.LotteryHead" EnableTheming="true" %>
<link type="text/css" href="../../css/themes/base/ui.all.css" rel="stylesheet" />
<link type="text/css" href="../../css/css.css" rel="stylesheet" />
<link type="text/css" href="../../css/demos.css" rel="stylesheet" />
<link type="text/css" href="../../css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

<script type="text/javascript" src="../../javascript/jquery-1.3.2.js"></script>

<script type="text/javascript" src="../../javascript/jquery.blockUI.js"></script>

<script type="text/javascript" src="../../javascript/jquery-ui-1.7.2.custom.min.js"></script>

<script type="text/javascript" src="../../javascript/Header.js"></script>

<script type="text/javascript" src="../../javascript/SearchAjax.js"></script>

<div id="divLogin" style="display: none; cursor: default;">
    <table width="350" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="40" background="../../Images/Web/login1.jpg">
                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="95%">
                        </td>
                        <td width="5%">
                            <img style="cursor: pointer;" src="../../Images/Web/close.gif" width="15" height="15"
                                id="btnCancelMeng" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="160" valign="middle" background="../../Images/Web/login2.jpg">
                <table width="85%" border="0" align="center" cellpadding="4" cellspacing="0" height="145">
                    <tr>
                        <td colspan="2" height="5px">
                            <%--<span id="validateTips"></span>--%>
                        </td>
                    </tr>
                    <tr>
                        <td width="23%" align="right">
                            用户名：</td>
                        <td width="77%" align="left">
                            <input type="text" id="txtUsername" maxlength="12" style="width: 150px;" />&nbsp;<a
                                style="cursor: pointer;" href="../../Register.aspx" tabindex='-1'>免费注册</a></td>
                    </tr>
                    <tr>
                        <td align="right">
                            密 &nbsp;码：</td>
                        <td align="left">
                            <input id="txtPassword" type="password" maxlength="16" style="width: 150px;" />&nbsp;<a
                                style="cursor: pointer;" href="../../RecoverPasswd1.aspx" target="_blank" tabindex='-2'>密码找回</a></td>
                    </tr>
                    <tr>
                        <td align="right">
                            验证码：</td>
                        <td align="left">
                            <input type="text" id="txtCode" maxlength="4" style="width: 50px;" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" />
                            <img src="../../publicPage/VerifyCode.aspx" align="top" alt="看不清？点击更换，不区分大小写！" id="imgVerify"
                                onclick="this.src=this.src+'?'" style="width: 65px; height: 25px; cursor: hand;" />
                            <img alt="正确" src="../../Images/Web/note_ok.gif" id="imgOKH" style="display: none;" />
                            <img alt="错误" src="../../Images/Web/note_error.gif" id="imgErrorH" style="display: none;" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            &nbsp;&nbsp;&nbsp;
                            <input type="button" id="btnLogin" class="HeadLogin" />
                            &nbsp;
                            <input type="button" id="imgReset" class="HeadReset" />
                            &nbsp;&nbsp;<input type="checkbox" id="cbState" title="保存我的登录状态" />保存登录状态
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <img src="../../Images/Web/login3.jpg" width="350" height="13" /></td>
        </tr>
    </table>
</div>
<div id="header">
    <div id="top">
        <table width="970" align="center">
            <tr>
                <td width="500" align="left">
                    设为首页|加入收藏</td>
                <td align="right" width="470">
                    <div align="right" style="vertical-align: middle">
                        <span id='aloginShow' style="cursor: pointer; color: #003399;">登录&nbsp;</span> <span
                            id="spUser"></span><span style="display: none;" id="userCenter"><a href="../../UserCenter/User_Center.aspx"
                                target="_blank">&nbsp;用户中心&nbsp;</a> <a href="../../UserCenter/User_Center.aspx?myUrl=/UsersMs.aspx"
                                    title='阅读短消息' target="_blank"><span id="spMessage"></span></a></span>
                        |<a href="#" id='aLoginOut' style="display: none;">&nbsp;退出</a> <a href="/Register.aspx"
                            id='aNewUserReg'>&nbsp;用户注册</a>
                            | <span id='Span1' style="cursor: pointer; color: #003399;">帮助中心&nbsp;</span>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="center">
        <div class="logo">
        </div>
        <div class="icon">
        </div>
<%--        <div class="tianqi">
        </div>--%>
    </div>
    <div id="banner">
    <div class="menuN" >
        <ul>
            <li><a href="/" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                拼搏首页</a></li>
            <li><a href="/Bulletin.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                网站公告</a></li>
            <li><a href="/News.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                新闻资讯</a></li>
            <li><a href="/Soft.aspx" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                软件商城</a></li>
            <li><a href="/SoftwarePrices.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                注册购买</a></li>
            <li><a href="/Source.aspx" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                资源下载</a></li>
            <li><a href="/Lottery.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                开奖信息</a></li>
            <li><a href="/graph.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                数据图表</a></li>
            <li><a href="/School.htm" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                软件学院</a></li>
            <li><a href="http://bbs.pinble.com/" onmouseover="this.style.color='#000000'" onmouseout="this.style.color='#ffffff'">
                拼搏论坛</a></li>
        </ul>
    </div>
    </div>
  <div id="daohang">
        <div class="tubiao">
           <img src="../../LotteryShop/image/daohang1.png" /></div>
        <div class="wenzi">
            当前位置：拼博在线首页 >> <a href="../../LotteryShop/LotteryIndex.aspx"> 彩票超市</a>
        </div>
    </div>
</div>
