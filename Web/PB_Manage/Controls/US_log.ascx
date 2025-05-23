<%@ Control Language="C#" AutoEventWireup="true" Codebehind="US_log.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.US_log" %>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table width="100%" border="0" cellspacing="0" cellpadding="2" style="font-size: 12px;"
    id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
    <tr>
        <td style="height: 24px">
            用户名：<asp:TextBox ID="txtName" runat="server" Width="90px"></asp:TextBox>认证码：<asp:TextBox
                ID="txtHDSN" runat="server" Width="90px"></asp:TextBox><asp:CheckBox ID="chkYuan"
                    runat="server" />原 版本号：<asp:TextBox ID="txtVersion" runat="server" Width="90px"></asp:TextBox>
            <asp:UpdatePanel ID="UpSoftType" runat="server">
                <ContentTemplate>
                    软件类型:<asp:DropDownList ID="ddlSoftwareType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSoftwareType_SelectedIndexChanged">
                    </asp:DropDownList>安装类型:<asp:DropDownList ID="ddlInstallType" runat="server">
                        <asp:ListItem Value="">所有</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td style="height: 24px">
            IP地址：<asp:TextBox ID="txtIP" runat="server" Width="90px"></asp:TextBox>日期段：从<asp:TextBox
                ID="txtCreateTime1" runat="server" Width="90px"></asp:TextBox>至<asp:TextBox ID="txtCreateTime2"
                    runat="server" Width="90px"></asp:TextBox>日期方式：<asp:RadioButtonList ID="rblDateType"
                        runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">登录时间</asp:ListItem>
                        <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
                    </asp:RadioButtonList>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" /></td>
    </tr>
</table>
