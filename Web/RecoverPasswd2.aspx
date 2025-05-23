<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RecoverPasswd2.aspx.cs"
    Inherits="Pbzx.Web.RecoverPasswd2"  EnableEventValidation="false" %>

<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>密码找回步骤二_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <table width="750" border="0" align="center" cellpadding="2" cellspacing="0">
                <tr>
                    <td align="left">
                        <img src="images/Web/l_c.gif" width="180" height="60" /></td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCDAF8">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="0" bordercolor="#FFFFFF">
                                        <tr>
                                            <td align="left" bgcolor="#EDF2FC">
                                                <img src="images/Web/l_c_li.gif" width="14" height="14" hspace="5" vspace="4" align="absbottom" />第2步：您可以通过以下方法自助找回密码
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="95%" border="0" align="center" cellpadding="4" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="85%" border="0" cellspacing="0" cellpadding="8" align="center">
                                                    <tr>
                                                        <td align="left" class="B14">
                                                            第一种是通过密码保护问题：</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="55">
                                                            &nbsp;<asp:ImageButton ID="imbtAsk" runat="server" ImageUrl="~/Images/Web/l_c_btn3.gif" OnClick="imbtAsk_Click" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"> 
                                                            在你注册成网站会员时，自己设置的问题和答案。</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table width="85%" border="0" cellspacing="0" cellpadding="4" align="center">
                                                    <tr>
                                                        <td align="left"  class="B14" >
                                                            第二种是注册邮箱：</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="55">
                                                            <asp:ImageButton ID="imbtEmail" runat="server" ImageUrl="~/Images/Web/l_c_btn2.gif"
                                                                OnClick="imbtEmail_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            在你注册成网站会员时，提供给我们的邮箱。</td>
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
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
