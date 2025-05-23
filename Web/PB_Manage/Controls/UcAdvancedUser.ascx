<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAdvancedUser.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcAdvancedUser" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="1000" border="0" cellspacing="0" cellpadding="1">
    <tr align="left">
        <td align="left">
            &nbsp;用户名:
        </td>
        <td align="left">
            <asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td align="left">
            &nbsp;真实姓名:
        </td>
        <td align="left">
            <asp:TextBox ID="txtRealName" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td align="left">
            &nbsp;Email：
        </td>
        <td align="left">
            <asp:TextBox ID="txtUserEmail" runat="server" Width="120px"></asp:TextBox></td>
        <td align="left">
            &nbsp;开户行:
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlBankName" runat="server">
            </asp:DropDownList>
        </td>
        <td align="left">
            &nbsp;银行卡号：
        </td>
        <td align="left">
            <asp:TextBox ID="txtAccountNumber" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
</table>
<table width="800" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">普通用户</asp:ListItem>
                <asp:ListItem Value="1">高级用户</asp:ListItem>
                <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            日期:</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至<asp:TextBox ID="txtCreateTime2" runat="server" Width="70" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式：</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">创建时间</asp:ListItem>
                <asp:ListItem Value="2">最后交易时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
        </td>
    </tr>
</table>
<table width="800" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            <asp:RadioButtonList ID="rblMoney" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">有余额</asp:ListItem>
                <asp:ListItem Value="1">有冻结金额</asp:ListItem>
                <asp:ListItem Selected="True">全部</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" />
            &nbsp;<asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="重置" />
        </td>
    </tr>
</table>
