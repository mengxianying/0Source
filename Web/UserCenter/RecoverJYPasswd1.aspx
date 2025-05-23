<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverJYPasswd1.aspx.cs" Inherits="Pbzx.Web.RecoverJYPasswd1" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>找回交易一</title>
     <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;
        <uc1:Head ID="Head1" runat="server" />
        <table align="center" border="0" cellpadding="2" cellspacing="0" width="750">
            <tr>
                <td align="left">
                    <img height="60" src="/images/Web/l_ca.gif" width="200" /></td>
            </tr>
            <tr>
                <td>
                    <table bgcolor="#ccdaf8" border="0" cellpadding="0" cellspacing="1" width="100%">
                        <tr>
                            <td bgcolor="#ffffff">
                                <table border="1" bordercolor="#ffffff" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" bgcolor="#edf2fc">
                                            <img align="absBottom" height="14" hspace="5" src="../Images/Web/l_c_li.gif" vspace="4"
                                                width="14" />第1步：您可以通过以下方法自助找回交易密码
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="4" cellspacing="0" width="95%">
                                    <tr>
                                        <td>
                                            <table align="center" border="0" cellpadding="8" cellspacing="0" width="85%">
                                                <tr>
                                                    <td align="left" class="B14">
                                                        第一种是通过密码保护问题：</td>
                                                </tr>
                                                <tr>
                                                    <td height="55">
                                                        &nbsp;<asp:ImageButton ID="imbtAsk" runat="server" ImageUrl="~/Images/Web/l_c_btn3.gif"
                                                            OnClick="imbtAsk_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        在您注册成网站会员后，申请密码保护的问题和答案。</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table align="center" border="0" cellpadding="4" cellspacing="0" width="85%">
                                                <tr>
                                                    <td align="left" class="B14">
                                                        第二种是通过密码保护邮箱：</td>
                                                </tr>
                                                <tr>
                                                    <td height="55">
                                                        <asp:ImageButton ID="imbtEmail" runat="server" ImageUrl="~/Images/Web/l_c_btn2.gif"
                                                            OnClick="imbtEmail_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        在您注册成网站会员后，申请密码保护的邮箱。</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
