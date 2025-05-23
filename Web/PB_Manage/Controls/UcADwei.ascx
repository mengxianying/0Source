<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcADwei.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcADwei" %>
<table width="100%" border="0" cellspacing="0" cellpadding="2">
    <tr>
        <td>
            所属频道:</td>
        <td>
            <asp:DropDownList ID="ddlChannel" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            广告类型:</td>
        <td>
            <asp:DropDownList ID="ddlADType" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
            </asp:DropDownList>&nbsp;</td>
        <td>
            广告位类别:</td>
        <td>
            <asp:DropDownList ID="ddlPlaceType" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
            </asp:DropDownList>&nbsp;</td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
