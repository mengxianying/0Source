<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="new_search2.ascx.cs" Inherits="Pbzx.Web.Contorls.new_search2" %>
<%@ Import Namespace="Pbzx.Common" %>

 &nbsp;&nbsp;<asp:TextBox ID="txtTitle" MaxLength="100" runat="server" onfocus='this.value=""' Width="120px">������ؼ���...</asp:TextBox>
<asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="����" />