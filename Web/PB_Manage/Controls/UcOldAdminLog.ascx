<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcOldAdminLog.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcOldAdminLog" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table border="0" cellspacing="0" cellpadding="1" style="width: 828px">
    <tr>
        <td>
            �û���:</td>
        <td>
            <asp:TextBox ID="txtlog_username" runat="server" Width="80px"></asp:TextBox></td>
        <td>
            IP��ַ:</td>
        <td>
            <asp:TextBox ID="txtlog_Ip" runat="server" Width="123px"></asp:TextBox></td>
        <td>
            ״̬:</td>
        <td>
            <asp:TextBox ID="txtlog_state" runat="server" Width="100"></asp:TextBox></td>
        <td>
            ���볡��:</td>
        <td>
            <asp:TextBox ID="txtlog_stepinto" runat="server" Width="100"></asp:TextBox></td>
        <td>
            ����/ע�����:</td>
        <td style="width: 103px">
            <asp:TextBox ID="txtlog_password" runat="server" Width="100"></asp:TextBox></td>
    </tr>
</table>
<table width="763" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
         ����URL:
        </td>
        <td>
            <asp:TextBox ID="txtlog_urlname" runat="server" Width="100"></asp:TextBox>
        </td>
        <td>
            ���ڶ�:��</td>
        <td style="width: 91px">
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            ��&nbsp;&nbsp;</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            ���ڷ�ʽ:</td>
        <td colspan="2">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">��¼ʱ��</asp:ListItem>
                <asp:ListItem Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="��������" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" /></td>
    </tr>
</table>
