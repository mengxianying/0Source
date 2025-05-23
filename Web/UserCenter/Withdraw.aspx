<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Withdraw.aspx.cs" Inherits="Pbzx.Web.UserCenter.Withdraw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户取款申请</title>
    <link href="/css/user_center.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

    <script type="text/javascript" src="/UserCenter/js/advance.js"></script>

    <script type="text/javascript" src="/javascript/SearchAjax.js"></script>

    <script type="text/javascript" language="javascript">
        function isnum()
        {
            if(event.keyCode<46||event.keyCode>57 || event.keyCode==47)
            {
                event.keyCode=0;
            }
        }  
    </script>

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
            <table id="tb1" runat="server" width="50%" border="0" align="center" cellpadding="0"
                cellspacing="0" style="margin-top: 5px;" visible="true">
                <tr>
                    <td>
                        <table width="800" border="0" align="center" cellpadding="2" cellspacing="0" class="uc_MT10">
                            <tr>
                                <td width="20" class="uc_xia" height="25">
                                    <img src="../images/web/Uc_li.gif" alt="" /></td>
                                <td width="780" class="uc_xia" valign="bottom">
                                    <span class="uc_font_blue14">请输入交易密码</span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="800" border="0" cellpadding="3" cellspacing="1" bgcolor="#DDDDDD" align="center">
                            <tr>
                                <td width="220" align="right" valign="top" bgcolor="#F6F6F6">
                                    交易密码：</td>
                                <td width="600" bgcolor="#FFFFFF">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="29%" align="left">
                                                <asp:TextBox ID="txtJyPWD" runat="server" TextMode="Password" Width="150px" MaxLength="18"></asp:TextBox><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtJyPWD"
                                                    ErrorMessage="请输入交易密码" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                            <td width="71%" align="left" valign="top">
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
                                            <td width="29%" align="left">
                                                <asp:TextBox ID="txtJyPWD2" runat="server" TextMode="Password" Width="150px" MaxLength="18"></asp:TextBox><br />
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtJyPWD"
                                                    ControlToValidate="txtJyPWD2" Display="Dynamic" ErrorMessage="两次输入交易密码不一致！"></asp:CompareValidator></td>
                                            <td width="71%" align="left" valign="top">
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
                                            <td align="left">
                                                <asp:TextBox ID="txtCode" runat="server" Width="50px" MaxLength="4" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox>
                                                <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" width="65"
                                                    height="23" align="absmiddle" id="imgVerify" onclick="this.src=this.src+'?'" />
                                                <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                                <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCode"
                                                    ErrorMessage="请输入验证码" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                                &nbsp;</td>
                                            <td width="25%">
                                                <asp:Button ID="btnOK" runat="server" Text="提  交" OnClick="btnOK_Click" CssClass="page_Save" />&nbsp;
                                                &nbsp;
                                                <input type="button" name="button" id="button1" value="关  闭" onclick="location='userManage.aspx';"
                                                    class="page_Save" /></td>
                                            <td width="50%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table id="tb2" runat="server" width="800" border="0" align="center" cellpadding="0"
                cellspacing="1" visible="false">
                <tr>
                    <td>
                        <table width="800" border="0" align="center" cellpadding="2" cellspacing="0" class="uc_MT10">
                            <tr>
                                <td width="20" class="uc_xia" height="25">
                                    <img src="../images/web/Uc_li.gif" alt="" /></td>
                                <td width="780" class="uc_xia" valign="bottom">
                                    <span class="uc_font_blue14">用户取款申请</span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="800" border="0" cellpadding="2" cellspacing="1" bgcolor="#FFCB99" align="center">
                            <tr>
                                <td bgcolor="#FFF8EE">
                                    &nbsp;用户名：<span class="uc_font_red"><asp:Label ID="lblUname" runat="server" Text=""></asp:Label></span>&nbsp;可取金额：<span
                                        class="uc_font_red"><asp:Label ID="lblCurrent" runat="server" Text=""></asp:Label></span>
                                    <b>取款金额：</b>
                                    <asp:TextBox ID="txtDraw" runat="server" MaxLength="8" Width="90px" onkeypress="isnum()"></asp:TextBox>元<span
                                        color="red">*</span>（注：最少取款金额为100元）
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr bgcolor="#ffffff">
                    <td height="23">
                        &nbsp;<span class="uc_font_gray">(注：请确认以下信息，保证帐号中的开户名和您的真实姓名一致！)</span></td>
                </tr>
                <tr>
                    <td>
                        <table width="800" border="0" cellpadding="2" cellspacing="1" bgcolor="#DDDDDD" align="center">
                            <tr>
                                <td width="200" align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                    省（市）</td>
                                <td width="600" align="left" bgcolor="#FFFFFF">
                                    <asp:Label ID="lblProvince" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                    市（区）</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                    银行名称：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:Label ID="lblBankName" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                    开户银行：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:Label ID="lblBankInfo" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                    账&nbsp;&nbsp;&nbsp;号：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:Label ID="lblAccountNumber" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#F6F6F6" class="uc_font_blue">
                                    真实姓名：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    <asp:Label ID="lblRealName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#ffffff" colspan="2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td width="20%">
                                                &nbsp;</td>
                                            <td width="30%">
                                                <asp:Button ID="btnSend" runat="server" Text="确认提交" OnClick="btnSend_Click" CssClass="page_Save" />
                                                &nbsp; &nbsp;
                                                <input type="button" name="button" id="button" value="关  闭" onclick="location='userManage.aspx';"
                                                    class="page_Save" /></td>
                                            <td width="50%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
