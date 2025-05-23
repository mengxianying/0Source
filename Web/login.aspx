<%@ Page Language="C#" AutoEventWireup="true" Codebehind="login.aspx.cs" Inherits="Pbzx.Web.login" %>

<%@ Register Src="Contorls/Login.ascx" TagName="Login" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%@ Register Src="Contorls/UcLogin.ascx" TagName="UcLogin" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员登录_拼搏在线彩神通软件</title>
    <meta name="keywords" content="网站登录" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
.blue14 {
	font-size: 14px;
	font-weight: 600;
	color: #135AAA;
}
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc2:Head ID="Head1" runat="server" />
            <table width="750" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" height="35">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="370">
                        <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left">
                                    <img src="images/Web/l_l_title.gif" width="160" height="58" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="images/Web/l_lbg1.gif" width="320" height="10" /></td>
                            </tr>
                            <tr>
                                <td background="images/Web/l_lbg2.gif">
                                  
                                    <uc4:Login ID="Login1" runat="server" InUrl="/" />
                                   
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="images/Web/l_lbg3.gif" width="320" height="10" /></td>
                            </tr>
                               <tr>
                                <td height="38">
                                   </td>
                            </tr>
                        </table>
                       
                    </td>
                    <td width="80" background="images/Web/l_center.gif" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td width="300" valign="top">
                        <table width="280" border="0" align="center" cellpadding="4" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <img src="images/Web/l_r-title.jpg" width="150" height="50" /></td>
                            </tr>
                            <tr>
                                <td align="left" class="blue14">
                                    如果您还不是拼搏会员？</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <img src="images/Web/l_li.jpg" width="6" height="11" hspace="3" />请先注册一个免费会员后，登录查看。</td>
                            </tr>
                            <tr>
                                <td height="50" align="center">
                                    <a href="Register.aspx">
                                        <img src="images/Web/l_register.jpg"  border="0" /></a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="30">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <uc3:Footer ID="Footer1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
