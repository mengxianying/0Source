<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcMsg_kuais.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcMsg_kuais" %>
<strong>快速查询：</strong><asp:DropDownList ID="ddlKuai" runat="server" OnSelectedIndexChanged="ddlKuai_SelectedIndexChanged" AutoPostBack="True">
    <asp:ListItem Selected="True" Value="100">快速查询</asp:ListItem>
    <asp:ListItem Value="1">本日新用户</asp:ListItem>
    <asp:ListItem Value="2">24小时内新用户</asp:ListItem>
    <asp:ListItem Value="3">二天内新用户</asp:ListItem>
    <asp:ListItem Value="4">三天内新用户</asp:ListItem>
</asp:DropDownList>