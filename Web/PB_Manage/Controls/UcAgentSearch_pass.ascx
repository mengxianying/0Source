<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcAgentSearch_pass.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcAgentSearch_pass" %>
<table width="750" cellpadding="2" cellspacing="0" border="0">
    <tr>
    <td>
            &nbsp;�û���:</td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server" Width="80"></asp:TextBox></td>
        <td>
          ����:</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="80"></asp:TextBox></td>
        <td>
            ״̬:
        </td>
        <td>
            <asp:RadioButtonList ID="ddlSate" runat="server" RepeatDirection="Horizontal" Width="180px">
                <asp:ListItem Selected="True">����</asp:ListItem>
                <asp:ListItem Value="1">���</asp:ListItem>
                <asp:ListItem Value="0">��ֹ</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            ����ʡ��:
        </td>
        <td>
            <asp:DropDownList ID="ddlProvince" runat="server" Width="100px">
                <asp:ListItem>����</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnO" runat="server" Text="����" OnClick="btnO_Click" />
        </td>
        <td>
            <asp:Button ID="btnReset" runat="server" Text="����" OnClick="btnReset_Click" />
        </td>
    </tr>
</table>