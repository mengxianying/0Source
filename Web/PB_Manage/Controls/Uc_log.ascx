<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_log.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.Uc_log" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="upSoftType" runat="server">
    <ContentTemplate>
        <table width="666" border="0" cellspacing="0" cellpadding="1">
            <tr>
                <td>
                    &nbsp;用户名:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="100"></asp:TextBox></td>
                <td>
                    认证码:</td>
                <td>
                    <asp:TextBox ID="txtHDSN" runat="server" Width="120"></asp:TextBox><asp:CheckBox
                        ID="chkYuan" runat="server" />原</td>
                <td>
                    软件类型:</td>
                <td>
                    <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged" Width="80">
                    </asp:DropDownList></td>
                <td style="width: 65px">
                    安装类型:</td>
                <td>
                    <asp:DropDownList ID="ddlInstallType" runat="server" Width="80">
                        <asp:ListItem Value="">所有</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<table width="595" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td style="height: 24px">
            &nbsp;版本号:</td>
        <td style="height: 24px">
            <asp:TextBox ID="txtVersion" runat="server" Width="100"></asp:TextBox></td>
        <td style="height: 24px">
            IP地址:</td>
        <td style="height: 24px">
            <asp:TextBox ID="txtIP" runat="server" Width="100"></asp:TextBox></td>
        <td style="height: 24px">
            SID:</td>
        <td style="height: 24px">
            <asp:TextBox ID="txtSID" runat="server" Width="100"></asp:TextBox></td>
        <td style="height: 24px">
            状态:</td>
        <td style="height: 24px">
            <asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">未登录</asp:ListItem>
                <asp:ListItem Value="1">登录</asp:ListItem>
                <asp:ListItem Value="2">退出</asp:ListItem>
                <asp:ListItem Value="3">超时</asp:ListItem>
                <asp:ListItem Value="4">超时2</asp:ListItem>
                <asp:ListItem Value="10">强退</asp:ListItem>
                <asp:ListItem Value="20">错误</asp:ListItem>
                <asp:ListItem Value="21">密码错</asp:ListItem>
                <asp:ListItem Value="22">ID锁定</asp:ListItem>
                <asp:ListItem Value="23">ID禁用</asp:ListItem>
                <asp:ListItem Value="24">数超额</asp:ListItem>
                <asp:ListItem Value="30">贴不够</asp:ListItem>
                <asp:ListItem Value="31">停试用</asp:ListItem>
                <asp:ListItem Value="32">超试次</asp:ListItem>
                <asp:ListItem Value="33">超试期</asp:ListItem>
                <asp:ListItem Value="34">超PC数</asp:ListItem>
                <asp:ListItem Value="35">超用期</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
</table>
<table width="610" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式:</td>
        <td colspan="2">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">登录时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
