<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="soft_verf.ascx.cs" Inherits="Pbzx.Web.Contorls.soft_verf" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%">
<HeaderTemplate></HeaderTemplate>
<ItemTemplate> 
  <img src="../Images/Web/soft_li1.jpg" border="0" hspace="3" /><a href ='Soft.aspx?TypeID=<%#Input.Encrypt(Eval("VersionTypeName").ToString())%>&vef=vef'><%# Eval("VersionTypeName")%>
</ItemTemplate>
<FooterTemplate></FooterTemplate>
</asp:DataList>