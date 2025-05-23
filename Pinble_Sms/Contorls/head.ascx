<%@ Control Language="C#" AutoEventWireup="true" Codebehind="head.ascx.cs" Inherits="Pinble_Market.Contorls.head" %>
<link href="../Css/head.css" rel="stylesheet" type="text/css" />
<link type="text/css" href="../Css/themes/base/ui.all.css" rel="stylesheet" />
<link type="text/css" href="../Css/css.css" rel="stylesheet" />
<link type="text/css" href="../Css/demos.css" rel="stylesheet" />
<link type="text/css" href="../Css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

<script type="text/javascript" src="../JS/jquery-1.3.2.js"></script>

<script type="text/javascript" src="../JS/jquery.blockUI.js"></script>

<script type="text/javascript" src="../JS/jquery-ui-1.7.2.custom.min.js"></script>

<script type="text/javascript" src="../JS/Header.js"></script>

<script type="text/javascript" src="../JS/SearchAjax.js"></script>

<div id="divLogin" style="display: none; cursor: default;">
    <table width="350" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="40" style="background: url(../image/login1.jpg)">
                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="95%">
                        </td>
                        <td width="5%">
                            <img style="cursor: pointer;" src="../image/close.gif" width="15" height="15" id="btnCancelMeng"
                                alt="" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="160" valign="middle" style="background: url(../image/login2.jpg)">
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
                                tabindex='-1'>免费注册</a></td>
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
                            <img src="../publicPage/VerifyCode.aspx" align="top" alt="看不清？点击更换，不区分大小写！" id="imgVerify"
                                onclick="this.src=this.src+'?'" style="width: 65px; height: 25px; cursor: hand;" />
                            <img alt="正确" src="../image/note_ok.gif" id="imgOKH" style="display: none;" />
                            <img alt="错误" src="../image/note_error.gif" id="imgErrorH" style="display: none;" />
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
                <img src="../image/login3.jpg" width="350" height="13" alt="" /></td>
        </tr>
    </table>
</div>
<div id="wrap">
    <div id="tophead">
        <table width="99%" height="57px">
            <tr>
                <td>
                    <div id="iconhead">
                        <img src="../image/sprite1.png" width="696" height="57" border="0" usemap="#Map" />
                        <map name="Map" id="Map">
                            <area shape="rect" coords="8,3,47,58" href="http://www.pinble.com" target="_blank" />
                            <area shape="rect" coords="76,5,131,59" href="#" target="_blank" />
                            <area shape="rect" coords="156,4,213,58" href="#" />
                            <area shape="rect" coords="245,5,293,61" href="#" target="_blank" />
                            <area shape="rect" coords="335,3,371,62" href="http://bar.pinble.com/" target="_blank" />
                            <area shape="rect" coords="403,4,462,61" href="#" />
                            <area shape="rect" coords="490,3,542,61" href="http://market.pinble2.com" target="_blank" />
                            <area shape="rect" coords="568,4,617,60" href="#" />
                            <area shape="rect" coords="646,5,694,62" href="#" />
                        </map>
                    </div>
                </td>
                <td valign="top">
                    <div class="topNav">
                        <ul>
                            <li><span id='aloginShow' style="cursor: pointer; color: #003399;"><a href="#">登录</a>&nbsp;</span>
                                <span id="spUser"></span></li>
                            <li><a href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx" id='aNewUserReg'
                                target="_blank">&nbsp;用户注册</a> </li>
                            <li><a href="#" id='aLoginOut' style="display: none;">&nbsp;退出</a></li>
                            <li><a href="#"><span id='Span1' style="cursor: pointer; color: #003399;">帮助中心&nbsp;</span></a></li>
                        </ul>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
