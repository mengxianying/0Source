<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcTradeInfo.ascx.cs"
    Inherits="Pbzx.Web.PB_Manage.Controls.UcTradeInfo" %>

<script src="../../javascript/calendar.js" type="text/javascript"></script>

<table width="790" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 50px;">
            用户名:</td>
        <td style="width: 105px;">
            <asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td style="width: 30px;">
            类别:
        </td>
        <td>
            <asp:DropDownList ID="ddlType" runat="server" Width="165">
                <asp:ListItem Selected="True" Value="">所有</asp:ListItem>
                <asp:ListItem Value="311">网银转入</asp:ListItem>
                <asp:ListItem Value="312">现金转入（含邮政汇款）</asp:ListItem>
                <asp:ListItem Value="313">手工转入（给用户充值）</asp:ListItem>
                <asp:ListItem Value="151">普通购买</asp:ListItem>
                <asp:ListItem Value="152">代理购买</asp:ListItem>
                <asp:ListItem Value="153">经纪人活动购买</asp:ListItem>
                <asp:ListItem Value="171">普通购买（余额支付）</asp:ListItem>
                <asp:ListItem Value="172">代理购买（余额支付）</asp:ListItem>
                <asp:ListItem Value="173">经纪人活动购买（余额支付）</asp:ListItem>
                <asp:ListItem Value="771">提现（网银转出）</asp:ListItem>
                <asp:ListItem Value="772">提现（现金支付）</asp:ListItem>
                <asp:ListItem Value="773">手工转出（给用户扣款）</asp:ListItem>
                <asp:ListItem Value="511">经纪人推荐收入</asp:ListItem>
                <asp:ListItem Value="512">登录用户返点</asp:ListItem>
                <asp:ListItem Value="501">汇款手续费</asp:ListItem>               
            </asp:DropDownList>
        </td>
        <td>
            时间:从
        </td>
        <td>
            <asp:TextBox ID="txtCreateTime1" title='开始时间' onfocus="calendar();" runat="server"
                Width="80px" MaxLength="20"></asp:TextBox>&nbsp;至&nbsp;<asp:TextBox ID="txtCreateTime2"
                    title='结束时间' onfocus="calendar();" runat="server" Width="80px" MaxLength="20"></asp:TextBox></td>
        <td>
            <asp:RadioButtonList ID="rblDate" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">创建时间</asp:ListItem>
                <asp:ListItem Selected="True">无时间限制</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
</table>
<table width="790">
    <tr>
        <td align="right">
            <asp:Button ID="btnLook" runat="server" OnClick="btnLook_Click" Text="查找" class="input_btn2" />&nbsp;&nbsp;<asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" class="input_btn2" />&nbsp;&nbsp;
        </td>
    </tr>
</table>
