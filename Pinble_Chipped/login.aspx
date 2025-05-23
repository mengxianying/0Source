<%@ Page Language="C#" AutoEventWireup="true" Codebehind="login.aspx.cs" Inherits="Pinble_Chipped.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录页面</title>

    <link type="text/css" href="loginCss/css.css" rel="stylesheet" />

    <script type="text/javascript" src="jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="jQuery/jquery.XYTipsWindow.2.7.js"></script>

    <script type="text/javascript" src="js/jquery.blockUI.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="js/Header.js?date=new date().gettime()"></script>

    <script type="text/javascript" src="js/SearchAjax.js?date=new date().gettime()"></script>
    <script type="text/javascript" src="js/public.js"></script>

</head>
<body id="body">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" align="center" cellpadding="4" cellspacing="0">
                <tr>
                    <td colspan="2" height="5px">
                    </td>
                </tr>
                <tr>
                    <td width="23%" align="right">
                        用户名：</td>
                    <td width="77%" align="left">
                        <input type="text" id="txtUsername" maxlength="12" style="width: 150px;" />&nbsp;<a style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>Register.aspx"
                            tabindex='-1'>免费注册</a></td>
                </tr>
                <tr>
                    <td align="right">
                        密&nbsp;码：</td>
                    <td align="left">
                        <input id="txtPassword" type="password" maxlength="16" style="width: 150px;" />&nbsp;<a
                            style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>/RecoverPasswd1.aspx" target="_blank" tabindex='-2'>密码找回</a></td>
                </tr>
                <tr>
                    <td align="right">
                        验证码：</td>
                    <td align="left">
                        <input type="text" id="txtCode" maxlength="4" style="width: 50px;" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" />
                        <img src="publicPage/VerifyCode.aspx" align="top" alt="看不清？点击更换，不区分大小写！" id="imgVerify"
                            onclick="this.src=this.src+'?'" style="width: 65px; height: 25px; cursor: hand;" />
                        <img alt="正确" src="image/note_ok.gif" id="imgOKH" style="display: none;" />
                        <img alt="错误" src="image/note_error.gif" id="imgErrorH" style="display: none;" />
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
        </div>
    </form>
</body>
</html>
