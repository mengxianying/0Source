<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Schoolc.ascx.cs" Inherits="Pbzx.Web.Contorls.Schoolc" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">   
<HeaderTemplate>
<ul>
</HeaderTemplate>
<ItemTemplate>
<li><a href="<%# Eval("SavePath") %>"><%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength*2)%></a></li>
</ItemTemplate>
<FooterTemplate>
</ul>
</FooterTemplate>
</asp:Repeater>
