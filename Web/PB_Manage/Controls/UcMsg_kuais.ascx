<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMsg_kuais.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcMsg_kuais" %>
<strong>���ٲ�ѯ��</strong><asp:DropDownList ID="ddlKuai" runat="server" OnSelectedIndexChanged="ddlKuai_SelectedIndexChanged" AutoPostBack="True">
    <asp:ListItem Selected="True" Value="100">���ٲ�ѯ</asp:ListItem>
    <asp:ListItem Value="1">�������û�</asp:ListItem>
    <asp:ListItem Value="2">24Сʱ�����û�</asp:ListItem>
    <asp:ListItem Value="3">���������û�</asp:ListItem>
    <asp:ListItem Value="4">���������û�</asp:ListItem>
</asp:DropDownList>