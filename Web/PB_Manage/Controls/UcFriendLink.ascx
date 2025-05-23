<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcFriendLink.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcFriendLink" %>
<table width="700" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            网站名称:</td>
        <td>
            <asp:TextBox ID="txtSiteName" runat="server" Width="130"></asp:TextBox></td>
        <td>
        </td>
        <td>
            审核状态:
        </td>
        <td>
            <asp:DropDownList ID="ddlPass" runat="server">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">已通过</asp:ListItem>
                <asp:ListItem Value="0">未通过</asp:ListItem>
                 <asp:ListItem Value="2">未审核</asp:ListItem>
            </asp:DropDownList>
        </td>
             <td>
           推荐:
        </td>
        <td>
            <asp:DropDownList ID="ddlIsGood" runat="server">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">已推荐</asp:ListItem>
                <asp:ListItem Value="0">不推荐</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            链接类型:</td>
        <td>
            <asp:DropDownList ID="ddlLinkType" runat="server">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">文字链接</asp:ListItem>
                <asp:ListItem Value="0">图片链接</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
