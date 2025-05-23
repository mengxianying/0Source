<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcBankCardYZ.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcBankCardYZ" %>
<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="620" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
            &nbsp;用&nbsp;户&nbsp;名：</td>
        <td>
            <asp:TextBox ID="txtUname" runat="server" Width="120"></asp:TextBox></td>
        <td>
            真实姓名：</td>
        <td>
           <asp:TextBox ID="txtRealName" runat="server" Width="120"></asp:TextBox></td>        
        <td>
            银行卡号：</td>
        <td>
           <asp:TextBox ID="txtAccountNumber" runat="server" Width="150px"></asp:TextBox></td>
           
    </tr>
</table>
<table width="760" cellpadding="0" cellspacing="0" border="0">
    <tr>
      <td>&nbsp;验证状态：</td>
        <td >
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem>所有</asp:ListItem>
                <asp:ListItem Value="0">未验证</asp:ListItem>
                <asp:ListItem Value="1">验证中</asp:ListItem>
                <asp:ListItem Value="4">已处理</asp:ListItem>
                <asp:ListItem Value="2">验证失败</asp:ListItem>
                <asp:ListItem Value="3">验证通过</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            申请验证时间：</td>
        <td align="left">
            从&nbsp;<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
        <td align="left">
            至&nbsp;<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
        <td>
        <asp:RadioButtonList ID="rbldate" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">申请验证时间</asp:ListItem>
            <asp:ListItem Selected="True">无日期限制</asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td><asp:Button ID="btnOK" runat="server" Text="搜索" OnClick="btnOK_Click" />&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
