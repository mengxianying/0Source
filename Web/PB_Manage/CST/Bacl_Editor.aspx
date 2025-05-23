<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bacl_Editor.aspx.cs" Inherits="Pbzx.Web.PB_Manage.CST.Bacl_Editor" %>

<html>
<head runat="server">
    <title>黑名单信息添加修改</title>
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
                                                当前位置： 黑名单信息添加修改</td>
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
                                    黑名单内容:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtValue" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    内容标志:</td>
                                <td>
                                 <asp:RadioButtonList ID="rdlFlag" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">原始认证码</asp:ListItem>
                                        <asp:ListItem Value="2">认证码</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="3">用户名</asp:ListItem>
                                        <asp:ListItem Value="4">IP地址</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    创建时间:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtTime" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    详细信息:</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtDetails" runat="server" Rows="7" TextMode="MultiLine" Width="320px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    状态:</td>
                                <td style="height: 25px">
                                   <asp:RadioButtonList ID="rdlStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">启用</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">解除</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                </td>
                                <td style="height: 30px">
                                    &nbsp;<asp:Button ID="bt_ok" runat="server" OnClick="bt_ok_Click" Text="提交" />
                                   <input type="button" value="关闭" onclick="window.opener=null;window.open('','_self');window.close();" />
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
