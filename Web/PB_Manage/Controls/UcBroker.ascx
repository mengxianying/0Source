<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcBroker.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcBroker" %>
<script src="../../javascript/calendar.js" type="text/javascript"></script>
<table width="620" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;经纪人用户名:</td>
        <td>
            <asp:TextBox ID="txtBrokerName" runat="server" Width="150"></asp:TextBox></td>
        <td>
            经纪人等级昵称:</td>
        <td>
            <asp:DropDownList ID="ddlgrade" runat="server">
            </asp:DropDownList></td>
        <td>
            折扣:</td>
        <td>
            <asp:DropDownList ID="ddlrate" runat="server">
            </asp:DropDownList></td>
        <td>
            状态:</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem>所有</asp:ListItem>
                <asp:ListItem Value="0">未审核</asp:ListItem>
                <asp:ListItem Value="1">正常</asp:ListItem>
                <asp:ListItem Value="2">锁定</asp:ListItem>
                <asp:ListItem Value="3">未通过</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>
<table width="720" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;日&nbsp;期&nbsp;段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至&nbsp;&nbsp;</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式:</td>
        <td colspan="2">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">登录时间</asp:ListItem>
                 <asp:ListItem Value="1">审核时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
