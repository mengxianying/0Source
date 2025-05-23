<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSoftRegSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcSoftRegSearch" %>
<link type="text/css" rel="stylesheet" href="../stylecss/Admin_r.css" />

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table width="710" border="0" cellpadding="1" cellspacing="0">
    <tr>
        <td>
            &nbsp;认&nbsp;证&nbsp;码:</td>
        <td>
            <asp:TextBox ID="txtHDSN" runat="server" Width="120"> </asp:TextBox><asp:CheckBox
                ID="chkYuan" runat="server" />原</td>
        <td>
            &nbsp;注册码:</td>
        <td>
            <asp:TextBox ID="txtAct_RN" runat="server" Width="205"></asp:TextBox>
        </td>
        <td>
            旧的认证码:</td>
        <td>
            <asp:TextBox ID="txtOldSN" runat="server" Width="120"></asp:TextBox></td>
    </tr>
</table>
<table width="730" border="0" cellpadding="1" cellspacing="0">
    <tr>
        <td>
            &nbsp;客&nbsp;户&nbsp;名:</td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server" Width="70"> </asp:TextBox>
        </td>
        <td>
            论坛名:</td>
        <td>
            <asp:TextBox ID="txtBBsID" Width="70" runat="server"></asp:TextBox></td>
        <td>
            包月:</td>
        <td>
            <asp:DropDownList ID="ddlTimeType" runat="server" Width="60">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="1">1个月</asp:ListItem>
                <asp:ListItem Value="2">3个月</asp:ListItem>
                <asp:ListItem Value="3">半年</asp:ListItem>
                <asp:ListItem Value="4">1年</asp:ListItem>
                <asp:ListItem Value="5">2年</asp:ListItem>
                <asp:ListItem Value="6">3年</asp:ListItem>
                <asp:ListItem Value="7">终身</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            付费方式:</td>
        <td>
            <asp:DropDownList ID="ddlPayType" runat="server" Width="105">
                <asp:ListItem>所有</asp:ListItem>
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
        <td>
            原始认证码
        </td>
        <td>
            <asp:TextBox ID="txtOrgSN" runat="server" Width="120"></asp:TextBox></td>
    </tr>
</table>
<asp:UpdatePanel ID="UpSoftType" runat="server">
    <ContentTemplate>
        <table width="780" border="0" cellpadding="1" cellspacing="0">
            <tr>
                <td>
                    &nbsp;软件类型:</td>
                <td>
                    <asp:DropDownList ID="ddlSoftwareType" runat="server" Width="65" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td>
                    安装类型:</td>
                <td>
                    <asp:DropDownList ID="ddlInstallType" runat="server" Width="75">
                        <asp:ListItem Value="">所有</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    使用类型:</td>
                <td>
                    <asp:DropDownList ID="ddlUseType" runat="server" Width="50">
                        <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                        <asp:ListItem Value="1">购买</asp:ListItem>
                        <asp:ListItem Value="2">免费</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    认证码类型:</td>
                <td>
                    <asp:DropDownList ID="ddlRegType" runat="server" Width="62">
                        <asp:ListItem Value="">所有</asp:ListItem>
                        <asp:ListItem Value="1">单机</asp:ListItem>
                        <asp:ListItem Value="8">网络</asp:ListItem>
                        <asp:ListItem Value="9">软件狗</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    状态:</td>
                <td>
                    <asp:DropDownList ID="ddlTStatus" runat="server" Width="50">
                        <asp:ListItem Value="">所有</asp:ListItem>
                        <asp:ListItem Value="1">许可</asp:ListItem>
                        <asp:ListItem Value="2">废除</asp:ListItem>
                        <asp:ListItem Value="0">禁止</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    注册方式:</td>
                <td>
                    <asp:DropDownList ID="ddlRegisterType" runat="server" Width="100">
                    </asp:DropDownList></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            &nbsp;支付信息:
        </td>
        <td>
            <asp:TextBox ID="txtPayDetails" runat="server" Width="190px"></asp:TextBox>
        </td>
        <td>
            备注:</td>
        <td>
            <asp:TextBox ID="txtRemarks" runat="server" Width="190px"></asp:TextBox>
        </td>
        <td>
            地址:
        </td>
        <td>
            <asp:TextBox ID="txtUserAddress" runat="server" Width="215px"></asp:TextBox>
        </td>
    </tr>
</table>
<table width="710" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            &nbsp;日期段:从
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox></td>
        <td>
            至&nbsp;<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox></td>
        <td>
            日期方式
        </td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">注册日期</asp:ListItem>
                <asp:ListItem Value="2">过期日期</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" Width="67px" /> 
            &nbsp;<asp:Button ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" />
           
        </td>
    </tr>
</table>
