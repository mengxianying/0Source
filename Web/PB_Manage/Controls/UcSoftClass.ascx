<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSoftClass.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcSoftClass" %>
<table width="736" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            �������:</td>
        <td>
            <asp:TextBox ID="txtNvarClassName" runat="server" Width="130"></asp:TextBox></td>
        <td>
        </td>
        <td>
            ����״̬:
        </td>
        <td>
            <asp:RadioButtonList ID="rblBitIsElite" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">����</asp:ListItem>
                <asp:ListItem Value="1">����</asp:ListItem>
                <asp:ListItem Value="0">δ����</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            ����:</td>
        <td>
            <asp:RadioButtonList ID="rblIntSetting" runat="server" RepeatDirection="Horizontal"
                AutoPostBack="True" OnSelectedIndexChanged="rblLinkType_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">��Ʒ</asp:ListItem>
                <asp:ListItem Value="1">��Դ</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="��������" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" /></td>
    </tr>
</table>
