<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewsOneTitleByType.ascx.cs"
    Inherits="Pbzx.Web.Contorls.NewsOneTitleByType" %>
<%@ Import Namespace="Pbzx.Common" %>
<div style="width: 95%; vertical-align: top; padding-left: 5px; margin-top: 2px;">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <span class="dianse">¡¤</span><a href='<%# Eval("SavePath") %>' target="_blank"
                class="school"><%# GetTitleByCount(Eval("NvarTitle"), Eval("NvarShortTitle"))%></a><br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</div>
