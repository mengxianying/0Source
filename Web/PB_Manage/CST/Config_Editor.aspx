<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Config_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.Config_Editor" %>

<html>
<head runat="server">
    <title>配置信息管理修改</title>
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
                                                当前位置： 配置信息管理修改</td>
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
                                    配置名称:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblName" runat="server" Text="Label" Width="200px"></asp:Label></td>
                            </tr>
                           <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    配置值:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtValue" runat="server" Rows="7" TextMode="MultiLine" Width="320px"></asp:TextBox></td>
                            </tr>
                         <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    配置详细信息:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtDetails" runat="server" Rows="7" TextMode="MultiLine" Width="320px"></asp:TextBox></td>
                            </tr>
                         <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    标志:</td>
                                <td>
                                    &nbsp;<asp:Label ID="lblFlag" runat="server" Width="100px"></asp:Label></td>
                            </tr>
                        <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态:</td>
                                <td style="height: 25px">
                                    &nbsp;<asp:Label ID="lblStatus" runat="server" Width="100px"></asp:Label></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                </td>
                                <td>
                                    &nbsp;<asp:Button ID="bt_ok" runat="server" OnClick="bt_ok_Click" Text="提交" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
