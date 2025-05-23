<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails2.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.UserDetails2" %>
<html>
<head runat="server">
 <title>网络用户资料查看</title>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                                                当前位置：网络用户资料查看</td>
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
                                    论坛昵称:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtBss" runat="server" ReadOnly="True"></asp:TextBox><span
                                        class="red12"></span></td>
                                <td class="bold">
                                    客户姓名:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    客户电话:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtTel" runat="server"></asp:TextBox><span style="color: #ff0000"></span></td>
                                <td class="bold">
                                    客户Email:</td>
                                <td>
                                    &nbsp;
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><span style="color: #ff0000"></span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    客户地址:</td>
                                <td>
                                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><span style="color: #ff0000"></span></td>
                                <td class="bold">
                                    客户状态:</td>
                                <td>
                                    &nbsp;<asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="0" Selected="True">许可</asp:ListItem>
                                        <asp:ListItem Value="1">禁用</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    备注信息:</td>
                                <td colspan="3">
                                    &nbsp;<asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="7" Width="520px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td>
                                    &nbsp;</td>
                                <td colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                        ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClientClick="history.back();return false;" />
                                    <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
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
