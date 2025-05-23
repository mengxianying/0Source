<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcAsk_User.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcAsk_User" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="320" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;用户名:</td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server" Width="130"></asp:TextBox></td>
        <td>
            状态:</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="0">正常</asp:ListItem>
                <asp:ListItem Value="1">锁定</asp:ListItem>
            </asp:DropDownList></td> 
    </tr>
</table>
<table width="700" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至&nbsp;&nbsp;</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式:</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">开通时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>