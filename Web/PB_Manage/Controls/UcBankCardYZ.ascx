<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcBankCardYZ.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcBankCardYZ" %>
<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="620" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
            &nbsp;��&nbsp;��&nbsp;����</td>
        <td>
            <asp:TextBox ID="txtUname" runat="server" Width="120"></asp:TextBox></td>
        <td>
            ��ʵ������</td>
        <td>
           <asp:TextBox ID="txtRealName" runat="server" Width="120"></asp:TextBox></td>        
        <td>
            ���п��ţ�</td>
        <td>
           <asp:TextBox ID="txtAccountNumber" runat="server" Width="150px"></asp:TextBox></td>
           
    </tr>
</table>
<table width="760" cellpadding="0" cellspacing="0" border="0">
    <tr>
      <td>&nbsp;��֤״̬��</td>
        <td >
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem>����</asp:ListItem>
                <asp:ListItem Value="0">δ��֤</asp:ListItem>
                <asp:ListItem Value="1">��֤��</asp:ListItem>
                <asp:ListItem Value="4">�Ѵ���</asp:ListItem>
                <asp:ListItem Value="2">��֤ʧ��</asp:ListItem>
                <asp:ListItem Value="3">��֤ͨ��</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            ������֤ʱ�䣺</td>
        <td align="left">
            ��&nbsp;<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
        <td align="left">
            ��&nbsp;<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
        <td>
        <asp:RadioButtonList ID="rbldate" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">������֤ʱ��</asp:ListItem>
            <asp:ListItem Selected="True">����������</asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td><asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" />&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" /></td>
    </tr>
</table>
