<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SoftClass.ascx.cs" Inherits="Pbzx.Web.Contorls.SoftClass" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%">
<HeaderTemplate></HeaderTemplate>
<ItemTemplate> 
<b>¡¤</b><a href ="/"> <%#StrFormat.CutStringByNum(Eval("NvarClassName"), this.TitleLength*2, " ")%></a>
</ItemTemplate>
<FooterTemplate></FooterTemplate>
</asp:DataList>
