<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcAgentSearch_pass.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcAgentSearch_pass" %>
<table width="750" cellpadding="2" cellspacing="0" border="0">
    <tr>
    <td>
            &nbsp;用户名:</td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server" Width="80"></asp:TextBox></td>
        <td>
          姓名:</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="80"></asp:TextBox></td>
        <td>
            状态:
        </td>
        <td>
            <asp:RadioButtonList ID="ddlSate" runat="server" RepeatDirection="Horizontal" Width="180px">
                <asp:ListItem Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">许可</asp:ListItem>
                <asp:ListItem Value="0">禁止</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            所属省份:
        </td>
        <td>
            <asp:DropDownList ID="ddlProvince" runat="server" Width="100px">
                <asp:ListItem>所有</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnO" runat="server" Text="搜索" OnClick="btnO_Click" />
        </td>
        <td>
            <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" />
        </td>
    </tr>
</table>