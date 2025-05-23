<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_countlog.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.Uc_countlog" %>
<script src="../../javascript/calendar.js" type="text/javascript" ></script>
<table width="792" border="0" cellspacing="0" cellpadding="1">
  <tr>
    <td>&nbsp;运行时间:</td>
    <td>
        <asp:TextBox ID="txtRun" runat="server" Width="25"></asp:TextBox>(秒)</td>
    <td>统计天数:</td>
    <td>
      <asp:TextBox ID="txtDays" runat="server" Width="25"></asp:TextBox>(天)</td>
    <td>结果:</td>
    <td>
        <asp:TextBox ID="txtResult" runat="server" Width="45"></asp:TextBox></td>
    <td>错误信息:</td>
    <td>
        <asp:TextBox ID="txtErrorInfo" runat="server" Width="115"></asp:TextBox></td>
    <td>标志:</td>
    <td>
      <asp:TextBox ID="txtFlag" runat="server" Width="80"></asp:TextBox></td>
    <td>统计表名:</td>
    <td>
        <asp:TextBox ID="txtStatTableName" runat="server" Width="85"></asp:TextBox></td>
  </tr></table>
  <table width="762" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>&nbsp;日期段:从</td>
    <td colspan="2">&nbsp;<asp:TextBox ID="txtCreateTime1" runat="server" Width="80" onfocus="calendar();"></asp:TextBox>至</td>
    <td colspan="2">&nbsp;<asp:TextBox ID="txtCreateTime2" runat="server" Width="80" onfocus="calendar();"></asp:TextBox></td>
    <td>日期方式:</td>
    <td colspan="5"><asp:RadioButtonList ID="rblDateType" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="1">统计开始</asp:ListItem>
            <asp:ListItem  Value="2">统计结束</asp:ListItem>
            <asp:ListItem Value="3">统计截至</asp:ListItem>
            <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
        </asp:RadioButtonList></td>
    <td>      
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="立即查找" />&nbsp;<asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click" Text="重置" /></td>
  </tr>
</table>