<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcPicAds.ascx.cs" Inherits="Pbzx.Web.Contorls.UcPicAds" %>
<div runat="server"  id="dvImgAD" class="MT">
    <asp:DataList ID="dlJsADs" CellSpacing="0" runat="server" >
        <ItemTemplate>
            <%#GetAdPic(Eval("PlaceName"))%>
        </ItemTemplate>
    </asp:DataList>
</div>
