<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_UserPost.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.Uc_UserPost" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="600" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td style="height: 26px">
            跟帖对象:</td>
        <td colspan="2" style="height: 26px">
            <asp:TextBox ID="txtParentID" runat="server" Width="120px"></asp:TextBox></td>
        <td style="height: 26px">
        </td>
        <td style="height: 26px">
            帖子ID:</td>
        <td style="height: 26px">
            <asp:TextBox ID="txtAnnounceID" runat="server" Width="120px"></asp:TextBox></td>
        <td style="height: 26px">
            版面:</td>
        <td style="height: 26px">
            &nbsp;<asp:DropDownList ID="ddlBoard" runat="server">
            </asp:DropDownList></td>
        <td colspan="4" style="height: 26px">
        </td>
    </tr>
</table>
<table width="740" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;用户名：</td>
        <td colspan="2">
            &nbsp;<asp:TextBox ID="txtUserName" runat="server" Width="120px"></asp:TextBox></td>
        <td colspan="1">
            表
        </td>
        <td>
            &nbsp;<asp:TextBox ID="txtPostTable" runat="server" Width="120px"></asp:TextBox></td>
        <td>
            是否精华:</td>
        <td>
            <asp:DropDownList ID="ddlisbest" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="1">精华</asp:ListItem>
                <asp:ListItem Value="0">普通</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            状态
        </td>
        <td>
            <asp:DropDownList ID="ddllocktopic" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">正常</asp:ListItem>
                <asp:ListItem Value="1">锁定</asp:ListItem>
                <asp:ListItem Value="50">删除</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="立即查找" />&nbsp;<asp:Button
                ID="btn_cancel" runat="server" OnClick="btnReset_Click" Text="重置" /></td>
    </tr>
</table>
