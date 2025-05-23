<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAskHead.ascx.cs" Inherits="Pinble_Ask.Contorls.UcAskHead" %>
<%@ Register Src="UcSearch.ascx" TagName="UcSearch" TagPrefix="uc1" %>
<%--<link type="text/css" href="/css/themes/base/ui.all.css" rel="stylesheet" />
<link type="text/css" href="/css/demos.css" rel="stylesheet" />--%>
<link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
<link type="text/css" href="/css/XYTipsWindow.css" rel="stylesheet" />
<script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

<script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

<script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

<script type="text/javascript" src="/javascript/Header.js"></script>

<script type="text/javascript" src="/javascript/SearchAjax.js"></script>

<script type="text/javascript" src="/javascript/CustomService.js"></script>

<script type="text/javascript" src="/javascript/jquery.XYTipsWindow.2.7.js"></script>

<div id="divLogin" style="display: none; cursor: default;">
    <table width="350" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="40" background="/Images/Web/login1.jpg">
                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="95%">
                        </td>
                        <td width="5%">
                            <img style="cursor: pointer;" src="/Images/Web/close.gif" width="15" height="15"
                                id="btnCancel" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="160" valign="middle" background="/Images/Web/login2.jpg">
                <table width="85%" border="0" align="center" cellpadding="4" cellspacing="0" height="145">
                    <tr>
                        <td colspan="2" height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td width="23%" align="right">
                            用户名：</td>
                        <td width="77%" align="left">
                            <input type="text" id="txtUsername" maxlength="12" style="width: 150px;" />&nbsp;<a
                                style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx"
                                tabindex="-1">免费注册</a></td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 32px">
                            密 &nbsp;码：</td>
                        <td align="left" style="height: 32px">
                            <input id="txtPassword" type="password" maxlength="16" style="width: 150px;" />&nbsp;<a
                                style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>RecoverPasswd1.aspx" target="_blank" tabindex="-2">密码找回</a></td>
                    </tr>
                    <tr>
                        <td align="right">
                            验证码：</td>
                        <td align="left">
                            <input type="text" id="txtCode" maxlength="4" style="width: 50px;" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" />
                            <img src="/publicPage/VerifyCode.aspx" align="top" alt="看不清？点击更换，不区分大小写！" id="imgVerify"
                                onclick="this.src=this.src+'?'" style="width: 65px; height: 25px; cursor: pointer;" />
                            <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKH" style="display: none;" />
                            <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorH" style="display: none;" />
                            &nbsp;
                        </td>
                    </tr>
                    <%-- <tr>
                        <td align="right">
                        </td>
                        <td>
                                                     <input type="radio" name="rdState" checked="checked" id="rd1" value="0" />不保存<input
                                type="radio" name="rdState" id="rd2" value="1" />一天<input type="radio" name="rdState"
                                    id="rd3" value="2" />一月<input type="radio" name="rdState"
                                    id="rd4" value="3" />一年
                           
                        </td>
                    </tr>--%>
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
                <img src="/Images/Web/login3.jpg" width="350" height="13" /></td>
        </tr>
    </table>
</div>
<div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none; margin: 0px; padding: 0px;">
    <p>
    </p>
</div>
<div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none; margin: 0px; padding: 0px;">
    <p>
    </p>
</div>
<%--#{lblMessage}.setText('LOGIN CANCELED')--%>
<div class="main">
    <table width="100%" border="0" cellspacing="0" cellpadding="2">
        <tr>
            <td align="left">
                <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>">网站首页</a>&nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Bulletin.htm">网站公告</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>News.htm">新闻资讯</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Soft.aspx">软件商城</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>SoftwarePrices.htm">注册购买</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Source.aspx">资源下载</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Lottery.htm">开奖信息</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>graph.htm">数据图表</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>School.htm">软件学院</a>
                &nbsp;&nbsp;<a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Broker.aspx">经纪人</a>
                &nbsp;&nbsp;<a href="http://bbs.pinble.com">拼搏论坛</a>&nbsp;
            </td>
            <td align="right" style="width: 270px">
                <div class="Top">
                  <span id='aloginShow1' style="cursor: pointer; color: #003399;"><a href="/Login.aspx">登录&nbsp;</a></span>

                  <!--  <span id='aloginShow' style="cursor: pointer; color: #003399;">登录</span> -->

                    <span id="spUser"></span>
                    <span style="display: none;" id='User'><a href='/User.aspx'>我的拼搏吧</a> <a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>UserCenter/User_Center.aspx?myUrl=/UsersMs.aspx"
                        title='阅读短消息' target='_blank'><span id="spMessage"></span></a></span>&nbsp;|&nbsp;<a href="#" id='aLoginOut'
                            style="display: none;">退出</a><a href="<%= Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Register.aspx"
                                id='aNewUserReg'>用户注册</a>
                </div>
            </td>
        </tr>
    </table>
</div>
<div class="main">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="13%" align="right" valign="top">
                <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="158" height="72" align="center">
                            <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="12%">
                <a href="<%=Pbzx.Common.WebInit.ask.WebUrl%>">
                    <img src="/images/A_Logo.jpg" width="120" height="58" border="0" /></a></td>
            <td width="2%">
            </td>
            <td align="left" colspan="4">
                <uc1:UcSearch ID="UcSearch1" runat="server"></uc1:UcSearch>
            </td>
        </tr>
    </table>
</div>
