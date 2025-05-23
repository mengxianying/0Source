<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcRegInfoSearch.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcRegInfoSearch" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<table width="750" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
            &nbsp;客户姓名:</td>
        <td>
           <asp:TextBox ID="txtUsername" runat="server" Width="100"></asp:TextBox></td>
        <td>
            软件类型:</td>
        <td>
           <asp:DropDownList ID="ddlSoftwareType" runat="server">
               <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
               <asp:ListItem Value="14">打印一</asp:ListItem>
               <asp:ListItem Value="15">打印二</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            付费状态:</td>
        <td>
            <asp:DropDownList ID="ddlPayStatus" runat="server">
                <asp:ListItem Selected="True">所有</asp:ListItem>
                <asp:ListItem Value="1">未付费</asp:ListItem>
                <asp:ListItem Value="2">已付费</asp:ListItem>
                <asp:ListItem Value="3">免费</asp:ListItem>
            </asp:DropDownList></td>
       <td>    付费方式:</td>
          <td>
  <asp:DropDownList ID="ddlPayType" runat="server" Width="105">
                <asp:ListItem Value="">所有</asp:ListItem>
                <asp:ListItem Value="招商银行汇款">招商银行汇款</asp:ListItem>
                <asp:ListItem Value="工商银行汇款">工商银行汇款</asp:ListItem>
                <asp:ListItem Value="建设银行汇款">建设银行汇款</asp:ListItem>
                <asp:ListItem>建行对公汇款</asp:ListItem>
                <asp:ListItem>农业银行汇款</asp:ListItem>
                <asp:ListItem>交通银行汇款</asp:ListItem>
                <asp:ListItem>邮政储蓄汇款</asp:ListItem>
                <asp:ListItem>邮局汇款</asp:ListItem>
                <asp:ListItem>在线支付</asp:ListItem>
                <asp:ListItem>上门支付</asp:ListItem>
                <asp:ListItem>充值卡支付</asp:ListItem>
                <asp:ListItem>其他方式</asp:ListItem>
                <asp:ListItem>余额支付（自动）</asp:ListItem>
                <asp:ListItem>云网支付（自动）</asp:ListItem>
                <asp:ListItem>网银在线（自动）</asp:ListItem>
                <asp:ListItem>快钱支付（自动）</asp:ListItem>
                <asp:ListItem>支付宝支付（自动）</asp:ListItem>
                <asp:ListItem>京东支付（自动）</asp:ListItem>
            </asp:DropDownList>
            </td>
          <td>
              注册方式:</td>
           <td>
                <asp:DropDownList ID="ddlRegisterType" runat="server">
                </asp:DropDownList></td>
    </tr>
</table>
<table width="700" cellpadding="1" cellspacing="0" border="0">
    <tr>
        <td>
         &nbsp;日期段:从
        </td>
            <td>
            <asp:TextBox ID="txtCreateTime1" onfocus="calendar();" runat="server" Width="80"></asp:TextBox>
        </td>
        <td>至
                    </td>
                <td>
                        <asp:TextBox ID="txtCreateTime2" onfocus="calendar();" runat="server" Width="80"></asp:TextBox>
                    </td>
                 <td>
                     日期方式:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblDateType" runat="server" Font-Size="12px" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">付费时间</asp:ListItem>
                            <asp:ListItem Value="2">注册时间</asp:ListItem>
                            <asp:ListItem Selected="True">无日期限制</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                   <td>
                        <asp:Button ID="btnOK" runat="server" Text="立即查找" OnClick="btnOK_Click" />
                        &nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="重置" OnClick="btnClear_Click" />
                    </td>         
                </tr>
            </table>
