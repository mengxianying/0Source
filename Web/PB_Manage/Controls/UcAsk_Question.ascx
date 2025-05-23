<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcAsk_Question.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcAsk_Question" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<script src="/PB_Manage/JScript/Language_Nation.js" type="text/javascript"></script>

<table width="780" border="0" cellspacing="0" cellpadding="1">
    <tr>
        <td>
            &nbsp;问题标题:</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" Width="180"></asp:TextBox></td>
        <td>
            提问者</td>
        <td>
            <asp:TextBox ID="txtAsker" runat="server" Width="70"></asp:TextBox></td>
        <%--<td>
            回答者:</td>
        <td>
            <asp:TextBox ID="txtAnswerer" runat="server" Width="70"></asp:TextBox></td>--%>
        <td>
            类别:</td>
        <td>
            <asp:DropDownList ID="ddlTypeName" runat="server">
            </asp:DropDownList></td>
        <td>
            状态:</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="0">待解决</asp:ListItem>
                <asp:ListItem Value="1">已解决</asp:ListItem>
                <asp:ListItem Value="2">已关闭</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
</table>
<table border="0" cellspacing="0" cellpadding="1" style="width: 880px">
    <tr>
        <td>
            &nbsp;日期段:从</td>
        <td>
            <asp:TextBox ID="txtCreateTime1" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            至&nbsp;&nbsp;</td>
        <td>
            <asp:TextBox ID="txtCreateTime2" runat="server" Width="90px" onfocus="calendar();"></asp:TextBox></td>
        <td>
            日期方式:</td>
        <td>
            <asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">提问时间</asp:ListItem>
                <asp:ListItem Value="2">结束时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
            <td>
            审核状态：<asp:DropDownList ID="dropsh" runat="server">
                    <asp:ListItem Value="2">所有</asp:ListItem>
                    <asp:ListItem Value="1">已通过</asp:ListItem>
                    <asp:ListItem Value="0">未通过</asp:ListItem>
            </asp:DropDownList>
            </td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>
