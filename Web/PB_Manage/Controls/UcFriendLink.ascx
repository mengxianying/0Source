<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcFriendLink.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcFriendLink" %>
<table width="700" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            ��վ����:</td>
        <td>
            <asp:TextBox ID="txtSiteName" runat="server" Width="130"></asp:TextBox></td>
        <td>
        </td>
        <td>
            ���״̬:
        </td>
        <td>
            <asp:DropDownList ID="ddlPass" runat="server">
                <asp:ListItem Value="" Selected="True">����</asp:ListItem>
                <asp:ListItem Value="1">��ͨ��</asp:ListItem>
                <asp:ListItem Value="0">δͨ��</asp:ListItem>
                 <asp:ListItem Value="2">δ���</asp:ListItem>
            </asp:DropDownList>
        </td>
             <td>
           �Ƽ�:
        </td>
        <td>
            <asp:DropDownList ID="ddlIsGood" runat="server">
                <asp:ListItem Value="" Selected="True">����</asp:ListItem>
                <asp:ListItem Value="1">���Ƽ�</asp:ListItem>
                <asp:ListItem Value="0">���Ƽ�</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            ��������:</td>
        <td>
            <asp:DropDownList ID="ddlLinkType" runat="server">
                <asp:ListItem Value="" Selected="True">����</asp:ListItem>
                <asp:ListItem Value="1">��������</asp:ListItem>
                <asp:ListItem Value="0">ͼƬ����</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="��������" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" /></td>
    </tr>
</table>
