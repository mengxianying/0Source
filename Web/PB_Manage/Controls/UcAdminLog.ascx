<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAdminLog.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcAdminLog" %>

<script src="../javascript/calendar.js" type="text/javascript"></script>

<table width="770" border="0" cellspacing="0" cellpadding="1">
    <tr>      
        <td>
            ������:
        </td>
        <td>
            <asp:TextBox ID="txtOperator" runat="server" Width="90px"></asp:TextBox>
        </td>
        <td>
            ������IP:
        </td>
        <td>
            <asp:TextBox ID="txtUserIP" runat="server" Width="140px"></asp:TextBox>
        </td>
        <td>
            ����:
        </td>
        <td>
            <asp:DropDownList ID="ddlActionType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlActionType_SelectedIndexChanged"
                Width="154px">
                <asp:ListItem Selected="True">����</asp:ListItem>
                <asp:ListItem>��̨��¼</asp:ListItem>
                <asp:ListItem>����</asp:ListItem>
                <asp:ListItem>�޸�</asp:ListItem>
                <asp:ListItem>ɾ��</asp:ListItem>
            </asp:DropDownList>
        </td>
          <td>
              ��������ؼ���:
        </td>
        <td>
            <asp:TextBox ID="txtKey" runat="server" Width="90px"></asp:TextBox>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            ����:</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="65" onfocus="calendar();"></asp:TextBox></td>
        <td>
            ��<asp:TextBox ID="txtCreateTime2" runat="server" Width="65" onfocus="calendar();"></asp:TextBox></td>
        <td>
            ���ڷ�ʽ��</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">����ʱ��</asp:ListItem>
                <asp:ListItem Value="2">����¼ʱ��</asp:ListItem>
                <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" />
            &nbsp;<asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="����" /></td>
    </tr>
</table>
