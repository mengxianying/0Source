<%@ Control Language="C#" AutoEventWireup="True" Codebehind="UcWebUser.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcWebUser" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="98%" border="0" cellspacing="0" cellpadding="1" >
    <tr>
        <td align="left">
            &nbsp;�û�����</td>
        <td align="left">
            <asp:TextBox ID="txtUserName" runat="server" Width="90px"></asp:TextBox></td>
        <td align="left">
            <asp:CheckBox ID="ckbox" runat="server" /></td>
        <td align="left">
            &nbsp;Email��</td>
        <td align="left">
            <asp:TextBox ID="txtUserEmail" runat="server" Width="90px"></asp:TextBox></td>
        <td align="left">
            &nbsp;�ֻ����룺</td>
        <td align="left">
            <asp:TextBox ID="txtUserMobile" runat="server" Width="90px"></asp:TextBox></td>
        <td align="left">
            &nbsp;����:</td>
        <td align="left">
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td align="left" style="width: 95px">
            ��<asp:TextBox ID="txtCreateTime2" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td align="left" style="width: 81px">
            &nbsp;���ڷ�ʽ��</td>
        <td align="left">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">����ʱ��</asp:ListItem>
                <asp:ListItem Value="2">����¼ʱ��</asp:ListItem>
                <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList></td>
        <td align="left">
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" />
            <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="����" />&nbsp;</td>
    </tr>
</table>
