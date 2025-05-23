<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcUserCharge.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcUserCharge" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="810" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td style="width: 45px" align="right">
           用户名:</td>
        <td style="width: 80px">
            <asp:TextBox ID="txtUname" runat="server" Width="80"></asp:TextBox></td>
        <td style="width: 60px" align="right">
            真实姓名:</td>
        <td style="width: 80px">
            <asp:TextBox ID="txtRealName" runat="server" Width="80"></asp:TextBox></td>
        <td style="width: 45px">
            订单号:</td>
        <td style="width: 120px">
            <asp:TextBox ID="txtOrderID" runat="server" Width="120"></asp:TextBox></td>
        <td align="right" style="width: 60px">
            充值方式:</td>
        <td align="left" style="width: 80px">
            <asp:DropDownList ID="ddlPayTypeName" runat="server">
            </asp:DropDownList>
        </td>
        <td align="right" style="width: 30px">
            类型:
        </td>
        <td align="left" style="width: 148px">
            <asp:RadioButtonList ID="rblOrderType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1">所有</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">人工</asp:ListItem>
                <asp:ListItem Value="0">自动</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table width="780" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td align="right">
            &nbsp;状&nbsp;&nbsp;态：</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="-1">所有</asp:ListItem>
                <asp:ListItem Value="0">未付款</asp:ListItem>
                <asp:ListItem Value="3" Selected="True">已付款等待审核</asp:ListItem>
                <asp:ListItem Value="1">已通过</asp:ListItem>
                <asp:ListItem Value="2">审核未通过</asp:ListItem>
            </asp:DropDownList></td>
        <td align="right">
            充值日期：</td>
        <td align="left">
            从&nbsp;<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
        <td align="left">
            至&nbsp;<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
        <td>
            <asp:RadioButtonList ID="rbldate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">充值日期</asp:ListItem>
                <asp:ListItem Selected="True" Value="">无日期限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="搜索" OnClick="btnOK_Click" />&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
