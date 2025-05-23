<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_free_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.US_free_Editor" %>

<html>
<head runat="server">
    <title>免费用户信息查看</title>
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
                                                当前位置： 免费用户信息</td>
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
                                    认证码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblHDSN" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    C盘卷标:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblDiskCVol" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSoftwareType" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    安装类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblInstallType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    第一次登录时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblFirstLoginTime" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    最近一次登录时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastLoginTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    使用次数:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUseCount" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    最后登录IP:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastLoginIP" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    服务ID:</td>
                                <td>
                                    &nbsp;<asp:Label ID="ServiceID" runat="server"></asp:Label><span class="red12"></span></td>
                                <td class="bold">
                                    最后登录ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLastLoginID" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">正常</asp:ListItem>
                                        <asp:ListItem Value="2">禁止</asp:ListItem>
                                    </asp:RadioButtonList><span class="red12"></span></td>
                                <td class="bold">
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                </td>
                                <td colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_add" runat="server" Text="提交"
                                        OnClick="btn_add_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnreset" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();" />
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
