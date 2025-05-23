<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Admin_ChangePWD.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.Admin_ChangePWD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改登录密码</title>
    <link href="StyleCss/css.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <a href="News_Manage.aspx" class="zilan">修改登录密码</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：修改登录密码</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    您的旧密码：</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtold" runat="server" TextMode="Password" Width="150px" MaxLength="16"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv_old" runat="server" ErrorMessage="请输入旧密码" ControlToValidate="txtold"
                                        Display="Dynamic"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    输入新密码：</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtNewPWD1" runat="server" TextMode="Password" Width="150px" MaxLength="16"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNew1" runat="server" ControlToValidate="txtNewPWD1"
                                        ErrorMessage="请输入新密码" Display="Dynamic"></asp:RequiredFieldValidator><strong><span
                                            style="color: #d11b00">6～16</span></strong><span style="color: #666666">位。限用字母、数字、特殊字符。</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    新密码确认：</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtNewPWD2" runat="server" TextMode="Password" Width="150px" MaxLength="16"></asp:TextBox>
                                    <asp:CompareValidator ID="rfvNew2" runat="server" ControlToCompare="txtNewPWD1" ControlToValidate="txtNewPWD2"
                                        ErrorMessage="新密码两次输入不一致" Display="Dynamic"></asp:CompareValidator></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    请输入验证码：</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtTry" runat="server" MaxLength="4" TextMode="Password" Width="50px"
                                        onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtry" runat="server" ControlToValidate="txtTry"
                                        ErrorMessage="请输入验证码" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                        id="imgVerify" onclick="this.src=this.src+'?'" height="26" width="106" />
                                    <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                    <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btBack" runat="server" Text="保存" OnClick="btBack_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
