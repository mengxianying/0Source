<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SoftTitle_school.ascx.cs" Inherits="Pbzx.Web.Contorls.SoftTitle_school" %>
<%@ Import Namespace="Pbzx.Common" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <table cellpadding="0" cellspacing="0" border="0" width="100%"> 
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td width="72%">
<span class="dianse">¡¤</span><a href='/Soft_explain.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("pb_SoftID").ToString()) %>' class="school" target="_blank"><%# StrFormat.CutStringByNum(Eval("pb_SoftName"), this.TilteLength*2)%></a>
   </td></tr> 
    </ItemTemplate>
    <FooterTemplate></table>
    </FooterTemplate>
</asp:Repeater>