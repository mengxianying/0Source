<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSource.ascx.cs" Inherits="Pbzx.Web.Contorls.UcSource" %>
<table width="300" border="0" cellspacing="0" cellpadding="1">
  <tr>
    <td><img src="../Images/Web/source_search.gif" border="0" /></td>
    <td><asp:TextBox ID="txtKey" runat="server" Width="200" Text=""></asp:TextBox></td>
    <td><asp:DropDownList ID="ddltype" runat="server">
    <asp:ListItem  Value="0">资源名称</asp:ListItem>
    <asp:ListItem Selected="True" Value="1">资源介绍</asp:ListItem>
    </asp:DropDownList></td>
    <td><asp:Button ID="btn_soft" runat="server" OnClick="btn_soft_Click" Text="搜 索"  CssClass="soft_btnbg"/></td>  
  </tr>
</table>