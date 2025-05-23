<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcPrintLineSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcPrintLineSearch" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="590" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
            &nbsp;序&nbsp;列&nbsp;号:</td>
        <td>
            <asp:TextBox ID="txtSN" runat="server" Width="130"></asp:TextBox></td>
        <td>
            姓名:</td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server" Width="100"></asp:TextBox>
        </td>
        <td>
            人员类型:</td>
        <td>
            <asp:DropDownList ID="ddlUseType" runat="server">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">创建者</asp:ListItem>
                <asp:ListItem Value="2">入库者</asp:ListItem>
                <asp:ListItem Value="3">销售者</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            状态:</td>
        <td align="right" style="width: 12%">
            <asp:DropDownList ID="ddlPayStatus" runat="server" Width="90%">
                <asp:ListItem Value="" Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="0">新创建</asp:ListItem>
                <asp:ListItem Value="1">已入库</asp:ListItem>
                <asp:ListItem Value="2">已销售</asp:ListItem>
                <asp:ListItem Value="3">已丢失</asp:ListItem>
                <asp:ListItem Value="4">已损坏</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
</table>
<table width="765" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
            &nbsp;日期段:</td>
        <td>
            从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td>
            至
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td>
            日期方式:
        </td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">创建时间</asp:ListItem>
                <asp:ListItem Value="2">销售时间</asp:ListItem>
                <asp:ListItem Selected="True" Value="3">入库时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无时间限制</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />
            &nbsp;
            <asp:Button ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" />
        </td>
    </tr>
</table>
