<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcLog_kuais.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcLog_kuais" %>
<strong>���ٲ�ѯ��</strong><asp:DropDownList ID="ddlKuai" runat="server" OnSelectedIndexChanged="ddlKuai_SelectedIndexChanged" AutoPostBack="True">
    <asp:ListItem Selected="True" Value="100">���ٲ�ѯ</asp:ListItem>
    <asp:ListItem Value="1">���߳���1Сʱ</asp:ListItem>
    <asp:ListItem Value="2">���߳���3Сʱ</asp:ListItem>
    <asp:ListItem Value="3">���߳���6Сʱ</asp:ListItem>
    <asp:ListItem Value="4">���߳���12Сʱ</asp:ListItem>
    <asp:ListItem Value="5">���߳���1��</asp:ListItem>
    <asp:ListItem Value="6">���߳���2��</asp:ListItem>
    <asp:ListItem Value="7">���߳���3��</asp:ListItem>
    <asp:ListItem Value="8">�շ�</asp:ListItem>
    <asp:ListItem Value="9">�����û�</asp:ListItem>
    <asp:ListItem Value="10">���</asp:ListItem>
    <asp:ListItem Value="11">���</asp:ListItem>
    <asp:ListItem Value="12">����</asp:ListItem>
    <asp:ListItem Value="13">����</asp:ListItem>
    <asp:ListItem Value="14">����</asp:ListItem>
    <asp:ListItem Value="15">�����</asp:ListItem>
</asp:DropDownList>
