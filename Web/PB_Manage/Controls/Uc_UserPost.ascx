<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_UserPost.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.Uc_UserPost" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="600" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td style="height: 26px">
            ��������:</td>
        <td colspan="2" style="height: 26px">
            <asp:TextBox ID="txtParentID" runat="server" Width="120px"></asp:TextBox></td>
        <td style="height: 26px">
        </td>
        <td style="height: 26px">
            ����ID:</td>
        <td style="height: 26px">
            <asp:TextBox ID="txtAnnounceID" runat="server" Width="120px"></asp:TextBox></td>
        <td style="height: 26px">
            ����:</td>
        <td style="height: 26px">
            &nbsp;<asp:DropDownList ID="ddlBoard" runat="server">
            </asp:DropDownList></td>
        <td colspan="4" style="height: 26px">
        </td>
    </tr>
</table>
<table width="740" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;�û�����</td>
        <td colspan="2">
            &nbsp;<asp:TextBox ID="txtUserName" runat="server" Width="120px"></asp:TextBox></td>
        <td colspan="1">
            ��
        </td>
        <td>
            &nbsp;<asp:TextBox ID="txtPostTable" runat="server" Width="120px"></asp:TextBox></td>
        <td>
            �Ƿ񾫻�:</td>
        <td>
            <asp:DropDownList ID="ddlisbest" runat="server">
                <asp:ListItem Value="">����</asp:ListItem>
                <asp:ListItem Value="1">����</asp:ListItem>
                <asp:ListItem Value="0">��ͨ</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            ״̬
        </td>
        <td>
            <asp:DropDownList ID="ddllocktopic" runat="server">
                <asp:ListItem Value="">����</asp:ListItem>
                <asp:ListItem Value="0">����</asp:ListItem>
                <asp:ListItem Value="1">����</asp:ListItem>
                <asp:ListItem Value="50">ɾ��</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="��������" />&nbsp;<asp:Button
                ID="btn_cancel" runat="server" OnClick="btnReset_Click" Text="����" /></td>
    </tr>
</table>
