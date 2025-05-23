<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SourceClass.ascx.cs" Inherits="Pbzx.Web.Contorls.SourceClass" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:DataList ID="DataList1" runat="server">
<HeaderTemplate></HeaderTemplate>
<ItemTemplate>
<img src="/images/Web/res_li.gif" hspace="5"  alt=""/><a href='Source.aspx?id=<%# Pbzx.Common.Input.Encrypt(Eval("IntClassID").ToString()) %>'><%#Eval("NvarClassName")%></a>
</ItemTemplate>
<FooterTemplate></FooterTemplate>
</asp:DataList>
