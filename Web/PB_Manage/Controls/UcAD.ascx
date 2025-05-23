<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcAD.ascx.cs" Inherits="Pbzx.Web.PB_Manage.Controls.UcAD" %>
<script src="../../javascript/calendar.js" type="text/javascript" ></script>
<script src="/PB_Manage/JScript/Language_Nation.js"type="text/javascript"></script>
<table width="700" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>&nbsp;网站名称:</td>
    <td>&nbsp;<asp:TextBox ID="txtSiteName" runat="server" Width="135px"></asp:TextBox></td>
    <td>
        网站地址:</td>
    <td>
        <asp:TextBox ID="txtSiteUrl" runat="server" Width="135px"></asp:TextBox>&nbsp;</td>
<td>
          广告类型:</td>
    <td>&nbsp;
        <asp:DropDownList ID="ddlADType" runat="server">
            <asp:ListItem Value="">所有</asp:ListItem>
        </asp:DropDownList></td>
	  <td>
          所属频道:</td>
    <td>
        <asp:DropDownList ID="ddlChannel" runat="server">
      <asp:ListItem Value="">所有</asp:ListItem>
        </asp:DropDownList>&nbsp;</td>
  </tr>
</table>
 <table width="730" border="0" cellspacing="0" cellpadding="0">
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
                <asp:ListItem Value="1">加入时间</asp:ListItem>
                <asp:ListItem Value="2">结束时间</asp:ListItem>
                <asp:ListItem Value="" Selected="True">无日期限制</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
            <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />&nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
       </tr>
</table>