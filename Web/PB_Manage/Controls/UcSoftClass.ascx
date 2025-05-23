<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSoftClass.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcSoftClass" %>
<table width="736" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            类别名称:</td>
        <td>
            <asp:TextBox ID="txtNvarClassName" runat="server" Width="130"></asp:TextBox></td>
        <td>
        </td>
        <td>
            启用状态:
        </td>
        <td>
            <asp:RadioButtonList ID="rblBitIsElite" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">启用</asp:ListItem>
                <asp:ListItem Value="0">未启用</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            类型:</td>
        <td>
            <asp:RadioButtonList ID="rblIntSetting" runat="server" RepeatDirection="Horizontal"
                AutoPostBack="True" OnSelectedIndexChanged="rblLinkType_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">商品</asp:ListItem>
                <asp:ListItem Value="1">资源</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
