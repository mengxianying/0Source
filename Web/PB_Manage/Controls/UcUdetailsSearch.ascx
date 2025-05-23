<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcUdetailsSearch.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcUdetailsSearch" %>
<table width="655" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
         &nbsp;<b>输入关键字:</b></td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" Width="120"></asp:TextBox></td>
        <td>
           <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="btnOK_Click" /></td>
        <td>
            <asp:RadioButtonList ID="rblsearch" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="BbsName" Selected="True">论坛昵称</asp:ListItem>
                <asp:ListItem Value="UserName">客户姓名</asp:ListItem>
                <asp:ListItem Value="UserTel">客户电话</asp:ListItem>
                <asp:ListItem Value="UserAddress">客户地址</asp:ListItem>
                <asp:ListItem Value="Remarks">备注信息</asp:ListItem>
            </asp:RadioButtonList></td>
                
    </tr>
</table>