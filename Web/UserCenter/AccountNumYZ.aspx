<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AccountNumYZ.aspx.cs" Inherits="Pbzx.Web.UserCenter.AccountNumYZ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>银行卡验证_拼搏在线彩神通软件</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="dialog1" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <div id="dialog2" title="拼搏在线彩神通软件网站提醒" style="display: none;">
                <p>
                    提醒内容</p>
            </div>
            <table width="800" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFCB99" align="center"
                class="uc_MT10">
                <tr>
                    <td height="24" bgcolor="#FFF8EE" class="uc_font_black">
                        <span class="uc_font_orange">&nbsp;我的资料：</span><a href="ChangePWD.aspx"><b>修改登录密码</b></a>&nbsp;|&nbsp;<a
                            href="PWD_Ask.aspx">修改密码问题</a>&nbsp;|&nbsp;<a href="User_Info.aspx">修改详细信息</a>&nbsp;|&nbsp;<a
                                href="ChangePWD_buy.aspx">修改交易密码</a>&nbsp;|&nbsp;<a href="Bank_Info.aspx">修改银行信息</a></td>
                </tr>
            </table>
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                <tr>
                    <td width="5" bgcolor="#FF7300">
                    </td>
                    <td width="800" height="28" bgcolor="#DCEDFC" class="uc_font_black">
                        &nbsp;银行卡验证</td>
                </tr>
            </table>
            <table width="800" border="0" cellpadding="3" cellspacing="1" bgcolor="#DDDDDD" align="center">
                <tr>
                    <td width="163" align="right" valign="top" bgcolor="#F6F6F6">
                        请输入银行卡验证码：
                    </td>
                    <td width="626" bgcolor="#ffffff">
                        <asp:TextBox ID="txtYZM" runat="server" MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="银行卡验证码不能为空"
                            ControlToValidate="txtYZM"></asp:RequiredFieldValidator><br />
                        <span class="uc_font_gray">（注：拼搏在线已将0.01元到0.99元的款项划入您的银行卡。 您只需把划入银行卡的金额正确填入验证框，银行卡验证就成功完成。验证码有效期为14天。
                            银行卡验证码： （例如：金额为0.88元，则输入0.88）</span>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td>
                    </td>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" CssClass="page_Save"
                            Text="提交" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
