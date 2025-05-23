<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RecoverPasswd1.aspx.cs"
    Inherits="Pbzx.Web.RecoverPasswd1" EnableEventValidation="false" %>

<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>密码找回步骤一_拼搏在线彩神通软件</title>
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
                    <td align="left" style="height: 64px">
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
                                                <img src="images/Web/l_c_li.gif" width="14" height="14" hspace="5" vspace="4" align="absbottom" />第1步：请输入用户名</td>
                                        </tr>
                                    </table>
                                    <table width="40%" border="0" align="center" cellpadding="7" cellspacing="0">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lab_num" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td width="23%" style="height: 38px">
                                                用户名：</td>
                                            <td width="77%" align="left" style="height: 38px">
                                                <asp:TextBox ID="txtUserName" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                                                
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Web/l_c_bt1.jpg"
                                                    OnClick="ImageButton1_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
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
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
