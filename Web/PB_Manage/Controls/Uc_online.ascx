<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_online.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.Uc_online" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table width="750" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;用户名:</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="80px"></asp:TextBox></td>
        <td>
            认证码:</td>
        <td>
            <asp:TextBox ID="txtHDSN" runat="server" Width="120px"></asp:TextBox><asp:CheckBox
                ID="chkYuan" runat="server" />原</td>
        <td>
            版本号:</td>
        <td>
            <asp:TextBox ID="txtVersion" runat="server" Width="50px"></asp:TextBox></td>
        <td>
            <asp:UpdatePanel ID="UpSoftType" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                软件类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged" Width="80px">
                                </asp:DropDownList></td>
                            <td>
                                安装类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlInstallType" runat="server" Width="80px">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<table width="788" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            &nbsp;IP地址:</td>
        <td>
            <asp:TextBox ID="txtIP" runat="server" Width="85px"></asp:TextBox></td>
        <td>
            日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式:</td>
        <td colspan="2">
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">登录时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />
            <asp:Button ID="btn_czh" runat="server" OnClick="btn_czh_Click" Text="重置" /></td>
    </tr>
</table>
