<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAsk_Reply.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcAsk_Reply" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="550" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;回复者:</td>
        <td>
            <asp:TextBox ID="txtReplyer" runat="server" Width="90"></asp:TextBox></td>
        <td>
            内容包含关键字:</td>
        <td>
            <asp:TextBox ID="txtContent" runat="server" Width="180"></asp:TextBox></td>
        <%--<td>
         是否最佳:</td>
        <td>
         <asp:DropDownList ID="ddlIsBest" runat="server">
                <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">是最佳</asp:ListItem>
                <asp:ListItem Value="1">不最佳</asp:ListItem>
            </asp:DropDownList></td>--%>
    </tr>
</table>
<table width="650" border="0" cellspacing="0" cellpadding="1">
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
                <asp:ListItem Value="1">回复时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
