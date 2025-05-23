<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Bulletin_r.ascx.cs"
    Inherits="Pbzx.Web.Contorls.Bulletin_r" %>
<%@ Import Namespace="Pbzx.Common" %>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
        ·<a href="<%# Eval("SavePath") %>" target="_blank" class="<%=ClassCss%>"><%# GetTitleByCount(Eval("NvarTitle"), Eval("NvarShortTitle"))%></a><br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
