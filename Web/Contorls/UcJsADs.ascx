<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcJsADs.ascx.cs" Inherits="Pbzx.Web.Contorls.UcJsADs" %>
<div>
    <asp:DataList ID="dlJsADs" runat="server">
        <ItemTemplate>
            <%#Eval("pb_SiteIntro") %>
        </ItemTemplate>
    </asp:DataList>
</div>
