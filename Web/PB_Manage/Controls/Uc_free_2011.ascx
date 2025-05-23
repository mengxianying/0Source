<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Uc_free_2011.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.Uc_free_2011" %>
<script src="../../javascript/calendar.js" type="text/javascript"></script>
<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>
<div >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="1" cellspacing="0" style="width: 884px;">
        <tr>
            <td>
                &nbsp;认&nbsp;证&nbsp;码:</td>
            <td>
                <asp:TextBox ID="txtHDSN" runat="server" Width="120"></asp:TextBox><asp:CheckBox
                    ID="chkYuan" runat="server" Visible="False" /></td>
            <td>
                全局ID:</td>
            <td>
                <asp:TextBox ID="txtDiskCVol" runat="server" Width="147px"></asp:TextBox></td>
            <td>
                <asp:UpdatePanel ID="upSoftType" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    软件类型:</td>
                                <td>
                                    <asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged"
                                        Width="80">
                                    </asp:DropDownList></td>
                                <td>
                                    安装类型:</td>
                                <td>
                                    <asp:DropDownList ID="ddlInstallType" runat="server" Width="80">
                                        <asp:ListItem Value="">所有</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="1" cellspacing="0" style="width: 880px">
        <tr>
            <td style="width: 67px">
                &nbsp;最后登ID:</td>
            <td align="left" style="width: 160px">
                <asp:TextBox ID="txtLastID" runat="server" Width="120px"></asp:TextBox></td>
            <td style="width: 58px">
                服务ID:</td>
            <td>
                <asp:TextBox ID="txtServiceID" runat="server" Width="70"></asp:TextBox></td>
            <td colspan="2">
                使用次数:<asp:TextBox ID="txtUseCount" runat="server" Width="40"></asp:TextBox></td>
            <td>
                登录IP:</td>
            <td>
                <asp:TextBox ID="txtLastIp" runat="server" Width="120"></asp:TextBox></td>
            <td>
                状态:</td>
            <td style="width: 104px;">
                &nbsp;<asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="1">正常</asp:ListItem>
                    <asp:ListItem Value="0">禁止</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 50px;">
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="1" cellspacing="0" style="width: 820px">
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
            <td style="width: 294px">
                <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">第一次登录</asp:ListItem>
                    <asp:ListItem Value="2">最近一次登录</asp:ListItem>
                    <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
                </asp:RadioButtonList></td>
            <td style="width: 140px">
                <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />
                &nbsp;<asp:Button ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" /></td>
            <td style="width: 20px">
            </td>
        </tr>
    </table>
</div>
