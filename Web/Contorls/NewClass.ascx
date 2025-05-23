<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewClass.ascx.cs" Inherits="Pbzx.Web.Contorls.NewClass" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="RptClass" runat="server">
<HeaderTemplate>
 <ul>
</HeaderTemplate>
<ItemTemplate>
<li><a href='/News_list.aspx?NewsType=<%#Input.Encrypt(Eval("IntNewsTypeID").ToString()) %>'><%# StrFormat.CutStringByNum(Eval("VarTypeName"), this.TitleLength*2)%></a></li>
</ItemTemplate>
<FooterTemplate>
</ul>
</FooterTemplate>
</asp:Repeater>
