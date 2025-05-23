<%@ Page Language="C#" AutoEventWireup="true" Codebehind="OnMakePwd.aspx.cs" Inherits="Pbzx.Web.OnMakePwd" EnableEventValidation="false" %>

<%@ Register Src="/Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="/Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�����һ�_ƴ�����߲���ͨ���</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
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
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCDAF8"
                            id="email" runat="server">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="0" bordercolor="#FFFFFF">
                                        <tr>
                                            <td align="left" bgcolor="#EDF2FC">
                                                <img src="images/Web/l_c_li.gif" width="14" height="14" hspace="5" vspace="4" align="absbottom" />��4�����޸�����
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="62%" border="0" align="center" cellpadding="4" cellspacing="0" id="email2"
                                        runat="server">
                                        <tr>
                                            <td colspan="2" height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="28%" align="right">
                                                �û���:</td>
                                            <td align="left" width="72%">
                                                &nbsp;<asp:Label ID="txtUserName" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                ������:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtUserPassword" runat="server" Width="140px" TextMode="Password" MaxLength="16"></asp:TextBox>
                                                <font color="#333333">�����������롣</font><br />
                                                <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtUserPassword"
                                                    Display="Dynamic" ErrorMessage="���������6-16λ����ĸ������" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9_]{6,18}$"
                                                    ValidationGroup="baseinfo"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td width="28%" align="right">
                                                ȷ��������:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtAgain" runat="server" Width="140px" TextMode="Password" MaxLength="16"></asp:TextBox>
                                                <font color="#333333">�ٴ����������롣</font><br />
                                                <asp:CompareValidator ID="agein" runat="server" ControlToCompare="txtUserPassword"
                                                    ControlToValidate="txtAgain" Display="Dynamic" ErrorMessage=" �����������벻һ��!"></asp:CompareValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                ��֤��:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCode" MaxLength="4" 
                                                    runat="server" Width="50px" onkeyup="CheckYZM(this.value,'1','btnLogin','imgOKH','imgErrorH')" ></asp:TextBox>
                                                <img src="/publicPage/VerifyCode.aspx" alt="�����壿�������" name="imgVerify" align="absmiddle"
                                                    id="imgVerify" onclick="this.src=this.src+'?'" style="width: 85px; height: 25px" />
                                                <img alt="��ȷ" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                                <img alt="����" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:ImageButton ID="inbtEmail" runat="server" ImageUrl="~/Images/Web/l_c_btn4.jpg"
                                                    OnClick="inbtEmail_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="10">
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
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
