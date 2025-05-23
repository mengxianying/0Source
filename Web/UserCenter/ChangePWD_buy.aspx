<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChangePWD_buy.aspx.cs"
    Inherits="Pbzx.Web.UserCenter.ChangePWD_buy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改交易密码</title>
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
                class="uc_MT10">
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
                            &nbsp;修改交易密码</td>
                    </tr>
                </table>
                <table width="800" border="0" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD" align="center">
                    <tr>
                        <td width="155" align="right" bgcolor="#F6F6F6">
                            交易密保问题：
                        </td>
                        <td bgcolor="#F6F6F6">
                            <asp:Label ID="lblMBWT" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="155" align="right" bgcolor="#F6F6F6">
                            交易密保答案：
                        </td>
                        <td bgcolor="#F6F6F6">
                            <asp:TextBox ID="txtMBDA" runat="server" Width="180px" MaxLength="20"></asp:TextBox>
                            <span style="color: #666666">请输入您的交易密保答案</span>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f6f6f6" width="155">
                        </td>
                        <td bgcolor="#f6f6f6">
                            <asp:Button ID="btnKSYZ" runat="server" Text="下一步" OnClick="btnKSYZ_Click" CssClass="page_Save" /></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlXiuG" runat="server" Visible="false">
                <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                    <tr>
                        <td width="5" bgcolor="#FF7300">
                        </td>
                        <td width="800" height="28" bgcolor="#DCEDFC" class="uc_font_black">
                            &nbsp;修改交易密码</td>
                    </tr>
                </table>
                <table width="800" border="0" cellpadding="2" cellspacing="1" bgcolor="#DDDDDD" align="center">
                    <tr>
                        <td width="192" align="right" bgcolor="#F6F6F6">
                            旧交易密码：</td>
                        <td width="602" align="left" bgcolor="#FFFFFF">
                            <asp:TextBox ID="txtOldTrade" runat="server" TextMode="Password" MaxLength="16"></asp:TextBox>
                            <a href="/UserCenter/RecoverJYPasswd1.aspx" target="_blank">忘记交易密码？</a>
                        </td>
                    </tr>
                    <tr>
                        <td width="192" align="right" bgcolor="#F6F6F6">
                            新交易密码：</td>
                        <td width="602" align="left" bgcolor="#FFFFFF">
                            <asp:TextBox ID="txtTradePwd1" runat="server" TextMode="Password"></asp:TextBox>
                            <span class="uc_font_gray">密码必须是6-16位的字母和数字。</span><br />
                            <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtTradePwd1"
                                Display="Dynamic" ErrorMessage="密码必须是6-16位的字母和数字" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9_]{6,18}$"
                                ValidationGroup="baseinfo"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td width="192" align="right" bgcolor="#F6F6F6">
                            确认交易密码：</td>
                        <td width="602" align="left" bgcolor="#FFFFFF">
                            <asp:TextBox ID="txtTradePwd2" runat="server" TextMode="Password"></asp:TextBox>
                            <span class="uc_font_gray">请再次输入交易密码</span><br />
                            <asp:CompareValidator ID="rfd2" runat="server" ControlToCompare="txtTradePwd1" ControlToValidate="txtTradePwd2"
                                Display="Dynamic" ErrorMessage="交易密码两次输入不一致，请重新输入。"></asp:CompareValidator></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F6F6F6">
                            验证码：</td>
                        <td align="left" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="4%">
                                        <asp:TextBox ID="txtCode" runat="server" MaxLength="4" Width="50" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox></td>
                                    <td width="5%" align="left">
                                        <div id="errcheckcode" class="errMsg">
                                        </div>
                                    </td>
                                    <td width="20%">
                                        <div id="checkcode">
                                            <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                                id="imgVerify" onclick="this.src=this.src+'?'" height="23" width="65" />
                                            <img alt="正确" src="../Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                            <img alt="错误" src="../Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                        </div>
                                    </td>
                                    <td width="71%">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode"
                                            ErrorMessage="请输入验证码"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" bgcolor="#FFFFFF" align="center">
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td width="23%">
                                        &nbsp;
                                    </td>
                                    <td width="25%">
                                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="保存" CssClass="page_SaveS" />&nbsp;&nbsp;
                                        <input type="button" name="button" id="button" value="取消" onclick="location='userManage.aspx';"
                                            class="page_SaveS" /></td>
                                    <td width="52%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
