<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Ucadmin_Ly.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.Ucadmin_Ly" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="580" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp; 用户名:</td>
        <td>
            <asp:TextBox ID="txtLy_Email" runat="server" Width="80px"></asp:TextBox></td>
        <td>
            关键字:</td>
        <td>
            <asp:TextBox ID="txtLyContent" runat="server" Width="110px"></asp:TextBox></td>
        <td>
            类型:
        </td>
        <td>
            <asp:DropDownList ID="ddlSort" runat="server">
            </asp:DropDownList></td>
        <td>
            状态:
        </td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="" >全部</asp:ListItem>
                <asp:ListItem Value="0">未回复</asp:ListItem>
                <asp:ListItem Value="1">已回复</asp:ListItem>
            </asp:DropDownList>&nbsp;</td>
    </tr>
</table>
<table width="610" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td colspan="2">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">留言时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无时间限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btReset" runat="server" Text="重置" OnClick="btReset_Click" /></td>
    </tr>
</table>
