<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bank_Info.aspx.cs" Inherits="Pbzx.Web.UserCenter.Bank_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改银行信息</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

    <script type="text/javascript" src="/UserCenter/js/advance.js"></script>

    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

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
                class="uc_MT10" runat="server" id="tbBank">
                <tr>
                    <td height="24" bgcolor="#FFF8EE" class="uc_font_black">
                        <span class="uc_font_orange">&nbsp;我的资料：</span><a href="ChangePWD.aspx"><b>修改登录密码</b></a>&nbsp;|&nbsp;<a
                            href="PWD_Ask.aspx">登录密保修改</a>&nbsp;|&nbsp;<a href="User_Info.aspx">修改详细信息</a>&nbsp;|&nbsp;<a
                                href="Bank_Info.aspx">修改银行信息</a>&nbsp;|&nbsp;<a href="ChangePWD_buy.aspx">修改交易密码</a>&nbsp;|&nbsp;<a
                                    href="PWD_BuyAsk.aspx">交易密保修改</a></td>
                </tr>
            </table>
            <asp:Panel ID="pnlYanZ" runat="server" Visible="true">
                <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                    <tr>
                        <td width="5" bgcolor="#FF7300">
                        </td>
                        <td width="800" height="28" bgcolor="#DCEDFC" class="uc_font_black">
                            &nbsp;验证交易密码</td>
                    </tr>
                </table>
                <table width="800" border="0" cellpadding="3" cellspacing="1" bgcolor="#DDDDDD" align="center">
                    <tr>
                        <td width="220" align="right" valign="top" bgcolor="#F6F6F6">
                            交易密码：</td>
                        <td width="600" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="28%" align="left">
                                        <asp:TextBox ID="txtJyPWD" runat="server" TextMode="Password" Width="150px" MaxLength="18"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtJyPWD"
                                            ErrorMessage="请输入交易密码" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                    <td width="72%" align="left" valign="top">
                                        <a href="/UserCenter/RecoverJYPasswd1.aspx" target="_blank">忘记交易密码？</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#F6F6F6">
                            确认交易密码：</td>
                        <td bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="28%" align="left">
                                        <asp:TextBox ID="txtJyPWD2" runat="server" TextMode="Password" Width="150px" MaxLength="18"></asp:TextBox><br />
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtJyPWD"
                                            ControlToValidate="txtJyPWD2" Display="Dynamic" ErrorMessage="两次输入交易密码不一致！"></asp:CompareValidator></td>
                                    <td width="72%" align="left" valign="top">
                                        请再次输入交易密码。</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" align="right" valign="top" bgcolor="#F6F6F6">
                            验证码：</td>
                        <td height="30" class="black" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="28%" align="left">
                                        <asp:TextBox ID="txtCode" runat="server" Width="50px" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"
                                            MaxLength="4"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCode"
                                            ErrorMessage="请输入验证码" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                    <td width="72%" align="left" valign="top">
                                        <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" width="65"
                                            height="23" align="absmiddle" id="imgVerify" onclick="this.src=this.src+'?'" />
                                        <img alt="正确" src="../Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                        <img alt="错误" src="../Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td height="30" colspan="2" align="center">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="25%">
                                        &nbsp;
                                    </td>
                                    <td width="25%">
                                        <asp:Button ID="btnOK" runat="server" Text="保存" OnClick="btnOK_Click" CssClass="page_SaveS" />&nbsp;
                                        &nbsp;&nbsp;
                                    </td>
                                    <td width="50%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlXiuG" runat="server" Visible="false">
                <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                    <tr>
                        <td width="5" bgcolor="#FF7300">
                        </td>
                        <td width="800" height="28" bgcolor="#DCEDFC" class="uc_font_black">
                            &nbsp;修改银行信息</td>
                    </tr>
                </table>
                <table width="800" border="0" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD" align="center">
                    <tr>
                        <td width="27%" align="right" bgcolor="#F6F6F6">
                            发卡银行：</td>
                        <td width="76%" colspan="2" align="left" bgcolor="#FFFFFF">
                            <asp:RadioButtonList ID="rblBankList" runat="server" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#F6F6F6">
                            开户行：</td>
                        <td colspan="2" align="left" bgcolor="#FFFFFF">
                            <asp:TextBox ID="txtBankInfo" runat="server" Width="360px" MaxLength="50"></asp:TextBox>
                            <span style="color: #ff0000">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBankInfo"
                                ErrorMessage="请填写开户行"></asp:RequiredFieldValidator><br />
                            <span class="color3">例如：北京市中国建设银行铁道专业支行官园南里储蓄所 注意：无论您的银行卡的发卡银行和地区怎样选择，请您务必填写‘银行卡开户银行’。其格式如上例子所示，XX省XX银行XX市XX支行(营业部)</span></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#F6F6F6">
                            卡号：</td>
                        <td colspan="2" align="left" bgcolor="#FFFFFF">
                            <asp:TextBox ID="txtAccountNumber" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                            <span style="color: #ff0000">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAccountNumber"
                                ErrorMessage="请填写卡号"></asp:RequiredFieldValidator><br />
                            <span class="color3" style="color: Red;">此处填写的发卡银行所属开户行和卡号必须与您的银行卡真实信息完全一致。如由您提交的银行卡信息资料不准确，造成的任何资金往来损失，您将承担全部责任。</span></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#F6F6F6">
                        </td>
                        <td align="left" colspan="2" bgcolor="#FFFFFF">
                            <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="page_SaveS" OnClick="btnUpdate_Click" />&nbsp;
                            <input type="button" name="button" id="button" value="取消" onclick="location='userManage.aspx';"
                                class="page_SaveS" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
