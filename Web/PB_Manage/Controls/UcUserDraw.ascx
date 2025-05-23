<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcUserDraw.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcUserDraw" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="760" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td align="right">
            &nbsp;用户名：</td>
        <td>
            <asp:TextBox ID="txtUname" runat="server" Width="80"></asp:TextBox></td>
        <td align="right">
            真实姓名：</td>
        <td>
            <asp:TextBox ID="txtRealName" runat="server" Width="80"></asp:TextBox></td>
          <td align="right">
            状态：</td>
        <td>
            <asp:DropDownList ID="ddlState" runat="server">
                <asp:ListItem Value="-1" >所有</asp:ListItem>
                <asp:ListItem Value="0" Selected="True" >处理中</asp:ListItem>
                <asp:ListItem Value="1" >已通过</asp:ListItem>
                <asp:ListItem Value="2" >审核未通过</asp:ListItem>
            </asp:DropDownList></td>
        <td align="right">
            发卡银行：</td>
        <td align="left">
            <asp:DropDownList ID="rblBankList" runat="server">
            </asp:DropDownList>
        </td>
        <td align="right">
            开户行：</td>
        <td>
            <asp:TextBox ID="txtBankInfo" runat="server" Width="120"></asp:TextBox></td>
    </tr>
</table>
<table width="730" cellpadding="0" cellspacing="0" border="0">
    <tr>
     
        <td>
           &nbsp;编&nbsp;&nbsp;号：</td>
        <td>
            <asp:TextBox ID="txtOrderID" runat="server" Width="125"></asp:TextBox></td>
        <td align="right">
            申请日期：</td>
        <td>
            从&nbsp;<asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
        <td>
            至&nbsp;<asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80"></asp:TextBox></td>
       
       <td>
        <asp:RadioButtonList ID="rbldate" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">申请日期</asp:ListItem>
            <asp:ListItem Selected="True" Value="">无日期限制</asp:ListItem>
        </asp:RadioButtonList></td>
        <td>
            &nbsp;<asp:Button ID="btnOK" runat="server" Text="搜索" OnClick="btnOK_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" /></td>
    </tr>
</table>


