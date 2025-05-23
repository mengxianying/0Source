<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SourceTitle.ascx.cs" Inherits="Pbzx.Web.Contorls.SourceTitle" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
<HeaderTemplate></HeaderTemplate>
<ItemTemplate>
<span class="dianse">¡¤</span><a href='Source_explain.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("PBnet_SoftID").ToString()) %>' target="_blank"><%# StrFormat.CutStringByNum(Eval("PBnet_SoftName"), this.TilteLength*2)%></a><br />
</ItemTemplate>
<FooterTemplate></FooterTemplate>
</asp:Repeater>
