<%@ Control Language="C#" AutoEventWireup="True" Codebehind="UcWebUser.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcWebUser" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="98%" border="0" cellspacing="0" cellpadding="1" >
    <tr>
        <td align="left">
            &nbsp;用户名：</td>
        <td align="left">
            <asp:TextBox ID="txtUserName" runat="server" Width="90px"></asp:TextBox></td>
        <td align="left">
            <asp:CheckBox ID="ckbox" runat="server" /></td>
        <td align="left">
            &nbsp;Email：</td>
        <td align="left">
            <asp:TextBox ID="txtUserEmail" runat="server" Width="90px"></asp:TextBox></td>
        <td align="left">
            &nbsp;手机号码：</td>
        <td align="left">
            <asp:TextBox ID="txtUserMobile" runat="server" Width="90px"></asp:TextBox></td>
        <td align="left">
            &nbsp;日期:</td>
        <td align="left">
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td align="left" style="width: 95px">
            至<asp:TextBox ID="txtCreateTime2" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td align="left" style="width: 81px">
            &nbsp;日期方式：</td>
        <td align="left">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">申请时间</asp:ListItem>
                <asp:ListItem Value="2">最后登录时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td align="left">
            <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" />
            <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="重置" />&nbsp;</td>
    </tr>
</table>
