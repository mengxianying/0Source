<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_SoftMessage.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.Uc_SoftMessage" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="785" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            标题：
        </td>
        <td>
            <asp:TextBox ID="txtTitleSerch" runat="server" Width="125"></asp:TextBox></td>
        <td>
                &nbsp;日期段:从</td>
            <td>
                <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
            <td>
                至</td>
            <td>
                <asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
            <td>
                <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">发布时间</asp:ListItem>
                    <asp:ListItem Value="2">开始时间</asp:ListItem>
                    <asp:ListItem Value="3" Selected="True">截止时间</asp:ListItem>
                    <asp:ListItem Value="4" Selected="True">无限制</asp:ListItem>
                </asp:RadioButtonList></td>
          <td><asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" />&nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
