<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcOrder.ascx.cs" Inherits="Pbzx.Web.UserCenter.Contorls.WebUserControl1" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="790" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;����״̬:</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="">ȫ��</asp:ListItem>
                <asp:ListItem Value="2">�ȴ�����</asp:ListItem>
                <asp:ListItem Value="3">�����</asp:ListItem>
                <asp:ListItem Value="4">�Ѹ���</asp:ListItem>
                <asp:ListItem Value="6">�����</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:RadioButtonList ID="rblIsCancel" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">δȡ��</asp:ListItem>
                <asp:ListItem Value="1">��ȡ��</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            ����</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            ��</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">��������</asp:ListItem>
                <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" class="input_btn2" OnClick="btnReset_Click" /></td>
    </tr>
</table>
