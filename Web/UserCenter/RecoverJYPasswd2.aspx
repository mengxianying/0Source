<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverJYPasswd2.aspx.cs" Inherits="Pbzx.Web.RecoverJYPasswd2" %>

<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc4" %>

<%@ Register Src="/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="/Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>找回交易二</title>
        <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<uc3:Head ID="Head1" runat="server" />
        <table width="750" border="0" align="center" cellpadding="2" cellspacing="0">
                <tr>
                    <td align="left">
                        <img src="/images/Web/l_ca.gif" width="200" height="60" /></td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCDAF8" id="email" runat="server">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="0" bordercolor="#FFFFFF">
                                        <tr>
                                            <td align="left" bgcolor="#EDF2FC">
                                                <img src="/Images/Web/l_c_li.gif" width="14" height="14" hspace="5" vspace="4" align="absbottom" />第2步：请填写下面信息，系统将通过密码保护设置的邮箱找回交易密码
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="55%" border="0" align="center" cellpadding="5" cellspacing="0" id="email2" runat="server">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" align="right">
                                                密码保护邮箱：</td>
                                            <td width="75%" align="left" >
                                                <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                    ErrorMessage="Email格式不正确；" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td height="50">
                                                &nbsp;</td>
                                            <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="inbtEmail" runat="server" ImageUrl="~/Images/Web/l_c_btn4.jpg"
                                                    OnClick="inbtEmail_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                                <table width="43%" border="0" align="center" cellpadding="7" cellspacing="0" id="email3" runat="server" visible="false">
                                        <tr>
                                            <td height= "15px">                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" align="center" cellpadding="7" cellspacing="1" bgcolor="#00BE00">
                                                    <tr>
                                                        <td bgcolor="#E6FFE6" height="80" align="center">
                                                            您的密码找回申请已经提交成功<br />
                                                            新密码已发送到邮箱
                                                            <asp:Label ID="lblEmails" runat="server"></asp:Label><br />
                                                            请进入邮箱查阅
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center"  height= "35px" valign="bottom">
                                                <asp:ImageButton ID="imbtEmail2" runat="server" ImageUrl="~/Images/Web/l_c_btn5.jpg"
                                                    OnClick="imbtEmail2_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>                    
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCDAF8" id="ask" runat="server">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="0" bordercolor="#FFFFFF">
                                        <tr>
                                            <td align="left" bgcolor="#EDF2FC">
                                                <img src="/Images/Web/l_c_li.gif" width="14" height="14" hspace="5" vspace="4" align="absbottom" />第2步：请选择保护问题和填写答案
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="43%" border="0" align="center" cellpadding="7" cellspacing="0" id="ask2" runat="server">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%">
                                                选择问题：</td>
                                            <td width="75%" align="left">
                                                &nbsp;<asp:Label ID="lblAsk" runat="server"></asp:Label></td>
                                        </tr>
                                                <tr>
                                            <td width="25%">
                                                问题答案：</td>
                                            <td width="75%" align="left">
                                                <asp:TextBox ID="txtAnswer" runat="server" Width="180px" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imbtAsk" runat="server" ImageUrl="~/Images/Web/l_c_btn4.jpg" OnClick="imbtAsk_Click" />
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
            </table>
    </div>
        <uc4:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
