<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSoft.ascx.cs" Inherits="Pbzx.Web.Contorls.UcSoft" %>
<table width="300" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <%--  <td><img src="../Images/Web/soft_search.gif" border="0" /></td>--%>
        <td>
            <asp:TextBox ID="txtKey" runat="server" onfocus="this.value=''" Width="160" Text="请输入软件搜索关键字..."></asp:TextBox></td>
        <td>
            <asp:DropDownList ID="ddltype" runat="server">
                <asp:ListItem Value="0">软件名称</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">软件介绍</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:Button ID="btn_soft" runat="server" OnClick="btn_soft_Click" Text="搜 索" CssClass="soft_btnbg" /></td>
    </tr>
</table>
