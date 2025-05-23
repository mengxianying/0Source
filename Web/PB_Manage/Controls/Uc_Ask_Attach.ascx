<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_Ask_Attach.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.Uc_Ask_Attach" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="370" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;用户名:</td>
        <td>
            <asp:TextBox ID="txtBrokerName" runat="server" Width="90"></asp:TextBox></td>
        <td>
            文件地址:</td>
        <td>
            <asp:TextBox ID="txtCustomerName" runat="server" Width="150"></asp:TextBox></td>
     
    </tr>
</table>
<table width="685" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
         &nbsp;日期段:</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
           &nbsp; &nbsp;至&nbsp;&nbsp;</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式:</td>
        <td colspan="2">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">登录时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
