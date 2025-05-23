<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcLottery.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcLottery" %>
<table align="left" cellpadding="1" cellspacing="0" border="0" width="770">
    <tr>
        <td>
            &nbsp;彩种名称:</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="110px"></asp:TextBox></td>
        <td align="right">
            类别:</td>
        <td>
            <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                AutoPostBack="True">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem>全国福彩</asp:ListItem>
                <asp:ListItem>全国体彩</asp:ListItem>
                <asp:ListItem>各省福彩</asp:ListItem>
                <asp:ListItem>各省体彩</asp:ListItem>
                <asp:ListItem>高频福彩</asp:ListItem>
                <asp:ListItem>高频体彩</asp:ListItem>
            </asp:DropDownList></td>
        <td align="right">
            是否显示:</td>
        <td align="left">
            <asp:RadioButtonList ID="rblIsShow" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="" Selected="True">不限</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            是否启用:
        </td>
        <td align="left">
            <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="" Selected="True">不限</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="搜索" OnClick="btnOK_Click" />&nbsp;<asp:Button ID="btnCanl" runat="server" Text="重置" OnClick="btnCanl_Click" />
        </td>
    </tr>
</table>
