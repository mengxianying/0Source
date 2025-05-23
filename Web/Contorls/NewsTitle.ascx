<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewsTitle.ascx.cs" Inherits="Pbzx.Web.css.NewsTitle" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
       <li><span class="dianse">¡¤</span><a href='<%# Eval("SavePath") %>' target="_blank"><%# StrFormat.CutStringByNum(Eval("NvarTitle"),this.TitleLength*2) %></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
