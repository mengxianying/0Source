<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcBroker_Trade.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcBroker_Trade" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="560" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;经纪人用户名:</td>
        <td>
            <asp:TextBox ID="txtBrokerName" runat="server" Width="90"></asp:TextBox></td>
        <td>
            客户用户名:</td>
        <td>
            <asp:TextBox ID="txtCustomerName" runat="server" Width="90"></asp:TextBox></td>
        <td>
            订单号:</td>
        <td>
            <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox>
        </td>
     <%--   <td>
            折扣:</td>
        <td>
            <asp:DropDownList ID="ddlrate" runat="server">
            </asp:DropDownList></td>--%>
    </tr>
</table>
<table width="670" border="0" cellspacing="0" cellpadding="0">
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
                <asp:ListItem Value="1">创建时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
