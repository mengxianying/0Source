<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcRegLogSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcRegLogSearch" %>
<link type="text/css" rel="stylesheet" href="../stylecss/Admin_r.css" />

<script src="/javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table width="690" border="0" cellpadding="1" cellspacing="0">
    <tr>
        <td>
            &nbsp;论&nbsp;坛&nbsp;名:</td>
        <td>
            <asp:TextBox ID="txtBbsName" runat="server" Width="70px"></asp:TextBox></td>
        <td>
            客户名:
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" Width="70px"></asp:TextBox></td>
        <td>
            使用类型:</td>
        <td>
            <asp:DropDownList ID="ddlUseType" runat="server">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">包月</asp:ListItem>
                <asp:ListItem Value="2">计天</asp:ListItem>
                <asp:ListItem Value="3">限期</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            付费状态:</td>
        <td>
            <asp:DropDownList ID="ddlPayStatus" runat="server">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">未付费</asp:ListItem>
                <asp:ListItem Value="2">已付费</asp:ListItem>
                <asp:ListItem Value="3">免费</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            付费方式:</td>
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
                 <asp:ListItem>财付通支付</asp:ListItem>
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

<asp:UpdatePanel ID="upSoftType" runat="server">
    <ContentTemplate>
    <table width="470" border="0" cellpadding="1" cellspacing="0">
    <tr>
        <td>
            &nbsp;软件类型:</td>
        <td>
            <asp:DropDownList ID="ddlSoftwareType" runat="server" Width="72" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
            </asp:DropDownList></td>
        <td>
            安装类型:</td>
        <td>
            <asp:DropDownList ID="ddlInstallType" runat="server" Width="72">
                <asp:ListItem Value="">所有</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            注册方式:</td>
        <td>
            <asp:DropDownList ID="ddlRegisterType" runat="server">
            </asp:DropDownList></td>
    </tr>
</table>
    </ContentTemplate>
</asp:UpdatePanel>
<table width="737" border="0" cellpadding="0" cellspacing="0">
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
                <asp:ListItem Value="1">注册日期</asp:ListItem>
                <asp:ListItem Value="2">过期日期</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
             <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />
            &nbsp;<asp:Button ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" />
           
        </td>
    </tr>
</table>
