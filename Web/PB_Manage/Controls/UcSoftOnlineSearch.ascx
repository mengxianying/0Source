<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcSoftOnlineSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcSoftOnlineSearch" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table width="780" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;认&nbsp;证&nbsp;码:</td>
        <td>
            <asp:TextBox ID="txtHDSN" runat="server" Width="120"></asp:TextBox></td>
        <td>
            <asp:CheckBox ID="chkYuan" runat="server" /></td>
        <td>
            原
        </td>
        <td>
            注册码:
        </td>
        <td>
            <asp:TextBox ID="txtAct_RN" runat="server" Width="166"></asp:TextBox>
        </td>
        <td>
            注册方式:
        </td>
        <td>
            <asp:DropDownList ID="ddlAct_RegType" runat="server" Width="60">
                <asp:ListItem>所有</asp:ListItem>
                <asp:ListItem Value="1">单机</asp:ListItem>
                <asp:ListItem Value="8">网络</asp:ListItem>
                <asp:ListItem Value="9">软件狗</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:RadioButtonList ID="rblCheckHDSN" runat="server" Font-Size="12px" RepeatDirection="Horizontal"
                Height="18px">
                <asp:ListItem Selected="True" Value="">全部</asp:ListItem>
                <asp:ListItem Value="2">非法</asp:ListItem>
                <asp:ListItem Value="3">错位</asp:ListItem>
                <asp:ListItem Value="4">过期</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table width="700" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:UpdatePanel ID="UpSoftType" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                &nbsp;软件类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td>
                                安装类型:</td>
                            <td>
                                <asp:DropDownList ID="ddlInstallType" runat="server" Width="72">
                                    <asp:ListItem Value="">所有</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            版本号:
        </td>
        <td>
            <asp:TextBox ID="txtVersion" runat="server" Width="40"></asp:TextBox>
        </td>
        <td>
            操作系统:</td>
        <td>
            <asp:DropDownList ID="ddlOSVersion" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem>Windows 7</asp:ListItem>
                <asp:ListItem>Win2008</asp:ListItem>
                <asp:ListItem Value="Vista">Vista</asp:ListItem>
                <asp:ListItem Value="Win2003">Win2003</asp:ListItem>
                <asp:ListItem Value="Windows XP">Windows XP</asp:ListItem>
                <asp:ListItem Value="Win2000">Win2000</asp:ListItem>
                <asp:ListItem Value="Windows NT">Windows NT</asp:ListItem>
                <asp:ListItem>Windows ME</asp:ListItem>
                <asp:ListItem>Windows 98</asp:ListItem>
                <asp:ListItem>Windows CE</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            IP
        </td>
        <td>
            <asp:TextBox ID="txtIP" runat="server" Width="115"></asp:TextBox>
        </td>
    </tr>
</table>
<table width="760" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;日期段:
        </td>
        <td>
            <span>从<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="90"></asp:TextBox></span>
        </td>
        <td>
            至<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="90"></asp:TextBox>
        </td>
        <td>
            日期方式
        </td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">最近登录日期</asp:ListItem>
                <asp:ListItem Value="2">第一次登陆日期</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="查找" OnClick="btnOK_Click" />
        </td>
        <td>
            <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" />
        </td>
    </tr>
</table>
