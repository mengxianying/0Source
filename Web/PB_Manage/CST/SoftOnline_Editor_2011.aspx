<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoftOnline_Editor_2011.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.SoftOnline_Editor_2011" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>软件上线管理-详细</title>
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
                                                当前位置：软件上线管理</td>
                                            <td width="9%" class="bold2">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="2" cellspacing="1" width="100%" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    认证码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblHDSN" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    状态:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    注册码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblRN" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    注册方式:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblRegType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    软件类型:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblSoftwareType" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    安装类型:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblInstallType" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    软件版本号:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblTVersion" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    过期日期:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblExpireDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    操作系统版本:</td>
                                <td colspan="3">
                                    &nbsp;<asp:Label ID="lblOSVersion" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    第一次登录时间:</td>
                                <td colspan="3">
                                    <asp:Label ID="lblFirstLoginTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    登录时间:</td>
                                <td colspan="3">
                                    <asp:Label ID="lblLoginTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    登录IP:</td>
                                <td colspan="3">
                                    <asp:Label ID="lblIP" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    当日登陆次数:</td>
                                <td colspan="3">
                                    <asp:Label ID="lblLoginCount" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    总登陆次数:</td>
                                <td colspan="3">
                                    <asp:Label ID="lblTotalCount" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    最近消息时间:</td>
                                <td colspan="3">
                                    <asp:Label ID="lblAginTime" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    &nbsp;<asp:Button ID="Button3" runat="server" Text="关闭" OnClientClick="window.opener=null;window.open('','_self');window.close();" OnClick="btn_OK_Click" />       
                                                                 
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

