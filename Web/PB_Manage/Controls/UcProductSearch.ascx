<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcProductSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcProductSearch" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table cellpadding="0" cellspacing="0" border="0" width="660">
    <tr>
        <td>
            &nbsp;软件名称:</td>
        <td>
            <asp:TextBox ID="txtSoftName" runat="server" Width="150" Height="19px"></asp:TextBox></td>
        <td>
            软件类别:</td>
        <td>
            <asp:DropDownList ID="ddlSoftClass" runat="server" Height="19px">
            </asp:DropDownList></td>
        <td>
        软件版本：
        </td>
        <td>
            <asp:DropDownList ID="ddlSoftVersion" runat="server" 
                Width="130px">
            </asp:DropDownList>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" border="0" width="680">
    <tr>
        <td>
            &nbsp;日期段:
        </td>
        <td>
            <span>从<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80"
                Height="19px"></asp:TextBox></span>
        </td>
        <td>
            至<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80"
                Height="19px"></asp:TextBox>
        </td>
        <td>
            日期方式:
        </td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal"
                Height="19px">
                <asp:ListItem Value="1">更新日期</asp:ListItem>
                <asp:ListItem Value="2">最后下载日期</asp:ListItem>
                <asp:ListItem Selected="True" Value="">无日期限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="搜索" OnClick="btnOK_Click" />&nbsp; &nbsp;<asp:Button
                ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" /></td>
    </tr>
</table>
