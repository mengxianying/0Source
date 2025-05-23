<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcLog_kuais.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcLog_kuais" %>
<strong>快速查询：</strong><asp:DropDownList ID="ddlKuai" runat="server" OnSelectedIndexChanged="ddlKuai_SelectedIndexChanged" AutoPostBack="True">
    <asp:ListItem Selected="True" Value="100">快速查询</asp:ListItem>
    <asp:ListItem Value="1">在线超过1小时</asp:ListItem>
    <asp:ListItem Value="2">在线超过3小时</asp:ListItem>
    <asp:ListItem Value="3">在线超过6小时</asp:ListItem>
    <asp:ListItem Value="4">在线超过12小时</asp:ListItem>
    <asp:ListItem Value="5">在线超过1天</asp:ListItem>
    <asp:ListItem Value="6">在线超过2天</asp:ListItem>
    <asp:ListItem Value="7">在线超过3天</asp:ListItem>
    <asp:ListItem Value="8">收费</asp:ListItem>
    <asp:ListItem Value="9">发帖用户</asp:ListItem>
    <asp:ListItem Value="10">贵宾</asp:ListItem>
    <asp:ListItem Value="11">免费</asp:ListItem>
    <asp:ListItem Value="12">管理</asp:ListItem>
    <asp:ListItem Value="13">试用</asp:ListItem>
    <asp:ListItem Value="14">单机</asp:ListItem>
    <asp:ListItem Value="15">软件狗</asp:ListItem>
</asp:DropDownList>
