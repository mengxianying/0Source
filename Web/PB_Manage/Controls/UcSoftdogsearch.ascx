<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSoftdogsearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcSoftdogsearch" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="650" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;软件狗号:</td>
        <td>
            <asp:TextBox ID="txtSN" runat="server" Width="82"></asp:TextBox></td>
        <td>
            补发前序列号:</td>
        <td>
            <asp:TextBox ID="txtOldSN" runat="server" Width="82"></asp:TextBox></td>
        <td>
            销售者:</td>
        <td>
            <asp:TextBox ID="txtSeller" runat="server" Width="58"></asp:TextBox></td>
        <%--    <td>代理商:</td>
    <td>
        <asp:DropDownList ID="ddlAgent" runat="server">
        </asp:DropDownList></td>--%>
        <td>
            付费方式:
        </td>
        <td>
            <asp:DropDownList ID="ddlPayType" runat="server" Width="105">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="招商银行汇款">招商银行汇款</asp:ListItem>
                <asp:ListItem Value="工商银行汇款">工商银行汇款</asp:ListItem>
                <asp:ListItem Value="建设银行汇款">建设银行汇款</asp:ListItem>
                <asp:ListItem>建行对公汇款</asp:ListItem>
                <asp:ListItem>农业银行汇款</asp:ListItem>
                <asp:ListItem>交通银行汇款</asp:ListItem>
                <asp:ListItem>邮政储蓄汇款</asp:ListItem>
                <asp:ListItem>邮局汇款</asp:ListItem>
                <asp:ListItem>在线支付</asp:ListItem>
                <asp:ListItem>上门支付</asp:ListItem>
                <asp:ListItem>充值卡支付</asp:ListItem>
                <asp:ListItem>其他方式</asp:ListItem>
                <asp:ListItem>余额支付</asp:ListItem>
                <asp:ListItem>云网支付</asp:ListItem>
                <asp:ListItem>网银在线</asp:ListItem>
                <asp:ListItem>快钱支付</asp:ListItem>
                <asp:ListItem>支付宝支付</asp:ListItem>
                <asp:ListItem>京东支付</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>
<table width="750" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;状态:</td>
        <td>
            <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">未出售</asp:ListItem>
                <asp:ListItem Value="1">已出售</asp:ListItem>
                <asp:ListItem Value="10">禁止</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();"></asp:TextBox><asp:CheckBox
                ID="chkTime" runat="server" />
            日期查询</td>
        <td>
            备注:</td>
        <td>
            <asp:TextBox ID="txtRemarks" runat="server" Width="130px"></asp:TextBox></td>
        <td>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="立即查找" />
            &nbsp;<asp:Button ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" /></td>
    </tr>
</table>
