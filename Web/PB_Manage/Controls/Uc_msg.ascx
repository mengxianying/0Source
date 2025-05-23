<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_msg.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.US_msg" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table width="620" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;用&nbsp;户&nbsp;名:</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="100"></asp:TextBox></td>
        <td>
            用户类型:</td>
        <td>
            <asp:DropDownList ID="ddlUserType" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">初始值</asp:ListItem>
                <asp:ListItem Value="2">无限免费</asp:ListItem>
                <asp:ListItem Value="3">临时使用</asp:ListItem>
                <asp:ListItem Value="10">收费记天</asp:ListItem>
                <asp:ListItem Value="11">免费记天</asp:ListItem>
                <asp:ListItem Value="20">收费包月</asp:ListItem>
                <asp:ListItem Value="21">免费包月</asp:ListItem>
                <asp:ListItem Value="200">禁止使用</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:UpdatePanel ID="UpSoftType" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                软件类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td>
                                安装类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlInstallType" runat="server">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<table width="730" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;有效天数:</td>
        <td>
            <asp:TextBox ID="txtValidDays" runat="server" Width="100"></asp:TextBox></td>
        <td>
            使用次数:</td>
        <td>
            <asp:TextBox ID="txtUseCount" runat="server" Width="100"></asp:TextBox></td>
        <td>
            用户备注:</td>
        <td>
            <asp:TextBox ID="txtUserRemarks" runat="server" Width="130"></asp:TextBox></td>
        <td>
            备注信息:</td>
        <td>
            <asp:TextBox ID="txtRemarks" runat="server" Width="130"></asp:TextBox></td>
    </tr>
</table>
<table width="720" border="0" cellspacing="0" cellpadding="0">
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
            日期方式：</td>
        <td colspan="2">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">创建时间</asp:ListItem>
                <asp:ListItem Value="2">过期时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
