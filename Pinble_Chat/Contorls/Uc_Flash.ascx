<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_Flash.ascx.cs" Inherits="Pbzx.Web.Contorls.Uc_Flash" %>
<div runat="server" id="dvImgAD">
    <asp:DataList ID="dlJsADs" CellSpacing="0" runat="server">
        <ItemTemplate>
            <%#GetAdPic(Eval("PlaceName"))%>
        </ItemTemplate>
    </asp:DataList>
</div>
