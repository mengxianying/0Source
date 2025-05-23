<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcDelegateOrderSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcDelegateOrderSearch" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="750" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="right" style="width: 60px">
            &nbsp;论&nbsp;坛&nbsp;名:</td>
        <td align="left" style="width: 125px">
            <asp:TextBox ID="txtBbsName" runat="server" Width="120px"></asp:TextBox></td>
        <td align="right" style="width: 60px">
            客户名:
        </td>
        <td align="left" style="width: 125px">
            <asp:TextBox ID="txtUsername" runat="server" Width="120px"></asp:TextBox></td>
        <td align="right" style="width: 60px">
            订单号:</td>
        <td align="left" style="width: 125px">
            <asp:TextBox ID="txtOrderID" runat="server" Width="120px"></asp:TextBox></td>
        <td align="left">
            &nbsp;&nbsp;
            <asp:CheckBox ID="chbError" runat="server" Text="部分处理失败" Checked="false" /></td>
    </tr>
</table>
<table width="750" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="right" style="width: 50px">
            类型:
        </td>
        <td style="width: 160px" align="left">
            <asp:RadioButtonList ID="rblOrderType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1" Selected="True">全部</asp:ListItem>
                <asp:ListItem Value="1">人工</asp:ListItem>
                <asp:ListItem Value="0">自动</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="right" style="width: 50px">
            取消:
        </td>
        <td align="left" style="width: 180px">
            <asp:RadioButtonList ID="rblIsCancal" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="-1">全部</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">未取消</asp:ListItem>
                <asp:ListItem Value="1">已取消</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="right" style="width: 50px">
            处理：</td>
        <td align="left">
            <asp:RadioButtonList ID="rblIsPay" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem  Selected="True"  Value="">全部</asp:ListItem>
                <asp:ListItem Value="1">等待处理</asp:ListItem>
                <asp:ListItem Value="3">已处理</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
</table>
<table width="750" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 60px">
            付款方式:</td>
        <td style="width: 80px">
            <asp:DropDownList ID="ddlPayType" runat="server">
            </asp:DropDownList>
        </td>
        <td align="right" style="width: 85px">
            订单状态:</td>
        <td style="width: 380px" align="left">
            <asp:RadioButtonList ID="rblOrderState" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="" Selected="True">全部</asp:ListItem>
                <asp:ListItem Value="2">等待付款</asp:ListItem>
                <asp:ListItem Value="3">货款不足</asp:ListItem>
                <asp:ListItem Value="4">已付款</asp:ListItem>
                <asp:ListItem Value="6">已完成</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table width="680" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            &nbsp;日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td>
            至
            <asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td>
            日期方式:</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">下单日期</asp:ListItem>
                <asp:ListItem Value="2">更新日期</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="搜索" OnClick="btnOK_Click" />
            &nbsp;
            <asp:Button ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" />
        </td>
    </tr>
</table>
