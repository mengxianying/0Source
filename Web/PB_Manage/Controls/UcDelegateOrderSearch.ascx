<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcDelegateOrderSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcDelegateOrderSearch" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="750" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="right" style="width: 60px">
            &nbsp;��&nbsp;̳&nbsp;��:</td>
        <td align="left" style="width: 125px">
            <asp:TextBox ID="txtBbsName" runat="server" Width="120px"></asp:TextBox></td>
        <td align="right" style="width: 60px">
            �ͻ���:
        </td>
        <td align="left" style="width: 125px">
            <asp:TextBox ID="txtUsername" runat="server" Width="120px"></asp:TextBox></td>
        <td align="right" style="width: 60px">
            ������:</td>
        <td align="left" style="width: 125px">
            <asp:TextBox ID="txtOrderID" runat="server" Width="120px"></asp:TextBox></td>
        <td align="left">
            &nbsp;&nbsp;
            <asp:CheckBox ID="chbError" runat="server" Text="���ִ���ʧ��" Checked="false" /></td>
    </tr>
</table>
<table width="750" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="right" style="width: 50px">
            ����:
        </td>
        <td style="width: 160px" align="left">
            <asp:RadioButtonList ID="rblOrderType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1" Selected="True">ȫ��</asp:ListItem>
                <asp:ListItem Value="1">�˹�</asp:ListItem>
                <asp:ListItem Value="0">�Զ�</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="right" style="width: 50px">
            ȡ��:
        </td>
        <td align="left" style="width: 180px">
            <asp:RadioButtonList ID="rblIsCancal" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1">ȫ��</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">δȡ��</asp:ListItem>
                <asp:ListItem Value="1">��ȡ��</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="right" style="width: 50px">
            ����</td>
        <td align="left">
            <asp:RadioButtonList ID="rblIsPay" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem  Selected="True"  Value="">ȫ��</asp:ListItem>
                <asp:ListItem Value="1">�ȴ�����</asp:ListItem>
                <asp:ListItem Value="3">�Ѵ���</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
</table>
<table width="750" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 60px">
            ���ʽ:</td>
        <td style="width: 80px">
            <asp:DropDownList ID="ddlPayType" runat="server">
            </asp:DropDownList>
        </td>
        <td align="right" style="width: 85px">
            ����״̬:</td>
        <td style="width: 380px" align="left">
            <asp:RadioButtonList ID="rblOrderState" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="" Selected="True">ȫ��</asp:ListItem>
                <asp:ListItem Value="2">�ȴ�����</asp:ListItem>
                <asp:ListItem Value="3">�����</asp:ListItem>
                <asp:ListItem Value="4">�Ѹ���</asp:ListItem>
                <asp:ListItem Value="6">�����</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table width="680" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            &nbsp;���ڶ�:��</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td>
            ��
            <asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td>
            ���ڷ�ʽ:</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">�µ�����</asp:ListItem>
                <asp:ListItem Value="2">��������</asp:ListItem>
                <asp:ListItem Value="" Selected="True">����������</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" />
            &nbsp;
            <asp:Button ID="btnClear" runat="server" Text="����" OnClick="btnClear_Click" />
        </td>
    </tr>
</table>
