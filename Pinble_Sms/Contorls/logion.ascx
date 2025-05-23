<%@ Control Language="C#" AutoEventWireup="true" Codebehind="logion.ascx.cs" Inherits="Pinble_DataRivalry.Contorls.logion" %>
<link type="text/css" href="../css/css.css" rel="stylesheet" />

<script type="text/javascript" src="../jQuery/jquery-1.3.2.js"></script>

<script type="text/javascript" src="../js/jquery.blockUI.js"></script>

<script type="text/javascript" src="../js/jquery-ui-1.7.2.custom.min.js"></script>

<script type="text/javascript" src="../js/Header.js"></script>

<script type="text/javascript" src="../js/SearchAjax.js?date=new date().gettime()"></script>

<div id="divLogin" style="display: none; cursor: default;">
    <table width="350" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="40" background="/images/login1.jpg">
                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="95%">
                        </td>
                        <td width="5%">
                            <img style="cursor: pointer;" src="/images/close.gif" width="15" height="15" id="btnCancelMeng" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="160" valign="middle" background="/images/login2.jpg">
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
                                style="cursor: pointer;" href="/Register.aspx" tabindex='-1'>免费注册</a></td>
                    </tr>
                    <tr>
                        <td align="right">
                            密 &nbsp;码：</td>
                        <td align="left">
                            <input id="txtPassword" type="password" maxlength="16" style="width: 150px;" />&nbsp;<a
                                style="cursor: pointer;" href="/RecoverPasswd1.aspx" target="_blank" tabindex='-2'>密码找回</a></td>
                    </tr>
                    <tr>
                        <td align="right">
                            验证码：</td>
                        <td align="left">
                            <input type="text" id="txtCode" maxlength="4" style="width: 50px;" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" />
                            <img src="/publicPage/VerifyCode.aspx" align="top" alt="看不清？点击更换，不区分大小写！" id="imgVerify"
                                onclick="this.src=this.src+'?'" style="width: 65px; height: 25px; cursor: hand;" />
                            <img alt="正确" src="/images/note_ok.gif" id="imgOKH" style="display: none;" />
                            <img alt="错误" src="/images/note_error.gif" id="imgErrorH" style="display: none;" />
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
                <img src="/images/login3.jpg" width="350" height="13" /></td>
        </tr>
    </table>
</div>
<div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="2" align="right" width="100%">
                <div align="right" style="vertical-align: middle">
                    <span id='aloginShow' style="cursor: pointer; color: #003399;">登录&nbsp;</span> <span
                        id="spUser"></span><span style="display: none;" id="userCenter"><a href="/UserCenter/User_Center.aspx"
                            target="_blank">&nbsp;用户中心&nbsp;</a> <a href="/UserCenter/User_Center.aspx?myUrl=UsersMs.aspx"
                                title='阅读短消息' target="_blank"><span id="spMessage"></span></a></span>
                    |<a href="#" id='aLoginOut' style="display: none;">&nbsp;退出</a> <a href="/Register.aspx"
                        id='aNewUserReg'>&nbsp;用户注册</a>
                </div>
            </td>
        </tr>
    </table>
</div>
