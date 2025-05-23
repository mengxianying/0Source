<%@ Page Language="C#" AutoEventWireup="true" Codebehind="US_online_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.US_online_Editor" %>

<html>
<head runat="server">
    <title>在线用户信息查看</title>
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
                                                当前位置：在线用户信息查看</td>
                                            <td width="9%" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 24px">
                                    用户名:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblUsername" runat="server"></asp:Label></td>
                                <td class="bold" style="height: 24px">
                                    程序版本号:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblProgramVer" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    注册码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblRN" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户认证码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblHDSN" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    软件类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblSoftwaretype" runat="server"></asp:Label></td>
                                <td class="bold">
                                    安装类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblInstallType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 24px">
                                    用户IP:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblIP" runat="server"></asp:Label></td>
                                <td class="bold" style="height: 24px">
                                    用户端口号:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblPort" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" style="height: 24px">
                                    登录时间:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblStartTime" runat="server"></asp:Label></td>
                                <td class="bold" style="height: 24px">
                                    退出时间:</td>
                                <td style="height: 24px">
                                    &nbsp;<asp:Label ID="lblEndTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    用户互斥量:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblLoginMutex" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户状态:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    服务ID号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblServiceID" runat="server"></asp:Label></td>
                                <td class="bold">
                                    用户索引:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUserIndex" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    使用类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUseType" runat="server"></asp:Label></td>
                                <td class="bold">
                                    使用值:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblUseValue" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    <asp:Button ID="Button3" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();" />
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
