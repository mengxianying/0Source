<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcOrder.ascx.cs" Inherits="Pbzx.Web.UserCenter.Contorls.WebUserControl1" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="790" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;订单状态:</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="">全部</asp:ListItem>
                <asp:ListItem Value="2">等待付款</asp:ListItem>
                <asp:ListItem Value="3">货款不足</asp:ListItem>
                <asp:ListItem Value="4">已付款</asp:ListItem>
                <asp:ListItem Value="6">已完成</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:RadioButtonList ID="rblIsCancel" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1">全部</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">未取消</asp:ListItem>
                <asp:ListItem Value="1">已取消</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            日期</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">创建日期</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" class="input_btn2" OnClick="btnReset_Click" /></td>
    </tr>
</table>
