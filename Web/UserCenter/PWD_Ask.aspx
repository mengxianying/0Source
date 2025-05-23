<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PWD_Ask.aspx.cs" Inherits="Pbzx.Web.UserCenter.PWD_Ask" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录密码保护</title>
    <link href="../css/user_center.css" rel="stylesheet" type="text/css" />
    
        <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
            <asp:Panel ID="pnlYanZ" runat="server">
            <table width="800" border="0" align="center" cellpadding="0" cellspacing="0" class="uc_MT10">
                    <tr>
                        <td width="5" bgcolor="#FF7300">
                        </td>
                        <td width="800" height="28" bgcolor="#DCEDFC" class="uc_font_black">
                            &nbsp;<%=lblText%>登录密码保护
                        </td>
                    </tr>
                </table>
                <table width="800" border="0" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD" align="center">
<%--                    <tr>
                        <td width="200" align="right" bgcolor="#F6F6F6">
                            原密码保护问题：</td>
                        <td width="605" align="left" bgcolor="#FFFFFF">
                            &nbsp;<asp:Label ID="lblMBWT" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="200" align="right" bgcolor="#F6F6F6">
                            请输入原密码保护答案：</td>
                        <td width="605" align="left" bgcolor="#FFFFFF">
                            <asp:TextBox ID="txtMBDA" runat="server" MaxLength="20" Width="180px"></asp:TextBox>
                            <span
                                        class="uc_font_gray">请输入您的原密保答案</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="right" bgcolor="#F6F6F6" width="200">
                            请输入登录密码：</td>
                        <td align="left" bgcolor="#FFFFFF" width="605">
                            <asp:TextBox ID="tb_logionPassword" runat="server" MaxLength="20" Width="180px" 
                                TextMode="Password"></asp:TextBox>
                            输入您的登录密码，点击下一步继续。</td>
                    </tr>
                    <tr>
                        <td colspan="2" bgcolor="#FFFFFF" align="center">
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td width="25%">
                                        &nbsp;</td>
                                    <td width="25%">
                                        <asp:Button ID="btnYZ" runat="server" OnClick="btnYZ_Click" Text="下一步" CssClass="page_Save"/>
                                        &nbsp;
                                    </td>
                                    <td width="50%">
                                        &nbsp;</td>
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
                            &nbsp;<%=lblText%>登录密码保护</td>
                    </tr>
                </table>
                <table width="800" border="0" cellpadding="4" cellspacing="1" bgcolor="#DDDDDD" align="center">
                    <tr>
                        <td width="200" align="right" bgcolor="#F6F6F6">
                            请选择新密码保护问题：</td>
                        <td width="605" align="left" bgcolor="#FFFFFF">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlPassWordQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPassWordQuestion_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtWordQuestion" runat="server" Visible="false" MaxLength="100"></asp:TextBox><span
                                        class="uc_font_gray">请选择您常用的密码答案，以便您在忘记密码后根据问题取回密码</span>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right" bgcolor="#F6F6F6">
                            请输入新密码保护答案：</td>
                        <td width="605" align="left" bgcolor="#FFFFFF">
                            <asp:TextBox ID="txtPassWordAnswer" runat="server" ValidationGroup="baseinfo" Width="157px"
                                MaxLength="100"></asp:TextBox><span
                                        class="uc_font_gray">请输入您的密码答案</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" bgcolor="#FFFFFF" align="center">
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td width="25%">
                                        &nbsp;</td>
                                    <td width="25%">
                                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="保存" CssClass="page_SaveS" />&nbsp;&nbsp;
                                        <input type="button" name="button" id="button" value="取消" onclick="location='userManage.aspx';"
                                            class="page_SaveS" /></td>
                                    <td width="50%">
                                        &nbsp;</td>
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
