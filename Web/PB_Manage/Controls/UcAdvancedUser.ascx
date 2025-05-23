<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAdvancedUser.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcAdvancedUser" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="1000" border="0" cellspacing="0" cellpadding="1">
    <tr align="left">
        <td align="left">
            &nbsp;�û���:
        </td>
        <td align="left">
            <asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td align="left">
            &nbsp;��ʵ����:
        </td>
        <td align="left">
            <asp:TextBox ID="txtRealName" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td align="left">
            &nbsp;Email��
        </td>
        <td align="left">
            <asp:TextBox ID="txtUserEmail" runat="server" Width="120px"></asp:TextBox></td>
        <td align="left">
            &nbsp;������:
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlBankName" runat="server">
            </asp:DropDownList>
        </td>
        <td align="left">
            &nbsp;���п��ţ�
        </td>
        <td align="left">
            <asp:TextBox ID="txtAccountNumber" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
</table>
<table width="800" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">��ͨ�û�</asp:ListItem>
                <asp:ListItem Value="1">�߼��û�</asp:ListItem>
                <asp:ListItem Selected="True" Value="">ȫ��</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            ����:</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td>
            ��<asp:TextBox ID="txtCreateTime2" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td>
            ���ڷ�ʽ��</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">����ʱ��</asp:ListItem>
                <asp:ListItem Value="2">�����ʱ��</asp:ListItem>
                <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
        </td>
    </tr>
</table>
<table width="800" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            <asp:RadioButtonList ID="rblMoney" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">�����</asp:ListItem>
                <asp:ListItem Value="1">�ж�����</asp:ListItem>
                <asp:ListItem Selected="True">ȫ��</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" />
            &nbsp;<asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="����" />
        </td>
    </tr>
</table>
