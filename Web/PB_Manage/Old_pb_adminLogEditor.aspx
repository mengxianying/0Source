<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Old_pb_adminLogEditor.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Old_pb_adminLogEditor" %>

<html>
<head id="Head1" runat="server">
    <title>用户日志查看</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
</head>
<body >
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
                                                当前位置：用户日志管理</td>
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
                                    用户名:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lbllog_username" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    密码:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblPWD" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    登录时间:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lbllog_time" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    IP:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lbllog_Ip" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    状态:</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lbllog_state" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    侵入场合:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lbllog_stepinto" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    调用URL:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lbllog_urlname" runat="server"></asp:Label></td>
                                <td class="bold2" style="width: 114px">
                                    用户地址:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lbllog_country" runat="server"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold2">
                                    备注信息:</td>
                                <td colspan="3">
                                    <asp:Label ID="lbllog_allhttp" runat="server" Height="218px" Width="336px"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    &nbsp;<asp:Button ID="Button3" runat="server" Text="关闭" OnClientClick="javascript:self.close();" />
                                
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
