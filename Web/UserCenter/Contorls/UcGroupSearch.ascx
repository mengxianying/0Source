<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcGroupSearch.ascx.cs"
    Inherits="Pbzx.Web.UserCenter.Contorls.UcGroupSearch" %>
<table width="740" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;QQȺ��:</td>
        <td>
            <asp:TextBox ID="txtQQ_GroupID" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td align="right">
            QQȺ����:</td>
        <td align="left">
            <asp:TextBox ID="txtQQ_GroupName" runat="server" Width="100px"></asp:TextBox></td>
        <td  align="right">
            Ⱥ��Ʊ����:</td>
        <td align="left">
            <asp:RadioButtonList ID="rblQQ_GroupType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="">����</asp:ListItem>
                <asp:ListItem Value="0">����Ⱥ</asp:ListItem>
                <asp:ListItem Value="1">���Ⱥ</asp:ListItem>
                <asp:ListItem Value="2">˫��Ⱥ</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="����" OnClick="btnOK_Click" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="����" class="input_btn2" OnClick="btnReset_Click" /></td>
    </tr>
</table>
