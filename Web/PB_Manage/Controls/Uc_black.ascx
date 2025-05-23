<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_black.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.Uc_black" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="680" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;黑名单信息:</td>
        <td>
            <asp:TextBox ID="txtValue" runat="server" Width="110"></asp:TextBox></td>
        <td>
            内容标志:</td>
        <td>
            <asp:DropDownList ID="ddlFlag" runat="server">
                <asp:ListItem Value="">全部</asp:ListItem>
                <asp:ListItem Value="1">原始认证码</asp:ListItem>
                <asp:ListItem Value="2">认证码</asp:ListItem>
                <asp:ListItem Value="3">用户名</asp:ListItem>
                <asp:ListItem Value="4">IP地址</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            详细信息:</td>
        <td>
            <asp:TextBox ID="txtDetails" runat="server" Width="220"></asp:TextBox></td>
    </tr>
</table>
<table width="740" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;状态：</td>
        <td>
            <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="1">启用</asp:ListItem>
                <asp:ListItem Value="0">禁用</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至<asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式：</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">创建时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;&nbsp;&nbsp;<asp:Button
                ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="重置" /></td>
    </tr>
</table>
